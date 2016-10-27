using System;

namespace TestUnium.Annotating
{
    public class NameAttribute : Attribute
    {
        public String Name { get; set; }
        public NameAttribute(String name)
        {
            Name = name;
        }
    }
}