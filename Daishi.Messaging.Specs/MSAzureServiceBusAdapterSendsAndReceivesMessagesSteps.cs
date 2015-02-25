#region Includes

using System;
using System.Threading;
using Daishi.Messaging.Brokers.Microsoft;
using Microsoft.ServiceBus.Messaging;
using NUnit.Framework;
using TechTalk.SpecFlow;

#endregion

namespace Daishi.Messaging.Specs {
    [Binding]
    public class MSAzureServiceBusAdapterSendsAndReceivesMessagesSteps {
        private MSAzureServiceBusAdapter _msAzureServiceBusAdapter;
        private const string topicName = "TestTopic";
        private string _messageId;

        [Given(@"I have initialised an MSAzureServiceBusAdapter")]
        public void GivenIHaveInitialisedAnMSAzureServiceBusAdapter() {
            _msAzureServiceBusAdapter = new MSAzureServiceBusAdapter();
            _msAzureServiceBusAdapter.Initialise(topicName);
        }

        [When(@"I send a message")]
        public void WhenISendAMessage() {
            Thread.Sleep(10000);

            var message = new BrokeredMessage();
            _messageId = message.MessageId;

            _msAzureServiceBusAdapter.SendMessage(topicName, message);
        }

        [Then(@"I should be able to receive that message")]
        public void ThenIShouldBeAbleToReceiveThatMessage() {
            Thread.Sleep(10000);
            var message = _msAzureServiceBusAdapter.ReceiveNextMessage(topicName, new TimeSpan(0, 1, 0), true);
            StringAssert.AreEqualIgnoringCase(_messageId, message.MessageId);
        }
    }
}