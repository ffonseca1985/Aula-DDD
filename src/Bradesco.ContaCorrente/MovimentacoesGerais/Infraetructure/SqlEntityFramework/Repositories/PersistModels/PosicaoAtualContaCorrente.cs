using System;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels
{
    //Tem o status da ContaCorrente em determinado momento
    public class PosicaoAtualContaCorrente
        : Snapshot
    {
        private PosicaoAtualContaCorrente(){}

        public PosicaoAtualContaCorrente( Guid aggregateId, int versaoAtual, int versaoAnterior,
            string numeroConta, string numeroAgencia, decimal saldo) 
        {
            this.NumeroConta = numeroConta;
            this.NumeroAgencia = numeroAgencia;
            this.Saldo = saldo;
            this.Id = Guid.NewGuid();
            this.DataCriacao = DateTime.Now;
            this.VersaoAtual = versaoAtual;
            this.VersaoAnterior = VersaoAnterior;

        }
        public bool Encerrada { get; private set; }
        public Guid ClienteId { get; private set; }
        public string NumeroConta { get; private set; }
        public string NumeroAgencia { get; private set; }
        public decimal Saldo { get; private set; }
    }
}
