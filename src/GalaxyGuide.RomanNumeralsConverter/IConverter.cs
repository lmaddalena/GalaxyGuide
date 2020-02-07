using System;
using System.Collections.Generic;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public interface IConverter
    {
        int Convert(string roman);
        Dictionary<string, int> GetSymbols();
    }
}