Feature: Scenario1

Test a particular API method with the following URL https://reqres.in/api/users?page=1.

@scenario1
Scenario: Extract user data from page 1
	Given I have the API endpoint https://reqres.in/api/users?page=1
    When I send a GET request to the API endpoint
    Then the API request should return a successful response
    And the API request should return 6 users in total
    And the page number returned matches the one specified in the URL
    And the API request should return a user with specific information:
    | First Name | Last Name | Email                  | Avatar                                  |
    | Janet      | Weaver    | janet.weaver@reqres.in | https://reqres.in/img/faces/2-image.jpg |
    And I log specific information from page