using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaxyGuide.RomanNumeralsConverter;

namespace RomanNumeralsConverterTests
{
    [TestClass]
    public class ValidationTest
    {
        [TestMethod]
        public void TestSymbolsValidation()
        {
            IValidationRules validationRules = new ValidationRules();

            int actual = -1;
            int expected = 2;
            string roman = "XLKC";

            try
            {                
                validationRules.SymbolsValidation(roman);
            }
            catch  (SymbolValidationException e)
            {
                actual = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }

            Assert.AreEqual(expected, actual, "Symbol Position does not match");
        }

        [TestMethod]
        public void TestSymbol_D_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 1;
            string actualSym = "";
            string expectedSym = "D";
            string roman = "DDLV";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_L_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 2;
            string actualSym = "";
            string expectedSym = "L";
            string roman = "DLLV";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_V_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 3;
            string actualSym = "";
            string expectedSym = "V";
            string roman = "DLVV";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_I_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 3;
            string actualSym = "";
            string expectedSym = "I";
            string roman = "IIIIXCM";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_X_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 4;
            string actualSym = "";
            string expectedSym = "X";
            string roman = "IXXXXCM";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_C_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 5;
            string actualSym = "";
            string expectedSym = "C";
            string roman = "IXCCCCM";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSymbol_M_Repetition()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 6;
            string actualSym = "";
            string expectedSym = "M";
            string roman = "IXCMMMM";

            try
            {                
                validationRules.SymbolsRepetitionValidation(roman);
            }
            catch  (SymbolsRepetitionException e)
            {
                actualPos = e.Position;
                actualSym = e.Symbol;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");
            Assert.AreEqual(expectedSym, actualSym, "Symbol does not match");
        }

        [TestMethod]
        public void TestSubtractionSymbol_I()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 0;
            string roman = "IM";

            try
            {                
                validationRules.SubtractionValidation(roman);
            }
            catch  (InvalidSubtractionException e)
            {
                actualPos = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");

            validationRules.SubtractionValidation("IV");
            validationRules.SubtractionValidation("IX");
        }

        [TestMethod]
        public void TestSubtractionSymbol_X()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 0;
            string roman = "XM";

            try
            {                
                validationRules.SubtractionValidation(roman);
            }
            catch  (InvalidSubtractionException e)
            {
                actualPos = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");

            validationRules.SubtractionValidation("XL");
            validationRules.SubtractionValidation("XC");

        }

        [TestMethod]
        public void TestSubtractionSymbol_C()
        {
            IValidationRules validationRules = new ValidationRules();

            validationRules.SubtractionValidation("CD");
            validationRules.SubtractionValidation("CM");

        }

        [TestMethod]
        public void TestSubtractionSymbol_V()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 0;
            string roman = "VX";

            try
            {                
                validationRules.SubtractionValidation(roman);
            }
            catch  (InvalidSubtractionException e)
            {
                actualPos = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");

        }

        [TestMethod]
        public void TestSubtractionSymbol_L()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 0;
            string roman = "LC";

            try
            {                
                validationRules.SubtractionValidation(roman);
            }
            catch  (InvalidSubtractionException e)
            {
                actualPos = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");

        }

        [TestMethod]
        public void TestSubtractionSymbol_D()
        {
            IValidationRules validationRules = new ValidationRules();

            int actualPos = -1;
            int expectedPos = 0;
            string roman = "DM";

            try
            {                
                validationRules.SubtractionValidation(roman);
            }
            catch  (InvalidSubtractionException e)
            {
                actualPos = e.Position;
            }
            catch (System.Exception)
            {                
                throw;
            }
            Assert.AreEqual(expectedPos, actualPos, "Symbol Position does not match");

        }

    }    
}
