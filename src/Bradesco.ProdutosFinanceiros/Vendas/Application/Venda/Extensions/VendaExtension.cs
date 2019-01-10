using Vendas.Application.Venda.Dtos;

namespace Vendas.Application.Venda.Extensions
{
    using DomainModel.Venda;
    using System.Collections.Generic;
    using System.Linq;

    public static class VendaExtension
    {
        public static VendaDto ToDto(this Venda entity)
        {
            return new VendaDto(entity.IdContaCorrente,
                entity.Id, entity.Total, entity.DataVenda);
        }

        public static IEnumerable<VendaDto> ToDto(this IEnumerable<Venda> entity)
        {
            return entity.ToList().ConvertAll(ToDto);
        }
    }
}
