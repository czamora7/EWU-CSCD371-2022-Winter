
using System;

namespace Logger
{
    public class LogFactory
    {
        readonly LogFactory log = new();
        public string status = "success";
        public object? ClassName { get; set;}
        public string? CreateLogger(string className, LogLevel LogLevel, string message,FileLogger fileLogger)
        {
            Console.WriteLine("Enter File Path you want to write to: ");
            string path = Console.ReadLine();
            fileLogger.Log(className, LogLevel, message, path);
            string x = "success";
            try
            {
                log.ConfigureFileLogger(path);
            }
            catch (Exception) { return null; }

                
            return x;   
        }
        public void ConfigureFileLogger(string path){
                 string privatePath = path;
               }
        
    }

        
    }

