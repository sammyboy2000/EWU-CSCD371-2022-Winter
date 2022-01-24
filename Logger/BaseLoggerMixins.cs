using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(string message, params BaseLogger[] loggers)
        {
            if (loggers is null)
            {
                throw new ArgumentNullException(nameof(loggers));
            }
            foreach (var logger in loggers)
            {
                logger.Log(LogLevel.Error, message);
            }
        }
        public static void Warning(string message, params BaseLogger[] loggers)
        {
            if (loggers is null)
            {
                throw new ArgumentNullException(nameof(loggers));
            }
            foreach (var logger in loggers)
            {
                logger.Log(LogLevel.Warning, message);
            }
        }
        public static void Information(string message, params BaseLogger[] loggers)
        {
            if (loggers is null)
            {
                throw new ArgumentNullException(nameof(loggers));
            }
            foreach (var logger in loggers)
            {
                logger.Log(LogLevel.Information, message);
            }
        }
        public static void Debug(string message, params BaseLogger[] loggers)
        {
            if (loggers is null)
            {
                throw new ArgumentNullException(nameof(loggers));
            }
            foreach (var logger in loggers)
            {
                logger.Log(LogLevel.Debug, message);
            }
        }
    }
}
