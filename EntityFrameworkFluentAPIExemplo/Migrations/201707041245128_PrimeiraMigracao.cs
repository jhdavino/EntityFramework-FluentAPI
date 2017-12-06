namespace EntityFrameworkFluentAPIExemplo.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class PrimeiraMigracao : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 55),
                        Description = c.String(nullable: false, maxLength: 255),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Posts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 255),
                        Slug = c.String(nullable: false, maxLength: 255),
                        Pusblished = c.Boolean(nullable: false),
                        CreatedAt = c.DateTime(nullable: false),
                        UpdatedAt = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PostsCategories",
                c => new
                    {
                        PostId = c.Int(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.PostId, t.CategoryId })
                .ForeignKey("dbo.Posts", t => t.PostId, cascadeDelete: true)
                .ForeignKey("dbo.Categories", t => t.CategoryId, cascadeDelete: true)
                .Index(t => t.PostId)
                .Index(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.PostsCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.PostsCategories", "PostId", "dbo.Posts");
            DropIndex("dbo.PostsCategories", new[] { "CategoryId" });
            DropIndex("dbo.PostsCategories", new[] { "PostId" });
            DropTable("dbo.PostsCategories");
            DropTable("dbo.Posts");
            DropTable("dbo.Categories");
        }
    }
}
