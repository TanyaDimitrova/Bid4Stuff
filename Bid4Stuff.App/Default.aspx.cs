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

        protected void Page_PreRender(object sender, EventArgs e)
        {
            if (this.User.Identity.IsAuthenticated)
            {
                foreach (ListViewItem item in ListViewOffersEndingSoon.Items)
                {
                    item.FindControl("btnBidOES").Visible = true;
                }
                foreach (ListViewItem item in ListViewLatestAddedOffers.Items)
                {
                    item.FindControl("btnBidLAO").Visible = true;
                }
            }
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

        protected void btnBidLAO_Click(object sender, EventArgs e)
        {
        }

        protected void btnBidOES_Click(object sender, EventArgs e)
        {
            
        }
    }
}