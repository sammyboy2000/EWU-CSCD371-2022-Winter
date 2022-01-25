using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string? FilePath { get; set; }
        //string? ClassName inherited from BaseLogger
        public FileLogger(string className, string filePath)
        {
            ClassName = className;
            FilePath = filePath;
        }

        public override void Log(LogLevel logLevel, string message)
        {
            //example: 10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message
            File.AppendAllText(FilePath, $"{DateTime.Now} {ClassName} {logLevel}: {message} \n");
        }
    }
}
