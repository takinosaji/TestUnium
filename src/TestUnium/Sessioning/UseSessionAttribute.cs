using System;
using System.Collections.Generic;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Sessioning
{
    [TheOnly]
    [CancelIfApplied(typeof(UseSessionWithContextAttribute))]
    [Priority((UInt16)CustomizationAttributePriorities.Session)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseSessionAttribute : CustomizationAttribute, ICustomizer<ISessionDrivenTest>
    {
        protected readonly Type SessionType;

        public UseSessionAttribute(Type sessionType)
        {
            if (!typeof(ISession).IsAssignableFrom(sessionType))
                throw new IncorrectInheritanceException(new List<String> { sessionType.Name },
                    new List<String> { nameof(ISessionContext) });
            SessionType = sessionType;
        }

        public void Customize(ISessionDrivenTest context)
        {
            context.Kernel.Bind<ISession>().To(SessionType); 
        }
    }
}