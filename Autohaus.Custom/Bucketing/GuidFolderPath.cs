using System;
using System.Globalization;
using Sitecore.Buckets.Util;
using Sitecore.Data;
using Sitecore.Diagnostics;

namespace Autohaus.Custom.Bucketing
{
    public class GuidFolderPath : IDynamicBucketFolderPath
    {
        /// <summary>
        ///     Getting the folder path by the first 3 characters of item ID
        /// </summary>
        public string GetFolderPath(ID itemId, ID parentItemId, DateTime creationDateOfNewItem)
        {
            Assert.ArgumentNotNull(itemId, "itemId");
            Assert.ArgumentNotNull(parentItemId, "parentItemId");

            char[] path =
                IdHelper.NormalizeGuid(itemId).ToString(CultureInfo.InvariantCulture).Substring(0, 3).ToCharArray();
            return string.Join(Constants.ContentPathSeperator, path);
        }
    }
}