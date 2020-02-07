using System.Collections.Generic;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public class Symbols
    {
        private static Dictionary<string, int> _symbols;

        public static Dictionary<string, int> GetSymbols()
        {
            if(_symbols == null)
            {
                _symbols = new Dictionary<string, int>();
                _symbols.Add("I", 1);
                _symbols.Add("V", 5);
                _symbols.Add("X", 10);
                _symbols.Add("L", 50);
                _symbols.Add("C", 100);
                _symbols.Add("D", 500);
                _symbols.Add("M", 1000);            
            }

            return _symbols;
        }
    }
}