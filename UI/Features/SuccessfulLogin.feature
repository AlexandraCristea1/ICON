Feature: SuccessfulLogin

Testing successfullogin on https://evernote.com/.

@task2 @succesfulLogin
Scenario: Successful Login
	Given I am on https://evernote.com/
	And I accept all cookies
	And I click on Log In button
	When I enter a valid email address
	And I enter a valid password 
	Then I am logged in