using NUnit.Framework;
using PlaywrightSample.Framework;

namespace PlaywrightSample.Tests;

[TestFixture]
public class GoogleTest : BaseTest
{
    private GooglePage _googlePage;
    
    public override async Task BaseSetup() // overriding BaseTest's setup method with additional setup
    {
        await base.BaseSetup();
        _googlePage = new GooglePage(_page);
    }
    
    [Test]
    public async Task NavigateToGoogleAndVerifyTitle()
    {
        // navigate to Google
        await _googlePage.GoTo();

        // verify google page title
        var pageTitle = await _googlePage.GetPageTitle();
        Assert.That(pageTitle, Does.Contain("Google"), "Page title should contain 'Google'");
    }

    [Test]
    public async Task SearchForPlaywrightCSharpExample()
    {
        // navigate to google
        await _googlePage.GoTo();
        Assert.That(_googlePage.GetCurrentUrl(), Does.StartWith("https://www.google.com"), "Should be on Google homepage");

        // search
        await _googlePage.Search("Playwright C# example");

        // validate url and search term
        Assert.That(_googlePage.GetCurrentUrl(), Does.Contain("Playwright"), "URL should reflect the search query");

        // validate page title
        var searchResultsTitle = await _googlePage.GetPageTitle();
        Assert.That(searchResultsTitle, Does.Contain("Playwright C# example"),
            "Search results page title should contain the search query");
            
        // validate first search result
        var firstResult = await _googlePage.GetFirstSearchResultHeadingText();
        Assert.That(firstResult, Does.Contain("Playwright"), "First search result should contain 'Playwright'");
    }
}