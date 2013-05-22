using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Autohaus.Data.Models;
using Sitecore.Buckets.Extensions;
using Sitecore.Collections;
using Sitecore.Configuration;
using Sitecore.ContentSearch;
using Sitecore.ContentSearch.Linq;
using Sitecore.ContentSearch.Utilities;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using FacetValue = Sitecore.ContentSearch.Linq.FacetValue;

namespace Autohaus.Data
{
    public static class SearchService
    {
        private static ISearchIndex _index;

        private static ISearchIndex Index
        {
            get { return _index ?? (_index = ContentSearchManager.GetIndex(Config.WebIndexName)); }
        }

        public static IQueryable<Facet> GetFacets(IQueryable<Car> query, string[] facets)
        {
            var facetGroups = new List<Facet>();

            query = facets.Aggregate(query, (current, facetName) => current.FacetOn(c => c[facetName]));

            FacetResults facetResults = query.GetFacets();
            Database database = Factory.GetDatabase("master");
            List<Item> facetDefinitions = GetFacetDefinitionItems(database);

            foreach (FacetCategory category in facetResults.Categories)
            {
                Item matchingFacetDefinition = facetDefinitions.FirstOrDefault(i => i["Parameters"] == category.Name);
                string friendlyName = category.Name;
                var key = category.Name;
                if (matchingFacetDefinition != null)
                {
                    friendlyName = matchingFacetDefinition["Name"];
                    string handle = matchingFacetDefinition["Client Side Handle"];
                    if (!handle.IsNullOrEmpty())
                    {
                        key = handle;
                    }
                }

                var group = new Facet(key, friendlyName);
                foreach (FacetValue facetValue in category.Values)
                {
                    group.Values.Add(new Models.FacetValue(facetValue.Name, facetValue.Aggregate));
                }

                facetGroups.Add(group);
            }

            return facetGroups.AsQueryable();
        }

        public static Car GetCarByIdOrAny(ID id)
        {
            using (IProviderSearchContext context = Index.CreateSearchContext())
            {
                var match = context.GetQueryable<Car>().FirstOrDefault(i => i.ItemId == id);

                if (match == null)
                {
                    return context.GetQueryable<Car>().Take(1).FirstOrDefault();
                }

                return match;
            }
        }

        public static List<CarSearchResult> GetCarsByStartsWith(string startsWith, int max)
        {
            Assert.ArgumentNotNullOrEmpty(startsWith, "startsWith");

            List<CarSearchResult> result;

            var stopWatch = new Stopwatch();
            stopWatch.Start();

            using (IProviderSearchContext context = Index.CreateSearchContext())
            {
                result = context.GetQueryable<Car>().Where(i => i.TemplateId == Constants.Templates.CarModel)
                    .Where(i => i.FullModelName.StartsWith(startsWith))
                    .Select(car => new CarSearchResult(car.Uri, car.FullModelName, car.FriendlyUrl))
                    .Take(max)
                    .ToList();
            }

            stopWatch.Stop();
            result.Add(new CarSearchResult(string.Format("Query returned in {0} ms", stopWatch.ElapsedMilliseconds), "#"));
            return result;
        }

        private static List<Item> GetFacetDefinitionItems(Database database)
        {
            var facets = new Item[] {};
            Item item = database.GetItem(Sitecore.Buckets.Util.Constants.FacetFolder).EnsureFallbackVersion();
            if (item != null)
            {
                facets = item.GetChildren(ChildListOptions.SkipSorting).ToArray();
            }

            return facets.ToList();
        }
    }
}