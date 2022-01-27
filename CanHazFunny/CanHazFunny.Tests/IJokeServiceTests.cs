using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

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
