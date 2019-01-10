namespace Vendas.DomainModel.Venda
{
    public class Desconto
    {
        public Desconto(decimal valor = 0, UnidadeMedida unidadeMedida = UnidadeMedida.porcentagem)
        {
            this.Valor = valor;
            this.UnidadeMedida = UnidadeMedida;
        }

        public decimal Valor { get; internal set; }
        public UnidadeMedida UnidadeMedida { get; private set; }
        
    }
}