using System;
using TestUnium.Customization;

namespace TestUnium.Instantiation.Prioritizing
{
    public class PriorityAttribute : Attribute
    {
        public UInt16 Value { get; set; }
        public PriorityAttribute(UInt16 value)
        {
            if (value < 1)
            {
                throw new InvalidPriorityException(value);
            }
            Value = value;
        }
    }
}