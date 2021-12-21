using BoDi;
using CsharpBaseSelenium.Drivers;
using TechTalk.SpecFlow;

namespace CsharpBaseSelenium.Hooks
{
    
    [Binding]
    public class SharedBrowserHooks
    {
        [BeforeTestRun]
        public static void BeforeTestRun(ObjectContainer testThreadContainer)
        {
            //Initialize a shared BrowserDriver in the global container
          //  testThreadContainer.BaseContainer.Resolve<BrowserDriver>();
        }
    }
}
