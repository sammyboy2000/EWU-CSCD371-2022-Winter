using System;
using System.Net.Http;

namespace CanHazFunny
{
    public class Jester : IJokeService, IOutput
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

        public string FindJoke(string[] filters)
        {
            string joke;
            do
            {
                joke = GetJoke();
            } while (!ScreenJoke(joke, filters));

            return joke;
        }

        public static bool ScreenJoke(string joke, string[] filters)
        {
            if (joke == null || filters == null || filters.Length == 0)
                return false;
            bool approved = true;
            foreach (string filter in filters)
            {
                if (joke.ToLower().Contains(filter.ToLower()))
                    approved = false;
            }
            return approved;
        }
    }
}
