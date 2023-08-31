using Amazon_Playwright.Pages;
using Microsoft.Playwright;

namespace Amazon_Playwright;

public class Tests
{
    [Test]
    public async Task CheckBookDetails()
    {
        //Playwright
        var playwright = await Playwright.CreateAsync();
        
        //Set Browser
        await using var browser = await playwright.Chromium.LaunchAsync(
            new BrowserTypeLaunchOptions
            {
                Headless = true
            }
        );
        
        //Page
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.amazon.co.uk/");

        HomePage homePage = new HomePage(page);
        await homePage.ClickAcceptCookiesBtn();
        await homePage.SelectBooksOptn();
        await homePage.EnterTextInSearchInput("Bitcoin");
        await homePage.ClickSearchBtn();
        
        var isExist = await homePage.IsBookExists();
        Assert.That(isExist, Is.True);
    }
}
