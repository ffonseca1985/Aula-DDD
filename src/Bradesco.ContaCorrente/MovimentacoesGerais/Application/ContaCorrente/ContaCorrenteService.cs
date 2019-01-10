using System;

namespace MovimentacoesGerais.Application.ContaCorrente
{
    using DomainModel.ContaCorrente;
    using MovimentacoesGerais.Application.Commands;
    using MovimentacoesGerais.Application.ContaCorrente.Commands;
    using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories;
    using SharedKernel.DomainModel.Events;
    using SharedKernel.InfraEstructure.Messages;

    public class ContaCorrenteService
    {
        RepositorioDeContaCorrente _ccRepository;
        IBus _bus;

        public ContaCorrenteService(RepositorioDeContaCorrente ccRepository,
            IBus bus)
        {
            _ccRepository = ccRepository;
            _bus = bus;
        }

        public void Execute(DepositarCommand command)
        {
            if (command == null)
                _bus.Publish(new ExceptionEvent("Comando", "Comando não enviado, favor tentar novamente"));

            _bus.Send(command);
        }

        public void Execute(SacarCommand command)
        {
            if (command == null)
                _bus.Publish(new ExceptionEvent("Comando", "Comando não enviado, favor tentar novamente"));

            _bus.Send(command);
        }

        public void Execute(EmprestimoCommand command)
        {
            if (command == null)
                _bus.Publish(new ExceptionEvent("Comando", "Comando não enviado, favor tentar novamente"));

            _bus.Send(command);
        }


        public void Execute(ComprarCdbCommand command)
        {
            if (command == null)
                _bus.Publish(new ExceptionEvent("Comando", "Comando não enviado, favor tentar novamente"));

            _bus.Send(command);
        }

        public void Execute(CriarCommand command)
        {
            if (command == null)
                _bus.Publish(new ExceptionEvent("Comando", "Comando não enviado, favor tentar novamente"));

            _bus.Send(command);
        }

        public ContaCorrente Get(Guid idContaCorrente)
        {
            return _ccRepository.BuscarPor(idContaCorrente);
        }
    }
}
