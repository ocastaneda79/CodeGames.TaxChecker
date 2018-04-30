namespace Shared.Messages
{
    using System;

    public interface IAcknowledgedMessage
    {
        Guid Id { get; set; }

        string Sender { get; set; }
    }
}