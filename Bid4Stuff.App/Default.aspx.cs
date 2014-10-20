using Bid4Stuff.Data;
using Bid4Stuff.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Bid4Stuff.App
{
    public partial class _Default : Page
    {
        private const int TopItemsCount = 15;
        private Bid4StuffData db = new Bid4StuffData();
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IQueryable<Item> ListViewLatestAddedOffers_GetData()
        {
            var latestAddedItems = this.db.Items.All().OrderByDescending(i => i.StartDate).Take(TopItemsCount);
            return latestAddedItems;
        }

        public IQueryable<Item> ListViewOffersEndingSoon_GetData()
        {
            var latestAddedItems = this.db.Items.All().OrderBy(i => i.EndDate).Take(TopItemsCount);
            return latestAddedItems;
        }
    }
}