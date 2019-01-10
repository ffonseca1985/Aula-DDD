using EmprestimoPessoaFisica.Application.EmprestimoGeral.Dtos;

namespace EmprestimoPessoaFisica.Application.EmprestimoGeral.Extensions
{
    using DomainModel.EmprestimoGeral;
    using System.Collections.Generic;
    using System.Linq;

    public static class EmprestimoGeralExtension
    {
        public static EmprestimoGeralDto ToDto(this EmprestimoGeral entity)
        {
            return new EmprestimoGeralDto(entity.Id, entity.Valor, entity.Data);
        }

        public static IEnumerable<EmprestimoGeralDto> ToDto(this IEnumerable<EmprestimoGeral> entity)
        {
            return entity.ToList().ConvertAll(ToDto);
        }
    }
}
