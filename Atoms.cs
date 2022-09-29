using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace Homework
{
    internal class Atoms
    {
        public IWebDriver WebDriver { get; }

        public IWebElement emailAdresss => WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));

        public IWebElement firstName => WebDriver.FindElement(By.XPath("//div/input[@id='FirstName']"));

        public IWebElement lastName => WebDriver.FindElement(By.XPath("//div/input[@id='LastName']"));

        public IWebElement userPassword => WebDriver.FindElement(By.XPath("//div[@class='input-control password'][1]/input[@id='UserPassword']"));

        public IWebElement confirmPassword => WebDriver.FindElement(By.XPath("//div[@class='input-control password'][2]/input[@id='UserPassword']"));

        public IWebElement phone => WebDriver.FindElement(By.XPath("//div/input[@id='Phone']"));

        public IWebElement organizationalname => WebDriver.FindElement(By.XPath("//div/input[@id='OrgDisplayName']"));

        public IWebElement submitButton => WebDriver.FindElement(By.XPath("//*[@id='signupbtn']"));

        public IWebElement emailError => WebDriver.FindElement(By.XPath("//span[@for='UsernameOrEmail']"));

        public IWebElement differentPasswordError => WebDriver.FindElement(By.XPath("//span[@class='field-validation-error'][@data-bind='visible: showPasswordConfirmationError']"));

        public IWebElement weakPasswordError => WebDriver.FindElement(By.XPath("//span[@data-bind='visible: showPasswordWeaknessError']"));
        public Atoms(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }
    }
}
