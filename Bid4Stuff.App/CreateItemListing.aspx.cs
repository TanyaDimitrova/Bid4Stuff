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
    public partial class CreateItemListing : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var db = new Bid4StuffData();
                //TODO: add validations validations and fileupload
                var user = db.Users.SearchFor(x=> x.UserName == this.User.Identity.Name).FirstOrDefault();
                var item = new Item()
                {
                    Name = this.ItemNameInput.Text,
                    Description = this.ItemDescriptionInput.Text,
                    Price = decimal.Parse(this.ItemPriceInput.Text),
                    Owner = user,
                    StartDate = this.StartDateInput.SelectedDate,
                    EndDate = this.EndDateInput.SelectedDate
                };
                db.Items.Add(item);
                db.SaveChanges();
                this.Response.Redirect("MyListings.aspx");
            }
            else
            {
                this.Response.Redirect("Account/Login");
                //return;
            }
        }
    }
}