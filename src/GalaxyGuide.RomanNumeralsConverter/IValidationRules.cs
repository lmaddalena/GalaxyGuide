using System;

namespace GalaxyGuide.RomanNumeralsConverter
{
    public interface IValidationRules
    {
        void SymbolsValidation(string roman);
        void SubtractionValidation(string roman);
        void SymbolsRepetitionValidation(string roman);
    }
}