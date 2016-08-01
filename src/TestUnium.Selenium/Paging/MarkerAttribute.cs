using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;

namespace TestUnium.Selenium.Paging
{
    public class MarkerAttribute : Attribute
    {
        public How How { get; set; }
        public String Pattern { get; set; }
        public By GetBy()
        {
            switch (How)
            {
                case How.Id:
                    return By.Id(Pattern);
                case How.Name:
                    return By.Name(Pattern);
                case How.TagName:
                    return By.TagName(Pattern);
                case How.ClassName:
                    return By.ClassName(Pattern);
                case How.CssSelector:
                    return By.CssSelector(Pattern);
                case How.LinkText:
                    return By.LinkText(Pattern);
                case How.PartialLinkText:
                    return By.PartialLinkText(Pattern);
                case How.XPath:
                    return By.XPath(Pattern);
                case How.Custom:
                    throw new NotImplementedException("Custom method of seeking PageMarker is not implemented yet.");
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}