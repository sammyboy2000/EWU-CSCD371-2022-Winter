using System;
using System.Net.Http;

namespace CanHazFunny
{
    public class Jester : IOutput
    {
        public HttpClient HttpClient { get; }
        public JokeService JokeService { get; }
        public Jester()
        {
            HttpClient = new HttpClient();
            JokeService = new JokeService();
        }

        public void TellJoke(string[] filters)
        {
            string joke;
            do
            {
                joke = JokeService.GetJoke(HttpClient);
            } while (!ScreenJoke(joke, filters));

            IOutput.PresentJoke(joke);
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
