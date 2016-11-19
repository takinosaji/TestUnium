using System;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using Ninject;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Internal.Services;
using TestUnium.Stepping.Steps;

namespace TestUnium.Internal.Validation.Step
{
    public class RequiredMembersStepValidator : IStepValidator
    {
        private readonly IReflectionService _reflectionService;

        public RequiredMembersStepValidator()
        {
            _reflectionService = Container.Instance.Current.Get<IReflectionService>();
        }

        public IValidationResult Validate(IStep step)
        {
            var stepType = step.GetType();
            const BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            var fields = _reflectionService.GetAllFields(stepType, flags);
            var properties = _reflectionService.GetAllProperties(stepType, flags);
            foreach (var fieldInfo in fields.Where(f => f.GetCustomAttribute<RequiredAttribute>() != null))
            {
                var value = fieldInfo.GetValue(step);
                if ((!fieldInfo.FieldType.IsValueType && value == null) ||
                    (fieldInfo.FieldType.IsValueType &&
                     value == Activator.CreateInstance(fieldInfo.FieldType)))
                {
                    return new StepValidationResult
                    {
                        Message =
                            $"Step {stepType.Name} has unconfigured field: {fieldInfo.Name} and can not being executed.",
                        IsValid = false
                    };
                }
            }
            foreach (var propertyInfo in properties.Where(f => f.GetCustomAttribute<RequiredAttribute>() != null))
            {
                var value = propertyInfo.GetValue(step);
                if ((!propertyInfo.PropertyType.IsValueType && value == null) ||
                    (propertyInfo.PropertyType.IsValueType &&
                     value == Activator.CreateInstance(propertyInfo.PropertyType)))
                {
                    return new StepValidationResult
                    {
                        Message =
                            $"Step {stepType.Name} has unconfigured property: {propertyInfo.Name} and can not being executed.",
                        IsValid = false
                    };
                }
            }

            return new StepValidationResult(true);
        }
    }
}