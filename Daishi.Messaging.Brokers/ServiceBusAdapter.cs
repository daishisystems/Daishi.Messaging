#region Includes

using System;

#endregion

namespace Daishi.Messaging.Brokers {
    public abstract class ServiceBusAdapter<T> : IDisposable where T : class {
        public abstract void Initialise(string publisherName);

        public abstract void SendMessage(string publisherName, T message);

        public abstract T ReceiveNextMessage(string topicName, TimeSpan timeout, bool autoAcknowledge = false);

        public abstract void Dispose();
    }
}