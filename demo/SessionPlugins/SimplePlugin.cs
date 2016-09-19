using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ninject;
using TestUnium.Sessioning;

namespace SessionContexts
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
