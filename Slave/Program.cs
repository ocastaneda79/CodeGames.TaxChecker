namespace Slave
{
    using NServiceBus;
    using NServiceBus.Features;
    using System;
    using System.Threading.Tasks;

    class Program
    {
        static async Task Main()
        {
            var endpointConfiguration = new EndpointConfiguration("Gateway.Slave");
            endpointConfiguration.EnableInstallers();
            endpointConfiguration.EnableFeature<Gateway>();
            endpointConfiguration.UsePersistence<InMemoryPersistence>();
            endpointConfiguration.UseTransport<LearningTransport>();
            endpointConfiguration.Conventions().DefiningMessagesAs(type => {
                return type.Name.EndsWith("Message");
            });

            var endpointInstance = await Endpoint.Start(endpointConfiguration).ConfigureAwait(false);

            Console.WriteLine("\r\nPress any key to stop program\r\n");
            Console.ReadKey();

            await endpointInstance.Stop().ConfigureAwait(false);
        }
    }
}