Feature: Scenario3

Verify that no users are returned from an invalid API like https://reqres.in/api/users?page=12.

@scenario3
Scenario: No users are returned
	Given I have the API endpoint https://reqres.in/api/users?page=12
    When I send a GET request to the API endpoint
    Then the API request should return no response
    And I log specific information from page