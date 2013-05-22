using System.Runtime.Serialization;
using Sitecore;
using Sitecore.Data;

namespace Autohaus.Data.Models
{
    [DataContract]
    public class CarSearchResult
    {
        public CarSearchResult([NotNull] string name, [NotNull] string url)
        {
            Name = name;
            Url = url;
        }

        public CarSearchResult([NotNull] ItemUri uri, [NotNull] string name, [NotNull] string url)
        {
            Uri = uri;
            Name = name;
            Url = url;
        }

        public ItemUri Uri { get; protected set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public string Url { get; set; }
    }
}