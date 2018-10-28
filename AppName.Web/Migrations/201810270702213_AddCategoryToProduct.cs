namespace AppName.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddCategoryToProduct : DbMigration
    {
        public override void Up()
        {
            AddColumn("public.Products", "Category", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("public.Products", "Category");
        }
    }
}
