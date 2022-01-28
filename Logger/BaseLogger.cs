using static Logger.BaseLoggerMixins;
namespace Logger
{
    public abstract class BaseLogger
    {
        public abstract void Log(string className, LogLevel logLevel, string message, string path); 
    }
 
    public class Baselogger {
        public void Log(BaseLogger logger, string message, LogLevel logLevel) 
        {
            logger.Error(message, "");
            logger.Warning(message, "");
            logger.Information(message, logLevel);
            logger.Debug(message, logLevel);
        }
    }
}
