# PlaywrightTests-MsTest

Based on https://playwright.dev/dotnet/docs/intro#first-test

https://playwright.dev/dotnet/docs/api/class-playwright#playwright-chromium

**You can clone this repo or you can follow the instructions below in your own project.**

    # Create new project.
    dotnet new mstest -n PlaywrightTests-MsTest
    cd PlaywrightTests-MsTest
    
Install dependencies, build project and download necessary browsers. This is only done once per project.

    # Add project dependency
    dotnet add package Microsoft.Playwright.MsTest
    # Build the project
    dotnet build
    # Install required browsers
    pwsh bin\Debug\netX\playwright.ps1 install

One caveat is to change the \netX\ value in the path for the command below to the value on your machine.

    pwsh bin\Debug\netX\playwright.ps1 install
    
could be

    pwsh bin\Debug\net6.0\playwright.ps1 install
    
Edit UnitTest1.cs file.

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
    
Run the test

        dotnet test
