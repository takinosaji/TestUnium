using System;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Sessioning
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.SessionContext)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseSessionContextAttribute : SessionAttribute
    {
        public UseSessionContextAttribute(Type sessionContextType) : base(typeof(SessionBase), sessionContextType) { }  

        public override void Customize(SessionDrivenTest context)
        {
            context.Kernel.Bind<ISession>().To<SessionBase>(); 
            context.Kernel.Bind<ISessionContext>().To(SessionContextType); 
        }
    }
}