using NServiceBus;
using NServiceBus.Logging;
using NServiceBus.Pipeline;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestFramework;

namespace NewPOLSlave
{
    class InvoiceCreatedHandler : IHandleMessages<InvoiceCreatedMessage>
    {
        static ILog log = LogManager.GetLogger<MessageHandler>();
       

        public Task Handle(InvoiceCreatedMessage message, IMessageHandlerContext context)
        {
            var header = context.MessageHeaders[Headers.OriginatingSite];
            log.Info($"Message {message.Id} received. Reply over channel: {header}");

            var acknowledgement = new InvoiceRecievedMessage
            {
                InvoiceNumber = message.InvoiceNumber,
                Sender = "NewPOL"
            };

            //var client = RestClientFluentAPI.GetRestClient("http://np-dev-ci.northeurope.cloudapp.azure.com")
            //    .ForTenantWithFakeToken("E2E03");

            return context.Reply(acknowledgement);
        }
    }

    
}
