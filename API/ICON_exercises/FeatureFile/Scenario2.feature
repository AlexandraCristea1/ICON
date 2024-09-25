Feature: Scenario2

Test a particular API method with the following URL https://reqres.in/api/users?page=2.

@scenario2
Scenario: Extract user data from page 2
	Given I have the API endpoint https://reqres.in/api/users?page=2
	When I send a GET request to the API endpoint
	Then the API request should return a successful response
	And the API request should return 6 users in total
	And the page number returned matches the one specified in the URL
	And the API request should return a user with specific information:
		| First Name | Last Name | Email                  | Avatar                                   |
		| Byron      | Fields    | byron.fields@reqres.in | https://reqres.in/img/faces/10-image.jpg |
	And I log specific information from page