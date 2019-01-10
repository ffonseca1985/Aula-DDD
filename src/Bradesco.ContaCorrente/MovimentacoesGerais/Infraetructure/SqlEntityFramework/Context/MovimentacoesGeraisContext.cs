using MovimentacoesGerais.Infraetructure.SqlEntityFramework.Repositories.PersistModels;
using SharedKernel.InfraEstructure.SqlEntityFramework;
using SharedKernel.InfraEstructure.SqlEntityFramework.Constants;
using System.Data.Entity;

namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Context
{
    public class MovimentacoesGeraisContext
        : DbContextBase
    {
        public MovimentacoesGeraisContext() 
            : base(DbORMConstant.ConnectionName)
        {}

        public DbSet<DadosEvento> DadosEvento { get; set; }
        public DbSet<PosicaoAtualContaCorrente> PosicaoAtualContaCorrente { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
