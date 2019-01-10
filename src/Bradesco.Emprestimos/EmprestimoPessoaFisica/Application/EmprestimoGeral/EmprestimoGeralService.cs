namespace EmprestimoPessoaFisica.Application.EmprestimoGeral
{
    using DomainModel.EmprestimoGeral;
    using System;
    using SharedKernel.InfraEstructure.Messages;
    using EmprestimoPessoaFisica.Application.Events;
    using System.Collections.Generic;
    using EmprestimoPessoaFisica.Application.EmprestimoGeral.Dtos;
    using Extensions;
    using EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Repository;

    public class EmprestimoGeralService
    {
        //DM.EmprestimoGeralService _emprestimoService;
        RepositoryBase<EmprestimoGeral> _emprestimoGeralRepository;
        IBus _bus;

        public EmprestimoGeralService(
          //   DM.EmprestimoGeralService emprestimoService,
             RepositoryBase<EmprestimoGeral> emprestimoGeralRepository,
             IBus bus)
        {
            //_emprestimoService = emprestimoService;
            _emprestimoGeralRepository = emprestimoGeralRepository;
            _bus = bus;
        }

        public void Salvar(Guid idContaCorrente, decimal valor)
        {
            //var retornoValidacao = _emprestimoService.AnalisarEmprestimoGeral(idContaCorrente, valor);

            //if (retornoValidacao.Status == StatusEmprestimo.Aprovado)
            //{
                var emprestimo = new EmprestimoGeral(idContaCorrente, valor);
                emprestimo.Situacao = new SituacaoEmprestimo(StatusEmprestimo.Aprovado);

                _emprestimoGeralRepository.Add(emprestimo);

                _bus.Publish(new EmprestimoFinalizadoEvent(emprestimo.Id, idContaCorrente, valor));

            //    return;
            //}

            //var exceptionEvent = new ExceptionEvent("Emprestimo", "Usuário não foi aprovado");
            //_bus.Publish(exceptionEvent);
        }

        public IEnumerable<EmprestimoGeralDto> Get()
        {
            var emprestimos = _emprestimoGeralRepository.Get();
            return emprestimos.ToDto();
        }
    }
}