@Integration
Feature: PATCH Clients

User patches a Client

Scenario: Changing the client secret of an existing Client
	Given a Client c
	When a PATCH request is sent to the /Clients/{c.ClientId}/ChangeSecret endpoint with a new secret
	Then the response status code is 200 (OK)
	And the response contains Client c with the new client secret

Scenario: Changing the client secret of an existing Client with an empty secret
	Given a Client c
	When a PATCH request is sent to the /Clients/{c.ClientId}/ChangeSecret endpoint with an empty new secret
	Then the response status code is 200 (OK)
	And the response contains Client c with a newly generated client secret

Scenario: Changing the client secret of a non-existent Client
	When a PATCH request is sent to the /Clients/{clientId}/ChangeSecret endpoint
	Then the response status code is 404 (Not Found)
	And the response content includes an error with the error code "error.platform.recordNotFound"
