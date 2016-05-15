using System;
using System.Collections.Generic;
using TestUnium.Common;
using TestUnium.Instantiation.Customization;
using TestUnium.Instantiation.Customization.Prioritizing;
using TestUnium.Instantiation.Settings;

namespace TestUnium.Instantiation.Sessioning
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Session)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionAttribute : CustomizationAttribute, ICustomizationAttribute<SessionDrivenTest>
    {
        protected readonly Type SessionType;
        protected readonly Type SessionContextType;

        public SessionAttribute(Type sessionType, Type sessionContextType) : base(typeof(SessionDrivenTest))
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