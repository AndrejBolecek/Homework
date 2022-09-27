# Homework

//bugs, where product behaves differently as the specification says and which are coverd by automated tests

bug 001: Password is evaluated as weak anytime
===================================================
Steps to reproduce:
go to https://reverent-aryabhata-11cf33.netlify.app/
go to Password textfield
enter any password you want

actual result:
there is message Password strength: weak anytime, no matter if the password met password policy

expected result:
proper message is shown according to the password policy rules

bug 002: Phone field does not have phone number format validation
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

bug 003: Email address field does not have phone number format validation
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

bug 004: backend for the page is missing (page is probably for testing purposes only)
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