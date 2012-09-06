namespace TDD.Blog.Migrations
{
    using System.Data.Entity.Migrations;
    
    public partial class Forced : DbMigration
    {
        public override void Up()
        {
            AlterColumn("Posts", "Title", c => c.String());
            AlterColumn("Comments", "Author", c => c.String());
            AlterColumn("Comments", "Content", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("Comments", "Content", c => c.String(maxLength: 4000));
            AlterColumn("Comments", "Author", c => c.String(maxLength: 4000));
            AlterColumn("Posts", "Title", c => c.String(maxLength: 4000));
        }
    }
}
