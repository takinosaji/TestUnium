using System;
using System.Collections.Generic;
using System.Reflection;

namespace TestUnium.Internal.Services
{
    public interface IReflectionService
    {
        IEnumerable<PropertyInfo> GetAllProperties(Type t, BindingFlags flags);
        IEnumerable<FieldInfo> GetAllFields(Type t, BindingFlags flags);
    }
}