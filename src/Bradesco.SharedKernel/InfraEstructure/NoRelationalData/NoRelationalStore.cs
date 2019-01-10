using MongoDB.Driver;
using SharedKernel.InfraEstructure.NoRelationalData.Constants;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SharedKernel.InfraEstructure.NoRelationalData
{
    public class NoRelationalStore<T> 
        where T : class
    {
        public async Task Add(T obj, string dataBase, string collectionName)
             
        {
            //strind de conexão
            //mongodb://localhost:2701/Venda
            var connection = MongoDbConstant.ConnectionString + dataBase;

            var client = new MongoClient(connection);
            var db = client.GetDatabase(dataBase);

            //Qual collection??
            //R: Posso ter vendaCDB, VendaPIC, VendaSeguro... 
            var collection = db.GetCollection<T>(collectionName);

            await collection.InsertOneAsync(obj);
        }

        public async Task<IEnumerable<T>> GetAll(string dataBase, string collectionName)
        {
            //string de conexão
            //mongodb://localhost:2701/Venda
            var connection = MongoDbConstant.ConnectionString + dataBase;

            var client = new MongoClient(connection);
            var db = client.GetDatabase(dataBase);

            List<T> entidades = await db.GetCollection<T>(collectionName)
                .Find(x => true).ToListAsync();

            return entidades;
        }
    }
}
