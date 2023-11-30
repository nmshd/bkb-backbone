@Integration
Feature: PATCH Clients

User patches a Client

Scenario: Changing the client secret of an existing Client
	Given a Tier t
	And a Client c with Tier t
	When a PATCH request is sent to the /Clients/{c.ClientId}/ChangeSecret endpoint with a new secret
	Then the response status code is 200 (OK)
	And the response contains Client c with the new client secret

Scenario: Changing the client secret of an existing Client with an empty secret
	Given a Tier t
	And a Client c with Tier t
	When a PATCH request is sent to the /Clients/{c.ClientId}/ChangeSecret endpoint without passing a secret
	Then the response status code is 200 (OK)
	And the response contains Client c with a random secret generated by the backend

Scenario: Changing the client secret of a non-existent Client
	When a PATCH request is sent to the /Clients/{clientId}/ChangeSecret endpoint
	Then the response status code is 404 (Not Found)
	And the response content includes an error with the error code "error.platform.recordNotFound"

Scenario: Changing the default tier of an existing Client
	Given a Tier t1
	And a Tier t2
	And a Client c with Tier t1
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint with the defaultTier t2.Id
	Then the response status code is 200 (OK)
	And the response contains Client c
	And the Client in the Backend has the new defaultTier

Scenario: Changing the default tier of an existing Client with a non-existent tier id
	Given a Tier t
	And a Client c with Tier t
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint with a non-existent tier id
	Then the response status code is 400 (Bad request)
	And the response content includes an error with the error code "error.platform.validation.device.tierIdInvalidOrDoesNotExist"


Scenario: Changing the default tier of a non-existing Client
	When a PATCH request is sent to the /Clients/{c.clientId} endpoint with a non-existing clientId
	Then the response status code is 404 (Not Found)
	And the response content includes an error with the error code "error.platform.recordNotFound"

Scenario: Changing the default tier of an existing Client with the same tier id
	Given a Tier t
	And a Client c with Tier t
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint with the defaultTier t.Id
	Then the response status code is 400 (Bad request)
	And the response content includes an error with the error code "error.platform.validation.device.cannotUpdateClient"

Scenario: Changing the max identities of an existing Client
	Given a Tier t
	And a Client c with Tier t and MaxIdentities mi1
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint with the maxIdentities mi2
	Then the response status code is 200 (OK)
	And the response contains Client c
	And the Client in the Backend has the new maxIdentities

Scenario: Removing the max identities of an existing Client
	Given a Tier t
	And a Client c with Tier t and MaxIdentities mi
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint without passing a maxIdentities
	Then the response status code is 200 (OK)
	And the response contains Client c
	And the Client in the Backend has no max identities limit

Scenario: Changing the max identities of an existing Client with the same max identities
	Given a Tier t
	And a Client c with Tier t and MaxIdentities mi
	When a PATCH request is sent to the /Clients/{c.ClientId} endpoint with the maxIdentities mi
	Then the response status code is 400 (Bad request)
	And the response content includes an error with the error code "error.platform.validation.device.cannotUpdateClient"
