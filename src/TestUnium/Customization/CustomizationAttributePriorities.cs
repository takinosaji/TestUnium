namespace TestUnium.Customization
{
    public enum CustomizationAttributePriorities
    {
        Container = 1,
        StepRunner = 1,
        StepModuleRegistrationStrategy = 2,
        SessionWithContext = 1,
        Session = 2,
        SessionContext = 3,
        NoSettings = 1,
        Settings = 2,
        DefaultBrowser = 1,
        DetectBrowser = 2,
        ForbiddenBrowsers = 3,
        AllowedBrowsers = 4,
        DefaultWebDriver = 5
    }
}