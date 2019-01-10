namespace ControleAcesso.Application.Cliente
{
    using ControleAcesso.Application.Cliente.Dto;
    using ControleAcesso.Application.Cliente.Extensions;
    using ControleAcesso.Infraestructure.SqlEntityFramework.Repository;
    using DomainModel.Cliente;
    using SharedKernel.DomainModel.Events;
    using SharedKernel.InfraEstructure.Messages;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class ClienteService
    {
        private RepositoryBase<Cliente> _clienteRepository;
        private IBus _bus;

        public ClienteService(RepositoryBase<Cliente> clienteRepository,
            IBus bus)
        {
            _clienteRepository = clienteRepository;
            _bus = bus;
        }

        //Como este contexto não se comunica com ninguém
        //não vamos criar uma estrutura de commands e events
        //NOTA: "BUT" => sempre mantenha um padrão!!!
        public void Create(ClienteDto cliente)
        {
            var entity = _clienteRepository.Get(x => x.Cpf == cliente.Cpf);

            if (!entity.Any())
            {
                _clienteRepository.Add(cliente.ToEntity());
                return;
            }

            _bus.Publish(new ExceptionEvent("Cliente", "Cliente já existente"));
            return;
        }

        public ClienteDto Get(Guid idCliente)
        {
            return _clienteRepository.FindById(idCliente).ToDto();
        }

        public IEnumerable<ClienteDto> Get()
        {
            return _clienteRepository.Get().ToDto();
        }
    }
}
