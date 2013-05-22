using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Text;
using System.Web.Http.Hosting;
using System.Web.Http.OData.Query;
using Sitecore.Diagnostics;

namespace Autohaus.Web.Controllers
{
    public static class ODataHelper
    {
        public static HttpRequestMessage BuildCustomRequest(this ODataQueryOptions originalOptions,
            out TopQueryOption top,
            out SkipQueryOption skip, out OrderByQueryOption orderBy)
        {
            top = null;
            skip = null;
            orderBy = null;

            // cuttin out $top and $skip from the request
            HttpRequestMessage customRequest = originalOptions.Request;

            if (customRequest.Properties.ContainsKey(HttpPropertyKeys.RequestQueryNameValuePairsKey))
            {
                Uri uri = originalOptions.Request.RequestUri;
                var pairs =
                    customRequest.Properties[HttpPropertyKeys.RequestQueryNameValuePairsKey] as
                        IEnumerable<KeyValuePair<string, string>>;

                if (pairs != null)
                {
                    IEnumerable<KeyValuePair<string, string>> jQueryNameValuePairs =
                        new FormDataCollection(uri).GetJQueryNameValuePairs();
                    var updatedPairs = new List<KeyValuePair<string, string>>();

                    foreach (var pair in jQueryNameValuePairs)
                    {
                        if (pair.Key.Equals("$top"))
                        {
                            top = originalOptions.Top;
                        }
                        else if (pair.Key.Equals("$skip"))
                        {
                            skip = originalOptions.Skip;
                        }
                        else if (pair.Key.Equals("$orderby"))
                        {
                            orderBy = originalOptions.OrderBy;
                        }
                        else
                        {
                            updatedPairs.Add(pair);
                        }
                    }

                    customRequest.Properties.Remove(HttpPropertyKeys.RequestQueryNameValuePairsKey);
                    customRequest.Properties.Add(HttpPropertyKeys.RequestQueryNameValuePairsKey, updatedPairs);
                }
            }

            return customRequest;
        }

        public static IEnumerable<KeyValuePair<string, string>> GetJQueryNameValuePairs(this FormDataCollection formData)
        {
            Assert.IsNotNull(formData, "formData");
            int count = 0;
            foreach (var data in formData)
            {
                Assert.IsTrue(count < MediaTypeFormatter.MaxHttpCollectionKeys, "MaxHttpCollectionKeyLimitReached");
                string key = NormalizeJQueryToMvc(data.Key);
                string value = data.Value ?? string.Empty;
                yield return new KeyValuePair<string, string>(key, value);
                count++;
            }
        }

        private static string NormalizeJQueryToMvc(string key)
        {
            if (key == null)
            {
                return string.Empty;
            }
            StringBuilder builder = null;
            int startIndex = 0;
            do
            {
                int index = key.IndexOf('[', startIndex);
                if (index < 0)
                {
                    if (startIndex == 0)
                    {
                        return key;
                    }
                    builder = builder ?? new StringBuilder();
                    builder.Append(key, startIndex, key.Length - startIndex);
                    break;
                }
                builder = builder ?? new StringBuilder();
                builder.Append(key, startIndex, index - startIndex);
                int num3 = key.IndexOf(']', index);
                Assert.IsTrue(num3 != -1, "JQuerySyntaxMissingClosingBracket");
                if (num3 != (index + 1))
                {
                    if (char.IsDigit(key[index + 1]))
                    {
                        builder.Append(key, index, (num3 - index) + 1);
                    }
                    else
                    {
                        builder.Append('.');
                        builder.Append(key, index + 1, (num3 - index) - 1);
                    }
                }
                startIndex = num3 + 1;
            } while (startIndex < key.Length);
            return builder.ToString();
        }
    }
}