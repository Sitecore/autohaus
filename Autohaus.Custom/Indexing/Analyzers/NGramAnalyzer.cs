using System.IO;
using Lucene.Net.Analysis;
using Lucene.Net.Analysis.Shingle;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Util;

namespace Autohaus.Custom.Indexing.Analyzers
{
    public class NGramAnalyzer : Analyzer
    {
        public override TokenStream TokenStream(string fieldName, TextReader reader)
        {
            var tokenizer = new StandardTokenizer(Version.LUCENE_30, reader);
            var shingleMatrix = new ShingleMatrixFilter(tokenizer, 2, 8, ' ');
            var lowerCaseFilter = new LowerCaseFilter(shingleMatrix);
            return new StopFilter(true, lowerCaseFilter, StopAnalyzer.ENGLISH_STOP_WORDS_SET);
        }
    }
}