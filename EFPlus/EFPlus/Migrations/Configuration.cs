using Bogus;

namespace EFPlus.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<EFPlus.DataContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(EFPlus.DataContext context)
        {
            if (context.Categories.Any() == false)
            {
                var categories = new Faker<Category>()
                    .RuleFor(c => c.Name, (f, c) => f.Commerce.Categories(1)[0])
                    .RuleFor(c => c.IsActive, (f, c) => f.Random.Bool())
                    .Generate(10);

                context.Categories.AddRange(categories);

                context.SaveChanges();
            }

            if (context.Products.Any() == false)
            {
                var categories = context.Categories.ToList();

                var products = new Faker<Product>()
                    .RuleFor(c => c.Name, (f, c) => f.Commerce.ProductName())
                    .RuleFor(c => c.Category, (f, c) => f.PickRandom(categories))
                    .RuleFor(c => c.IsActive, (f, c) => f.Random.Bool())
                    .Generate(100);

                context.Products.AddRange(products);

                context.SaveChanges();
            }
        }
    }
}
