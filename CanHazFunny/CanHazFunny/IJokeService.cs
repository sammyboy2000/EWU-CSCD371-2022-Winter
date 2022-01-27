using System;
using System.Net.Http;

namespace CanHazFunny
{
    public interface IJokeService
    {
        public HttpClient HttpClient { get; }
        public static string GetJoke(HttpClient? httpClient)
        {
            if(httpClient == null) { throw new ArgumentNullException(nameof(httpClient)); }
            return httpClient.GetStringAsync(new Uri("https://geek-jokes.sameerkumar.website/api")).Result;
        }
    }
}
