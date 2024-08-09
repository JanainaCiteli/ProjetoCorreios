using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace CorreiosAutomationProject.Drivers
{
  public static class WebDriverFactory
  {
    public static IWebDriver CreateWebDriver(string browser)
    {
      IWebDriver driver;
      if(browser.ToLower() == "chrome")
      {
        var chromeOptions = new ChromeOptions();
        chromeOptions.AddArgument("--start-maximized");
        driver = new ChromeDriver(chromeOptions);
      }
      else
      {
        throw new NotSupportedException($"O navegador {browser} não é suportado.");
      }

      return driver;
    }
  }
}