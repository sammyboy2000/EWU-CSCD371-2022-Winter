﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny
{
    public class Jester
    {
        private readonly IJokeService JokeService;
        private readonly IJokeTeller JokeTeller;

        public Jester(IJokeService jokeService, IJokeTeller jokeTeller)
        {
            JokeService = jokeService;
            JokeTeller = jokeTeller;
        }

        public void TellJoke()
        {
            string joke = JokeService.GetJoke();
            while (joke.Contains("Chuck Norris"))
            {
                joke = JokeService.GetJoke();
            }
            JokeTeller.TellJoke(joke);
        }

    }
}
