using System;

namespace TestUnium.Instantiation.Customization
{
    [Serializable]
    class IncorrectCustomizationTargetTypeException : ApplicationException
    {
        public IncorrectCustomizationTargetTypeException(String typeName) : base($"{typeName} is not inherited from {nameof(ICustomizationAttributeDrivenTest)}") { }
        public IncorrectCustomizationTargetTypeException(String typeName, Exception innerException) : base($"{typeName} is not inherited from {nameof(ICustomizationAttributeDrivenTest)}", innerException) { }
    }
}
