using System;
using System.Collections.Generic;
using Ninject;
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
    public class ConfigureKernelAttribute : CustomizationAttribute, ICustomizer<IKernelDrivenTest>
    {
        private readonly Type _configurerType;
  
        public ConfigureKernelAttribute(Type configurerType)
        {  
            if (!typeof(IKernelConfigurer).IsAssignableFrom(configurerType))
                throw new IncorrectInheritanceException(new List<String> { configurerType.Name },
                    new List<String> { nameof(IKernelConfigurer) });
            _configurerType = configurerType;
        }
        public void Customize(IKernelDrivenTest context)
        {
            var configurer = (IKernelConfigurer) Activator.CreateInstance(_configurerType);
            context.Kernel = configurer.GetKernel();
        }
    }
}