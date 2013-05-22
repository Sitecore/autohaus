using Sitecore.Data.Items;
using Sitecore.Links;

namespace Autohaus.Data.Models
{
    public abstract class SitecoreItem
    {
        protected SitecoreItem(Item item)
        {
            InnerItem = item;
        }

        protected Item InnerItem { get; set; }

        public virtual string Url
        {
            get { return LinkManager.GetItemUrl(InnerItem); }
        }
    }
}