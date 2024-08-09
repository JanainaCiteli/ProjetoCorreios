using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace TesteSimples
{
  class Program
  {
    static void Main(string[] args)
    {
      IWebDriver driver = new ChromeDriver();
      driver.Navigate().GoToUrl("https://www.correios.com.br/");
      Console.WriteLine("Título da página: " + driver.Title);
      driver.Quit();
    }
  }
}

