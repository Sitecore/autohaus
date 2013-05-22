using System;
using System.Collections.Generic;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.FieldReaders;
using Sitecore.Data.Fields;

namespace Autohaus.Custom.Indexing.FieldReaders
{
    /// <summary>
    ///     The numeric range field reader.
    ///     Processes numeric range field values like "3-5", etc.
    /// </summary>
    public class NumericRangeFieldReader : FieldReader
    {
        /// <summary>
        ///     The separators.
        /// </summary>
        private readonly string[] separators = {"-"};

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

            var list = new List<int>();

            if (field != null)
            {
                string[] range = field.Value.Split(separators, StringSplitOptions.RemoveEmptyEntries);

                foreach (string number in range)
                {
                    int currentNumber;
                    if (!string.IsNullOrEmpty(number) && int.TryParse(number, out currentNumber))
                    {
                        list.Add(currentNumber);
                    }
                }
            }

            return list;
        }
    }
}