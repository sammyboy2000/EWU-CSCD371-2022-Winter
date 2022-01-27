using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Net.Http;

namespace CanHazFunny.Tests
{
    [TestClass]
    public class IJokeServiceTests
    {
        HttpClient _TestHttpClient = new();
        [TestMethod]
        public void GetJoke_GivenHttpClient_ReturnsJoke()
        {
            string joke = IJokeService.GetJoke(_TestHttpClient);

            Assert.IsNotNull(joke);
        }
    }
}
