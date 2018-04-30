namespace Shared.Messages
{
    using System;

    public class StupidAcknowledgeMessage : IAcknowledgedMessage
    {
        public Guid Id { get; set; }
        public string Sender { get; set; }
    }
}
