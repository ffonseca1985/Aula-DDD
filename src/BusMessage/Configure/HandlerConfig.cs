using EmprestimoPessoaFisica.Application.EventHandlers;
using MovimentacoesGerais.Application.CommandHandlers;
using SharedKernel.EventHandlers;
using SharedKernel.InfraEstructure.Messages;

namespace BusMessage.Configure
{
    public static class HandlerConfig
    {
        public static void Initialize(this IBus bus)
        {
            //SharedKernel
            bus.Register<ExceptionEventHandler>();

            //Movimentações Gerais
            bus.Register<ComprarCdbCommandHandler>();
            bus.Register<CriarCommandHandler>();
            bus.Register<DepositarCommandhandler>();
            bus.Register<EmprestimoCommandHandler>();
            bus.Register<SacarCommandHandler>();

            //Emprestimos
            bus.Register<EmprestimoEventHandler>();
        }
    }
}
