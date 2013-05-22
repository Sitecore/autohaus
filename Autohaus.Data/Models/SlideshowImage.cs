using Sitecore.Data.Items;
using Sitecore.Resources.Media;
using Sitecore.Web.UI.WebControls;

namespace Autohaus.Data.Models
{
    public class SlideshowImage : SitecoreItem
    {
        public SlideshowImage(Item item)
            : base(item)
        {
        }

        public virtual string Title
        {
            get { return FieldRenderer.Render(InnerItem, "Alt"); }
        }

        public virtual string Attribution
        {
            get { return InnerItem["Copyright"]; }
        }

        public virtual string ImageUrl
        {
            get { return MediaManager.GetMediaUrl(InnerItem); }
        }
    }
}