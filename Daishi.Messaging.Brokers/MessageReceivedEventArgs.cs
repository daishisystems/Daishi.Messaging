#region Includes

using System;

#endregion

namespace Daishi.Messaging.Brokers {
    public abstract class MessageReceivedEventArgs<TMessage> : EventArgs where TMessage : class {
        public TMessage Message { get; set; }

        protected MessageReceivedEventArgs(TMessage message) {
            Message = message;
        }
    }
}