using SharedKernel.InfraEstructure.SqlEntityFramework;
using SharedKernel.InfraEstructure.SqlEntityFramework.Constants;
using System.Data.Entity;
using EmprestimoPessoaFisica.DomainModel.EmprestimoGeral;

namespace EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Contexts
{
    public class EmprestoPessoFisicaContext
        : DbContextBase
    {
        public EmprestoPessoFisicaContext() 
            : base(DbORMConstant.ConnectionName)
        {}

        public DbSet<EmprestimoGeral> EmprestimoGeral { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
