using System;
using System.Collections.Generic;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public class Converter : IConverter
    {
        private IValidationRules _validationRules;
        private Dictionary<string, int> symbols;
        public Converter(IValidationRules validationRules)
        {
            _validationRules = validationRules;
            symbols = Symbols.GetSymbols();
        }
        public int Convert(string roman)
        {
            _validationRules.SymbolsValidation(roman);
            _validationRules.SymbolsRepetitionValidation(roman);
            _validationRules.SubtractionValidation(roman);

            int i = 0;              // symbol pointer
            int res = 0;            // final result

            while(i < roman.Length)
            {
                if(i < roman.Length - 1)
                {
                    // keep two symbols at a time
                    string s = roman.Substring(i, 2);

                    // split the two symbols in two variables
                    string sym1 = s.Substring(0, 1);
                    string sym2 = s.Substring(1, 1);

                    // get the corresponding values
                    int val1 = symbols.GetValueOrDefault(sym1);
                    int val2 = symbols.GetValueOrDefault(sym2);

                    if(val1 >= val2)
                    {
                        // take only the first value
                        res += val1;
                        i++;
                    }
                    else
                    {
                        //if(prevVal < (val2 - val1))
                        //    throw new ApplicationException("Invalid symbol at position " + (i + 1));

                        // take both values
                        res += (val2 - val1);
                        //prevVal = (val2 - val1);
                        i += 2;
                    }                        
                }
                else
                {
                    string s = roman.Substring(i, 1);
                    res += symbols.GetValueOrDefault(s);                    
                    i++;
                }
            }

            return res;
        }

        public Dictionary<string, int> GetSymbols()
        {
            return Symbols.GetSymbols();
        }
    }
}
