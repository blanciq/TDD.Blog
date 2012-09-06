namespace TDD.Blog.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "Posts",
                c => new
                    {
                        PostId = c.Long(nullable: false, identity: true),
                        Title = c.String(maxLength: 4000),
                    })
                .PrimaryKey(t => t.PostId);
            
            CreateTable(
                "Comments",
                c => new
                    {
                        CommentId = c.Long(nullable: false, identity: true),
                        Author = c.String(maxLength: 4000),
                        Content = c.String(maxLength: 4000),
                        PostId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => t.CommentId)
                .ForeignKey("Posts", t => t.PostId, cascadeDelete: true)
                .Index(t => t.PostId);
            
        }
        
        public override void Down()
        {
            DropIndex("Comments", new[] { "PostId" });
            DropForeignKey("Comments", "PostId", "Posts");
            DropTable("Comments");
            DropTable("Posts");
        }
    }
}
