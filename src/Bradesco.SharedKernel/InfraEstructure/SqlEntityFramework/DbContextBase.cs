using SharedKernel.InfraEstructure.Messages;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace SharedKernel.InfraEstructure.SqlEntityFramework
{
    public abstract class DbContextBase
        : DbContext
    {
        protected DbContextBase(string connection)
            : base(connection)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingEntitySetNameConvention>();
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
