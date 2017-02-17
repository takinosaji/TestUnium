using System;
using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using OpenQA.Selenium;
using TestUnium.Internal.Bootstrapping;
using TestUnium.Selenium.Settings;
using TestUnium.Selenium.WebDriving;
using TestUnium.Selenium.WebDriving.Screenshots;
using TestUnium.Stepping;
using TestUnium.Stepping.Steps;
using TestUnium.Stepping.Steps.Settings;

namespace TestUnium.Selenium.Stepping
{
    public abstract class WebDriverDrivenStepCore : SettingsDrivenStepCore, IScreenshotMaker
    {
        private readonly IMakeScreenshotStrategy _makeScreenshotStrategy;

        public IWebDriver Driver { get; set; }

        protected WebDriverDrivenStepCore()
        {
            _makeScreenshotStrategy = CoreContainer.Instance.Current.Resolve<IMakeScreenshotStrategy>();
        }

        public String MakeScreenshot([CallerMemberName] String callingMethodName = "")
        {
            //Contract.Requires(Settings is IWebSettings, $"Type which is representing Settings in your test doesnt implement interface IWebSettings.");
            if(!(Settings is IWebSettings))
                throw new ArgumentException($"Type which is representing Settings in your test doesnt implement interface IWebSettings.");

            return _makeScreenshotStrategy.MakeScreenshot(this as IStep, GetTestClassType(Executor), GetCallingMethodName(Executor, callingMethodName), Driver, Settings as IWebSettings);
        }

        private String GetCallingMethodName(IStepExecutor executor, String callingMethodName)
        {
            var exe = executor as IStep;
            if (exe == null) return callingMethodName;
            return GetCallingMethodName(exe.Executor, exe.CallingMethodName);
        }

        private Type GetTestClassType(IStepExecutor executor)
        {
            var exe = executor as IStep;
            if (exe == null) return executor.GetType();
            return GetTestClassType(executor);
        }
    }
}