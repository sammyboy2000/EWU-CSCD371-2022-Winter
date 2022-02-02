using System;

namespace CanHazFunny
{
    public interface IOutput
    {
        public static void PresentJoke(string joke) => Console.WriteLine(joke);
    }
}
