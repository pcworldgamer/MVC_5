namespace MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class startdb : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        nome = c.String(nullable: false, maxLength: 50),
                        password = c.String(),
                        confirmaPassword = c.String(),
                        perfil = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Users");
        }
    }
}
