namespace Vendas.Infraestructure.SqlEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CDB",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Nome = c.String(),
                        Preco_Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Venda",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        IdContaCorrente = c.Guid(nullable: false),
                        DataVenda = c.DateTime(nullable: false),
                        Version = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ItemVenda",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Desconto_Valor = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Desconto_UnidadeMedida = c.Int(nullable: false),
                        Qtde = c.Int(nullable: false),
                        Cdb_Id = c.Guid(),
                        Venda_Id = c.Guid(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CDB", t => t.Cdb_Id)
                .ForeignKey("dbo.Venda", t => t.Venda_Id)
                .Index(t => t.Cdb_Id)
                .Index(t => t.Venda_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ItemVenda", "Venda_Id", "dbo.Venda");
            DropForeignKey("dbo.ItemVenda", "Cdb_Id", "dbo.CDB");
            DropIndex("dbo.ItemVenda", new[] { "Venda_Id" });
            DropIndex("dbo.ItemVenda", new[] { "Cdb_Id" });
            DropTable("dbo.ItemVenda");
            DropTable("dbo.Venda");
            DropTable("dbo.CDB");
        }
    }
}
