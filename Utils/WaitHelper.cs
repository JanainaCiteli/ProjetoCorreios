using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;

namespace CorreiosAutomationProject.Helpers
{
  public static class WaitHelper
  {
    public static void WaitForElementToBeVisible(IWebDriver driver, By by, TimeSpan timeout)
    {
      var wait = new WebDriverWait(driver, timeout);
      wait.Until(drv =>
      {
        var element = drv.FindElement(by);
        return element.Displayed ? element : null;
      });
    }

    public static void WaitForElementToBeClickable(IWebDriver driver, By by, TimeSpan timeout)
    {
      var wait = new WebDriverWait(driver, timeout);
      wait.Until(drv =>
      {
        var element = drv.FindElement(by);
        return (element.Displayed && element.Enabled) ? element : null;
      });
    }

    public static void WaitForTextToBePresentInElement(IWebDriver driver, By by, string text, TimeSpan timeout)
    {
      var wait = new WebDriverWait(driver, timeout);
      wait.Until(drv =>
      {
        var element = drv.FindElement(by);
        return element.Text.Contains(text) ? element : null;
      });
    }
  }
}