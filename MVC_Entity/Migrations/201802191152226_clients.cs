namespace MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class clients : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clients",
                c => new
                    {
                        ClientId = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        morada = c.String(nullable: false, maxLength: 50),
                        cp = c.String(nullable: false, maxLength: 8),
                        email = c.String(),
                        telefone = c.String(),
                        data_nascimento = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ClientId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Clients");
        }
    }
}
