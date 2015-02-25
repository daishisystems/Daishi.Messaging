#region Includes

using System;
using System.Linq;
using Daishi.Messaging.Brokers;
using NUnit.Framework;

#endregion

namespace Daishi.Messaging.Tests {
    [TestFixture]
    internal class MessageValidatorTests {
        [Test]
        public void MessageValidatorIdentifiesDuplicateMessage() {
            var messageValidator = new MessageValidator();
            const string messageId = "5439c23e59b84786ae9395ca04d826b9";

            messageValidator.AddMessageIdToCache(messageId);
            for (var i = 0; i < 100; i++) {
                messageValidator.AddMessageIdToCache(Guid.NewGuid().ToString("N"));
            }

            Assert.IsTrue(messageValidator.ValidateMessageId(messageId));
        }

        [Test]
        public void MessageValidatorFormatsMessageIdBeforeCaching() {
            var messageValidator = new MessageValidator();
            var messageId = Guid.NewGuid().ToString();

            messageValidator.AddMessageIdToCache(messageId);
            Assert.IsTrue(!messageValidator.Cache.First().Contains("-"));
        }
    }
}