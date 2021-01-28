namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class securepasswordmoredescription : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Articles", "title", c => c.String(nullable: false));
            AlterColumn("dbo.Articles", "content", c => c.String(nullable: false));
            AlterColumn("dbo.Users", "username", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Users", "email", c => c.String(nullable: false));
            DropColumn("dbo.Users", "password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Users", "password", c => c.String());
            AlterColumn("dbo.Users", "email", c => c.String());
            AlterColumn("dbo.Users", "username", c => c.String());
            AlterColumn("dbo.Articles", "content", c => c.String());
            AlterColumn("dbo.Articles", "title", c => c.String());
        }
    }
}
