using System;

namespace TestUnium.Instantiation.Customization.Prioritizing
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