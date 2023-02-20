namespace TravelTripProje.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class YorumlarVirtualAdd : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Yorumlars", "Blog_ID", "dbo.Blogs");
            DropIndex("dbo.Yorumlars", new[] { "Blog_ID" });
            RenameColumn(table: "dbo.Yorumlars", name: "Blog_ID", newName: "BlogID");
            AlterColumn("dbo.Yorumlars", "BlogID", c => c.Int(nullable: false));
            CreateIndex("dbo.Yorumlars", "BlogID");
            AddForeignKey("dbo.Yorumlars", "BlogID", "dbo.Blogs", "ID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Yorumlars", "BlogID", "dbo.Blogs");
            DropIndex("dbo.Yorumlars", new[] { "BlogID" });
            AlterColumn("dbo.Yorumlars", "BlogID", c => c.Int());
            RenameColumn(table: "dbo.Yorumlars", name: "BlogID", newName: "Blog_ID");
            CreateIndex("dbo.Yorumlars", "Blog_ID");
            AddForeignKey("dbo.Yorumlars", "Blog_ID", "dbo.Blogs", "ID");
        }
    }
}
