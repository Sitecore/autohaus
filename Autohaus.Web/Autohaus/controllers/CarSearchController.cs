using System.Linq;
using Autohaus.Data;
using Sitecore.ContentSearch.SearchTypes;

namespace Autohaus.Web.Controllers
{
    public class CarSearchController : ODataSearchController
    {
        public IQueryable<SearchResultItem> Get()
        {
            return SearchContext.GetQueryable<SearchResultItem>()
                .Where(c => c.TemplateId == Constants.Templates.CarModel);
        }
    }
}