using System;

namespace SharedKernel.InfraEstructure.Queue.Messages
{
    public interface IEmprestimo
    {
        Guid IdEmprestimo { get; set; }
        Guid IdContaCorrente { get; set; }
        decimal Valor { get; set; }
    }
}
