using TestUnium.Instantiation.Sessioning;
using TestUnium.Instantiation.Settings;
using TestUnium.Instantiation.Stepping;
using TestUnium.Instantiation.Stepping.Steps;
using TestUnium.Selenium.Browsing;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;

namespace TestUnium.Selenium
{
    [SessionContext(typeof(ContextBase))]
    [StepRunner(typeof(StepRunnerBase))]
    [Settings(typeof(WebSettings))]
    [WebDriver]
    [DetectBrowser]
    [DefaultBrowser(Browser.Firefox)]
    public class SeleniumCore : WebDriverDrivenTest { }
}