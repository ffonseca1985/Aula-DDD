namespace MovimentacoesGerais.Infraetructure.SqlEntityFramework.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DadosEvento",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        AggregateId = c.Guid(nullable: false),
                        Eventos = c.String(),
                        Versao = c.Int(nullable: false),
                        Data = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PosicaoAtualContaCorrente",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Encerrada = c.Boolean(nullable: false),
                        ClienteId = c.Guid(nullable: false),
                        NumeroConta = c.String(),
                        NumeroAgencia = c.String(),
                        Saldo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DataCriacao = c.DateTime(nullable: false),
                        AggregateId = c.Guid(nullable: false),
                        VersaoAtual = c.Int(nullable: false),
                        VersaoAnterior = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PosicaoAtualContaCorrente");
            DropTable("dbo.DadosEvento");
        }
    }
}
