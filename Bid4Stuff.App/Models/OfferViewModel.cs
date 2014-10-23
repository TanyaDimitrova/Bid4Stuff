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
            this.ItemId = item.Id;
            this.Name = item.Name;
            this.Price = item.Price;
            this.CategoryName = item.Category.Name;
            this.StartDate = item.StartDate.ToString("dd.MM.yyyy");
            this.ImagePath = String.IsNullOrEmpty(item.ImagePath) ? DefaultImagePath : item.ImagePath;
            
            var diff = item.EndDate - DateTime.Now;
            var withoutDays = string.Format("{0}h {1}m {2}s", diff.Hours, diff.Minutes, diff.Seconds);
            var withDays = string.Format("{0}d, {1}h {2}m {3}s", diff.Days, diff.Hours, diff.Minutes, diff.Seconds);
            var timeLeft = diff.Days == 0 ? withoutDays : withDays;
            this.TimeLeft = timeLeft;
        }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string CategoryName { get; set; }

        public string StartDate { get; set; }

        public string TimeLeft { get; set; }

        public string ImagePath { get; set; }

        public int ItemId { get; set; }
    }
}