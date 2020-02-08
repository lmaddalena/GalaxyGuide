using System;
using System.Linq;
using System.Collections.Generic;
using GalaxyGuide.FiniteStateMachine;
using GalaxyGuide.RomanNumeralsConverter;

namespace GalaxyGuide.Mediator
{
    public class GalaxyEngine : IGalaxyEngine
    {
        private Dictionary<string, double> _metals;
        private Dictionary<string, string> _symbolPairs;
        
        private IConverter _converter;

        public GalaxyEngine()
        {
            _metals = new Dictionary<string, double>();
            _metals.Add("Silver", 0);
            _metals.Add("Gold", 0);
            _metals.Add("Iron", 0);

            _symbolPairs = new Dictionary<string, string>();
            _converter = new Converter(new ValidationRules());
        }

        public string Evaluate(string sentence)
        {
            sentence = sentence.Trim();
            
            List<ParseResult> results = new List<ParseResult>();
            ParseResult pr; 

            pr = GetPatternRecognizerForSentence1().Parse(sentence);
            results.Add(pr);
            if(pr.IsCorrect)
                return ProcessSentence1(pr);

            pr = GetPatternRecognizerForSentence2().Parse(sentence);
            results.Add(pr);
            if(pr.IsCorrect)
                return ProcessSentence2(pr);

            pr = GetPatternRecognizerForSentence3().Parse(sentence);
            results.Add(pr);
            if(pr.IsCorrect)
                return ProcessSentence3(pr);

            pr = GetPatternRecognizerForSentence4().Parse(sentence);
            results.Add(pr);
            if(pr.IsCorrect)
                return ProcessSentence4(pr);

            // no one is correct
            pr = null;

            // select the most deep
            foreach(var r in results)
            {
                if(pr == null || r.GetPathDepth() > pr.GetPathDepth())
                    pr = r;
            }

            string s = "I have no idea what you are talking about\n\n";

            // compose Syntax Error message
            if(pr.GetPathDepth() > 0 && pr.HasSyntaxError)
            {
                s += "Syntax Error:\n";
                string[] words = sentence.Split(' ');

                s += sentence + "\n";

                for(int j = 0; j < pr.IncorrectWordIndex; j++)
                {
                    string w = words[j];
                    s += new string(' ', w.Length + 1);
                }
                s += new string('^', pr.IncorrectWord.Length);
            }
            
            return s;
        }

        private string ProcessSentence1(ParseResult pr)
        {
            string l = pr.Path.Where(p => p.Item3 == "A").Single().Item2;
            string r = pr.Path.Where(p => p.Item3 == "Z").Single().Item2;

            if(_symbolPairs.ContainsKey(l))
                return l + " is already specified";
            if(_symbolPairs.ContainsValue(r))
                return "symbol " + r + " is already specified";

            this._symbolPairs.Add(l,r);
            return "OK";
        }

        private string ProcessSentence2(ParseResult pr)
        {
            // get symbols
            var sym = pr.Path.Where(p => p.Item3 == "A");
            string roman = "";
            foreach(var s in sym)
            {
                roman += _symbolPairs.GetValueOrDefault(s.Item2);
            }

            // nummber of units
            int units = _converter.Convert(roman);

            // metal
            string metal = pr.Path.Where(p => p.Item3 == "D").Single().Item2;

            // credis
            string credits = pr.Path.Where(p => p.Item3 == "G").Single().Item2;

            // parse string in int
            double icredits;
            double.TryParse(credits, out icredits);

            Double price = icredits / units;

            _metals[metal] = price;

            return "OK";
        }

        private string ProcessSentence3(ParseResult pr)
        {
            // get symbols
            var sym = pr.Path.Where(p => p.Item1 == "D" && p.Item3 == "D");
            string roman = "";
            foreach(var s in sym)
            {
                roman += _symbolPairs.GetValueOrDefault(s.Item2);
            }

            // number of units
            int units = _converter.Convert(roman);

            // metal
            string metal = pr.Path.Where(p => p.Item3 == "E").Single().Item2;

            // credis
            double credits = _metals[metal] * units;

            string message = "";

            foreach(var s in sym)
            {
                message += s.Item2 + " ";
            }

            message += metal;
            message += " is " + credits.ToString() + " Credits";

            return message;
        }

        private string ProcessSentence4(ParseResult pr)
        {
            // get symbols
            var sym = pr.Path.Where(p => p.Item3 == "D");
            string roman = "";
            foreach(var s in sym)
            {
                roman += _symbolPairs.GetValueOrDefault(s.Item2);
            }

            // value
            int val = _converter.Convert(roman);

            string message = "";

            foreach(var s in sym)
            {
                message += s.Item2 + " ";
            }

            message += "is " + val.ToString();
            return message;

        }

        private IPatternRecognizer GetPatternRecognizerForSentence1()
        {
            // initial state
            string S = "S";

            // final state
            string[] Z = new string[] { "Z" };

            // productions
            List<Tuple<string, string, string>> prod = new List<Tuple<string, string, string>>();

            prod.Add(new Tuple<string, string, string>("S", PatternRecognizer.ANY, "A"));
            prod.Add(new Tuple<string, string, string>("A", "means", "B"));

            var romanSymbols = _converter.GetSymbols();

            foreach(var s in romanSymbols)
            {
                prod.Add(new Tuple<string, string, string>("B", s.Key, "Z"));    
            }            

            PatternRecognizer pr = new PatternRecognizer(S, Z, prod);
            return pr;

        }

        private IPatternRecognizer GetPatternRecognizerForSentence2()
        {
            // initial state
            string S = "S";

            // final state
            string[] Z = new string[] { "Z" };

            // productions
            List<Tuple<string, string, string>> prod = new List<Tuple<string, string, string>>();

            foreach(var sym in _symbolPairs)
            {
                prod.Add(new Tuple<string, string, string>("S", sym.Key, "A"));    
                prod.Add(new Tuple<string, string, string>("A", sym.Key, "A")); 
            }

            
            prod.Add(new Tuple<string, string, string>("A", "units", "B"));
            prod.Add(new Tuple<string, string, string>("B", "of", "C"));

            foreach(var m in _metals)
            {
                prod.Add(new Tuple<string, string, string>("C", m.Key, "D"));    
            }

            prod.Add(new Tuple<string, string, string>("D", "are", "E"));
            prod.Add(new Tuple<string, string, string>("E", "worth", "F"));
            prod.Add(new Tuple<string, string, string>("F", PatternRecognizer.NUMBER, "G"));
            prod.Add(new Tuple<string, string, string>("G", "Credits", "Z"));

            PatternRecognizer pr = new PatternRecognizer(S, Z, prod);
            return pr;

        }

        private IPatternRecognizer GetPatternRecognizerForSentence3()
        {
            // initial state
            string S = "S";

            // final state
            string[] Z = new string[] { "Z" };

            // productions
            List<Tuple<string, string, string>> prod = new List<Tuple<string, string, string>>();

            
            prod.Add(new Tuple<string, string, string>("S", "how", "A"));
            prod.Add(new Tuple<string, string, string>("A", "many", "B"));
            prod.Add(new Tuple<string, string, string>("B", "Credits", "C"));
            prod.Add(new Tuple<string, string, string>("C", "is", "D"));

            foreach(var sym in _symbolPairs)
            {
                prod.Add(new Tuple<string, string, string>("D", sym.Key, "D"));    
                prod.Add(new Tuple<string, string, string>("D", sym.Key, "D")); 
            }

            foreach(var m in _metals)
            {
                prod.Add(new Tuple<string, string, string>("D", m.Key, "E"));    
            }

            prod.Add(new Tuple<string, string, string>("E", "?", "Z"));
            
            PatternRecognizer pr = new PatternRecognizer(S, Z, prod);
            return pr;

        }

        private IPatternRecognizer GetPatternRecognizerForSentence4()
        {
            // initial state
            string S = "S";

            // final state
            string[] Z = new string[] { "Z" };

            // productions
            List<Tuple<string, string, string>> prod = new List<Tuple<string, string, string>>();

            prod.Add(new Tuple<string, string, string>("S", "how", "A"));
            prod.Add(new Tuple<string, string, string>("A", "much", "B"));
            prod.Add(new Tuple<string, string, string>("B", "is", "C"));

            foreach(var sym in _symbolPairs)
            {
                prod.Add(new Tuple<string, string, string>("C", sym.Key, "D"));    
                prod.Add(new Tuple<string, string, string>("D", sym.Key, "D")); 
            }

            prod.Add(new Tuple<string, string, string>("D", "?", "Z"));

            PatternRecognizer pr = new PatternRecognizer(S, Z, prod);
            return pr;

        }
    }


}
