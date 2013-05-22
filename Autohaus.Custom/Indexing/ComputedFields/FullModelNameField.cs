using System;
using System.Globalization;
using Sitecore;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Items;
using Sitecore.StringExtensions;

namespace Autohaus.Custom.Indexing.ComputedFields
{
    public class FullModelNameField : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var item = (SitecoreIndexableItem) indexable;

            if (item != null && item.Item != null &&
                item.Item.TemplateID.ToString().Equals("{6FB79081-4D9E-413D-AE86-B855A5BDC65C}"))
            {
                return "{0} {1} {2} {3}".FormatWith(
                    GetManufacturedYear(item),
                    item.Item["{E6A36520-A063-4906-AA2D-4471D4720AFA}"],
                    item.Item["{26D1E50A-E374-4577-8258-732E8E50A36C}"],
                    item.Item["{AE64C200-73BA-4C53-A5A8-258B1AD60D4A}"]);
            }

            return string.Empty;
        }

        private string GetManufacturedYear(Item item)
        {
            // manufactured date field
            string dateRaw = item["{EF82E79D-4454-478A-B744-44F08CAFE9F6}"];

            if (dateRaw.IsNullOrEmpty() || !DateUtil.IsIsoDate(dateRaw))
            {
                return DateTime.MinValue.Year.ToString(CultureInfo.InvariantCulture);
            }

            return DateUtil.IsoDateToDateTime(dateRaw, DateTime.MinValue).Year.ToString(CultureInfo.InvariantCulture);
        }
    }
}