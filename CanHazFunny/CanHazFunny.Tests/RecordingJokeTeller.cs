using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CanHazFunny.Tests
{
    public class RecordingJokeTeller : IJokeTeller
    {
        public string? LastJoke { get; internal set; }

        public void TellJoke(string joke)
        {
            LastJoke = joke;
        }
    }
}
