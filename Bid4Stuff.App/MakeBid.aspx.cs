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
    public partial class MakeBid : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void ButtonMakeBid_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                //TODO: Validation
                var db = new Bid4StuffData();
                var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
                var selectedItemId = int.Parse(Request["ItemId"]);
                var selectedItem = db.Items.SearchFor(i => i.Id == selectedItemId).FirstOrDefault();
                if (selectedItem != null)
                {
                    var newBid = new Bid()
                    {
                        ItemId = selectedItemId,
                        Time = DateTime.Now,
                        User = user,
                        Price = decimal.Parse(this.InputBidPrice.Text)
                    };
                
                    selectedItem.Bids.Add(newBid);
                    db.SaveChanges();
                    this.Response.Redirect("Default.aspx");
                }
            }
            else
            {
                this.Response.Redirect("Account/Login");
            }
        }
    }
}