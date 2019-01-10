using System;

namespace ContaCorrenteServiceService.ContaCorrente
{
    public class ContaCorrenteService : IContaCorrenteService
    {
        ContaCorrenteService _contaCorrenteService;

        public ContaCorrenteService(ContaCorrenteService contaCorrenteService)
        {
            _contaCorrenteService = contaCorrenteService;
        }

        public ContaCorrente Get(Guid IdContaCorrente)
        {
            var cc = _contaCorrenteService.Get(IdContaCorrente);
            return new ContaCorrente(cc.IdContaCorrente, cc.NumeroConta, cc.NumeroAgencia, cc.IdCliente, cc.Saldo);
        }
    }
}
