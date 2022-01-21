using System;

namespace Logger
{
    public class LogFactory
    {
        public BaseLogger CreateLogger(string className)
        {
            //Unfinished
            return ConfigureFileLogger(className, Console.ReadLine());
        }

        public BaseLogger ConfigureFileLogger(string className, string filePath)
        {
            if (String.IsNullOrEmpty(filePath))
            {
                Console.WriteLine("File path cannot be empty or null");
                return null!;
            }

            return new FileLogger(className, filePath);
        }
    }
}
