namespace AnotherSlave
{
    using System.Threading.Tasks;
    using NServiceBus;
    using NServiceBus.Logging;
    using Shared.Messages;

    public class MessageHandler : IHandleMessages<StupidMessage>
    {
        static ILog log = LogManager.GetLogger<MessageHandler>();

        public Task Handle(StupidMessage message, IMessageHandlerContext context)
        {
            var header = context.MessageHeaders[Headers.OriginatingSite];
            log.Info($"Message {message.Id} received. Reply over channel: {header}");

            var acknowledgement = new StupidAcknowledgeMessage
            {
                Id = message.Id,
                Sender = "AnotherSlave"
            };

            return context.Reply(acknowledgement);
        }
    }
}