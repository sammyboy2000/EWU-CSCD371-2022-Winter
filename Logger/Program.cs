using System;

namespace Logger
{
    internal class Program
    {
        public static void Main()
        {
            BaseLogger logger;
            logger = LogFactory.CreateLogger("Program");
            if (logger == null)
            {
                Finished();
            }
            string option = "";
            while (option != "q")
            {
                Console.WriteLine();
                Console.WriteLine("Would you like to log something?");
                Console.WriteLine("1. Error");
                Console.WriteLine("2. Warning");
                Console.WriteLine("3. Information");
                Console.WriteLine("4. Debug");
                Console.WriteLine("press q to quit");
                option = Console.ReadLine();
                switch (option)
                {
                    case "1":
                        logger!.Error(GetMessage(), GetArgs());
                        break;
                    case "2":
                        logger!.Warning(GetMessage(), GetArgs());
                        break;
                    case "3":
                        logger!.Information(GetMessage(), GetArgs());
                        break;
                    case "4":
                        logger!.Debug(GetMessage(), GetArgs());
                        break;
                    default:
                        break;
                }
            }
            Finished();
        }

        private static object[] GetArgs()
        {
            Console.WriteLine("What're the (comma seperated) arguments?");
            return Console.ReadLine().Split(',');
        }

        public static string GetMessage()
        {
            Console.WriteLine("What's the message?");
            return Console.ReadLine();
        }

        public static void Finished()
        {
            Console.WriteLine("Goodbye");
            Environment.Exit(0);
        }
    }
}

