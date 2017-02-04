using System;

namespace TestUnium.Sessioning.Managing
{
    public class SessionStoreContext
    {
        public SessionStoreContext ParentContext { get; set; }
        public ISession Session { get; set; }
    }
}