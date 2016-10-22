using System;

namespace TestUnium.Specification
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property)]
    public class TestParameterAttribute : TestCaseAttribute
    {
        
    }
}