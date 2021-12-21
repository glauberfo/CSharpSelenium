using CsharpBaseSelenium.Drivers;
using CsharpBaseSelenium.PageObjects;
using TechTalk.SpecFlow;

namespace CsharpBaseSelenium.Hooks
{
  
    [Binding]
    public class BaseHooks
    {
        [BeforeScenario("Automate")]
        public static void BeforeScenario(BrowserDriver browserDriver)
        {
            var home = new HomePageObject(browserDriver.Current);
            home.GoToHomePage();
        }
    }
}