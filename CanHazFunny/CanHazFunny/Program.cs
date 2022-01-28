using System;

namespace CanHazFunny
{
    class Program
    {
        static void Main(string[] args)
        {
            //Filter jokes based on args[].
            //else default to filtering Chuck Norris jokes.
            if (args.Length != 0)
            {
                Console.WriteLine("Filtering out the following jokes: ");
                foreach (string arg in args) { Console.WriteLine(arg); }
            }
            else
            {
                Console.WriteLine("Filtering out \"Chuck Norris\" jokes.");
                args = new string[]{ "Chuck", "Norris" };
            }
            Jester jester = new();
            string? response;
            Console.WriteLine("Would you like to hear a joke? y/n");
            do
            {
                response = Console.ReadLine();
                switch (response)
                {
                    case "y":
                        string joke = jester.FindJoke(args);
                        jester.PresentJoke(joke);
                        Console.WriteLine("Would you like to hear another joke?");
                        break;
                    case "n":
                        break;
                    default:
                        Console.WriteLine("That's not a y or n.");
                        break;
                }

            } while (response != "n");
            Console.WriteLine("Have a pun-derful day!");
        }
}
}
