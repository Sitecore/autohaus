using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Sitecore.ContentSearch.SearchTypes;

namespace Autohaus.Web.UI.Controls
{
    public partial class DataQueryRenderer : DataQueryControl
    {
        protected Stopwatch stopWatch = new Stopwatch();

        protected override int MaxCount
        {
            get { return 50; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            stopWatch.Reset();
            stopWatch.Start();
            resultMessage.Text = "";

            List<SitecoreUISearchResultItem> data = GetData().ToList();

            stopWatch.Stop();
            if (stopWatch.ElapsedMilliseconds > 250)
            {
                alert.CssClass = "alert alert-error";
                resultMessage.Text += "<strong>Oh oh!</strong><br/>";
            }
            else
            {
                alert.CssClass = "alert alert-success";
                resultMessage.Text += "<strong>Schweeet!</strong><br/>";
            }

            resultMessage.Text += string.Format("{0} result(s) returned in {1} ms", data.Count(),
                stopWatch.ElapsedMilliseconds);
            alert.Visible = true;

            carsRepeater.DataSource = data;
            carsRepeater.DataBind();
        }
    }
}