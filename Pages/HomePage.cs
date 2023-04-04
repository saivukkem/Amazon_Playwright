using Microsoft.Playwright;

namespace Amazon_Playwright.Pages;

public class HomePage
{
    private IPage _page;

    public HomePage(IPage page) => _page = page;

    private ILocator AcceptCookiesBtn => _page.Locator("#sp-cc-accept");
    private ILocator SearchDrpdwn => _page.Locator("#searchDropdownBox");
    private ILocator SearchInput => _page.Locator("#twotabsearchtextbox");

    private ILocator SearchBtn => _page.Locator("#nav-search-submit-button");

    private ILocator FindBook => 
        _page.Locator("xpath=//h2/a/span[contains(text(),'The Bitcoin Standard: The Decentralized Alternative to Central Banking')]");
    
    public async Task ClickAcceptCookiesBtn() => await AcceptCookiesBtn.ClickAsync();
    
    public async Task SelectBooksOptn() =>
        await SearchDrpdwn.SelectOptionAsync(new SelectOptionValue { Label = "Books" });

    public async Task EnterTextInSearchInput(String text) => await SearchInput.FillAsync(text);

    public async Task ClickSearchBtn() => await SearchBtn.ClickAsync();

    public async Task<bool> IsBookExists()
    {
        await FindBook.WaitForAsync();
        return await FindBook.IsVisibleAsync();
    } 
}
