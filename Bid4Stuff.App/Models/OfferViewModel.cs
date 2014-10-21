using System;
using System.Linq;
using Bid4Stuff.Models;

namespace Bid4Stuff.App.Models
{
    public class OfferViewModel
    {
        private const string DefaultImagePath = "http://goo.gl/ZwPMYZ";

        public OfferViewModel(Item item)
        {
            this.Name = item.Name;
            this.Price = item.Price;
            this.StartDate = item.StartDate.ToString("dd.MM.yyyy");
            this.ImagePath = item.ImagePath == null ? DefaultImagePath : item.ImagePath;

            var diff = item.EndDate - DateTime.Now;
            this.TimeLeft = string.Format(
                "{0}d, {1}h {2}m {3}s",
                diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
        }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string StartDate { get; set; }

        public string TimeLeft { get; set; }

        public string ImagePath { get; set; }
    }
}