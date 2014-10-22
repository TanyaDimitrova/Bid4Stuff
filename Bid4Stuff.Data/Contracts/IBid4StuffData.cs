namespace Bid4Stuff.Data.Contracts
{
    using System;
    using System.Linq;
    
    using Bid4Stuff.Models;

    public interface IBid4StuffData
    {
        IGenericRepository<ApplicationUser> Users { get; }

        IGenericRepository<Item> Items { get; }

        IGenericRepository<Bid> Bids { get; }

        IGenericRepository<Category> Categories { get; }

        void SaveChanges();
    }
}