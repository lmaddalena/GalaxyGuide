using System;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public class SymbolValidationException : System.Exception
    {
        public int Position { get; private set; }   

        public SymbolValidationException() 
        { }
        
        public SymbolValidationException(string message, int position) : base(message) 
        { 
            this.Position = position;
        }
        
        public SymbolValidationException(string message, int position, System.Exception inner) : base(message, inner) 
        { 
            this.Position = position;
        }
        
        protected SymbolValidationException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}
