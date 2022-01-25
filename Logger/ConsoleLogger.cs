using System;
using System.Collections.Generic;
using System.Text;

namespace Logger
{
    internal class ConsoleLogger : BaseLogger
    {
        public ConsoleLogger(string className)
        {
            ClassName = className;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            Console.WriteLine($"{DateTime.Now} {ClassName} {logLevel}: {message}");
        }
    }
}
