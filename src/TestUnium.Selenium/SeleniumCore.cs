using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Pipeline.Registration;
using TestUnium.Stepping.Pipeline.Registration.Customization;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium
{
    [UseSessionWithContext(typeof(SessionBase), typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategyForTest(typeof(InTestStepModuleRegistrationStrategy))]
    [UseAppSettings(typeof(WebSettings))]
    [WebDriver]
    [DetectBrowser]
    [DefaultBrowser(Browser.Firefox)]
    public class SeleniumCore : WebDriverDrivenTest { }
}