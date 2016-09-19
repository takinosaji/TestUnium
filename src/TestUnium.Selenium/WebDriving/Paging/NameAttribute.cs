using System;

namespace TestUnium.Selenium.WebDriving.Paging
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