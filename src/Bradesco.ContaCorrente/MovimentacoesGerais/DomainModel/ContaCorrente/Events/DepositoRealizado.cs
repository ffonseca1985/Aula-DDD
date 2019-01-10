using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;

namespace MovimentacoesGerais.DomainModel.ContaCorrente.Events
{
    public class DepositoRealizado
        : Event
    {
        public DepositoRealizado(decimal valor)
        {
            this.Valor = valor;
        }
        public decimal Valor { get; private set; } 
    }
}
