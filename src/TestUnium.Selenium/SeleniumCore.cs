using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Steps;

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