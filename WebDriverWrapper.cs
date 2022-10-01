using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace Homework
{
    internal class WebDriverWrapper : IDisposable
    {
        public IWebDriver WebDriver { get; }
        public WebDriverWrapper()
        {
            WebDriver = new ChromeDriver();
            WebDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(3);
        }

        public void Dispose()
        {
            WebDriver.Quit();
        }
    }
}
