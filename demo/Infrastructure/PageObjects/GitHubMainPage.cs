using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using TestUnium.Annotating;
using TestUnium.Selenium.Extensions;
using TestUnium.Selenium.WebDriving.Paging;

namespace PageObjects
{
    [Lazy]
    [Name("GitHub main")]    
    [Marker(How = How.XPath, Pattern = "//*[text() = 'Sign up for GitHub']")]
    public class GitHubMainPage : PageObject
    {
        [FindsBy(How = How.XPath, Using = "//*[text() = 'Sign up for GitHub']")]
        public IWebElement SignUpBtn { get; set; }

        public IWebElement StickySignUpBtn()
        {
            return Driver.FindStickyElement(By.XPath("//*[text() = 'Sign up for GitHub']"));
        }
    }
}
