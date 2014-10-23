using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bid4Stuff.Data;
using Bid4Stuff.App.Models;

namespace Bid4Stuff.App
{
    public partial class ListAllItems : System.Web.UI.Page
    {
        private Bid4StuffData db = new Bid4StuffData();

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        public IEnumerable<OfferViewModel> ListViewItems_GetData()
        {
            var latestAddedItems = this.db.Items.All()
                                       .ToList();

            var latestAddedOffers = latestAddedItems.Select(i => new OfferViewModel(i));

            return latestAddedOffers;
        }

        protected void ListViewItems_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem && this.User.Identity.IsAuthenticated)
            {
                e.Item.FindControl("btnBidLAO").Visible = true;
            }
        }
    }
}