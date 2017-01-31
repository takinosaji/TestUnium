using System;
using System.Collections.Generic;
using Castle.MicroKernel.Registration;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;

namespace TestUnium.Sessioning
{
    [TheOnly]
    [CancelIfApplied(typeof(UseSessionWithContextAttribute))]
    [Priority((UInt16)CustomizationAttributePriorities.SessionContext)]
    [AttributeUsage(AttributeTargets.Class)]
    public class UseSessionContextAttribute : CustomizationAttribute, ICustomizer<ISessionDrivenTest>
    {
        protected readonly Type SessionContextType;

        public UseSessionContextAttribute(Type sessionContextType)
        {
            if (!typeof(ISessionContext).IsAssignableFrom(sessionContextType))
                throw new IncorrectInheritanceException(new List<String> { sessionContextType.Name },
                    new List<String> { nameof(ISessionContext) });
            SessionContextType = sessionContextType;
        }

        public void Customize(ISessionDrivenTest context)
        {
            context.Container.Register(Component.For<ISessionContext>().ImplementedBy(SessionContextType));
        }
    }
}