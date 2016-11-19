using System;
using System.Collections.Generic;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Sessioning
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.SessionWithContext)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseSessionWithContextAttribute : CustomizationAttribute, ICustomizer<SessionDrivenTest>
    {
        protected readonly Type SessionType;
        protected readonly Type SessionContextType;

        public UseSessionWithContextAttribute(Type sessionType, Type sessionContextType)
        {
            if (!typeof(ISession).IsAssignableFrom(sessionType) || !typeof(ISessionContext).IsAssignableFrom(sessionContextType))
                throw new IncorrectInheritanceException(new List<String> { sessionType.Name, sessionContextType.Name },
                    new List<String> { nameof(ISession), nameof(ISessionContext)});
            SessionType = sessionType;
            SessionContextType = sessionContextType;
        }  

        public virtual void Customize(SessionDrivenTest context)
        {
            context.Kernel.Bind<ISession>().To(SessionType); 
            context.Kernel.Bind<ISessionContext>().To(SessionContextType); 
        }
    }
}