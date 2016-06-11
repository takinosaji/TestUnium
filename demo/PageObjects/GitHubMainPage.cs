using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using TestUnium.Extensions;
using TestUnium.Paging;

namespace PageObjects
{
    //[Lazy]
    [Name("GitHub main")]    
    [Marker(How = How.XPath, Pattern = "//*[text() = 'Sign up for GitHub']")]
    public class GitHubMainPage : PageObject
    {
        [FindsBy(How = How.XPath, Using = "//*[text() = 'Sign up for GitHub']")]
        public IWebElement SignUpBtn { get; set; }

        public IWebElement StikySignUpBtn()
        {
            return Driver.FindStickyElement(By.XPath("//*[text() = 'Sign up for GitHub']"));
        }
    }
}
