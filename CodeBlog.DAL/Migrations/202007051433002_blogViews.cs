namespace CodeBlog.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class blogViews : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Blogs", "Views", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Blogs", "Views");
        }
    }
}
