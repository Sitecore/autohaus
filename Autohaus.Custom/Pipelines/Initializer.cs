using System.Web.Http;
using System.Web.Http.OData.Builder;
using System.Web.Routing;
using Autohaus.Data.Models;
using Microsoft.Data.Edm;
using Sitecore.ContentSearch.SearchTypes;
using Sitecore.Diagnostics;
using Sitecore.Pipelines;

namespace Autohaus.Custom.Pipelines
{
    public class Initializer
    {
        /// <summary>
        ///     Runs the processor.
        /// </summary>
        /// <param name="args">
        ///     The arguments.
        /// </param>
        public void Process(PipelineArgs args)
        {
            Log.Info("Initializing Autohaus...", this);

            ODataModelBuilder modelBuilder = new ODataConventionModelBuilder();
            modelBuilder.EntitySet<SearchResultItem>("CarSearch");
            modelBuilder.EntitySet<Car>("Cars");
            modelBuilder.EntitySet<Facet>("Facets");
            IEdmModel model = modelBuilder.GetEdmModel();
            GlobalConfiguration.Configuration.Routes.MapODataRoute("ODataRoute", "odata", model);
            RouteTable.Routes.MapHttpRoute("DefaultApi", "api/{controller}/{action}/{id}",
                new {id = RouteParameter.Optional});

            Log.Info("Finished initializing Autohaus", this);
        }
    }
}