Feature: MSAzureServiceBusAdapterSendsAndReceivesMessages
	In order to send and receive messages
	As an MSAzureServiceBusAdapter
	I want to send and receive messages

Scenario: Send and receive messages
	Given I have initialised an MSAzureServiceBusAdapter	
	When I send a message
	Then I should be able to receive that message