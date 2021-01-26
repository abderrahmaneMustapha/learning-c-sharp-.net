namespace NinjaDomain.DataModel.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addbirthdaytoninja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Ninjas", "dateOfBirth", c => c.DateTime(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Ninjas", "dateOfBirth");
        }
    }
}
