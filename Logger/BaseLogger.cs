using System;

namespace Logger
{
    public abstract class BaseLogger
    {
        private string _ClassName;

        public string ClassName
        {
            get => _ClassName;

            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value));
                _ClassName = value;
            }
        }
        public abstract void Log(LogLevel logLevel, string message);
    }
}
