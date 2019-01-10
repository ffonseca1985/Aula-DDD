using System;

namespace SharedKernel.DomainModel
{
    public interface AggregateRoot
    {
        Guid Id { get;}
    }
}
