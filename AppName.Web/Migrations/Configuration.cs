namespace AppName.Web.Migrations
{
    using AppName.Web.Models;
    using Bogus;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<AppName.Web.Models.DataContex>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppName.Web.Models.DataContex context)
        {
            if (context.Categories.Any() == false)
            {
                var category = new Faker<Category>()
                    .RuleFor(c => c.Name, (f, c) => f.Commerce.Categories(1)[0])
                    .Generate(10);
                context.Categories.AddRange(category);
            }
            context.SaveChanges();

            if (context.Products.Any() == false)
            {
                var categories = context.Categories.ToList();
                var products = new Faker<Product>()
                    .RuleFor(p => p.Name, (f, p) => f.Commerce.ProductName())
                    .RuleFor(p => p.Price, (f, p) => f.Random.Decimal())
                    .RuleFor(p => p.Category, (f,p) => f.PickRandom(categories))
                    .Generate(10);
                context.Products.AddRange(products);
                
            }
            context.SaveChanges();
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
