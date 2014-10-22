using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.UI;
using Bid4Stuff.App.Models;
using Bid4Stuff.Data;
using System.Web.UI.WebControls;

namespace Bid4Stuff.App
{
    public partial class _Default : Page
    {
        private const int TopItemsCount = 5;
        private Bid4StuffData db = new Bid4StuffData();
        
        protected void Page_Load(object sender, EventArgs e)
        {
        }
        
        public IEnumerable<OfferViewModel> ListViewLatestAddedOffers_GetData()
        {
            var latestAddedItems = this.db.Items.All()
                                       .OrderByDescending(i => i.StartDate)
                                       .Take(TopItemsCount)
                                       .ToList();

            var latestAddedOffers = latestAddedItems.Select(i => new OfferViewModel(i));

            return latestAddedOffers;
        }

        public IEnumerable<OfferViewModel> ListViewOffersEndingSoon_GetData()
        {
            var latestAddedItems = this.db.Items.All()
                                       .OrderBy(i => i.EndDate)
                                       .Take(TopItemsCount)
                                       .ToList();

            var latestAddedOffers = latestAddedItems.Select(i => new OfferViewModel(i));

            return latestAddedOffers;
        }

        protected void UpdateTimer_Tick(object sender, EventArgs e)
        {
            ListViewLatestAddedOffers.DataBind();
            ListViewOffersEndingSoon.DataBind();
        }
        
        protected void ListViewOffersEndingSoon_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem && this.User.Identity.IsAuthenticated)
            {
                e.Item.FindControl("btnBidOES").Visible = true;
            }
        }

        protected void ListViewLatestAddedOffers_ItemDataBound(object sender, ListViewItemEventArgs e)
        {
            if (e.Item.ItemType == ListViewItemType.DataItem && this.User.Identity.IsAuthenticated)
            {
                e.Item.FindControl("btnBidLAO").Visible = true;
            }
        }
    }
}