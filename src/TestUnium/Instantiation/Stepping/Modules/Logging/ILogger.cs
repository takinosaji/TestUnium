using System;

namespace TestUnium.Instantiation.Stepping.Modules.Logging
{
    public interface ILogger
    {
        void Info(String message);
        void Info(String template, params Object[] args);
        void Debug(String message);
        void Debug(String template, params Object[] args);
        void Exception(String message);
        void Exception(String template, params Object[] args);
        void Exception(Exception exception);
    }
}
