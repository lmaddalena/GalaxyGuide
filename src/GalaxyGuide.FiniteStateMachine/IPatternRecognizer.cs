using System;
using System.Collections.Generic;
using System.Linq;

namespace GalaxyGuide.FiniteStateMachine
{
    public interface IPatternRecognizer
    {
        ParseResult Parse(string sentence);
    }
}