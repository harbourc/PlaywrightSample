using NUnit.Framework;
using Microsoft.Playwright;

namespace PlaywrightSample.Tests
{
    [TestFixture]
    public abstract class BaseTest
    {
        protected IPlaywright _playwright;
        protected IBrowser _browser;
        protected IPage _page;

        [SetUp]
        public virtual async Task BaseSetup()
        {
            // start playwright
            _playwright = await Playwright.CreateAsync();
            
            // launch browser
            _browser = await _playwright.Chromium.LaunchAsync(new BrowserTypeLaunchOptions
            {
                Headless = false,
                SlowMo = 50
            });

            // open a new page
            _page = await _browser.NewPageAsync();
        }

        [TearDown]
        public virtual async Task BaseTeardown()
        {
            // close browser, terminate playwright
            await _browser.CloseAsync();
            _playwright.Dispose();
        }
    }
}