using System;
using System.Linq;
using Bid4Stuff.Data;
using Bid4Stuff.Models;
using Error_Handler_Control;

namespace Bid4Stuff.App
{
    public partial class MakeBid : System.Web.UI.Page
    {
        private Item selectedItem;
        private int selectedItemId;
        private Bid4StuffData db = new Bid4StuffData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ItemId"] == null)
            {
                this.Response.Redirect("Default.aspx");
            }
            
            selectedItemId = int.Parse(Request["ItemId"]);
            selectedItem = db.Items.SearchFor(i => i.Id == selectedItemId).FirstOrDefault();
            if (selectedItem == null)
            {
                ErrorSuccessNotifier.AddErrorMessage("Can't find this item!");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("~/");
            }
            
            var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
            if (selectedItem.OwnerId == user.Id)
            {
                ErrorSuccessNotifier.AddErrorMessage("You can't bid on your own item!");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("~/");
            }
            
            this.LiteralItemName.Text = selectedItem.Name;
        }

        protected void ButtonMakeBid_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                //TODO: Validation
                var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
                if (Request["ItemId"] == null)
                {
                    this.Response.Redirect("Default.aspx");
                }

                var bidPrice = decimal.Parse(this.InputBidPrice.Text);
                if (bidPrice <= selectedItem.Price)
                {
                    ErrorSuccessNotifier.AddWarningMessage("Your bid must be higher than the current price!");
                }
                else
                {
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
            }
            else
            {
                this.Response.Redirect("Account/Login");
            }
        }

        public IQueryable<Bid> ListViewCurrentBids_GetData()
        {
            var bids = selectedItem.Bids.ToList();
            foreach (var bid in bids)
            {
                var user = db.Users.SearchFor(x => x.Id == bid.UserId).FirstOrDefault();
                bid.User = user;
            }
            return bids.OrderByDescending(b => b.Time).AsQueryable();
        }
    }
}