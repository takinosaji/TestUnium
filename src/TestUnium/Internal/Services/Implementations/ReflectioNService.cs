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
            return t?.GetProperties(flags).Union(GetAllProperties(t.BaseType, flags | BindingFlags.DeclaredOnly)) ?? 
                Enumerable.Empty<PropertyInfo>();
        }

        public IEnumerable<FieldInfo> GetAllFields(Type t, BindingFlags flags)
        {
            return t?.GetFields(flags).Union(GetAllFields(t.BaseType, flags | BindingFlags.DeclaredOnly)) ?? 
                Enumerable.Empty<FieldInfo>();
        }

        public Object InvokeMethod(Object obj, String methodName, params Object[] args)
        {
            var type = obj.GetType();
            var method = type.GetMethod(methodName);
            if (method == null) throw new NullReferenceException($"Couldn't find {methodName} method in {type.FullName}");
            return  method.Invoke(obj, args);
        }
    }
}