using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGuide.FiniteStateMachine
{
    public class PatternRecognizer : IPatternRecognizer
    {
        public const string ANY = "*";
        public const string NUMBER = "[NUM]";

        // the start symbol (usually S)
        public string StartSymbol { get; private set; }
        // array of end symbols (Z, Z1, Z2,...)
        public string[] EndSymbols { get; private set; }
        // productions
        public List<Tuple<string, string, string>> Prods { get; private set; } 

        /// Constructor
        public PatternRecognizer(string startSymbol, string[] endSymbols, List<Tuple<string, string, string>> prods)
        {
            this.Prods = prods;
            this.StartSymbol = startSymbol;
            this.EndSymbols = endSymbols;
        }

        /// Parse: return true 
        public ParseResult Parse(string sentence)
        {
            // return type
            List<Tuple<string, string, string>> path = new List<Tuple<string, string, string>>();
            int incorrectWordIndex = -1;
            string incorrectWord = "";
            bool hasSyntaxError = false;
            bool isCorrect = true;
            

            // split the sentence in words
            string[] words = sentence.Split(' ');

            // the initial state
            string state = this.StartSymbol;

            for(int i = 0; i < words.Length; i++)
            {
                int numb;
                bool isNumber = int.TryParse(words[i], out numb);

                // search the productions with respect to state and word
                var prod = this.Prods.Where(p => p.Item1 == state && (p.Item2 == words[i] || (isNumber && p.Item2 == NUMBER) || p.Item2 == ANY)).FirstOrDefault();

                if(prod == null)
                {
                    // production not found
                    incorrectWordIndex = i;
                    incorrectWord = words[i];
                    isCorrect = false;
                    hasSyntaxError = true;
                    path.Add(new Tuple<string, string, string>(state, words[i], ""));
                    break;
                }
                else
                {
                    // add the prod found to the path
                    path.Add(new Tuple<string, string, string>(prod.Item1, words[i], prod.Item3));


                    // set the new state for next walk in the path
                    state = prod.Item3;
                }    

            }

            if(this.EndSymbols.Contains(path.Last().Item3))
                isCorrect = true;
            else
                isCorrect = false;

            return new ParseResult(path, isCorrect, hasSyntaxError, incorrectWord, incorrectWordIndex);

        }
        

    }
}
