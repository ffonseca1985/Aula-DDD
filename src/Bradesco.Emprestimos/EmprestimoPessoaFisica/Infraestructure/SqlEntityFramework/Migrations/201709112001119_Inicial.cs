namespace EmprestimoPessoaFisica.Infraestructure.SqlEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.EmprestimoGeral",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IdContaCorrente = c.Guid(nullable: false),
                        Data = c.DateTime(nullable: false),
                        Situacao_Status = c.Int(nullable: false),
                        Situacao_Motivo = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.EmprestimoGeral");
        }
    }
}
