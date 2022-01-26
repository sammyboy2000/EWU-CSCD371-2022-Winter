using System;

namespace Logger
{
    public class LogFactory
    {
        public static BaseLogger CreateLogger(string className)
        {
            Console.WriteLine("What kind of logger whould you like to make?");
            Console.WriteLine("1. File Logger");
            Console.WriteLine("2. Console Logger");
            Console.WriteLine("press q to quit");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("What file would you like to write to?");
                    return ConfigureFileLogger(className, Console.ReadLine());
                case "2":
                    return ConfigureConsoleLogger(className);
                default:
                    return null!;

            }
        }

        public static BaseLogger ConfigureConsoleLogger(string className)
        {
            return new ConsoleLogger(className);
        }

        public static BaseLogger ConfigureFileLogger(string className, string? filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("File path cannot be empty or null");
                return null!;
            }

            return new FileLogger(className, filePath!);
        }
    }
}
