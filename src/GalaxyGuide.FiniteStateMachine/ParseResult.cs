using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGuide.FiniteStateMachine
{
    public class ParseResult
    {
        public List<Tuple<string, string, string>> Path { get; private set; }
        public bool IsCorrect { get; private set; } 
        public bool HasSyntaxError { get; private set; } 
        public string IncorrectWord { get; private set; }   
        public int IncorrectWordIndex { get; private set; } 
        public ParseResult(
            List<Tuple<string, string, string>> path,
            bool isCorrect,
            bool hasSyntaxError,
            string incorrectWord,
            int incorrectWordIndex )
        {
            this.Path = path;
            this.IsCorrect = isCorrect;
            this.HasSyntaxError = hasSyntaxError;
            this.IncorrectWord = incorrectWord;
            this.IncorrectWordIndex = incorrectWordIndex;
        }

        public int GetPathDepth()
        {
            if(this.Path == null)
                return 0;
            else
                return this.Path.Count;
        }
    }
}