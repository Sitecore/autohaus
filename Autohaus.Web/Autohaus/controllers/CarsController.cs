using System.Linq;
using System.Web.Http;
using System.Web.Http.OData.Query;
using Autohaus.Data;
using Autohaus.Data.Models;

namespace Autohaus.Web.Controllers
{
    public class CarsController : ODataSearchController
    {
        [Queryable(PageSize = 20)]
        public IQueryable<Car> GetCars(ODataQueryOptions<Car> options)
        {
            TopQueryOption top;
            SkipQueryOption skip;
            OrderByQueryOption orderby;

            var customOptions = new ODataQueryOptions<Car>(options.Context,
                options.BuildCustomRequest(out top, out skip, out orderby));
            IQueryable query =
                customOptions.ApplyTo(
                    SearchContext.GetQueryable<Car>().Where(c => c.TemplateId == Constants.Templates.CarModel));

            var results = query as IQueryable<Car>;

            if (results != null)
            {
                if (skip != null)
                {
                    results = results.Skip(skip.Value);
                }

                if (top != null)
                {
                    results = results.Take(top.Value);
                }

                if (orderby != null)
                {
                    string[] parts = orderby.RawValue.Split(' ');

                    if (parts.Length > 1 && !string.IsNullOrEmpty(parts[0]) && !string.IsNullOrEmpty(parts[1]))
                    {
                        string fieldName = parts[0];
                        if (parts[1] == "asc")
                        {
                            results = results.OrderBy(c => c[fieldName]);
                        }
                        else if (parts[1] == "desc")
                        {
                            results = results.OrderByDescending(c => c[fieldName]);
                        }
                    }
                }

                return results;
            }

            return null;
        }
    }
}