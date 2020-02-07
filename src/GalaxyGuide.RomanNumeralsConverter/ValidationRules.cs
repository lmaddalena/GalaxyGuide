using System;
using System.Linq;
using System.Collections.Generic;

namespace GalaxyGuide.RomanNumeralsConverter
{

    public class ValidationRules : IValidationRules
    {
        private Dictionary<string, int> symbols;

        public ValidationRules() 
        {
            symbols = Symbols.GetSymbols();
        }

        public void SubtractionValidation(string roman)
        {
            int i = 0;          // symbols pointer
            int prevVal = 9999; // value of symbol(s) in the previous iteration

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
                        prevVal = val1;
                        i++;
                    }
                    else
                    {
                        if(sym1 == "I" && sym2 != "I" && sym2 != "V" && sym2 != "X")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'I' can be subtracted from 'V' and 'X' only", i), i);

                        if(sym1 == "X" && sym2 != "X" && sym2 != "L" && sym2 != "C")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'X' can be subtracted from 'L' and 'C' only", i), i);

                        if(sym1 == "C" && sym2 != "C" && sym2 != "D" && sym2 != "M")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'C' can be subtracted from 'D' and 'M' only", i), i);

                        if(sym1 == "V" && sym2 != "V")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'V' can never be subtracted", i), i);

                        if(sym1 == "L" && sym2 != "L")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'L' can never be subtracted", i), i);

                        if(sym1 == "D" && sym2 != "D")
                            throw new InvalidSubtractionException (string.Format("Invalid subtraction at position {0}. 'D' can never be subtracted", i), i);

                        if(prevVal < (val2 - val1))
                            throw new InvalidSubtractionException("Invalid subtraction at position " + (i + 1), (i + 1));

                        // take both values
                        prevVal = (val2 - val1);
                        i += 2;
                    }                        
                }
                else
                {
                    i++;
                }
            }

        }

        public void SymbolsRepetitionValidation(string roman)
        {
            string currSym = "";        // current symbol
            string prevSym = "";        // previous symbol
            int count = 0;              // symbols count
        
            for(int i = 0; i < roman.Length; i++)
            {
                // get the current symbol
                currSym = roman.Substring(i, 1); 

                // check if current symbol is equl to the previous one
                if(currSym == prevSym)
                {
                    // increase the counter
                    count++;

                    // check symbols "DLV"
                    if(count > 1 && (currSym == "D" || currSym == "L" || currSym == "V" ))
                        throw new SymbolsRepetitionException(
                            string.Format("Symbol repeated more than once: symbol: {0}, position:{1}", currSym, i), 
                            i, 
                            currSym);
                    
                    // check symbols "IXCM"
                    if(count > 3 && (currSym == "I" || currSym == "X" || currSym == "C" || currSym == "M"))
                        throw new SymbolsRepetitionException(
                            string.Format("Symbol repeated more than three times: symbol: {0}, position:{1}", currSym, i), 
                            i, 
                            currSym);                    
                }
                else
                {
                    // reset the counter
                    count = 1;
                }

                // replace previous symbol with current
                prevSym = currSym;
            }
        }

        public void SymbolsValidation(string roman)
        {
            string currSym = "";    // current symbol
            int i = 0;              // symbols pointer

            while(i < roman.Length)
            { 
                currSym = roman.Substring(i, 1); 
                if(!symbols.ContainsKey(currSym))
                    throw new SymbolValidationException("Invalid symbol at position " + i, i);

                i++;
            }


        }
    }
}
