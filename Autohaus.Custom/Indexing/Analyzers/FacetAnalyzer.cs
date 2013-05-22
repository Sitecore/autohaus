using System.Collections.Generic;
using System.IO;
using Autohaus.Custom.Indexing.Filters;
using Lucene.Net.Analysis;

namespace Autohaus.Custom.Indexing.Analyzers
{
    public class FacetAnalyzer : KeywordAnalyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            TokenStream source = new KeywordTokenizer(reader);
            var map = new Dictionary<char, char> {{'-', ' '}};
            return new MapCharFilter(map, source);
        }
    }
}