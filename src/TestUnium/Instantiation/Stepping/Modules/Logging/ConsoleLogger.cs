using System;

namespace TestUnium.Instantiation.Stepping.Modules.Logging
{
    public class ConsoleLogger : ILogger
    {
        public void Info(String message)
        {
            Console.WriteLine("INFO: " + message);
        }

        public void Info(String template, params object[] args)
        {
            Console.WriteLine("INFO: " + template, args);
        }

        public void Debug(String message)
        {
            Console.WriteLine("DEBUG: " + message);
        }

        public void Debug(String template, params object[] args)
        {
            Console.WriteLine("DEBUG: " + template, args);
        }

        public void Exception(String message)
        {
            Console.WriteLine("EXCEPTION: " + message);
        }

        public void Exception(String template, params object[] args)
        {
            Console.WriteLine("EXCEPTION: " + template, args);
        }

        public void Exception(Exception exception)
        {
            Console.WriteLine("EXCEPTION: " + exception);
        }
    }
}
