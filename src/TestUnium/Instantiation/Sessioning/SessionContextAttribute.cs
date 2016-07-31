using System;
using TestUnium.Domain;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;

namespace TestUnium.Instantiation.Sessioning
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