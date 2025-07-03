using Microsoft.Playwright;

namespace PlaywrightSample.Framework;

public class GooglePage(IPage page)
{
    private readonly string SearchInputSelector = "[name='q']";
    private readonly string FirstSearchResultHeadingSelector = "h3"; // Selector for the first search result heading
    
    public async Task GoTo()
    {
        await page.GotoAsync("https://www.google.com");
    }

    public async Task Search(string searchText)
    {
        // type search term
        await page.FillAsync(SearchInputSelector, searchText);

        // submit
        await page.PressAsync(SearchInputSelector, "Enter");
        await page.WaitForLoadStateAsync(LoadState.DOMContentLoaded); // wait for navigation after search
    }

    public async Task<string> GetPageTitle()
    {
        return await page.TitleAsync();
    }

    public string GetCurrentUrl()
    {
        return page.Url;
    }

    public async Task<string> GetFirstSearchResultHeadingText()
    {
        return await page.Locator(FirstSearchResultHeadingSelector).First.TextContentAsync() ?? string.Empty;
    }
}