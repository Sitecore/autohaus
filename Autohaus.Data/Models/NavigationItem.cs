using System.Collections.Generic;
using System.Linq;
using Sitecore;
using Sitecore.Data.Items;

namespace Autohaus.Data.Models
{
    public class NavigationItem : SitecoreItem
    {
        public NavigationItem(Item item)
            : base(item)
        {
            SubItems = new List<NavigationItem>();
        }

        public string Title
        {
            get { return InnerItem["NavTitle"]; }
        }

        public string PageTitle
        {
            get { return InnerItem["Title"]; }
        }

        public string PageText
        {
            get { return InnerItem["Text"]; }
        }

        public bool Show
        {
            get { return InnerItem["ShowInNavBar"] == "1"; }
        }

        public bool Navigatable
        {
            get { return InnerItem["Navigatable"] == "1"; }
        }

        public bool IsActive
        {
            get
            {
                return InnerItem != null &&
                    (Context.Item.ID.Equals(InnerItem.ID) || (SubItems != null && SubItems.Any(s => s.IsActive)));
            }
        }

        public IEnumerable<NavigationItem> SubItems { get; set; }

        public override string Url
        {
            get { return Navigatable ? base.Url : "#"; }
        }
    }
}