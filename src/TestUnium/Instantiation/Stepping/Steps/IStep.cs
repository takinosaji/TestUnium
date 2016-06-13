using System;

namespace TestUnium.Instantiation.Stepping.Steps
{
    public interface IStep
    {
        Boolean IsFakeStep();
        Exception GetLastException();
        Exception SetException(Exception excp);
    }
}