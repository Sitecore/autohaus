using System.Collections.Generic;
using System.Linq;
using Autohaus.Data.Models;
using Sitecore;
using Sitecore.Buckets.Extensions;

namespace Autohaus.Web.UI.Controls
{
    public partial class Slideshow : DataQueryControl
    {
        protected List<SlideshowImage> SlideshowImages
        {
            get
            {
                return GetData().Select(i => i.GetItem())
                                .Where(i => !i.TemplateID.Equals(TemplateIDs.MediaFolder))
                                .OrderByDescending(i => i.Statistics.Updated)
                                .Select(i => new SlideshowImage(i))
                                .Where(i => !i.ImageUrl.IsNullOrEmpty())
                                .ToList();
            }
        }

        protected int TotalAnimation
        {
            get { return SlideshowImages.Count * SlideDelay; }
        }

        protected override int MaxCount
        {
            get { return 10; }
        }

        protected int SlideDelay
        {
            get { return 6; }
        }
    }
}