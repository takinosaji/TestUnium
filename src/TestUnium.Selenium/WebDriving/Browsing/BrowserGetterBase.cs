namespace TestUnium.Selenium.WebDriving.Browsing
{
    public class BrowserGetterBase : IBrowserGetter
    {
        private readonly IBrowserContext _context;
        public BrowserGetterBase(IBrowserContext context)
        {
            _context = context;
        }

        public Browser GetBrowser()
        {
            return _context.Browser;
        }
    }
}