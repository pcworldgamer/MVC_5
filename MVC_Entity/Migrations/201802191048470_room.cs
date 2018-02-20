namespace MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class room : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Rooms",
                c => new
                    {
                        nr = c.Int(nullable: false, identity: true),
                        piso = c.Int(nullable: false),
                        lotacao = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                        custo_dia = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.nr);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Rooms");
        }
    }
}
