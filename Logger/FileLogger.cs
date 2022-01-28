using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Logger
{
    public class FileLogger : BaseLogger{
        private DateTime dateTime;


        public override void Log(string className, LogLevel logLevel, string message, string path)
        {
            Console.WriteLine("Please enter the file path: ");
            path = Console.ReadLine();

            dateTime = DateTime.Now;
            Console.WriteLine(dateTime+ " "+ className+ " "+ logLevel+ " "+ message);
            string info = (dateTime + " " + className + " " + logLevel + " " + message);

            using StreamWriter sw = File.AppendText(path);
            sw.WriteLine(info);
        }
    }
}




