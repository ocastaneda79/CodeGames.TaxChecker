using NServiceBus;
using NServiceBus.Logging;
using Shared.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Master
{
    public class InoviceRecievedHandler : IHandleMessages<InvoiceRecievedMessage>
    {
        static ILog log = LogManager.GetLogger<InoviceRecievedHandler>();
        public Task Handle(InvoiceRecievedMessage message, IMessageHandlerContext context)
        {
            throw new NotImplementedException();
        }
    }
}
