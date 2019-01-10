using System;
using System.Collections.Generic;
using System.ServiceModel;

namespace ControleAccessoClienteService.Cliente
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IClienteService" in both code and config file together.
    [ServiceContract]
    public interface IClienteService
    {
        [OperationContract]
        Cliente Get(Guid id);

        [OperationContract]
        IEnumerable<Cliente> Get();
    }
}
