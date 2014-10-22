namespace Bid4Stuff.App.Admin
{
    using System;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Bid4Stuff.Data;
    using Bid4Stuff.Data.Contracts;
    using Bid4Stuff.Models;

    using Error_Handler_Control;

    public partial class EditBid : System.Web.UI.Page
    {
        private IBid4StuffData data;
        private Bid currentBid;

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
            this.DropDownListCategory.DataSource = data.Categories.All().ToList();
            this.DataBind();

            var bidId = Convert.ToInt32(Request.Params["id"]);

            if (bidId == 0)
            {
                ErrorSuccessNotifier.AddErrorMessage("There is no such bid to edit");
                Response.Redirect("AdminArea.aspx");
                return;
            }

            currentBid = this.data.Bids.SearchFor(b => b.Id == bidId).FirstOrDefault();
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            this.DropDownListCategory.Items.Insert(0, new ListItem(" ", "0"));
            this.DropDownListCategory.SelectedIndex = 0;

            this.ItemNameTextBox.Text = currentBid.Item.Name;
            this.ItemPriceTextBox.Text = currentBid.Price.ToString();
            this.BidEndDate.SelectedDate = currentBid.Item.EndDate;
        }

        protected void CancelEditBtn_Click(object sender, EventArgs e)
        {
            Response.Redirect("AdminArea");
        }

        protected void SaveEditBtn_Click(object sender, EventArgs e)
        {
            var itemName = this.ItemNameTextBox.Text.Trim();
            ValidateItemName(itemName);

            decimal itemPrice = GetValidNumberParsed();

            if (itemPrice < 0)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item price cannot be a negative number");
                Response.Redirect(Request.RawUrl);
            }

            var date = DateTime.Parse(this.NewSelectedDate.Value);
            if (date < DateTime.Now)
            {
                ErrorSuccessNotifier.AddWarningMessage("Ending date should be in the future");
                Response.Redirect(Request.RawUrl);
            }

            currentBid.Item.EndDate = date;
            currentBid.Item.Name = itemName;
            currentBid.Price = itemPrice;

            this.data.Bids.Update(currentBid);
            this.data.SaveChanges();

            ErrorSuccessNotifier.AddSuccessMessage("Successfully update bid!");
        }
 
        private decimal GetValidNumberParsed()
        {
            decimal itemPrice = 0;

            try
            {
                itemPrice = decimal.Parse(this.ItemPriceTextBox.Text);
            }
            catch (Exception)
            {
                ErrorSuccessNotifier.AddWarningMessage("Please enter a valid number");
                Response.Redirect(Request.RawUrl);
            }

            return itemPrice;
        }
 
        private void ValidateItemName(string itemName)
        {
            if (string.IsNullOrEmpty(itemName))
            {
                ErrorSuccessNotifier.AddWarningMessage("Item Name cannot be null or empty. Please fill in correct data");
                Response.Redirect(Request.RawUrl);
            }

            if (itemName.Length > 40)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item Name cannot be longer than 40 symbols");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void BidEndDate_SelectionChanged(object sender, EventArgs e)
        {
            this.NewSelectedDate.Value = this.BidEndDate.SelectedDate.ToString();
            this.BidEndDate.SelectedDate = DateTime.Parse(this.NewSelectedDate.Value);
        }
    }
}