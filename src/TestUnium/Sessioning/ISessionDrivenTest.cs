using System;
using System.Collections.Concurrent;
using Ninject.Parameters;
using TestUnium.Core;
using TestUnium.Customization;

namespace TestUnium.Sessioning
{
    public interface ISessionDrivenTest : IKernelDrivenTest
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
