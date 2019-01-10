namespace ControleAcesso.Application.Cliente.Extensions
{
    using ControleAcesso.Application.Cliente.Dto;
    using DomainModel.Cliente;
    using SharedKernel.DomainModel;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class ClienteExtension
    {
        public static Cliente ToEntity(this ClienteDto cliente)
        {
            var factory = Cliente.UsuarioFactory.Create(
                cliente.Nome,
                cliente.Cpf,
                cliente.NomeMae,
                cliente.Descricao,
                cliente.Numero,
                cliente.Bairro,
                cliente.Cidade,
                (Estado)Enum.Parse(typeof(Estado), cliente.Estado));

            return factory;
        }

        public static List<Cliente> ToEntity(this List<ClienteDto> clientesDto)
        {
            return clientesDto.ConvertAll(ToEntity);
        }

        public static ClienteDto ToDto(this Cliente cliente)
        {
            return new ClienteDto()
            {
                Id = cliente.Id,
                Bairro = cliente.Endereco.Bairro,
                Nome = cliente.Nome,
                Cpf = cliente.Cpf,
                Cidade = cliente.Endereco.Cidade,
                Descricao = cliente.Endereco.Descricao,
                Estado = cliente.Endereco.Estado.ToString(),
                NomeMae = cliente.NomeMae,
                Numero = cliente.Endereco.Numero
            };
        }

        public static IEnumerable<ClienteDto> ToDto(this IEnumerable<Cliente> clientes)
        {
            return clientes.ToList().ConvertAll(ToDto);
        }
    }
}
