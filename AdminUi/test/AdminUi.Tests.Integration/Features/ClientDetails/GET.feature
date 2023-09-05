@Integration
Feature: GET Client Details

User requests a Client's Details

Scenario: Requesting a Client by ClientId
	Given a Client c
	When a GET request is sent to the /Clients/{c.clientId} endpoint
	Then the response status code is 200 (OK)
	And the response contains Client c
