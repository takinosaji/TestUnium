using System;
using System.Collections.Generic;
using System.Linq;

namespace TestUnium.Instantiation.Customization
{
    [Serializable]
    class IncorrectCustomizationSourceTypeException : ApplicationException
    {
        public IncorrectCustomizationSourceTypeException(IEnumerable<String> typeNames) : this(typeNames, new List<String> { "ICustomizationSource" }) { }
        public IncorrectCustomizationSourceTypeException(IEnumerable<String> typeNames, IEnumerable<String> interfaceNames) : base($"{typeNames} doesn't implement {interfaceNames} interface!") { }
        public IncorrectCustomizationSourceTypeException(IEnumerable<String> typeNames, Exception innerException) : this(typeNames, new List<String> { "ICustomizationSource" }, innerException) { }
        public IncorrectCustomizationSourceTypeException(IEnumerable<String> typeNames, IEnumerable<String> interfaceNames, Exception innerException) : base($"{typeNames.Aggregate((tn1, tn2) => tn1 + ", " + tn2)} doesn't implement {interfaceNames.Aggregate((in1, in2) => in1 + ", " + in2)} interface(s)!", innerException) { }
    }
}
