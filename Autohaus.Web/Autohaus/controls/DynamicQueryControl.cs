using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI.WebControls;
using Autohaus.Data.Models;
using Autohaus.Data.ViewModels;
using HtmlAgilityPack;
using Microsoft.CSharp;
using Sitecore;
using Sitecore.Buckets.Extensions;

namespace Autohaus.Web.UI.Controls
{
    public abstract class DynamicQueryControl : SitecoreUserControl
    {
        protected const string baseCode = @"using System;
                                        using System.Collections.Generic;
                                        using System.Diagnostics;
                                        using System.Linq;
                                        using Sitecore.ContentSearch.Linq;
                                        using ContentSearchManager = Sitecore.ContentSearch.ContentSearchManager;
                                        using Autohaus.Data.Models;

                                        namespace Autohaus.Web {
                                           class Runner {
                                                                public static IEnumerable<Car> Run()
                                                                {
                                                                    using (var context = ContentSearchManager.GetIndex(""sitecore_master_index"").CreateSearchContext())
                                                                    {
                                                                           #queryable#
                                                                    }
                                                                }
                                                            }
                                                          }";

        protected TextBox LinqQuery;
        protected Panel alert;
        protected Repeater carsRepeater = new Repeater();
        protected Label resultMessage;

        public static ExecutionResult CompileAndRun(string code)
        {
            var result = new ExecutionResult();
            var CompilerParams = new CompilerParameters
            {
                GenerateInMemory = true,
                TreatWarningsAsErrors = false,
                GenerateExecutable = false,
                CompilerOptions = "/optimize"
            };

            string[] references = {"System.dll", "mscorlib.dll", "System.Core.dll"};
            string[] externalReferences =
            {
                @"Autohaus.Data.dll", @"Sitecore.Kernel.dll", @"Sitecore.Buckets.dll",
                @"Sitecore.ContentSearch.dll", @"Sitecore.ContentSearch.Linq.dll"
            };
            for (int i = 0; i < externalReferences.Length; i++)
                externalReferences[i] =
                    Path.Combine(Path.GetDirectoryName(HttpContext.Current.Request.PhysicalApplicationPath + "bin\\"),
                        externalReferences[i]);

            CompilerParams.ReferencedAssemblies.AddRange(externalReferences);
            CompilerParams.ReferencedAssemblies.AddRange(references);

            var provider = new CSharpCodeProvider();
            CompilerResults compile = provider.CompileAssemblyFromSource(CompilerParams, new[] {code});

            if (compile.Errors.HasErrors)
            {
                result.Messages.AddRange(compile.Errors);
                return result;
            }

            Module module = compile.CompiledAssembly.GetModules()[0];
            Type mt = null;
            MethodInfo methInfo = null;
            if (module != null)
            {
                mt = module.GetType("Autohaus.Web.Runner");
            }

            if (mt != null)
            {
                methInfo = mt.GetMethod("Run");
            }

            if (methInfo == null)
                return result;

            var stopwatch = new Stopwatch();
            stopwatch.Start();
            result.ResultSet = methInfo.Invoke(null, new object[0]) as IEnumerable<object>;
            stopwatch.Stop();
            result.TimeTaken = stopwatch.ElapsedMilliseconds;

            return result;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                resultMessage.Text = "";

                string queryableCode = Sitecore.Context.Item["collectioncode"];

                if (queryableCode.IsNullOrEmpty())
                {
                    alert.CssClass = "alert alert-warning";
                    resultMessage.Text += "<strong>Warning!</strong><br/>This collection does not have a query to run.";
                    alert.Visible = true;
                    return;
                }

                var doc = new HtmlDocument();
                doc.LoadHtml(queryableCode);

                string code = baseCode.Replace("#queryable#", HttpUtility.HtmlDecode(doc.DocumentNode.InnerText));

                List<object> results;
                string message;
                long timetaken;
                bool success = RunCode(code, out message, out timetaken, out results);

                if (!success)
                {
                    alert.CssClass = "alert alert-error";
                    resultMessage.Text += string.Format("<strong>Error!</strong><br/>{0}.", message);
                    alert.Visible = true;
                    return;
                }

                if (results == null || !results.Any())
                {
                    alert.CssClass = "alert alert-warning";
                    resultMessage.Text += "<strong>Warning!</strong><br/>Nothing was returned.";
                    alert.Visible = true;
                    return;
                }

                if (timetaken > 250)
                {
                    alert.CssClass = "alert alert-error";
                    resultMessage.Text += "<strong>Oh-oh!</strong><br/>";
                }
                else
                {
                    alert.CssClass = "alert alert-success";
                    resultMessage.Text += "<strong>Success!</strong><br/>";
                }

                resultMessage.Text += string.Format("{0} result(s) returned in {1} ms", results.Count(), timetaken);
                alert.Visible = true;

                carsRepeater.DataSource = results.Select(car => new DisplayCar(car as Car));
                carsRepeater.DataBind();
            }
        }

        protected bool RunCode([NotNull] string code, out string message, out long timeTaken, out List<object> results)
        {
            results = null;
            timeTaken = -1;
            try
            {
                ExecutionResult output = CompileAndRun(code);
                message = output.Messages.Cast<object>()
                    .Aggregate(string.Empty, (current, error) => current + (error + "<br />"));
                results = output.ResultSet.ToList();
                timeTaken = output.TimeTaken;
                return !output.Messages.HasErrors;
            }
            catch (Exception exception)
            {
                message = exception.Message;
                return false;
            }
        }

        public class ExecutionResult
        {
            public ExecutionResult()
            {
                Messages = new CompilerErrorCollection();
                ResultSet = new object[0];
            }

            public CompilerErrorCollection Messages { get; set; }

            public IEnumerable<object> ResultSet { get; set; }

            public long TimeTaken { get; set; }
        }
    }
}