using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Tests
    {
        //Test_001: happy path - fill all text field and click submit button - automated test shall pass
        //fill all text field and click submit button
        //result: redirect to welcome page
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_001()
        {
            using (var wd = new WebDriverWrapper())
            {
                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");

                var emailAdresss = wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                emailAdresss.SendKeys("name.surname@domain.com");

                var firstName = wd.WebDriver.FindElement(By.XPath("//div/input[@id='FirstName']"));
                firstName.SendKeys("Name");

                var lastName = wd.WebDriver.FindElement(By.XPath("//div/input[@id='LastName']"));
                lastName.SendKeys("LastName");

                var userPassword =
                    wd.WebDriver.FindElement(
                        By.XPath("//div[@class='input-control password'][1]/input[@id='UserPassword']"));
                userPassword.SendKeys("password");

                var confirmPassword =
                    wd.WebDriver.FindElement(
                        By.XPath("//div[@class='input-control password'][2]/input[@id='UserPassword']"));
                confirmPassword.SendKeys("password");

                var phone = wd.WebDriver.FindElement(By.XPath("//div/input[@id='Phone']"));
                phone.SendKeys("+380639992211");

                var organizationalname = wd.WebDriver.FindElement(By.XPath("//div/input[@id='OrgDisplayName']"));
                organizationalname.SendKeys("Portnox");

                var submitButton = wd.WebDriver.FindElement(By.XPath("//*[@id='signupbtn']"));
                submitButton.Click();


                //are you redirected?
                var result = false;
                try
                {
                    wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    Assert.Pass();
                    result = true;
                }

                if (result == false)
                {
                    Assert.Fail();

                }
            }
        }

        //test_002: fill all fields except Email address - automated test shall pass
        //fill all fields except Email address
        //click submit button
        //result: no redirect welcome page
        //visible error 'Field cannot be empty' next to item
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_002()
        {
            using (var wd = new WebDriverWrapper())
            {

                //string[] textfields = { "Email address", "First name", "Last name", "Password", "Confirm password", "Phone", "Organization name" };

                //foreach (string textfield in textfields)
                //    {
                ;



                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");

                var emailAdresss = wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                emailAdresss.SendKeys("");

                var firstName = wd.WebDriver.FindElement(By.XPath("//div/input[@id='FirstName']"));
                firstName.SendKeys("Name");

                var lastName = wd.WebDriver.FindElement(By.XPath("//div/input[@id='LastName']"));
                lastName.SendKeys("LastName");

                var userPassword =
                    wd.WebDriver.FindElement(
                        By.XPath("//div[@class='input-control password'][1]/input[@id='UserPassword']"));
                userPassword.SendKeys("password");

                var confirmPassword =
                    wd.WebDriver.FindElement(
                        By.XPath("//div[@class='input-control password'][2]/input[@id='UserPassword']"));
                confirmPassword.SendKeys("password");

                var phone = wd.WebDriver.FindElement(By.XPath("//div/input[@id='Phone']"));
                phone.SendKeys("+380639992211");

                var organizationalname = wd.WebDriver.FindElement(By.XPath("//div/input[@id='OrgDisplayName']"));
                organizationalname.SendKeys("Portnox");

                var submitButton = wd.WebDriver.FindElement(By.XPath("//*[@id='signupbtn']"));
                submitButton.Click();


                //are you redirected?
                var result = false;
                try
                {
                    wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                    //Is there error message
                    try
                    {
                        var error = wd.WebDriver.FindElement(By.XPath("//span[@for='UsernameOrEmail']"));
        
                        
                        if (error.Text.Equals("Field cannot be empty"))
                        {
                            result = true;
                        }
                    }
                    catch (Exception e)
                    {
                        result = false;
                    }
                   
                }
                catch (Exception e)
                {
               
                    result = false;
                }


                if (result == false)
                {
                    Assert.Fail();
                }
                else
                {
                    Assert.Pass();
                }
            }
        }
        //public static bool redirected()
        //{
        //    try
        //    {
        //        wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
        //        return false;
        //    }
        //    catch (Exception e)
        //    {
        //        return true; 
        //    }
        //}
    }
}