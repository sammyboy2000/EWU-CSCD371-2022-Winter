using Microsoft.VisualStudio.TestTools.UnitTesting;

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
            Assert.IsNotNull(mock.GetJoke());
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
        public void FindJoke_GivenFilters_Success()
        {
            Jester mock = new();
            string[] filters = { "Lots", "of", "filters", "Chuck", "Norris", "1337", "joke", "punny" };
            string joke = mock.FindJoke(filters);
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
