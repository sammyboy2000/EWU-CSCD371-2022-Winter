using System;
using System.Net.Http;

namespace CanHazFunny
{
    public interface IJokeService
    {
        public HttpClient HttpClient { get; }

        public string GetJoke();
    }
}
