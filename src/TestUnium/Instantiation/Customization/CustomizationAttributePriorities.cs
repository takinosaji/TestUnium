namespace TestUnium.Instantiation.Customization
{
    enum CustomizationAttributePriorities
    {
        StepRunner = 1,
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