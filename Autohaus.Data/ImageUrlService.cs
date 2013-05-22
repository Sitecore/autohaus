using System.Collections.Generic;
using System.Linq;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Resources.Media;

namespace Autohaus.Data
{
    public static class ImageUrlService
    {
        public static IEnumerable<string> GetImageUrls(this Item item, int width, int height)
        {
            if (item == null)
            {
                return new string[0];
            }

            MultilistField imagesField = item.Fields[Constants.Fields.CarModel.Images];

            if (imagesField == null)
            {
                return new string[0];
            }

            return imagesField.GetItems().Select(i => new MediaItem(i)).Select(m => MediaManager.GetMediaUrl(m, new MediaUrlOptions(width, height, false)));
        }
    }
}