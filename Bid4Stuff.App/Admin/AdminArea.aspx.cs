﻿namespace Bid4Stuff.App.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Bid4Stuff.Data;
    using Bid4Stuff.Data.Contracts;
    using Error_Handler_Control;

    public partial class AdminArea : System.Web.UI.Page
    {
        private IBid4StuffData data;

        protected void Page_Init(object sender, EventArgs e)
        {
            if (!User.IsInRole("admin"))
            {
                ErrorSuccessNotifier.AddWarningMessage("You are not authorized for this page");
                Response.Redirect("../Default");
            }

            this.data = new Bid4StuffData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.BidsListView.DataSource = this.data.Bids.All().ToList();
            this.DataBind();
        }

        protected void DeleteItem_Command(object sender, CommandEventArgs e)
        {
            var bidId = int.Parse(e.CommandArgument.ToString());
            var bid = data.Bids.SearchFor(b => b.Id == bidId).FirstOrDefault();

            data.Bids.Delete(bid);
            data.SaveChanges();

            Response.Redirect(Request.RawUrl);
        }

        protected void EditItem_Command(object sender, CommandEventArgs e)
        {
            var bidId = int.Parse(e.CommandArgument.ToString());

            Response.Redirect(string.Format("EditBid?id={0}",bidId));
        }

    }
}