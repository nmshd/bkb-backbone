@Integration
Feature: DELETE Tier

User deletes a Tier

Scenario: Deleting a Tier
	Given a Tier t
	When a DELETE request is sent to the /Tiers/{t.Id} endpoint
	Then the response status code is 200 (OK)

Scenario: Deleting the Basic Tier fails
	Given the Basic Tier as t
	When a DELETE request is sent to the /Tiers/{t.Id} endpoint
	Then the response status code is 403 (Forbidden)
	
Scenario: Deleting a non-existing Tier fails
	Given a non-existing Tier t
	When a DELETE request is sent to the /Tiers/{t.Id} endpoint
	Then the response status code is 404 (Not Found)

@ignore("skipping_due_to_required_adminAPI_changes")
Scenario: Deleting a Tier that is in use fails
	Given a Tier t
	And the Tier T has one associated identity
	When a DELETE request is sent to the /Tiers/{t.Id} endpoint
	Then the response status code is 403 (Forbidden)
