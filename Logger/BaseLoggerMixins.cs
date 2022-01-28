using System;

namespace Logger
{
    public static class BaseLoggerMixins
    {
        public static void Error(this BaseLogger logger, string message, params object[] list)
        {
            Console.WriteLine("Please enter the file path: ");
            string path = Console.ReadLine();
            CheckLoggerNull(logger);
            CheckIfListIsNull(list);

            string className = nameof(logger);
            logger.Log(className, LogLevel.Error, message, path);
        }

        public static void Warning(this BaseLogger logger, string message, params object[] list)
        {
            Console.WriteLine("Please enter the file path: ");
            string path = Console.ReadLine();
            CheckLoggerNull(logger);
            CheckIfListIsNull(list);

            string className = nameof(logger);
            logger.Log(className, LogLevel.Warning, message, path);
        }

        public static void Information(this BaseLogger logger, string message, params object[] list)
        {
            Console.WriteLine("Please enter the file path: ");
            string path = Console.ReadLine();
            CheckLoggerNull(logger);
            CheckIfListIsNull(list);

            string className = nameof(logger);
                logger.Log(className, LogLevel.Information, message, path);
        }

        public static void Debug(this BaseLogger logger, string message, params object[] list)
        {
            Console.WriteLine("Please enter the file path: ");
            string path = Console.ReadLine();
            CheckLoggerNull(logger);
            CheckIfListIsNull(list);

            string className = nameof(logger);
            logger.Log(className, LogLevel.Debug, message, path);
        }

        public static void CheckIfListIsNull(params object[] list) 
        {
            if (list is null)
            {
                throw new ArgumentNullException(nameof(list));
            }
        }

        public static void CheckLoggerNull(BaseLogger logger)
        {
            if (logger == null)
            {
                throw new ArgumentNullException(nameof(logger));
            }
        }
    }
}
