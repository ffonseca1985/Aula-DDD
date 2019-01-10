using System;
using System.Collections.Generic;

namespace EmprestimoPessoaFisica.Infraestructure.AntiCorruptionLayer.ControleAcesso.Cliente
{
    using ClienteServiceReference;
    using System.Linq;
    using DomainModel = DomainModel.Cliente;

    public class ClienteAdapter
    {
        //é o nosso channel => ponte entre o serviço e este projeto
        private ClienteServiceClient _clienteService;

        public ClienteAdapter()
        {
            _clienteService = new ClienteServiceClient();
        }

        public DomainModel.Cliente Get(Guid id)
        {
             var clienteExterno =  _clienteService.Get(id);
            return new DomainModel.Cliente(clienteExterno.Cpf, clienteExterno.Nome, clienteExterno.Id);
        }

        public List<DomainModel.Cliente> GetAll()
        {
            var clientesExterno = _clienteService.GetAll();
            return clientesExterno.Select(x => new DomainModel.Cliente(x.Cpf, x.Nome, x.Id)).ToList();
        }
    }
}
