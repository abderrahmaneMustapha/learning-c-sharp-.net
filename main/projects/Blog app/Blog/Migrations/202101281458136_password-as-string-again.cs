namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class passwordasstringagain : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Users", "password", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Users", "password");
        }
    }
}
