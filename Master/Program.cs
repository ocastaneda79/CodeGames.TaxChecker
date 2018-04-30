namespace Master
{
    using System;
    using System.Threading.Tasks;
    using NServiceBus;
    using NServiceBus.Features;
    using Shared.Messages;

    class Program
    {
        static async Task Main()
        {
            var endpointConfiguration = new EndpointConfiguration("Gateway.Master");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.EnableFeature<Gateway>();
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.Conventions().DefiningMessagesAs(type => {
                return type.Name.EndsWith("Message");
            }); 

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);
            Console.WriteLine("Press 'Enter' to send a message to sites which will reply.");
            Console.WriteLine("Press any other key to exit");

            while (true)
            {
                var key = Console.ReadKey();
                Console.WriteLine();

                if (key.Key != ConsoleKey.Enter)
                {
                    break;
                }

                string[] siteKeys =
                {
                    "Slave", "NewPOLSlave"
                };

                var message = new StupidMessage
                {
                    Id = Guid.NewGuid()
                };

                await endpointInstance.SendToSites(siteKeys, message).ConfigureAwait(false);

                Console.WriteLine("Message sent, check the output in RemoteSite");
            }

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}