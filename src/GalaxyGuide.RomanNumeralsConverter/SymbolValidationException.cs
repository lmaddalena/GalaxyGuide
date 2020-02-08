using System;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public class SymbolValidationException : System.Exception
    {
        public int Position { get; private set; }   
        public string RomanNumeral { get; private set; }

        public SymbolValidationException() 
        { }
        
        public SymbolValidationException(string message, int position, string romanNumeral) : base(message) 
        { 
            this.Position = position;
            this.RomanNumeral = romanNumeral;
        }
        
        public SymbolValidationException(string message, int position, string romanNumeral, System.Exception inner) : base(message, inner) 
        { 
            this.Position = position;
            this.RomanNumeral = romanNumeral;
        }
        
        protected SymbolValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}
