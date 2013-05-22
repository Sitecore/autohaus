namespace Autohaus.Data.Models
{
    public class FacetValue
    {
        public FacetValue(string name, int count)
        {
            Name = name;
            Count = count;
        }

        public string Name { get; set; }

        public int Count { get; set; }
    }
}