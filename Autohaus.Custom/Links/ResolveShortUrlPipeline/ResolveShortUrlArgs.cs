using Sitecore.Data.Items;
using Sitecore.Links;
using Sitecore.Pipelines;

namespace Autohaus.Custom.Links.ResolveShortUrlPipeline
{
    public class ResolveShortUrlArgs : PipelineArgs
    {
        #region Constructors and Destructors

        public ResolveShortUrlArgs(Item item, UrlOptions options)
        {
            Item = item;
            Options = options;
        }

        #endregion

        #region Public Properties

        public Item Item { get; set; }

        public string ResolvedUrl { get; set; }

        public UrlOptions Options { get; set; }

        #endregion
    }
}