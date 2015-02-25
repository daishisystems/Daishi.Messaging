#region Includes

using System;
using System.Threading;

#endregion

namespace Daishi.Messaging.Brokers {
    public abstract class ServiceBus<TServiceBusAdapter, TU> : IDisposable where TServiceBusAdapter : ServiceBusAdapter<TU> where TU : class {
        private volatile bool _stopListening;
        protected readonly TServiceBusAdapter serviceBusAdapter;
        protected readonly MessageValidator messageValidator;

        public abstract event EventHandler<MessageReceivedEventArgs<TU>> MessageReceived;

        public abstract event EventHandler<MessageReceivedEventArgs<TU>> DuplicateMessageReceived;

        protected ServiceBus(TServiceBusAdapter serviceBusAdapter, MessageValidator messageValidator) {
            this.serviceBusAdapter = serviceBusAdapter;
            this.messageValidator = messageValidator;
        }

        public void StartListening(string publisherName, TimeSpan timeout, bool autoAcknowledge = false) {
            _stopListening = false;
            serviceBusAdapter.Initialise(publisherName);

            var thread = new Thread(o => {
                while (!_stopListening) {
                    ReceiveNextMessage(publisherName, timeout, autoAcknowledge);
                }
                serviceBusAdapter.Dispose();
            });

            thread.Start();
        }

        public void StopListening() {
            _stopListening = true;
        }

        protected abstract void ReceiveNextMessage(string publisherName, TimeSpan timeout, bool autoAcknowledge);

        void IDisposable.Dispose() {
            StopListening();
        }
    }
}