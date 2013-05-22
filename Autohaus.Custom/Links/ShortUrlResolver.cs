using Sitecore;
using Sitecore.Diagnostics;
using Sitecore.Pipelines.HttpRequest;

namespace Autohaus.Custom.Links
{
    /// <summary>The short url resolver.</summary>
    public class ShortUrlResolver : HttpRequestProcessor
    {
        /// <summary>Short Url Resolver for use with Bucketed Items</summary>
        /// <param name="args">The args.</param>
        public override void Process(HttpRequestArgs args)
        {
            Assert.ArgumentNotNull(args, "args");
            if (Context.Item != null || Context.Database == null || args.Url.ItemPath.Length == 0)
            {
                return;
            }

            Context.Item = ShortUrlManager.GetItemByShortUrl(args.Url.FilePath);
        }
    }
}