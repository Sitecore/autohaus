using System.Collections.Generic;
using System.Linq;
using Autohaus.Data.Models;
using Sitecore;
using Sitecore.Collections;
using Sitecore.Data;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;

namespace Autohaus.Data
{
    public static class NavigationService
    {
        public static IEnumerable<NavigationItem> GetNavigationItems()
        {
            Database db = Context.ContentDatabase ?? Context.Database;
            Assert.IsNotNull(db, "context database");
            Item rootItem = db.GetItem("{D70CBEED-6DCF-483F-978F-6FC3C8049512}");
            return GetNavigationItems(db, rootItem);
        }

        private static IEnumerable<NavigationItem> GetNavigationItems(Database database, Item rootItem)
        {
            Assert.IsNotNull(database, "database");
            Assert.IsNotNull(rootItem, "root item");

            var navItems = new List<NavigationItem>();

            var rootNavItem = new NavigationItem(rootItem);
            if (rootNavItem.Show)
            {
                navItems.Add(rootNavItem);
            }

            foreach (Item child in rootItem.ReadChildren())
            {
                var navItem = new NavigationItem(child);

                if (navItem.Show)
                {
                    navItem.SubItems = child.ReadChildren().Select(i => new NavigationItem(i)).Where(n => n.Show);
                    navItems.Add(navItem);
                }
            }

            return navItems;
        }

        private static IEnumerable<Item> ReadChildren(this Item item)
        {
            Assert.IsNotNull(item, "item");
            return item.GetChildren(ChildListOptions.IgnoreSecurity);
        }
    }
}