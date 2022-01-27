using System;
using System.Net.Http;

namespace CanHazFunny
{
    public interface IJokeService
    {
        HttpClient HttpClient { get; }

        public string GetJoke()
        {
            return HttpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api")).Result;
        }
    }
}
