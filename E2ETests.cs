using System;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]
    [Parallelizable(ParallelScope.Self)]
    public class Tests
    {
        /// <summary>
        /// Method to open url https://reverent-aryabhata-11cf33.netlify.app/
        /// </summary>
        /// <param name="wd"></param>
        private static void GoToRegPage(WebDriverWrapper wd)
        {
            wd.WebDriver.Navigate().GoToUrl("https://reverent-aryabhata-11cf33.netlify.app/");
            Console.WriteLine("You are on Registration page");
        }

        /// <summary>
        /// Method to enter Email address text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="email"></param>
        private static void EnterEmail(Atoms atoms, string email)
        {
            var emailAdresss = atoms.emailAdresss;
            emailAdresss.SendKeys(email);
            Console.WriteLine("You entered email " + email);
        }

        /// <summary>
        /// Method to enter First name text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="name"></param>
        private static void EnterName(Atoms atoms, string name)
        {
            var firstName = atoms.firstName;
            firstName.SendKeys(name);
            Console.WriteLine("You entered name " + name);
        }

        /// <summary>
        /// Method to enter Last name text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="name"></param>
        private static void EnterLastName(Atoms atoms, string name)
        {
            var lastName = atoms.lastName;
            lastName.SendKeys(name);
            Console.WriteLine("You entered last name " + name);
        }

        /// <summary>
        /// Method to enter Password text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="password"></param>
        private static void EnterPassword(Atoms atoms, string password)
        {
            var userPassword = atoms.userPassword;
            userPassword.SendKeys(password);
            Console.WriteLine("You entered password " + password);
        }

        /// <summary>
        /// Method to enter Confirm password text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="password"></param>
        private static void ConfirmPassword(Atoms atoms, string password)
        {
            var confirmPassword = atoms.confirmPassword;
            confirmPassword.SendKeys(password);
            Console.WriteLine("You confirmed password " + password);
        }

        /// <summary>
        /// Method to enter Phone text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="phoneNumber"></param>
        private static void EnterPhone(Atoms atoms, string phoneNumber)
        {
            var phone = atoms.phone;
            phone.SendKeys(phoneNumber);
            Console.WriteLine("You entered phone number " + phoneNumber);
        }

        /// <summary>
        /// Method to enter Organization name text field
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="organization"></param>
        private static void EnterOrganizationName(Atoms atoms, string organization)
        {
            var organizationalname = atoms.organizationalname;
            organizationalname.SendKeys(organization);
            Console.WriteLine("You entered company name " + organization);
        }

        /// <summary>
        /// Method to click the Submit button
        /// </summary>
        /// <param name="atoms"></param>
        private static void ClickSubmitButton(Atoms atoms)
        {
            var submitButton = atoms.submitButton;
            submitButton.Click();
            Console.WriteLine("You clicked Submit button");
        }

        /// <summary>
        /// Method to check if you were redirected to Welcome page
        /// </summary>
        /// <param name="wd">webdriver</param>
        /// <returns></returns>
        private bool Redirected(WebDriverWrapper wd)
        {
            try
            {
                // this element is available only on the first page, so if it is found,
                // you were not redirected and you are still on Registration page
                wd.WebDriver.FindElement(By.XPath("//div/input[@id='registerName']"));
                Console.WriteLine("You were NOT redirected to Welcome page");
                return false;
            }
            catch (Exception e)
            {
                Console.WriteLine("You are on Welcome page"); ;
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
                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterEmail(atoms, "name.surname@domain.com");

                EnterName(atoms, "Name");

                EnterLastName(atoms, "LastName");

                EnterPassword(atoms, "password");

                ConfirmPassword(atoms, "password");

                EnterPhone(atoms, "+380639992211");

                EnterOrganizationName(atoms, "Portnox");

                ClickSubmitButton(atoms);

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

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterEmail(atoms, "");

                EnterName(atoms, "Name");

                EnterLastName(atoms, "LastName");

                EnterPassword(atoms, "password");

                ConfirmPassword(atoms, "password");

                EnterPhone(atoms, "+380639992211");

                EnterOrganizationName(atoms, "Portnox");

                ClickSubmitButton(atoms);

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

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterEmail(atoms, "name.surname@domain.com");

                EnterName(atoms, "Name");

                EnterLastName(atoms, "LastName");

                EnterPassword(atoms, "password");

                ConfirmPassword(atoms, "differentpassword");

                EnterPhone(atoms, "+380639992211");

                EnterOrganizationName(atoms, "Portnox");

                ClickSubmitButton(atoms);

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

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "pass");

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

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "password1");

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

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "password_123");

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

        //test_005: phone format - automated test shall fail due to bug 002
        //fill all fields except Phone
        //fill Phone textfield with 'this is not phone number'
        //click submit button
        //result: no redirect to welcome page
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_005()
        {
            using (var wd = new WebDriverWrapper())
            {
                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterEmail(atoms, "name.surname@domain.com");

                EnterName(atoms, "Name");

                EnterLastName(atoms, "LastName");

                EnterPassword(atoms, "password");

                ConfirmPassword(atoms, "password");

                EnterPhone(atoms, "this is not phone number");

                EnterOrganizationName(atoms, "Portnox");

                ClickSubmitButton(atoms);

                //you should not be redirected
                if (Redirected(wd))
                {
                    Assert.Fail();
                }
            }
        }
    }
}