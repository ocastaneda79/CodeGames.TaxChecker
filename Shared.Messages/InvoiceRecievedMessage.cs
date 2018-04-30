using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Messages
{
    public class InvoiceRecievedMessage
    {
        public string Sender;
        public Guid Id;
        public string InvoiceNumber;
    }
}
