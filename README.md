# HOMEWORK

Table of Contents

- [BUGS](#BUGS)
- [TESTS](#TESTS)
- [SETUP_ENVIRONMENT](#SETUP_ENVIRONMENT)
- [TESTS_EXECUTION](#TESTS_EXECUTION)

## BUGS

*bugs, where product behaves differently as the specification says, will be covered by automated tests*

### bug_001: Password is evaluated as weak anytime

Steps to reproduce:
* go to [https://reverent-aryabhata-11cf33.netlify.app/](https://reverent-aryabhata-11cf33.netlify.app/)
* go to Password textfield
* enter any password you want

actual result:
* there is message Password strength: weak anytime, no matter if the password met password policy

expected result:
* proper message is shown according to the password policy rules

### bug_002: Phone field does not have phone number format validation
Steps to reproduce:
* go to [https://reverent-aryabhata-11cf33.netlify.app/](https://reverent-aryabhata-11cf33.netlify.app/)
* go to Phone text field
* enter anything you want
* put some character to the other fields
* click the submit button

actual result:
* any entry is accepted 

expected result:
* only phone numbers in format: +380639992211 should be accepted


*bugs, which are not agains the specification, but should be reported and fixed*

### bug_003: Email address field does not have phone number format validation
Steps to reproduce:
* go to [https://reverent-aryabhata-11cf33.netlify.app/](https://reverent-aryabhata-11cf33.netlify.app/)
* go to Email address text field
* enter anything you want
* put some character to the other fields
* click the submit button

actual result:
* any entry is accepted 

expected result:
* only email adress in valid format should be accepted

### bug_004: backend for the page is missing (page is probably for testing purposes only)
Steps to reproduce:
* go to [https://reverent-aryabhata-11cf33.netlify.app/](https://reverent-aryabhata-11cf33.netlify.app/)
* go to Email address text field
* enter valid emali address
* put some character to the other fields
* click the submit button

actual result:
* no email arived
* there is just redirection to another page
* sing up buttons should work
* no other

expected result:
* email should be send
* singn up buttons are working
* futher validation on backend side (email duplicity validation, parword policy validation, other fielsd validation)

## TESTS

### test_001: happypath - fill all text field and click submit button *- automated test shall pass*

* You are on Registration page
* You entered email "name.surname@domain.com"
* You entered name "Name"
* You entered last name "LastName"
* You entered password "password"
* You confirmed password "password"
* You entered phone number "+380639992211"
* You entered company name "Portnox"
* You clicked Submit button

RESULT:
* You are on Welcome page

### test_002: email address empty *- automated test shall pass*

* You are on Registration page
* You entered email ""
* You entered name "Name"
* You entered last name "LastName"
* You entered password "password"
* You confirmed password "password"
* You entered phone number "+380639992211"
* You entered company name "Portnox"
* You clicked Submit button

RESULT:
* You were NOT redirected to Welcome page
* "Field cannot be empty" error appeared

### test_003: Passwords do not match *- automated test shall pass*

* You are on Registration page
* You entered email "name.surname@domain.com"
* You entered name "Name"
* You entered last name "LastName"
* You entered password "password"
* You confirmed password "differentpassword"
* You entered phone number "+380639992211"
* You entered company name "Portnox"
* You clicked Submit button

RESULT:
* You were NOT redirected to Welcome page
* "The password and confirmation password do not match" error appeared

### test_004a: Password weak *- automated test shall pass*

* You are on Registration page
* You entered password "pass"

RESULT:
* "Password strength: weak" message appeared

### test_004b: Password normal *- automated test shall fail due to bug 001*

* You are on Registration page
* You entered password "password1"

RESULT:
* "Password strength: normal" message appeared

### test_004c: Password strong *- automated test shall fail due to bug 001*

* You are on Registration page
* You entered password "password_123"

RESULT:
*  "Password strength: strong" message appeared

### test_005: invalid phone number *- automated test shall fail due to bug 002*

* You are on Registration page
* You entered email "name.surname@domain.com"
* You entered name "Name"
* You entered last name "LastName"
* You entered password "password"
* You confirmed password "password"
* You entered phone number "this is not phone number"
* You entered company name "Portnox"
* You clicked Submit button

RESULT:
* You were not regirected
* Error "Wrong phone numer format" appeared

## SETUP_ENVIRONMENT

* Install `Google Chrome` as solution supports chrome browser only
* Install `Java` for Allure report and set JAVA_HOME variable
* Install `scoop` and `allure` you can execute script `allure_install.ps1`

## TESTS_EXECUTION

* execute `run_test_xml_result.ps1` for pure ugly XML result

OR
* execute `run_test_allure_result.ps1` to see test result in Allure dashboard