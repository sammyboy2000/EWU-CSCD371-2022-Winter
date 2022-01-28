using System;

namespace CanHazFunny
{
    class Program
    {
#pragma warning disable IDE0060 // Remove unused parameter
        static void Main(string[] args)
#pragma warning restore IDE0060 // Remove unused parameter
        {
            Jester jester = new();
            string? response = "y";
            while (response == "y")
            {
                Console.WriteLine("Would you like to hear a joke? y/n");
                response = Console.ReadLine();
                if (response == "y")
                {
                    string joke = jester.FindJoke();
                    jester.PresentJoke(joke);
                }
            }
        }
    }
}
