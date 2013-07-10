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
            // Emits the entire input as a single token.
            TokenStream source = new KeywordTokenizer(reader);

            var map = new Dictionary<char, char> {{'-', ' '}};

            // replaces specified characters from the token stream and lowercases the result
            return new MapCharFilter(map, source);
        }
    }
}