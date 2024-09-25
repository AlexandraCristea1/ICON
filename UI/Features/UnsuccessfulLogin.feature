Feature: UnsuccessfulLogin

Testing unsuccessful login on https://evernote.com/.

@task2 @unsuccesfulLogin
Scenario: Unsuccessful login
	Given I am on https://evernote.com/
	And I accept all cookies
	And I click on Log In button
	When I enter an invalid email address checking if there is an error message
	And I enter a password 
	Then an error message appears