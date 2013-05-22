using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;

namespace Autohaus.Custom.Links
{
    public class ShortUrlProvider : LinkProvider
    {
        #region Public Methods and Operators

        public override string GetItemUrl(Item item, UrlOptions options)
        {
            Assert.ArgumentNotNull(item, "item");
            Assert.ArgumentNotNull(options, "options");

            if (options.ShortenUrls)
            {
                return item.AddAndGetShortUrl(options) ?? base.GetItemUrl(item, options);
            }

            return base.GetItemUrl(item, options);
        }

        #endregion
    }
}