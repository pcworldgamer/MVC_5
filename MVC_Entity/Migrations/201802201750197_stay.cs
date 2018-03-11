namespace MVC_Entity.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class stay : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Stays",
                c => new
                    {
                        StayId = c.Int(nullable: false, identity: true),
                        EntryDate = c.DateTime(nullable: false),
                        ExitDate = c.DateTime(nullable: false),
                        cost_paid = c.Decimal(nullable: false, precision: 18, scale: 2),
                        ClientId = c.Int(nullable: false),
                        nr = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.StayId)
                .ForeignKey("dbo.Clients", t => t.ClientId, cascadeDelete: true)
                .ForeignKey("dbo.Rooms", t => t.nr, cascadeDelete: true)
                .Index(t => t.ClientId)
                .Index(t => t.nr);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Stays", "nr", "dbo.Rooms");
            DropForeignKey("dbo.Stays", "ClientId", "dbo.Clients");
            DropIndex("dbo.Stays", new[] { "nr" });
            DropIndex("dbo.Stays", new[] { "ClientId" });
            DropTable("dbo.Stays");
        }
    }
}
