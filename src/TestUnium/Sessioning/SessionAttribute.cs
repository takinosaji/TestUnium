using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using TestUnium.Common;
using TestUnium.Customization;
using TestUnium.Instantiation.Prioritizing;
using TestUnium.Sessioning;

namespace TestUnium.Settings
{
    [TheOnly]
    [Priority((UInt16)CustomizationAttributePriorities.Session)]
    [AttributeUsage(AttributeTargets.Class)]
    public class SessionAttribute : CustomizationBase, ICustomizationAttribute<SessionDrivenTest>
    {
        private readonly Type _sessionType;
        private readonly Type _sessionContextType;

        public SessionAttribute(Type sessionType, Type sessionContextType) : base(typeof(SessionDrivenTest))
        {
            if (!typeof(ISettingsSource).IsAssignableFrom(sessionType) || !typeof(ISessionContext).IsAssignableFrom(sessionType))
                throw new IncorrectCustomizationSourceTypeException(new List<String> { sessionType.Name, sessionContextType.Name },
                    new List<String> { nameof(ISession), nameof(ISessionContext)});
            _sessionType = sessionType;
            _sessionContextType = sessionContextType;
        }  

        public virtual void Customize(SessionDrivenTest context)
        {
            context.Kernel.Bind<ISessionContext>(); 
            context.Kernel.Bind<SessionDrivenTest>().ToConstant(context);
        }
    }
}