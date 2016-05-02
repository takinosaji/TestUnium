using System;
using System.Collections.Generic;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Settings;

namespace TestUnium.Sessioning
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.SessionContext)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionContextAttribute : SessionAttribute
    {
        public SessionContextAttribute(Type sessionContextType) : base(typeof(SessionBase), sessionContextType) { }  

        public override void Customize(SessionDrivenTest context)
        {
            context.Kernel.Bind<ISession>().To<SessionBase>(); 
            context.Kernel.Bind<ISessionContext>().To(SessionContextType); 
        }
    }
}