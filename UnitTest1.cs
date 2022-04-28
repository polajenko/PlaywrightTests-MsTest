using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Microsoft.Playwright;

namespace PlaywrightTests_MsTest;

[TestClass]
public class UnitTest1
{
    [TestMethod]
    public async Task ShouldVisitGoogle()
    {
        using var playwright = await Playwright.CreateAsync();
        var chromium = playwright.Chromium;
        var browser = await chromium.LaunchAsync(new BrowserTypeLaunchOptions
        {
            Headless = false,
            SlowMo = 50,
        });
        var page = await browser.NewPageAsync();
        await page.GotoAsync("https://www.google.com");
        
        // Assert
        Assert.IsTrue(page.Url.Contains("google.com"));

        // other actions
        await browser.CloseAsync();
    }
}