namespace Bid4Stuff.App
{
    using System;
    using System.Linq;

    using Bid4Stuff.Data;
    using Bid4Stuff.Models;
    using Error_Handler_Control;

    public partial class MakeBid : System.Web.UI.Page
    {
        private Item selectedItem;
        private int selectedItemId;
        private Bid4StuffData db = new Bid4StuffData();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request["ItemId"] == null)
            {
                this.Response.Redirect("~/");
            }

            if (!int.TryParse(Request["ItemId"], out selectedItemId))
            {
                ErrorSuccessNotifier.AddErrorMessage("Invalid item ID!");
                ErrorSuccessNotifier.ShowAfterRedirect = true;
                Response.Redirect("~/");
            }
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
            this.LiteralItemPrice.Text = selectedItem.Price.ToString();
        }

        protected void ButtonMakeBid_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();

                decimal bidPrice;
                if (!decimal.TryParse(this.InputBidPrice.Text, out bidPrice))
                {
                    ErrorSuccessNotifier.AddWarningMessage("Invalid price!");
                }
                else if (bidPrice <= selectedItem.Price)
                {
                    ErrorSuccessNotifier.AddWarningMessage("Your bid must be higher than the current price!");
                }
                else
                {
                    var newBid = new Bid()
                    {
                        ItemId = selectedItemId,
                        Item = selectedItem,
                        Time = DateTime.Now,
                        UserId = user.Id,
                        User = user,
                        Price = bidPrice
                    };

                    selectedItem.Bids.Add(newBid);
                    selectedItem.Price = newBid.Price;
                    db.SaveChanges();
                    ErrorSuccessNotifier.AddSuccessMessage(String.Format("Your bid for {0} is accepted!", selectedItem.Name));
                    ErrorSuccessNotifier.ShowAfterRedirect = true;
                    Response.Redirect("~/");
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