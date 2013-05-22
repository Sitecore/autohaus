using System.Collections.Generic;

namespace Autohaus.Data.Models
{
    public class Facet
    {
        public Facet(string key, string name)
        {
            Key = key;
            Name = name;
            Values = new List<FacetValue>();
        }

        public string Key { get; set; }

        public string Name { get; set; }

        public List<FacetValue> Values { get; set; }
    }
}