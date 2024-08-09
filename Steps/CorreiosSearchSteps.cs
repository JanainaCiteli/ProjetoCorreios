using System;
using OpenQA.Selenium;
using TechTalk.SpecFlow;
using CorreiosAutomationProject.Helpers;

namespace CorreiosAutomationProject.Steps
{
  [Binding]
  public class CorreiosSearchSteps
  {
    private readonly IWebDriver _driver;

    public CorreiosSearchSteps(ScenarioContext scenarioContext)
    {
      _driver = scenarioContext.Get<IWebDriver>("WebDriver");
    }

    [Given(@"que eu entre no site dos Correios")]
    public void GivenQueEuEntreNoSiteDosCorreios()
    {
      _driver.Navigate().GoToUrl("https://www.correios.com.br/");
    }

    [When(@"eu procuro pelo CEP (.*)")]
    public void WhenEuProcuroPeloCEP(string cep)
    {
      var cepInput = By.Id("cep");
      WaitHelper.WaitForElementToBeVisible(_driver, cepInput, TimeSpan.FromSeconds(10));
      var inputElement = _driver.FindElement(cepInput);
      inputElement.Clear();
      inputElement.SendKeys(cep);

      PerformSearch();
    }

    [Then(@"devo ver a mensagem de erro indicando que o CEP não existe")]
    public void ThenDevoVerAMensagemDeErroIndicandoQueOCEPNaoExiste()
    {
      var errorMessage = By.CssSelector(".mensagem-resultado");
      WaitHelper.WaitForTextToBePresentInElement(_driver, errorMessage, "não encontrado", TimeSpan.FromSeconds(10));
    }

    [When(@"eu procuro pelo CEP (.*) e confirmo o endereço")]
    public void WhenEuProcuroPeloCEPConfirmoOEndereco(string cep)
    {
      WhenEuProcuroPeloCEP(cep);
      var resultText = By.CssSelector(".resultado");
      WaitHelper.WaitForTextToBePresentInElement(_driver, resultText, "Rua Quinze de Novembro, São Paulo/SP", TimeSpan.FromSeconds(10));
    }

    [When(@"eu procuro pelo código de rastreamento '(.*)'")]
    public void WhenEuProcuroPeloCodigoDeRastreamento(string codigo)
    {
      var trackingInput = By.Id("rastreamento");
      WaitHelper.WaitForElementToBeVisible(_driver, trackingInput, TimeSpan.FromSeconds(10));
      var inputElement = _driver.FindElement(trackingInput);
      inputElement.Clear();
      inputElement.SendKeys(codigo);

      PerformSearch();
    }

    [Then(@"devo ver uma mensagem indicando que o código não está correto")]
    public void ThenDevoVerUmaMensagemIndicandoQueOCodigoNaoEstaCorreto()
    {
      var errorMessage = By.CssSelector(".mensagem-resultado");
      WaitHelper.WaitForTextToBePresentInElement(_driver, errorMessage, "não encontrado", TimeSpan.FromSeconds(10));
    }

    [Then(@"eu volto para a tela inicial")]
    public void ThenEuVoltoParaATelaInicial()
    {
      var homeButton = By.XPath("//a[@class='logo']");
      WaitHelper.WaitForElementToBeClickable(_driver, homeButton, TimeSpan.FromSeconds(10));
      _driver.FindElement(homeButton).Click();
    }

    private void PerformSearch()
    {
      var searchButton = By.XPath("//button[@type='submit']");
      WaitHelper.WaitForElementToBeClickable(_driver, searchButton, TimeSpan.FromSeconds(10));
      _driver.FindElement(searchButton).Click();
    }
  }
}
