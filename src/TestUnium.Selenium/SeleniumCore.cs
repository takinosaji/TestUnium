using Ninject;
using TestUnium.Core;
using TestUnium.Core.Configuration;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Browsing;
using TestUnium.Sessioning;
using TestUnium.Settings;
using TestUnium.Stepping;
using TestUnium.Stepping.Pipeline;
using TestUnium.Stepping.Steps;

namespace TestUnium.Selenium
{
    [ConfigureKernel(typeof(StandardKernelConfigurer))]
    [UseSessionContext(typeof(ContextBase))]
    [UseStepRunner(typeof(StepRunnerBase))]
    [UseStepModulesRegistrationStrategy(typeof(BasicStepModuleRegistrationStrategy))]
    [UseAppSettings(typeof(WebSettings))]
    [WebDriver]
    [DetectBrowser]
    [DefaultBrowser(Browser.Firefox)]
    public class SeleniumCore : WebDriverDrivenTest { }
}