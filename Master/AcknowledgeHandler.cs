namespace Master
{
    using System.Threading.Tasks;
    using NServiceBus;
    using NServiceBus.Logging;
    using Shared.Messages;

    public class AcknowledgeHandler : IHandleMessages<IAcknowledgedMessage>
    {
        static ILog log = LogManager.GetLogger<AcknowledgeHandler>();

        public Task Handle(IAcknowledgedMessage message, IMessageHandlerContext context)
        {
            log.Info($"Response {message.Id} received from {message.Sender}");

            return Task.CompletedTask;
        }
    }
}