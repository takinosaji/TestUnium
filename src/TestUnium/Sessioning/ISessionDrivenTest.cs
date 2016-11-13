using System;
using System.Collections.Concurrent;
using Ninject.Parameters;

namespace TestUnium.Sessioning
{
    public interface ISessionDrivenTest
    {
        ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
        String GetCurrentSessionId();

        IParameter GetCurrentSessionIdConstructorArg();
    }

    public interface ISessionInvoker
    {
        ISession Session { get; }
    }
}
