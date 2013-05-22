using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.FieldReaders;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace Autohaus.Custom.Indexing.FieldReaders
{
    public class MultiListFieldReader : FieldReader
    {
        public override object GetFieldValue(IIndexableDataField indexableField)
        {
            Field field = indexableField as SitecoreItemDataField;

            var list = new List<string>();

            var multiField = FieldTypeManager.GetField(field) as MultilistField;

            if (multiField != null)
            {
                foreach (string key in multiField.List)
                {
                    string itm = key;

                    if (ID.IsID(itm))
                    {
                        itm = ShortID.Encode(itm).ToLowerInvariant();
                        list.Add(itm);
                    }
                }

                return list;
            }

            return list;
        }
    }
}