using System;
using TestUnium.Sessioning;
using TestUnium.Sessioning.Pipeline;

namespace SessionPlugins
{
    public class SimplePlugin : ISessionPlugin
    {
        public void OnStart(ISessionContext context)
        {
            throw new NotImplementedException();
        }

        public void OnEnd(ISessionContext context)
        {
            throw new NotImplementedException();
        }
    }
}
