using System;
using System.Collections.Concurrent;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Stepping;

namespace TestUnium.Instantiation.Sessioning
{
    public interface ISessionDrivenTest : IStepDrivenTest
    {
        ConcurrentDictionary<Int32, ISession> Sessions { get; set; }
    }
}
