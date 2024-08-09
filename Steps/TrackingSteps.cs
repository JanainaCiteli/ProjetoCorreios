using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using TechTalk.SpecFlow;

namespace CorreiosAutomationProject.Steps
{
  [Binding]
  public class TrackingSteps
  {
    private IWebDriver _driver;

    [Given(@"que eu entre no site dos Correios")]
    public void GivenQueEuEntreNoSiteDosCorreios()
    {
      _driver = new ChromeDriver();
      _driver.Navigate().GoToUrl("https://www.correios.com.br/");
      _driver.Manage().Window.Maximize();
    }

    [When(@"eu procurar no rastreamento de código o número ""(.*)""")]
    public void WhenEuProcurarNoRastreamentoDeCodigoONumero(string trackingCode)
    {
      var searchBox = _driver.FindElement(By.Id("objetos"));
      searchBox.Clear();
      searchBox.SendKeys(trackingCode);
      searchBox.Submit();
    }

    [Then(@"eu confirmo que o código não está correto")]
    public void ThenEuConfirmoQueOCodigoNaoEstaCorreto()
    {
      var resultText = _driver.FindElement(By.CssSelector(".alert-error")).Text;
      Assert.IsTrue(resultText.Contains("não encontrado"), "O código foi encontrado, mas não deveria.");
    }

    [When(@"eu volto para a tela inicial")]
    public void WhenEuVoltoParaATelaInicial()
    {
      _driver.Navigate().Back();
    }

    [Then(@"eu fecho o browser")]
    public void ThenEuFechoOBrowser()
    {
      _driver.Quit();
    }

    [AfterScenario]
    public void TearDown()
    {
      _driver.Quit();
    }
  }
}