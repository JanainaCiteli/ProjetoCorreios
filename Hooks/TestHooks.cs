using CorreiosAutomationProject.Drivers;
using OpenQA.Selenium;
using TechTalk.SpecFlow;

namespace CorreiosAutomationProject.Hooks
{
  [Binding]
  public class TestHooks
  {
    private readonly ScenarioContext _scenarioContext;
    private IWebDriver _driver;

    public TestHooks(ScenarioContext scenarioContext)
    {
      _scenarioContext = scenarioContext;
    }

    [BeforeScenario]
    public void InitializeWebDriver()
    {
      _driver = WebDriverFactory.CreateWebDriver("chrome");
      _scenarioContext.Set(_driver, "WebDriver");
    }

    [AfterScenario]
    public void TearDownWebDriver()
    {
      // Fecha o WebDriver ao final do cenário
      if (_driver != null)
      {
        _driver.Quit();
        _driver.Dispose();
      }
    }
  }
}