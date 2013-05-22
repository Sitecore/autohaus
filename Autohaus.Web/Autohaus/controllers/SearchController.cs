using System.Collections.Generic;
using System.Web.Http;
using Autohaus.Data;
using Autohaus.Data.Models;
using Sitecore.Diagnostics;

namespace Autohaus.Web.Controllers
{
    public class SearchController : ApiController
    {
        [HttpGet]
        [ActionName("starts")]
        public List<CarSearchResult> GetByStartsWith(string s, int top)
        {
            Assert.IsNotNullOrEmpty(s, "startswith parameter");
            Assert.IsTrue(top > 0, "top must be greater than zero");
            Assert.IsTrue(top <= 100, "top must not be greater than 100");
            return SearchService.GetCarsByStartsWith(s, top);
        }
    }
}