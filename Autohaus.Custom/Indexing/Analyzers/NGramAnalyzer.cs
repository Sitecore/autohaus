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
            // This should be a good tokenizer for most European-language documents:
            // Splits words at punctuation characters, removing punctuation.
            // Splits words at hyphens, unless there's a number in the token...
            // Recognizes email addresses and internet hostnames as one token.
            var intput = new StandardTokenizer(Version.LUCENE_30, reader);

            // A ShingleMatrixFilter constructs shingles from a token stream.
            // "2010 Audi RS5 Quattro Coupe" => "2010 Audi", "Audi RS5", "RS5 Quattro", "Quattro Coupe"
            var shingleMatrixOutput = new ShingleMatrixFilter(
                                                // stream from which to construct the matrix
                                                intput,
                                                // minimum number of tokens in any shingle
                                                2,
                                                // maximum number of tokens in any shingle.
                                                8,
                                                // character to use between texts of the token parts in a shingle.
                                                ' ');

            // Normalizes token text to lower case.
            var lowerCaseFilter = new LowerCaseFilter(shingleMatrixOutput);

            // Removes stop words from a token stream.
            return new StopFilter(true, lowerCaseFilter, StopAnalyzer.ENGLISH_STOP_WORDS_SET);
        }
    }
}