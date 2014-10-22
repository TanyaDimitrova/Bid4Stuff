﻿namespace Bid4Stuff.Models
{
    using System;
    using System.Collections.Generic;

    public class Item
    {
        public Item()
        {
            this.Bids = new HashSet<Bid>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int? CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public string ImagePath { get; set; }

        public decimal Price { get; set; }

        public string OwnerId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<Bid> Bids { get; set; }
    }
}