using System;

namespace TestUnium.Instantiation.Prioritizing
{
    [Serializable]
    class InvalidPriorityException : ApplicationException
    {
        public InvalidPriorityException(UInt16 priorityValue) : base($"Priority value {priorityValue} is invalid!") { }

        public InvalidPriorityException(UInt16 priorityValue, Exception innerException) : base($"Priority value {priorityValue} is invalid!", innerException) { }
    }
}
