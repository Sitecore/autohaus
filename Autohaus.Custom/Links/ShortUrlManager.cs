using System;
using System.Linq;
using Autohaus.Custom.Links.ResolveShortUrlPipeline;
using Sitecore;
using Sitecore.Buckets.Extensions;
using Sitecore.Data;
using Sitecore.Data.IDTables;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Links;
using Sitecore.Pipelines;

namespace Autohaus.Custom.Links
{
    public static class ShortUrlManager
    {
        public static readonly string Prefix = "Bucket";

        public static string AddAndGetShortUrl(this Item item, UrlOptions options)
        {
            if (item == null)
            {
                Log.Fatal("ShortUrlManager: AddAndGetShortUrl failed. Item was null", new object());
                return null;
            }

            return item.ReadShortUrl() ?? item.AddShortUrl(options);
        }

        public static string ResolveShortUrl(this Item item, UrlOptions options)
        {
            if (item == null)
            {
                Log.Fatal("ShortUrlManager: cannot resolve short url. Item was null", new object());
                return null;
            }

            var args = new ResolveShortUrlArgs(item, options);
            CorePipeline.Run("resolveShortUrl", args);
            return args.ResolvedUrl;
        }

        public static Item GetItemByShortUrl(string filePath)
        {
            Assert.ArgumentNotNullOrEmpty(filePath, "filePath");

            IDTableEntry id = ShortUrlTable.GetID(Prefix, filePath);

            if (id != null && !ID.IsNullOrEmpty(id.ID))
            {
                return Context.Database.GetItem(id.ID);
            }

            return null;
        }

        public static string ReadShortUrl(this Item item)
        {
            if (item != null && item.Parent != null && item.Parent.IsABucketFolder())
            {
                try
                {
                    IDTableEntry entry = ShortUrlTable.GetKeys(Prefix, item.ID).FirstOrDefault();
                    return entry == null ? null : entry.Key;
                }
                catch (Exception exception)
                {
                    Log.Fatal(
                        string.Format("Short Url Manager: cannot read short url for item {0} {1} {2}", item.Uri,
                            exception.Message,
                            exception.StackTrace), new object());
                    return null;
                }
            }

            return null;
        }

        public static string AddShortUrl(this Item item, UrlOptions options)
        {
            if (item != null && item.Parent != null && item.Parent.IsABucketFolder())
            {
                try
                {
                    string shortUrl = item.ResolveShortUrl(options);

                    if (string.IsNullOrEmpty(shortUrl))
                    {
                        return null;
                    }

                    if (options.EncodeNames)
                    {
                        shortUrl = MainUtil.EncodePath(shortUrl, '/');
                    }

                    if (options.LowercaseUrls)
                    {
                        shortUrl = shortUrl.ToLowerInvariant();
                    }

                    if (!shortUrl.EndsWith(".aspx") && options.AddAspxExtension)
                    {
                        shortUrl += ".aspx";
                    }

                    ShortUrlTable.RemoveID(Prefix, item.ID);
                    ShortUrlTable.Add(Prefix, shortUrl, item.ID);
                    return shortUrl;
                }
                catch (Exception exception)
                {
                    Log.Fatal(
                        string.Format("Short Url Manager: cannot add short url for item {0} {1} {2}", item.Uri,
                            exception.Message,
                            exception.StackTrace), new object());
                    return null;
                }
            }

            return null;
        }
    }
}