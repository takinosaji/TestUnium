using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Reflection;
using TestUnium.Internal.Validation;

namespace TestUnium.Stepping.Steps.Validation
{
    public class RequiredMembersStepValidator : IValidator
    {
        public IValidationResult Validate(IStep step)
        {
            var stepType = step.GetType();
            var fields = GetAllFields(stepType);
            var properties = GetAllProperties(stepType);
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

        private IEnumerable<PropertyInfo> GetAllProperties(Type t)
        {
            if (t == null)
                return Enumerable.Empty<PropertyInfo>();

            var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            return t.GetProperties(flags).Union(GetAllProperties(t.BaseType));
        }

        private IEnumerable<FieldInfo> GetAllFields(Type t)
        {
            if (t == null)
                return Enumerable.Empty<FieldInfo>();

            var flags = BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.DeclaredOnly;
            return t.GetFields(flags).Union(GetAllFields(t.BaseType));
        }
    }
}