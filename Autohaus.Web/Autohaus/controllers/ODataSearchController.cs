using System.Web.Http.OData;
using Autohaus.Data;
using Sitecore.ContentSearch;

namespace Autohaus.Web.Controllers
{
    public abstract class ODataSearchController : ODataController
    {
        private IProviderSearchContext _context;

        private ISearchIndex _index;

        protected ODataSearchController()
        {
            _context = Index.CreateSearchContext();
        }

        private ISearchIndex Index
        {
            get { return _index ?? (_index = ContentSearchManager.GetIndex(Config.WebIndexName)); }
        }

        protected IProviderSearchContext SearchContext
        {
            get { return _context ?? (_context = Index.CreateSearchContext()); }
        }
    }
}