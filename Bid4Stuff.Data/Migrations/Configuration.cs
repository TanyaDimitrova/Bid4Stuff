namespace Bid4Stuff.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Bid4Stuff.Data;
    using Bid4Stuff.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<Bid4StuffDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Bid4StuffDbContext context)
        {
            if (context.Categories.Count()==0)
            {
                context.Categories.Add(new Category("Home & Garden"));
                context.Categories.Add(new Category("Computers"));
                context.Categories.Add(new Category("Gaming & Fun"));
                context.Categories.Add(new Category("Cosmetics"));
                context.Categories.Add(new Category("Other"));
            }
        }
    }
}
