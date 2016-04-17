using System;

namespace TestUnium.Instantiation.Prioritizing
{
    [Serializable]
    class AbsentPriorityException : ApplicationException
    {
        public AbsentPriorityException() : base("Priority hasn't been stated for initializing attribute.") { }

        public AbsentPriorityException(Exception innerException) : base("Priority hasn't been stated for initializing attribute.", innerException) { }
    }
}
