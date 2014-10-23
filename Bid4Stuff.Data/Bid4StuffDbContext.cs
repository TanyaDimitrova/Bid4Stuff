namespace Bid4Stuff.Data
{
    using System.Data.Entity;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Bid4Stuff.Data.Migrations;
    using Bid4Stuff.Models;

    public class Bid4StuffDbContext : IdentityDbContext<ApplicationUser>
    {
        public Bid4StuffDbContext()
            : base("Bid4StuffConnection", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Bid4StuffDbContext, Configuration>());
        }

        public static Bid4StuffDbContext Create()
        {
            return new Bid4StuffDbContext();
        }

        public IDbSet<Category> Categories { get; set; }

        public IDbSet<Item> Items { get; set; }

        public IDbSet<Bid> Bids { get; set; }
    }
}
