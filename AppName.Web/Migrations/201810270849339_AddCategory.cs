namespace AppName.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategory : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "public.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            AddColumn("public.Products", "CategoryId", c => c.Int(nullable: false));
            CreateIndex("public.Products", "CategoryId");
            AddForeignKey("public.Products", "CategoryId", "public.Categories", "Id", cascadeDelete: true);
            DropColumn("public.Products", "Category");
        }
        
        public override void Down()
        {
            AddColumn("public.Products", "Category", c => c.String());
            DropForeignKey("public.Products", "CategoryId", "public.Categories");
            DropIndex("public.Products", new[] { "CategoryId" });
            DropColumn("public.Products", "CategoryId");
            DropTable("public.Categories");
        }
    }
}
