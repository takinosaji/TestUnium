using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace TestUnium.Internal.Services.Implementations
{
    public class ReflectionService : IReflectionService
    {
        public IEnumerable<PropertyInfo> GetAllProperties(Type t, BindingFlags flags)
        {
            return t?.GetProperties(flags).Union(GetAllProperties(t.BaseType, flags)) ?? 
                Enumerable.Empty<PropertyInfo>();
        }

        public IEnumerable<FieldInfo> GetAllFields(Type t, BindingFlags flags)
        {
            return t?.GetFields(flags).Union(GetAllFields(t.BaseType, flags)) ?? 
                Enumerable.Empty<FieldInfo>();
        }
    }
}