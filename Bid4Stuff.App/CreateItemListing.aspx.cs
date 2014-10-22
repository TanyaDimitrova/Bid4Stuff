using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Bid4Stuff.Data;
using Bid4Stuff.Models;
using Bid4Stuff.Data.Contracts;

namespace Bid4Stuff.App
{
    public partial class CreateItemListing : System.Web.UI.Page
    {
        private IBid4StuffData data;

        protected void Page_Init(object sender, EventArgs e)
        {
            this.data = new Bid4StuffData();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            this.DropDownListCategory.DataSource = data.Categories.All().ToList();
            this.DataBind();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DropDownListCategory.Items.Insert(0, new ListItem(" ", "0"));
            this.DropDownListCategory.SelectedIndex = 0;
        }

        protected void ButtonSubmit_Click(object sender, EventArgs e)
        {
            if (this.User != null && this.User.Identity.IsAuthenticated)
            {
                //var test = (this.DropDownListCategory.SelectedValue);
                //TODO: add validations validations and fileupload
                var user = this.data.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
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

                data.Items.Add(item);
                data.SaveChanges();

                this.Response.Redirect("MyListings.aspx");
            }
            else
            {
                this.Response.Redirect("Account/Login");
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}