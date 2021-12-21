using System;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace CsharpBaseSelenium.PageObjects
{

    public class HomePageObject : BasePage 
    {
      
        public HomePageObject(IWebDriver webDriver)
        {
            _webDriver = webDriver;
            wait = new WebDriverWait(_webDriver, TimeSpan.FromSeconds(DefaultWaitInSeconds));
        }
        // Encontrando elementos
        By close = By.CssSelector("a[class='sprite close']");
        By iframe = By.CssSelector("iframe[title='3rd party ad content']");
        public void GoToHomePage()
        {
            _webDriver.Navigate().GoToUrl(Url);
        }
        private IWebElement pageTitle => _webDriver.FindElement(By.XPath(""));

        public string getTitle()
        {
            return _webDriver.Title.ToString();
        }

        public void selecionarUmEsporte(string text)
        {

            switchToIframe(iframe);
            clicar(close);
            SwitchToDefautContent();
            Thread.Sleep(1000);
           
            By menu = By.XPath("//span[@class='link-text' and text()='" + text + "']");
            clicar(menu);
        }

        public void ValidarMenus(string [] menus)
        {
            foreach(string tx in menus)
            {
                Console.WriteLine(tx);
                By locator = By.XPath("//span[@class='link-text' and text()='" + tx + "']");
                IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
                Assert.IsTrue(element.Displayed);
            }
           
        }
    }
}
