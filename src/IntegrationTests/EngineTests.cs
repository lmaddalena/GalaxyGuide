using Microsoft.VisualStudio.TestTools.UnitTesting;
using GalaxyGuide.Mediator;

namespace IntegrationTests
{
    [TestClass]
    public class EngineTest
    {
        private IGalaxyEngine engine = new GalaxyEngine();

        [TestMethod]
        public void EvaluateTest1()
        {
            string expected = "OK";
            string actual;



            actual = engine.Evaluate("glob means I");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("prok means V");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("pish means X");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("tegj means L");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("glob glob units of Silver are worth 34 Credits");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("glob prok units of Gold are worth 57800 Credits");
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("pish pish units of Iron are worth 3910 Credits");            
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("how much is pish tegj glob glob ?");
            expected = "pish tegj glob glob is 42";
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("how many Credits is glob prok Silver ?");   
            expected = "glob prok Silver is 68 Credits";
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("how many Credits is glob prok Gold ?");  
            expected = "glob prok Gold is 57800 Credits";
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("how many Credits is glob prok Iron ?"); 
            expected = "glob prok Iron is 782 Credits";
            Assert.AreEqual(expected, actual);

            actual = engine.Evaluate("how much wood could ...");
            expected = "I have no idea what you are talking about";
            Assert.AreEqual(expected, actual.Substring(0, actual.IndexOf("\n")));

        }
    }
}
