using xUnium.Pipeline;

namespace xUnium.Instantiation.Browsing
{
    public class BrowserBasedTest : StepDrivenTest
    {
        public Browser Browser { get; set; } = Browser.Firefox;
    }
}