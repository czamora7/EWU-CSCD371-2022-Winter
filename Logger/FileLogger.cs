using System;
using System.IO;

namespace Logger
{
    public class FileLogger : BaseLogger
    {
        public string _PathName;

        public String PathName
        {
            get => _PathName;

            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                _PathName = value;
            }
        }

        public override void Log(LogLevel logLevel, string message)
        {
            StreamWriter fs = new StreamWriter(PathName);

            //append the message to the file
            fs.WriteLine(message);
            
            //output the date, time, class name, log level, and message
            Console.WriteLine($"{DateTime.Now} {ClassName} {nameof(logLevel)}:  {message}");

        }
    }
}
