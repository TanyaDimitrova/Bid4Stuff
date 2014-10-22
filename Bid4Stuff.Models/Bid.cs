namespace Bid4Stuff.Models
{
    using System;

    public class Bid
    {
        public int Id { get; set; }

        public ApplicationUser User { get; set; }

        public int ItemId { get; set; }

        public Item Item { get; set; }

        public decimal Price { get; set; }

        public DateTime Time { get; set; }
    }
}