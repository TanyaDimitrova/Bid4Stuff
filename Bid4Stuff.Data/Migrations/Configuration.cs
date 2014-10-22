namespace Bid4Stuff.Data.Migrations
{
    using Bid4Stuff.Models;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
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
            //  This method will be called after migrating to the latest version.
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //
            if (!context.Roles.Any(r => r.Name == "admin"))
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);
                var role = new IdentityRole { Name = "admin" };

                manager.Create(role);
            }

            if (!context.Users.Any(u => u.UserName == "admin@bid.bg"))
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser { UserName = "admin@bid.bg" };

                manager.Create(user, "asdasd");
                context.SaveChanges();
                manager.AddToRole(user.Id, "admin");
                context.SaveChanges();
            }

            if (context.Categories.Count() == 0)
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
