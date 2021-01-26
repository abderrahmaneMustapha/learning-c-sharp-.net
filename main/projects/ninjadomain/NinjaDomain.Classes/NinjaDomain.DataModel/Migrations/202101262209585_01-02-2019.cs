namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _01022019 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clans", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Clans", "IsDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.Ninjas", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.Ninjas", "IsDirty", c => c.Boolean(nullable: false));
            AddColumn("dbo.NinjaEquipements", "DateModified", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipements", "DateCreated", c => c.DateTime(nullable: false));
            AddColumn("dbo.NinjaEquipements", "IsDirty", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.NinjaEquipements", "IsDirty");
            DropColumn("dbo.NinjaEquipements", "DateCreated");
            DropColumn("dbo.NinjaEquipements", "DateModified");
            DropColumn("dbo.Ninjas", "IsDirty");
            DropColumn("dbo.Ninjas", "DateCreated");
            DropColumn("dbo.Ninjas", "DateModified");
            DropColumn("dbo.Clans", "IsDirty");
            DropColumn("dbo.Clans", "DateCreated");
            DropColumn("dbo.Clans", "DateModified");
        }
    }
}
