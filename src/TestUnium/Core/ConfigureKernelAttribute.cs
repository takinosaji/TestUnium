using System;
using System.Collections.Generic;
using TestUnium.Core.Configuration;
using TestUnium.Customization;
using TestUnium.Customization.Prioritizing;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;

namespace TestUnium.Core
{
    [TheOnly]
    [AttributeUsage(AttributeTargets.Class)]
    [Priority((UInt16)CustomizationAttributePriorities.Kernel)]
    public class ConfigureKernelAttribute : CustomizationAttribute, ICustomizer<IContainerDrivenTest>
    {
        private readonly Type _configurerType;
  
        public ConfigureKernelAttribute(Type configurerType)
        {  
            if (!typeof(IContainerConfigurer).IsAssignableFrom(configurerType))
                throw new IncorrectInheritanceException(new List<String> { configurerType.Name },
                    new List<String> { nameof(IContainerConfigurer) });
            _configurerType = configurerType;
        }
        public void Customize(IContainerDrivenTest context)
        {
            var configurer = (IContainerConfigurer) Activator.CreateInstance(_configurerType);
            context.Container = configurer.GetContainer();
        }
    }
}