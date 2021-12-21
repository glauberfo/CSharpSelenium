using CsharpBaseSelenium.Drivers;
using CsharpBaseSelenium.PageObjects;
using FluentAssertions;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace CalculatorSelenium.Specs.Steps
{
    [Binding]
    public sealed class HomeStepDefinitions
    {
        //Page Object for Calculator
        private readonly HomePageObject _homePage;
        IWebDriver driver;
        public HomeStepDefinitions(BrowserDriver browserDriver)
        {
            driver = browserDriver.Current;
            _homePage = new HomePageObject(driver);
            
        }

        [Given("que esteja na URL da ESPN")]
        public void NavegarAteAUrl()
        {
            
        }

        [When("salvo o titulo no arquivo")]
        public void WhenSalvoOTituloNoArquivo()
        {
            var title = _homePage.getTitle();
            BasePage.WriteTextFile(title);
            BasePage.GetScreenshot(driver);
        }

        [When("tiro um print da tela")]
        public void WhenTiroUPrintDaTela()
        {
            BasePage.GetScreenshot(driver);
        }

        [When("seleciono um esporte (.*)")]
        public void WhenSelecionoUmEsporte(string esporte)
        {
            _homePage.selecionarUmEsporte(esporte);
        }

        [Then("valido se estou na tela de (.*)")]
        public void ThenvalidoSeEstouNaTela(string esporte)
        {
            switch (esporte)
            {
                case "Futebol":
                    string[] futMenu = { "Notícias", "Times", "Campeonatos" };
                    _homePage.ValidarMenus(futMenu);
                    break;
                default:
                    Console.WriteLine("Não existe esta opção");
                    break;
            }
        }
    }
}
