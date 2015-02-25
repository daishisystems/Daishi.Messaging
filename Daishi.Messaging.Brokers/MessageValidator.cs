#region Includes

using System.Collections.Generic;

#endregion

namespace Daishi.Messaging.Brokers {
    public class MessageValidator {
        private readonly HashSet<string> _cache = new HashSet<string>();

        public IEnumerable<string> Cache { get { return _cache; } }

        public void AddMessageIdToCache(string messageId) {
            _cache.Add(messageId.Replace('-', '\0'));
        }

        public bool ValidateMessageId(string messageId) {
            return _cache.Contains(messageId);
        }
    }
}