using System;

namespace GalaxyGuide.RomanNumeralsConverter
{
    [System.Serializable]
    public class SymbolsRepetitionException : System.Exception
    {
        public int Position { get; private set; }   
        public string Symbol { get; private set; }   

        public SymbolsRepetitionException() 
        { }

        public SymbolsRepetitionException(string message, int position, string symbol) : base(message) 
        { 
            this.Position = position;
            this.Symbol = symbol;
        }

        public SymbolsRepetitionException(string message, int position, string symbol, System.Exception inner) : base(message, inner) 
        { 
            this.Position = position;
            this.Symbol = symbol;
        }
        
        protected SymbolsRepetitionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}

