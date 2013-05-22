using System.Collections.Generic;
using System.Globalization;
using Sitecore;
using Sitecore.Data;
using Sitecore.Diagnostics;

namespace Autohaus.Custom.Links.ResolveShortUrlPipeline
{
    public class ModelKeyShortUrlProcessor : ResolveShortUrlProcessor
    {
        public override void Process(ResolveShortUrlArgs args)
        {
            Assert.IsNotNull(args, "args");
            Assert.IsNotNull(args.Item, "item");

            if (args.Item.TemplateID == ID.Parse("{6FB79081-4D9E-413D-AE86-B855A5BDC65C}"))
            {
                string year = string.Empty;
                string dateIso = args.Item["{EF82E79D-4454-478A-B744-44F08CAFE9F6}"];
                if (!string.IsNullOrEmpty(dateIso) && DateUtil.IsIsoDate(dateIso))
                {
                    year = DateUtil.IsoDateToDateTime(dateIso).Year.ToString(CultureInfo.InvariantCulture);
                }

                string make = args.Item["{E6A36520-A063-4906-AA2D-4471D4720AFA}"];
                string model = args.Item["{26D1E50A-E374-4577-8258-732E8E50A36C}"];
                string trim = args.Item["{AE64C200-73BA-4C53-A5A8-258B1AD60D4A}"];
                var parts = new List<string> {year, make, model, trim};

                string url = string.Empty;

                foreach (string part in parts)
                {
                    if (!string.IsNullOrEmpty(part))
                    {
                        url += "/" + part;
                    }
                }

                args.ResolvedUrl = url;
                args.AbortPipeline();
            }
        }
    }
}