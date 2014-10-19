using Bid4Stuff.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Bid4Stuff.Data.Migrations;

namespace Bid4Stuff.Data
{

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
    }
}
