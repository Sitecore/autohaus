using System.Web;
using System.Web.UI;
using Sitecore.Buckets.Extensions;
using Sitecore.Web;
using Sitecore.Web.UI;

namespace Autohaus.Web.UI.Controls
{
    public class PageResourceRenderer : WebControl
    {
        private const string cssTemplate = @"<link rel='stylesheet' href='{0}'>";
        private const string jsTemplate = @"<script src='{0}'></script>";

        protected override void DoRender(HtmlTextWriter output)
        {
            var parameters = WebUtil.ParseUrlParameters(Parameters);
            foreach (var key in parameters.AllKeys)
            {
                var values = parameters.GetValues(key);
                if (values == null) continue;

                foreach (var value in values)
                {
                    if (value.IsNullOrEmpty()) continue;

                    var template = cssTemplate;
                    if (value.EndsWith("js"))
                    {
                        template = jsTemplate;
                    }

                    if (!value.IsNullOrEmpty())
                    {
                        output.Write(template, HttpUtility.UrlDecode(value));
                    }
                }
            }
        }
    }
}