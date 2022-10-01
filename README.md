# Homework

//bugs, where product behaves differently as the specification says, will be covered by automated tests

bug_001: Password is evaluated as weak anytime
===================================================
Steps to reproduce:
go to https://reverent-aryabhata-11cf33.netlify.app/
go to Password textfield
enter any password you want

actual result:
there is message Password strength: weak anytime, no matter if the password met password policy

expected result:
proper message is shown according to the password policy rules

bug_002: Phone field does not have phone number format validation
=================================================================
Steps to reproduce:
go to https://reverent-aryabhata-11cf33.netlify.app/
go to Phone text field
enter anything you want
put some character to the other fields
click the submit button

actual result:
any entry is accepted 

expected result:
only phone numbers in format: +380639992211 should be accepted

//bugs, which are not agains the specification, but should be reported and fixed

bug_003: Email address field does not have phone number format validation
=========================================================================
Steps to reproduce:
go to https://reverent-aryabhata-11cf33.netlify.app/
go to Email address text field
enter anything you want
put some character to the other fields
click the submit button

actual result:
any entry is accepted 

expected result:
only email adress in valid format should be accepted

bug_004: backend for the page is missing (page is probably for testing purposes only)
=====================================================================================
Steps to reproduce:
go to https://reverent-aryabhata-11cf33.netlify.app/
go to Email address text field
enter valid emali address
put some character to the other fields
click the submit button

actual result:
no email arived
there is just redirection to another page
sing up buttons should work
no other

expected result:
email should be send
singn up buttons are working
futher validation on backend side (email duplicity validation, parword policy validation, other fielsd validation)

======================================================================================================================

test_001: happypath - fill all text field and click submit button - automated test shall pass
fill all text field and click submit button
result: redirect to welcome page

test_002: fill all fields except Email address - automated test shall pass
fill all fields except Email address
click submit button
result: no redirect welcome page
visible error 'Field cannot be empty' next to item

<!-- repeat for each textfield
First name
Last name
Password
Confirm password
Phone
Organization name -->

test_003: passwords shall be same - automated test shall pass
fill all fields except Password and Confirm password
fill password in Password field and different passwod in Confirm password field
click submit button
result: no redirect welcome page
visible error 'Field cannot be empty' next to item

test_004a: weak password - automated test shall pass
fill password and confirm password fields with password 'pass'
result: visible message Password strength: weak

test_004b: normal password - automated test shall fail due to bug 001
fill password and confirm password fields with password 'password1'
result: visible message Password strength: normal

test_004c: strong password - automated test shall fail due to bug 001
fill password and confirm password fields with password 'password_123'
result: visible message Password strength: strong

test_005: phone format - automated test shall fail due to bug 002
fill all fields except Phone
fill Phone textfield with 'this is not phone number'
click submit button
result: no redirect to welcome page