namespace GalaxyGuide.RomanNumeralsConverter
{
    [System.Serializable]
    public class InvalidSubtractionException : System.Exception
    {
        public int Position { get; private set; }  
        public InvalidSubtractionException() 
        { }
        public InvalidSubtractionException(string message, int position) : base(message) 
        { 
            this.Position = position;
        }
        public InvalidSubtractionException(string message, int position, System.Exception inner) : base(message, inner) 
        { 
            this.Position = position;
        }
        protected InvalidSubtractionException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) 
        { }
    }
}
