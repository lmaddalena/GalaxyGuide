using System;
using GalaxyGuide.RomanNumeralsConverter;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace RomanNumeralsConverterTests
{
    [TestClass]
    public class ConverterTest
    {
        [TestMethod]
        public void ConvertTest()
        {
            IValidationRules validation = new ValidationRules();
            Converter conv = new Converter(validation);
            
            int actual = 0;
            int expected = 0;

            expected = 1140;
            actual = conv.Convert("MCXL");
            Assert.AreEqual(expected, actual);

            expected = 1969;
            actual = conv.Convert("MCMLXIX");
            Assert.AreEqual(expected, actual);

            expected = 2020;
            actual = conv.Convert("MMXX");
            Assert.AreEqual(expected, actual);

            expected = 999;
            actual = conv.Convert("CMXCIX");
            Assert.AreEqual(expected, actual);

            expected = 78;
            actual = conv.Convert("LXXVIII");
            Assert.AreEqual(expected, actual);

            expected = 1903;
            actual = conv.Convert("MCMIII");
            Assert.AreEqual(expected, actual);

            expected = 9;
            actual = conv.Convert("IX");
            Assert.AreEqual(expected, actual);

            expected = 1666;
            actual = conv.Convert("MDCLXVI");
            Assert.AreEqual(expected, actual);

            expected = 2006;
            actual = conv.Convert("MMVI");
            Assert.AreEqual(expected, actual);

            try
            {
                expected = 4;
                actual = conv.Convert("MCXXL");
                Assert.AreEqual(expected, actual);
                
            }
            catch(InvalidSubtractionException e)
            {
                actual = e.Position;
            }
            catch (System.Exception)
            {
                
                throw;
            }
            Assert.AreEqual(expected, actual);
        }

    }
}