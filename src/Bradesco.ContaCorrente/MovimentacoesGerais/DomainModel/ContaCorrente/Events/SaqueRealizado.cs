using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;

namespace MovimentacoesGerais.DomainModel.ContaCorrente
{
    public class SaqueRealizado
        : Event
    {
        public SaqueRealizado(decimal valor)
        {
            this.Valor = valor;
        }

        public decimal Valor { get; private set; }
    }
}
