using System;
using System.IO;

namespace Logger
{
    public class LogFactory
    {
        private String _pathname;
        public BaseLogger CreateLogger(string className)
        {
            FileLogger fl = new FileLogger();

            fl.ClassName = className;

            Console.WriteLine("Please enter a valid file path: ");
            String pathName = Console.ReadLine();

            ConfigureFileLogger(pathName);

            return fl;
        }
        
        public void ConfigureFileLogger(string pathname)
        {
            _pathname = pathname;
        }


    }
}
