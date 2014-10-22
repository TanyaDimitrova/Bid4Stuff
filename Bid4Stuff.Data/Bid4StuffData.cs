namespace Bid4Stuff.Data
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Linq;

    using Bid4Stuff.Data.Contracts;
    using Bid4Stuff.Data.Repositories;
    using Bid4Stuff.Models;

    /// <summary>
    /// Unit of work
    /// </summary>
    public class Bid4StuffData : IBid4StuffData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public Bid4StuffData()
            : this(new Bid4StuffDbContext())
        {
        }

        public Bid4StuffData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IGenericRepository<ApplicationUser> Users
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }
        public IGenericRepository<Category> Categories
        {
            get
            {
                return this.GetRepository<Category>();
            }
        }

        public IGenericRepository<Item> Items
        {
            get
            {
                return this.GetRepository<Item>();
            }
        }

        public IGenericRepository<Bid> Bids
        {
            get
            {
                return this.GetRepository<Bid>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        private IGenericRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(GenericRepository<T>);
                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IGenericRepository<T>)this.repositories[typeOfModel];
        }
    }
}