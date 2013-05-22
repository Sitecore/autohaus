using System.Collections.Generic;
using System.Linq;
using Sitecore.Buckets.Util;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.ContentSearch.Utilities;
using Sitecore.StringExtensions;

namespace Autohaus.Web.UI.Controls
{
    /// <summary>
    ///     The data query enabled user control.
    /// </summary>
    public abstract class DataQueryControl : SitecoreUserControl
    {
        protected abstract int MaxCount { get; }

        /// <summary>
        ///     The get data.
        /// </summary>
        /// <returns>
        ///     The <see cref="List" />.
        /// </returns>
        protected virtual List<SitecoreUISearchResultItem> GetData()
        {
            var indexable = new SitecoreIndexableItem(Sitecore.Context.Item);
            ISearchIndex index = ContentSearchManager.GetIndex(indexable);
            if (index == null)
            {
                return new List<SitecoreUISearchResultItem>(0);
            }

            string datasource = DataSource;

            if (datasource.IsNullOrEmpty())
            {
                return new List<SitecoreUISearchResultItem>(0);
            }

            IEnumerable<SearchStringModel> stringModel = UIFilterHelpers.ParseDatasourceString(datasource);

            using (IProviderSearchContext context = index.CreateSearchContext())
            {
                return LinqHelper.CreateQuery(context, stringModel).OrderBy(i => i.Updated).Take(MaxCount).ToList();
            }
        }
    }
}