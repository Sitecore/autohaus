using System.Collections.Generic;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Tokenattributes;

namespace Autohaus.Custom.Indexing.Filters
{
    public class MapCharFilter : TokenFilter
    {
        private readonly Dictionary<char, char> map;

        private readonly ITermAttribute termAtt;

        public MapCharFilter(Dictionary<char, char> map, TokenStream @in)
            : base(@in)
        {
            this.map = map;
            termAtt = AddAttribute<ITermAttribute>();
        }

        public override bool IncrementToken()
        {
            if (!input.IncrementToken())
            {
                return false;
            }

            char[] chars = termAtt.TermBuffer();
            int num = termAtt.TermLength();
            for (int i = 0; i < num; i++)
            {
                char key = chars[i];

                if (map.ContainsKey(key))
                {
                    chars[i] = map[key];
                }

                chars[i] = char.ToLower(chars[i]);
            }

            return true;
        }
    }
}