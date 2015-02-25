#region Includes

using System;
using Daishi.Messaging.Brokers;
using Daishi.Messaging.Brokers.Microsoft;
using Microsoft.ServiceBus.Messaging;

#endregion

namespace Daishi.Messaging.ConsoleApp {
    internal class Program {
        private static void Main(string[] args) {
            var serviceBus = new MSAzureServiceBus(new MSAzureServiceBusAdapter(), new MessageValidator());
            serviceBus.MessageReceived += serviceBus_MessageReceived;

            serviceBus.StartListening("TestTopic", new TimeSpan(0, 0, 1), true);
            Console.WriteLine("Listening to the Service Bus. Press any key to quit...");

            Console.ReadLine();
            serviceBus.StopListening();

            Console.WriteLine("Disconnecting...");
        }

        private static void serviceBus_MessageReceived(object sender, MessageReceivedEventArgs<BrokeredMessage> e) {
            Console.WriteLine(e.Message.MessageId);
        }
    }
}