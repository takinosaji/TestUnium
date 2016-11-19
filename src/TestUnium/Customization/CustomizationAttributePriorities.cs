namespace TestUnium.Customization
{
    public enum CustomizationAttributePriorities
    {
        Kernel = 1,
        StepRunner = 1,
        StepModuleRegistrationStrategy = 2,
        Session = 1,
        SessionContext = 2,
        NoSettings = 1,
        Settings = 2,
        DefaultBrowser = 1,
        DetectBrowser = 2,
        ForbiddenBrowsers = 3,
        AllowedBrowsers = 4,
        DefaultWebDriver = 5
    }
}