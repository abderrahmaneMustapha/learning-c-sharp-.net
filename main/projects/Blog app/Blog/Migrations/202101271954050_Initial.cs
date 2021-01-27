namespace Blog.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Authors",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        user_id = c.Int(),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Users", t => t.user_id)
                .Index(t => t.user_id);
            
            CreateTable(
                "dbo.Blogs",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        title = c.String(),
                        content = c.String(),
                        thumbnail = c.Binary(),
                        authorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id)
                .ForeignKey("dbo.Authors", t => t.authorId, cascadeDelete: true)
                .Index(t => t.authorId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        username = c.String(),
                        email = c.String(),
                        password = c.String(),
                        is_staff = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Authors", "user_id", "dbo.Users");
            DropForeignKey("dbo.Blogs", "authorId", "dbo.Authors");
            DropIndex("dbo.Blogs", new[] { "authorId" });
            DropIndex("dbo.Authors", new[] { "user_id" });
            DropTable("dbo.Users");
            DropTable("dbo.Blogs");
            DropTable("dbo.Authors");
        }
    }
}
