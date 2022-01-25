using System;

namespace Logger
{
    public class LogFactory
    {

        public string _classname;

        public string Classname
        {
            get => _classname;
            
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                _classname = value;
            }
        }

        public BaseLogger CreateLogger(string className)
        {
            
            return null;
        }
    }
}
