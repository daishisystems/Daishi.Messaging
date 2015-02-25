#region Includes

using System;
using Microsoft.ServiceBus;
using Microsoft.ServiceBus.Messaging;
using Microsoft.WindowsAzure;

#endregion

namespace Daishi.Messaging.Brokers.Microsoft {
    public class MSAzureServiceBusAdapter : ServiceBusAdapter<BrokeredMessage> {
        private const string subscriptionName = "DefaultSubscriber";
        private bool _isInitialised;

        private NamespaceManager _namespaceManager;
        private TopicDescription _topic;
        private TopicClient _topicClient;
        private SubscriptionClient _subscriptionClient;

        public override void Initialise(string topicName) {
            var connectionString = CloudConfigurationManager.GetSetting("Microsoft.ServiceBus.ConnectionString");
            _namespaceManager = NamespaceManager.CreateFromConnectionString(connectionString);

            _topic = !_namespaceManager.TopicExists(topicName) ?
                _namespaceManager.CreateTopic(topicName) : _namespaceManager.GetTopic(topicName);

            if (!_namespaceManager.SubscriptionExists(_topic.Path, subscriptionName))
                _namespaceManager.CreateSubscription(_topic.Path, subscriptionName);

            _isInitialised = true;
        }

        public override void SendMessage(string topicName, BrokeredMessage message) {
            if (!_isInitialised) Initialise(topicName);

            if (_topicClient == null)
                _topicClient = TopicClient.Create(topicName);
            _topicClient.Send(message);
        }

        public override BrokeredMessage ReceiveNextMessage(string topicName, TimeSpan timeout, bool autoAcknowledge = false) {
            if (!_isInitialised)
                Initialise(topicName);

            if (_subscriptionClient == null)
                _subscriptionClient = SubscriptionClient.Create(topicName, subscriptionName);

            BrokeredMessage message = null;

            try {
                message = _subscriptionClient.Receive(timeout);
                if (message == null)
                    return null;
                if (!autoAcknowledge) return message;
                message.Complete();
            }
            catch (Exception) {
                if (message != null) message.Abandon();
                throw;
            }
            return message;
        }

        public override void Dispose() {
            if (_topicClient != null && !_topicClient.IsClosed)
                _topicClient.Close();
            if (_subscriptionClient != null && !_subscriptionClient.IsClosed)
                _subscriptionClient.Close();
        }
    }
}