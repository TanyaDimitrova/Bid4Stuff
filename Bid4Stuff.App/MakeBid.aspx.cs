using System;
using System.Linq;
using Bid4Stuff.Data;
using Bid4Stuff.Models;

namespace Bid4Stuff.App
{
    public partial class MakeBid : System.Web.UI.Page
    {
        Item selectedItem;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ItemId"] == null)
            {
                this.Response.Redirect("Default.aspx");
            }
            var db = new Bid4StuffData();
            var selectedItemId = int.Parse(Request["ItemId"]);
            selectedItem = db.Items.SearchFor(i => i.Id == selectedItemId).FirstOrDefault();
            this.LiteralItemName.Text = selectedItem.Name;
        }

        protected void ButtonMakeBid_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                //TODO: Validation
                var db = new Bid4StuffData();
                var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
                if (Request["ItemId"] == null)
                {
                    this.Response.Redirect("Default.aspx");
                }
                var selectedItemId = int.Parse(Request["ItemId"]);
                var selectedItem = db.Items.SearchFor(i => i.Id == selectedItemId).FirstOrDefault();

                if (selectedItem.OwnerId == user.Id)
                {
                    //TODO: Send error msg and redirect
                }

                if (selectedItem == null)
                {
                    //TODO: Send error msg and redirect 
                }

                var bidPrice = decimal.Parse(this.InputBidPrice.Text);
                if (bidPrice <= selectedItem.Price)
                {
                    //TODO: Send error msg and redirect 
                }
                
                var newBid = new Bid()
                {
                    ItemId = selectedItemId,
                    Time = DateTime.Now,
                    UserId = user.Id,
                    Price = bidPrice
                };
                
                selectedItem.Bids.Add(newBid);
                selectedItem.Price = newBid.Price;
                db.SaveChanges();
                this.Response.Redirect("Default.aspx");
            }
            else
            {
                this.Response.Redirect("Account/Login");
            }
        }

        public IQueryable<Bid> ListViewCurrentBids_GetData()
        {
            var bids = selectedItem.Bids.ToList();
            var db = new Bid4StuffData();
            foreach (var bid in bids)
            {
                var user = db.Users.SearchFor(x => x.Id == bid.UserId).FirstOrDefault();
                bid.User = user;
            }
            return bids.OrderByDescending(b => b.Time).AsQueryable();
        }
    }
}