using System;

namespace VendasQueryStack.Infrastructure.Repositories.Dtos
{
    [MongoDB.Bson.Serialization.Attributes.BsonIgnoreExtraElements]
    public class VendaCDBDto
    {
        Guid IdContaCorrente { get; set; }
        decimal Valor { get; set; }
        string Descricao { get; set; }
    }
}
