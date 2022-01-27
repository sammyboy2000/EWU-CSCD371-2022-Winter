using System;

namespace CanHazFunny
{
    class Program
    { 
        static void Main(string[] args)
        {
            Jester jester = new Jester();
            string? response = "y";
            while (response == "y")
            {
                Console.WriteLine("Would you like to hear a joke? y/n");
                response = Console.ReadLine();
            }
        }
    }
}
