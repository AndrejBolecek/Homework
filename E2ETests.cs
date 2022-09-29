using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Tests
    {
        private bool Redirected(WebDriverWrapper wd)
        {
            try
            {
                // this element is available only on the firts page, so if it is found, you were not redirected and you are still there
                wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            return true;
        }

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
                var atoms = new Atoms(wd.WebDriver);
                var emailAdresss = atoms.emailAdresss;
                emailAdresss.SendKeys("name.surname@domain.com");

                var firstName = atoms.firstName;
                firstName.SendKeys("Name");

                var lastName = atoms.lastName;
                lastName.SendKeys("LastName");

                var userPassword = atoms.userPassword;
                userPassword.SendKeys("password");

                var confirmPassword = atoms.confirmPassword;
                confirmPassword.SendKeys("password");

                var phone = atoms.phone;
                phone.SendKeys("+380639992211");

                var organizationalname = atoms.organizationalname;
                organizationalname.SendKeys("Portnox");

                var submitButton = atoms.submitButton;
                submitButton.Click();

                //are you redirected?
                var result = Redirected(wd);


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

                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
                var atoms = new Atoms(wd.WebDriver);

                var emailAdresss = atoms.emailAdresss;
                emailAdresss.SendKeys("");

                var firstName = atoms.firstName;
                firstName.SendKeys("Name");

                var lastName = atoms.lastName;
                lastName.SendKeys("LastName");

                var userPassword = atoms.userPassword;
                userPassword.SendKeys("password");

                var confirmPassword = atoms.confirmPassword;
                confirmPassword.SendKeys("password");

                var phone = atoms.phone;
                phone.SendKeys("+380639992211");

                var organizationalname = atoms.organizationalname;
                organizationalname.SendKeys("Portnox");

                var submitButton = atoms.submitButton;
                submitButton.Click();


                //you should not be redirected
                if (!Redirected(wd))
                {
                    //find error
                    try
                    {
                        var emailError = atoms.emailError;

                        //check error
                        if (!emailError.Text.Equals("Field cannot be empty"))
                        {
                            Assert.Fail();
                        }
                    }
                    catch (Exception e)
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    Assert.Fail();
                }
            }
        }

        //test_003: passwords shall be same - automated test shall pass
        //fill all fields except Password and Confirm password
        //fill password in Password field and different passwod in Confirm password field
        //click submit button
        //result: no redirect welcome page
        //visible error 'Field cannot be empty' next to item
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_003()
        {
            using (var wd = new WebDriverWrapper())
            {

                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
                var atoms = new Atoms(wd.WebDriver);

                var emailAdresss = atoms.emailAdresss;
                emailAdresss.SendKeys("name.surname@domain.com");

                var firstName = atoms.firstName;
                firstName.SendKeys("Name");

                var lastName = atoms.lastName;
                lastName.SendKeys("LastName");

                var userPassword = atoms.userPassword;
                userPassword.SendKeys("password");

                var confirmPassword = atoms.confirmPassword;
                confirmPassword.SendKeys("differentpassword");

                var phone = atoms.phone;
                phone.SendKeys("+380639992211");

                var organizationalname = atoms.organizationalname;
                organizationalname.SendKeys("Portnox");

                var submitButton = atoms.submitButton;
                submitButton.Click();

                //you should not be redirected
                if (!Redirected(wd))
                {
                    //find error
                    try
                    {
                        var differentPasswordError = atoms.differentPasswordError;

                        //check error
                        if (!differentPasswordError.Text.Equals("The password and confirmation password do not match"))
                        {
                            Assert.Fail();
                        }
                    }
                    catch (Exception e)
                    {
                        Assert.Fail();
                    }
                }
                else
                {
                    Assert.Fail();
                }


            }
        }

        //    test_004a: weak password - automated test shall pass
        //fill password and confirm password fields with password 'pass'
        //result: visible message Password strength: weak
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004a()
        {
            using (var wd = new WebDriverWrapper())
            {


                    wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
                    var atoms = new Atoms(wd.WebDriver);

                    var userPassword = atoms.userPassword;
                    userPassword.SendKeys("pass");

                        //find error
                        try
                        {
                            var weakPasswordError = atoms.weakPasswordError;
                            //check error
                            if (!weakPasswordError.Text.Equals("Password strength: weak"))
                            {
                                Assert.Fail();
                            }
                        }
                        catch (Exception e)
                        {
                            Assert.Fail();
                        }
            }
        }

        //    test_004b: normal password - automated test shall fail due to bug 001
        //fill password and confirm password fields with password 'password1'
        //result: visible message Password strength: normal
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004b()
        {
            using (var wd = new WebDriverWrapper())
            {


                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
                var atoms = new Atoms(wd.WebDriver);

                var userPassword = atoms.userPassword;
                userPassword.SendKeys("password1");

                //find error
                try
                {
                    var weakPasswordError = atoms.weakPasswordError;
                    //check error
                    if (!weakPasswordError.Text.Equals("Password strength: normal"))
                    {
                        Assert.Fail();
                    }
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
        }

        //    test_004c: strong password - automated test shall fail due to bug 001
        //fill password and confirm password fields with password 'password_123'
        //result: visible message Password strength: strong

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004c()
        {
            using (var wd = new WebDriverWrapper())
            {


                wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
                var atoms = new Atoms(wd.WebDriver);

                var userPassword = atoms.userPassword;
                userPassword.SendKeys("password_123");

                //find error
                try
                {
                    var weakPasswordError = atoms.weakPasswordError;
                    //check error
                    if (!weakPasswordError.Text.Equals("Password strength: strong"))
                    {
                        Assert.Fail();
                    }
                }
                catch (Exception e)
                {
                    Assert.Fail();
                }
            }
        }

        //    test_005: phone format - automated test shall fail due to bug 002
        //fill all fields except Phone
        //    fill Phone textfill with 'this is not phone number'
        //click submit button
        //    result: no redirect to welcome page
    }
}