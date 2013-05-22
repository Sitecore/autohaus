using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.FieldReaders;
using Sitecore.Data;
using Sitecore.Data.Fields;

namespace Autohaus.Custom.Indexing.FieldReaders
{
    /// <summary>
    ///     The delimited list field reader.
    /// </summary>
    public class DelimitedListFieldReader : FieldReader
    {
        /// <summary>
        ///     The get field value.
        /// </summary>
        /// <param name="field">
        ///     The field.
        /// </param>
        /// <returns>
        ///     The <see cref="object" />.
        /// </returns>
        public override object GetFieldValue(IIndexableDataField indexableField)
        {
            Field field = indexableField as SitecoreItemDataField;

            var list = new List<string>();

            if (field != null)
            {
                foreach (string key in field.Value.Split(new[] {'|'}, StringSplitOptions.RemoveEmptyEntries))
                {
                    string itm = key;

                    if (ID.IsID(itm))
                    {
                        itm = ShortID.Encode(itm).ToLowerInvariant();
                        list.Add(itm);
                    }
                }
            }

            return list;
        }
    }
}