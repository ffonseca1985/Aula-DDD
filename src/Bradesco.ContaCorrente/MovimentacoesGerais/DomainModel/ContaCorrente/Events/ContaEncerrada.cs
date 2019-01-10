using SharedKernel.DomainModel;
using SharedKernel.InfraEstructure.Messages;

namespace MovimentacoesGerais.DomainModel.ContaCorrente.Events
{
    public class ContaEncerrada
        : Event
    {
        public ContaEncerrada(string motivo)
        {
            this.Motivo = motivo;
        }

        public string Motivo { get; set; }
    }
}
