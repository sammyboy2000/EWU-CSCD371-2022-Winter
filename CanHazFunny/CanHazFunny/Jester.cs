using System;
using System.Net.Http;

namespace CanHazFunny
{
    internal class Jester : IJokeService, IOutput
    {
        public HttpClient HttpClient { get; }
        public Jester()
        {
            HttpClient = new HttpClient();
        }
        public string GetJoke()
        {
            return HttpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api")).Result;
        }

        public void PresentJoke(string joke) => Console.WriteLine(joke);

        internal string FindJoke()
        {
            throw new NotImplementedException();
        }
    }
}
