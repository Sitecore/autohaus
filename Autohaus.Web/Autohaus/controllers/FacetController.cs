using System.Linq;
using System.Web.Http.OData.Query;
using Autohaus.Data;
using Autohaus.Data.Models;
using Sitecore;
using Sitecore.Buckets.Extensions;

namespace Autohaus.Web.Controllers
{
    public class FacetsController : ODataSearchController
    {
        public IQueryable<Facet> GetFacets(ODataQueryOptions<Car> options)
        {
            if (options.RawValues.Expand.IsNullOrEmpty())
            {
                return new Facet[0].AsQueryable();
            }

            IQueryable results = options.ApplyTo(SearchContext.GetQueryable<Car>());
            string[] facets = StringUtil.Split(options.RawValues.Expand, '|', true);
            var query = results as IQueryable<Car>;

            return SearchService.GetFacets(query, facets);
        }
    }
}