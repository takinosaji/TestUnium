using System;
using System.Collections.Generic;
using System.Linq;

namespace TestUnium.Instantiation
{
    [Serializable]
    class IncorrectInheritanceException : ApplicationException
    {
        public IncorrectInheritanceException(IEnumerable<String> derivedTypeNames, IEnumerable<String> baseTypeNames) 
            : base($"{derivedTypeNames.Aggregate((tn1, tn2) => tn1 + ", " + tn2)} doesn't inherit or implement {baseTypeNames.Aggregate((in1, in2) => in1 + ", " + in2)} interface(s)!") { }
        public IncorrectInheritanceException(IEnumerable<String> derivedTypeNames, IEnumerable<String> baseTypeNames, Exception innerException) 
            : base($"{derivedTypeNames.Aggregate((tn1, tn2) => tn1 + ", " + tn2)} doesn't inherit or implement {baseTypeNames.Aggregate((in1, in2) => in1 + ", " + in2)} interface(s)!", innerException) { }
    }
}
