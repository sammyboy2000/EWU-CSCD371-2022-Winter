﻿using System;
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
        public string GetJoke() => IJokeService.GetJoke(HttpClient);

        public void PresentJoke(string joke) => Console.WriteLine(joke);
    }
}