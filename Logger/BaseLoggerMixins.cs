using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            message = ParseMessage(message, args);
            logger.Log(LogLevel.Error, message);
        }
        public static void Warning(this BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            message = ParseMessage(message, args);
            logger.Log(LogLevel.Warning, message);
        }
        public static void Information(this BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            message = ParseMessage(message, args);
            logger.Log(LogLevel.Information, message);
        }
        public static void Debug(this BaseLogger logger, string message, params object[] args)
        {
            if (logger is null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
            message = ParseMessage(message, args);
            logger.Log(LogLevel.Debug, message);
        }
        private static string ParseMessage(string message, object[] args)
        {
            for (int x = 0; x < args.Length; x++)
            {
                message = message.Replace("{" + x + "}", args[x].ToString());
            }
            return message;
        }
    }
}

