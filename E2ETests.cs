using System;
using Allure.Commons;
using NUnit.Allure.Attributes;
using NUnit.Allure.Core;
using NUnit.Framework;
using OpenQA.Selenium;

namespace Homework
{
    [TestFixture]
    [AllureNUnit]
    [AllureSuite("Homework")]
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
            Console.WriteLine("You entered email \"{0}\"",email );
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
            Console.WriteLine("You entered name \"{0}\"", name);
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
            Console.WriteLine("You entered last name \"{0}\"", name);
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
            Console.WriteLine("You entered password \"{0}\"", password);
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
            Console.WriteLine("You confirmed password \"{0}\"", password);
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
            Console.WriteLine("You entered phone number \"{0}\"", phoneNumber);
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
            Console.WriteLine("You entered company name \"{0}\"", organization);
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

        /// <summary>
        /// Method that compare found error wit text in "errorText" parameter
        /// </summary>
        /// <param name="atoms"></param>
        /// <param name="errorAtom"></param>
        /// <param name="errorText"></param>
        private static void CheckError(Atoms atoms, IWebElement errorAtom, string errorText)
        {
            //check error
                if (errorText != null && !errorAtom.Text.Equals(errorText))
                {
                    Console.WriteLine("Error message should be \"{0}\", but it is \"{1}\"", errorText, errorAtom.Text);
                    Assert.Fail("Error message should be \"{0}\", but it is \"{1}\"", errorText, errorAtom.Text);
                }
                else
                {
                    Console.WriteLine("\"{0}\" error appeared", errorText);
                }
        }

        //Test_001: happy path - fill all text field and click submit button - automated test shall pass
        //fill all text field and click submit button
        //result: redirect to welcome page
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_001_happypath()
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

                Console.WriteLine("RESULT:");

                //are you redirected?
                var result = Redirected(wd);


                if (result == false)
                {
                    Assert.Fail("You were NOT redirected to Welcome page");

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
        public void Test_002_email_address_empty()
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

                Console.WriteLine("RESULT:");

                //you should not be redirected
                if (!Redirected(wd))
                {
                    try
                    {
                        CheckError(atoms, atoms.emailError, "Field cannot be empty");
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine(e);
                        Assert.Fail("\"{0}\" error was not found", atoms.emailError.Text);
                    }
                }
                else
                {
                    Assert.Fail("You were redirected to welcome page");
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
        public void Test_003_Passwords_do_not_match()
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

                Console.WriteLine("RESULT:");

                //you should not be redirected
                if (!Redirected(wd))
                {
                    //find error
                    try
                    {
                        CheckError(atoms, atoms.differentPasswordError, "The password and confirmation password do not match");
                    }
                    catch (NoSuchElementException e)
                    {
                        Console.WriteLine(e);
                        Assert.Fail("\"{0}\" error was not found", atoms.differentPasswordError.Text);
                    }
                }
                else
                {
                    Assert.Fail("You were redirected to welcome page");
                }


            }
        }

        //    test_004a: weak password - automated test shall pass
        //fill password and confirm password fields with password 'pass'
        //result: visible message Password strength: weak
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004a_Password_weak()
        {
            using (var wd = new WebDriverWrapper())
            {

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "pass");

                Console.WriteLine("RESULT:");

                //find error
                try
                {
                    CheckError(atoms, atoms.weakPasswordError, "Password strength: weak");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("\"Password strength: weak\" message was not found");
                    Assert.Fail("\"Password strength: weak\" messagewas not found");
                }
            }
        }

        //    test_004b: normal password - automated test shall fail due to bug 001
        //fill password and confirm password fields with password 'password1'
        //result: visible message Password strength: normal
        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004b_password_normal()
        {
            using (var wd = new WebDriverWrapper())
            {

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "password1");

                Console.WriteLine("RESULT:");

                //find error
                try
                {
                    CheckError(atoms, atoms.weakPasswordError, "Password strength: normal");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("\"Password strength: normal\" message not found");
                    Assert.Fail("\"Password strength: normal\" message was not found");
                }
            }
        }

        //    test_004c: strong password - automated test shall fail due to bug 001
        //fill password and confirm password fields with password 'password_123'
        //result: visible message Password strength: strong

        [Test]
        [Parallelizable(ParallelScope.Self)]
        public void Test_004c_password_strong()
        {
            using (var wd = new WebDriverWrapper())
            {

                GoToRegPage(wd);

                var atoms = new Atoms(wd.WebDriver);

                EnterPassword(atoms, "password_123");

                Console.WriteLine("RESULT:");

                //find error
                try
                {
                    CheckError(atoms, atoms.weakPasswordError, "Password strength: strong");
                }
                catch (NoSuchElementException)
                {
                    Console.WriteLine("\"Password strength: strong\" message not found");
                    Assert.Fail("\"Password strength: strongl\" message was not found");
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
        public void Test_005_invalid_phone_number()
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

                Console.WriteLine("RESULT:");

                //you should not be redirected
                if (Redirected(wd))
                {
                    Assert.Fail("You were redirected to Welcome page but you shouldn't be");
                }
            }
        }
    }
}