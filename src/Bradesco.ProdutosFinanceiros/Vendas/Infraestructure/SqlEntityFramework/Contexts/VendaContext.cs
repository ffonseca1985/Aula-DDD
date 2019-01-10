namespace Vendas.Infraestructure.SqlEntityFramework.Contexts
{
    using SharedKernel.InfraEstructure.SqlEntityFramework;
    using SharedKernel.InfraEstructure.SqlEntityFramework.Constants;
    using System.Data.Entity;
    using Vendas.DomainModel.Venda;

    public class VendaContext
        : DbContextBase
    {
        public VendaContext()
            : base(DbORMConstant.ConnectionName)
        { }

        public DbSet<Venda> Venda { get; set; }
        public DbSet<CDB> Cdb { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
