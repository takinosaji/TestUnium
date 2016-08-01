using System;

namespace TestUnium.Selenium.Paging
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