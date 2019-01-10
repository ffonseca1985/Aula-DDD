namespace Vendas.Infraestructure.SqlEntityFramework.Migrations
{
    using System.Data.Entity.Migrations;
    using Vendas.DomainModel.Venda;

    internal sealed class Configuration : DbMigrationsConfiguration<Vendas.Infraestructure.SqlEntityFramework.Contexts.VendaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Infraestructure\SqlEntityFramework\Migrations";
        }

        protected override void Seed(Contexts.VendaContext context)
        {
            var cdb = new CDB("CDB", new Preco() { Valor = 110 });

            //Adiciono somente se o nome for diferente
            context.Cdb.AddOrUpdate(x=>x.Nome, cdb);
            context.SaveChanges();
        }
    }
}
