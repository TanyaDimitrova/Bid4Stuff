using Bid4Stuff.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bid4Stuff.Data
{

    public class Bid4StuffDbContext : IdentityDbContext<ApplicationUser>
    {
        public Bid4StuffDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static Bid4StuffDbContext Create()
        {
            return new Bid4StuffDbContext();
        }
    }
}
