using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string _Path;

        public string Path
        {
            get; set;
        }
        public override void Log(LogLevel logLevel, string message)
        {
            //Create a FileLogger that derives from BaseLogger.
            //It should take in a path to a file to write the log message to.
            //When its Log method is called, it should append messages on
            //their own line in the file.
            //The output should include all of the following:
            //The current date / time 
            //The name of the class that created the logger
            //The log level
            //The message
            //The format may vary, but an example might look like this 
            //"10/7/2019 12:38:59 AM FileLoggerTests Warning: Test message"
            //
            //Console.WriteLine(DateTime.Now);

            FileStream fs = File.OpenWrite(_Path);
            fs.Write(message, 0, );
            Console.WriteLine(DateTime.Now + _className;
        }
    }
}
