using System;

namespace TestUnium.Customization
{
    [Serializable]
    class IncorrectCustomizationSourceTypeException : ApplicationException
    {
        public IncorrectCustomizationSourceTypeException(String typeName) : this(typeName, "ICustomizationSource") { }
        public IncorrectCustomizationSourceTypeException(String typeName, String interfaceName) : base($"{typeName} doesn't implement {interfaceName} interface!") { }
        public IncorrectCustomizationSourceTypeException(String typeName, Exception innerException) : this(typeName, "ICustomizationSource", innerException) { }
        public IncorrectCustomizationSourceTypeException(String typeName, String interfaceName, Exception innerException) : base($"{typeName} doesn't implement {interfaceName} interface!") { }
    }
}
