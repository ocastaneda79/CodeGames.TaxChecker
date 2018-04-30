namespace Shared.Messages
{
    using System;

    public interface IBaseMessage
    {
        Guid Id { get; }
    }
}
