﻿@Integration
Feature: UPDATE Device

User updates a Device

	Scenario: Updating own Device with valid data
		Given an Identity i with a device d
		When i sends a PUT request to the /Devices/Self endpoint with the communication language 'de'
		Then the response status code is 204 (No Content)
		And the Backbone has persisted 'de' as the new communication language of d belonging to i.

	Scenario: Updating own Device with an invalid language code as communication language
		Given an Identity i with a device d
		When i sends a PUT request to the /Devices/Self endpoint with a non-existent language code
		Then the response status code is 400 (Bad Request)
		And the response content contains an error with the error code "error.platform.validation.invalidDeviceCommunicationLanguage"

	Scenario: Updating own Device password with valid data
		Given an Identity i with a device d
		When i sends a PUT request to the /Devices/Self/Password endpoint with the new password 'password'
		Then the response status code is 204 (No Content)
