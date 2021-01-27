namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeblogtoarticle : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.Blogs", newName: "Articles");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Articles", newName: "Blogs");
        }
    }
}
