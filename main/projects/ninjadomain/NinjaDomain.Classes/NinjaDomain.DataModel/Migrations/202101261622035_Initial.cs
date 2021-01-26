namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clans",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        clanName = c.String(),
                    })
                .PrimaryKey(t => t.id);
            
            CreateTable(
                "dbo.Ninjas",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        served = c.Boolean(nullable: false),
                        clanId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Clans", t => t.clanId, cascadeDelete: true)
                .Index(t => t.clanId);
            
            CreateTable(
                "dbo.NinjaEquipements",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        type = c.Int(nullable: false),
                        ninja_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Ninjas", t => t.ninja_id)
                .Index(t => t.ninja_id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NinjaEquipements", "ninja_id", "dbo.Ninjas");
            DropForeignKey("dbo.Ninjas", "clanId", "dbo.Clans");
            DropIndex("dbo.NinjaEquipements", new[] { "ninja_id" });
            DropIndex("dbo.Ninjas", new[] { "clanId" });
            DropTable("dbo.NinjaEquipements");
            DropTable("dbo.Ninjas");
            DropTable("dbo.Clans");
        }
    }
}
