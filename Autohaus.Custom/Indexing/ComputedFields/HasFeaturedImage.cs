using Sitecore.ContentSearch;
using Sitecore.ContentSearch.ComputedFields;
using Sitecore.Data.Fields;

namespace Autohaus.Custom.Indexing.ComputedFields
{
    public class HasFeaturedImage : IComputedIndexField
    {
        public string FieldName { get; set; }

        public string ReturnType { get; set; }

        public object ComputeFieldValue(IIndexable indexable)
        {
            var item = (SitecoreIndexableItem) indexable;

            if (item != null && item.Item != null)
            {
                Field field = item.Item.Fields["{CFD2712F-8BF9-4023-AB94-59871A9C974E}"];

                if (field == null)
                {
                    return false;
                }

                if (field.TypeKey != "image")
                {
                    return null;
                }

                ImageField imgField = field;

                if (!imgField.MediaID.IsNull)
                {
                    if (item.Item.Database.GetItem(imgField.MediaID) != null)
                    {
                        return true;
                    }
                }

                return false;
            }

            return false;
        }
    }
}