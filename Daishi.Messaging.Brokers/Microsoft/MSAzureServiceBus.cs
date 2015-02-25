#region Includes

using System;
using Microsoft.ServiceBus.Messaging;

#endregion

namespace Daishi.Messaging.Brokers.Microsoft {
    public class MSAzureServiceBus : ServiceBus<MSAzureServiceBusAdapter, BrokeredMessage> {
        public MSAzureServiceBus(MSAzureServiceBusAdapter serviceBusAdapter, MessageValidator messageValidator) :
            base(serviceBusAdapter, messageValidator) {}

        public override event EventHandler<MessageReceivedEventArgs<BrokeredMessage>> MessageReceived;

        public override event EventHandler<MessageReceivedEventArgs<BrokeredMessage>> DuplicateMessageReceived;

        protected override void ReceiveNextMessage(string publisherName, TimeSpan timeout, bool autoAcknowledge) {
            var message = serviceBusAdapter.ReceiveNextMessage(publisherName, timeout, autoAcknowledge);
            if (message == null) return;

            var isValidMessage = messageValidator.ValidateMessageId(message.MessageId);

            if (isValidMessage) {
                messageValidator.AddMessageIdToCache(message.MessageId);
                OnMessageReceived(new BrokeredMessageReceivedEventArgs(message));
            }
            else {
                OnMessageReceived(new BrokeredMessageReceivedEventArgs(message));
            }
        }

        private void OnMessageReceived(MessageReceivedEventArgs<BrokeredMessage> e) {
            var handler = MessageReceived;
            if (handler != null) handler(this, e);
        }

        private void OnDuplicateMessageReceived(MessageReceivedEventArgs<BrokeredMessage> e) {
            var handler = DuplicateMessageReceived;
            if (handler != null) handler(this, e);
        }
    }
}