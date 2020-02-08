namespace GalaxyGuide.RomanNumeralsConverter
{
    [System.Serializable]
    public class InvalidSubtractionException : System.Exception
    {
        public int Position { get; private set; }  
        public string RomanNumeral { get; private set; }
        public InvalidSubtractionException() 
        { }
        public InvalidSubtractionException(string message, int position, string romanNumeral) : base(message) 
        { 
            this.Position = position;
            this.RomanNumeral = romanNumeral;
        }
        public InvalidSubtractionException(string message, int position, string romanNumeral, System.Exception inner) : base(message, inner) 
        { 
            this.Position = position;
            this.RomanNumeral = romanNumeral;
        }
        protected InvalidSubtractionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}
