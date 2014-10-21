using Bid4Stuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace Bid4Stuff.App.Models
{
    public class OfferViewModel
    {
        private const string DefaultImagePath = "http://goo.gl/ZwPMYZ";

        public OfferViewModel(Item item)
        {
            this.Name = item.Name;
            Price = item.Price;
            StartDate = item.StartDate;
            ImagePath = item.ImagePath == null ? DefaultImagePath : item.ImagePath;

            var diff = item.EndDate - DateTime.Now;
            this.TimeLeft = string.Format(
                "{0}d, {1}h, {2}m",
                diff.Days, diff.Hours, diff.Minutes);
        }
        
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime StartDate { get; set; }

        public string TimeLeft { get; set; }

        public string ImagePath { get; set; }
    }
}