using System;

namespace Logger
{
    public class LogFactory
    {
        public static BaseLogger CreateLogger(string className)
        {
            BaseLogger logger;
            Console.WriteLine("What kind of logger whould you like to make?");
            Console.WriteLine("1. File Logger");
            Console.WriteLine("2. Console Logger (not yet implemented)");
            Console.WriteLine("press q to quit");
            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("What file would you like to write to?");
                    return logger = ConfigureFileLogger(className, Console.ReadLine());
                case "2":
                    return null!;
                default:
                    return null!;

            }
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
