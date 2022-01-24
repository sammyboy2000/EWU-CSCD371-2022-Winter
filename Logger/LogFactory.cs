using System;

namespace Logger
{
    public class LogFactory
    {
        public static BaseLogger CreateLogger(string className)
        {
            Console.WriteLine("What file do you want to write the log to?");
            return ConfigureFileLogger(className, Console.ReadLine());
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
