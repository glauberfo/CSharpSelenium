using System;
using System.IO;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace CsharpBaseSelenium.PageObjects
{
   
    public class BasePage
    {
        public const string Url = "https://www.espn.com.br";
        public IWebDriver _webDriver;
        public const int DefaultWaitInSeconds = 15;
        public static WebDriverWait wait;

        public static void GetScreenshot(IWebDriver driver)
        {
            var number = Faker.RandomNumber.Next(9999999, 99999999);
            Screenshot screenShot = ((ITakesScreenshot)driver).GetScreenshot();
            string filePathAndName = getDirectory() + "\\Files" + "\\screenShot"+number+".png";
            screenShot.SaveAsFile(filePathAndName, ScreenshotImageFormat.Png);
        }

        public static void WriteTextFile(string text)
        {
            try
            {
                StreamWriter sw = new StreamWriter(getDirectory()+"\\Files\\title.txt");
                sw.WriteLine(text);
                sw.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }
                finally
            {
                Console.WriteLine("Executing finally block.");
            }
        }

        public static string getDirectory()
        {
            var currentDiretory = Directory.GetCurrentDirectory();
            return currentDiretory.Split("\\bin")[0];
        }

        public  void clicar( By by)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementToBeClickable(by));
            element.Click();
        }

        public void escrever(By by, string text)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(by));
            element.SendKeys(text);
        }

        public void switchToIframe(By locator)
        {
            IWebElement element = wait.Until(ExpectedConditions.ElementIsVisible(locator));
            _webDriver.SwitchTo().Frame(element);
        }

        public void SwitchToDefautContent()
        {
            _webDriver.SwitchTo().DefaultContent();
        }
    }
}
