
using SharedKernel.InfraEstructure.SqlEntityFramework;
using SharedKernel.InfraEstructure.SqlEntityFramework.Constants;
using System.Data.Entity;

namespace ControleAcesso.Infraestructure.SqlEntityFramework.Contexts
{
    using DomainModel.Cliente;

    public class ControleAcessoContext
        : DbContextBase
    {
        public ControleAcessoContext() 
            : base("DbBradescoORM")
        {
        }

        public DbSet<Cliente> Cliente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Map
            base.OnModelCreating(modelBuilder);
        }
    }
}
