using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bid4Stuff.Data;
using Bid4Stuff.Models;

namespace Bid4Stuff.App
{
    public partial class MyListings : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var db = new Bid4StuffData();
                var user = db.Users.SearchFor(x=> x.UserName == this.User.Identity.Name).FirstOrDefault();
                var items =db.Items.SearchFor(x => x.Owner.Id == user.Id).ToList();

                this.ItemListing.DataSource = items;
                this.DataBind();
            }
            else
            {
                this.Response.Redirect("Account/Login");
            }
            
        }
    }
}