#region Includes

using Microsoft.ServiceBus.Messaging;

#endregion

namespace Daishi.Messaging.Brokers.Microsoft {
    public class BrokeredMessageReceivedEventArgs : MessageReceivedEventArgs<BrokeredMessage> {
        public BrokeredMessageReceivedEventArgs(BrokeredMessage message) : base(message) {}
    }
}