using System;
using System.Collections.Concurrent;
using TestUnium.Core;
using TestUnium.Customization;

namespace TestUnium.Sessioning
{
    public interface ISessionDrivenTest : IContainerDrivenTest
    {
        ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
        String GetCurrentSessionId();
    }

    public interface ISessionInvoker
    {
        ISession Session { get; }
    }
}
