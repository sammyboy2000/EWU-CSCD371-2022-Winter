using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class JesterTests
    {
        [TestMethod]
        public void Jester_InitializeHttpClient_Success()
        {
            Jester mock = new();
            Assert.IsNotNull(mock.HttpClient);
        }

        [TestMethod]
        public void GetJoke_ReturnsValidJoke_Success()
        {
            Jester mock = new();
            Assert.IsNotNull(mock.JokeService.GetJoke(mock.HttpClient));
        }

        [TestMethod]
        public void ScreenJoke_GivenValidJoke_Success()
        {
            bool result = Jester.ScreenJoke("This is a joke.", new string[] { "some", "filter" });
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void ScreenJoke_GivenInvalidJoke_Failure()
        {
            bool result = Jester.ScreenJoke("This is a joke.", new string[] { "joke", "filter" });
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void TellJoke_GivenFilters_Success()
        {
            Jester mock = new();
            //Redirect Console output to StringWriter
            StringWriter output = new();
            Console.SetOut(output);
            string[] filters = { "Lots", "of", "filters", "Chuck", "Norris", "1337", "joke", "punny" };
            mock.TellJoke(filters);
            string joke = output.ToString();
            Assert.IsNotNull(@joke);
            //Close StringWriter
            output.Dispose();
            bool validJoke = true;
            foreach (string filter in filters)
            {
                if (joke.Contains(filter))
                    validJoke = false;
            }
            Assert.IsTrue(validJoke);
        }
    }
}
