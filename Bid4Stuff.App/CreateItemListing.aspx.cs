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

        protected void Page_Init(object sender, EventArgs e)
        {
            if (this.IsPostBack)
            {
                return;
            }

            var context = new Bid4StuffDbContext();
            DropDownListCategory.DataSource = context.Categories.ToList();
            this.DataBind();
            DropDownListCategory.Items.Insert(0, new ListItem(" ", "0"));
            DropDownListCategory.SelectedIndex = 0;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                var db = new Bid4StuffData();
                var test = (this.DropDownListCategory.SelectedValue);
                //TODO: add validations validations and fileupload
                var user = db.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
                var item = new Item()
                {
                    Name = this.ItemNameInput.Text,
                    CategoryId = int.Parse(this.DropDownListCategory.SelectedValue),
                    Description = this.ItemDescriptionInput.Text,
                    Price = decimal.Parse(this.ItemPriceInput.Text),
                    OwnerId = user.Id,
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