using System;
using System.ServiceModel;

namespace ContaCorrenteServiceService.ContaCorrente
{
    [ServiceContract]
    public interface IContaCorrenteService
    {
        [OperationContract]
        ContaCorrente Get(Guid IdContaCorrente);
    }
}
