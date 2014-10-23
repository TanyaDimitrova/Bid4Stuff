namespace Bid4Stuff.App
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    using Bid4Stuff.App.Models;
    using Bid4Stuff.Data;

    public partial class _Default : Page
    {
        private const int TopItemsCount = 5;
        private Bid4StuffData db = new Bid4StuffData();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            var endedOffers = db.Items.SearchFor(i => i.EndDate < DateTime.Now);
            foreach (var offer in endedOffers)
            {
                offer.Active = false;
            }
        }
        
        public IEnumerable<OfferViewModel> ListViewLatestAddedOffers_GetData()
        {
            var latestAddedItems = this.db.Items.All()
                                       .Where(i => i.Active)
                                       .OrderByDescending(i => i.StartDate)
                                       .Take(TopItemsCount)
                                       .ToList();

            var latestAddedOffers = latestAddedItems.Select(i => new OfferViewModel(i));

            return latestAddedOffers;
        }

        public IEnumerable<OfferViewModel> ListViewOffersEndingSoon_GetData()
        {
            var latestAddedItems = this.db.Items.All()
                                       .Where(i => i.Active)
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