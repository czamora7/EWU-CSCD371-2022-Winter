using System;

namespace Logger
{
    public class LogFactory
    {

        private string _ClassName;
        private string _PathName;

        public BaseLogger CreateLogger(string className)
        {
            FileLogger fl = new FileLogger();

            //write configure file logger method

            return fl;
        }

        //The LogFactory should be updated with a new method ConfigureFileLogger.
        //This should take in a file path and store it in a private member. It
        //should use this when instantiating a new FileLogger in its CreateLogger
        //method.
        
        public FileLogger ConfigureFileLogger(string pathname)
        {

            return null;
        }


    }
}
