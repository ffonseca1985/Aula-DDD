namespace EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Contexts.EmprestoPessoFisicaContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            MigrationsDirectory = @"Infraestructure\SqlEntityFramework\Migrations";
        }

        protected override void Seed(EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Contexts.EmprestoPessoFisicaContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
        }
    }
}
