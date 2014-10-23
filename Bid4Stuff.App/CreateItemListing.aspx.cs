namespace Bid4Stuff.App
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI.WebControls;

    using Error_Handler_Control;

    using Bid4Stuff.Data;
    using Bid4Stuff.Data.Contracts;
    using Bid4Stuff.Models;

    public partial class CreateItemListing : System.Web.UI.Page
    {
        private const string DefaultFileUploadFolder = "Uploaded_Files";
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
                string imagePath = string.Empty;

                var user = this.data.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();

                var currentItemName = this.ItemNameInput.Text.Trim();
                ValidateItemName(currentItemName);

                var currentCategoryId = Convert.ToInt32(this.DropDownListCategory.SelectedValue);
                ValidateCategory(currentCategoryId);

                var currentDescription = this.ItemDescriptionInput.Text.Trim();
                ValideItemDescription(currentDescription);

                var currentPrice = Convert.ToDecimal(this.ItemPriceInput.Text);
                ValidateItemPrice(currentPrice);

                var currentOwnerId = user.Id;

                var currentEndDate = this.EndDateInput.SelectedDate;
                ValidateEndDate(currentEndDate);

                imagePath = HandleFileInput(imagePath);

                var item = new Item()
                {
                    Name = currentItemName,
                    CategoryId = currentCategoryId,
                    Description = currentDescription,
                    Price = currentPrice,
                    ImagePath = imagePath,
                    OwnerId = currentOwnerId,
                    StartDate = DateTime.Now,
                    EndDate = this.EndDateInput.SelectedDate,
                    Active = true
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

        private string HandleFileInput(string imagePath)
        {
            if (this.ItemImageInput.HasFile)
            {
                string[] fileData = Path.GetFileName(this.ItemImageInput.FileName).Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries);
                string fileExtension = fileData[fileData.Length - 1];

                string uniqueFileName = string.Format("{0}.{1}", Guid.NewGuid(), fileExtension);

                string subPath;
                string defaultPath;
                HandleDirectories(out subPath, out defaultPath);

                this.ItemImageInput.SaveAs(Server.MapPath(string.Format("~/{2}/{0}/{1}", subPath, uniqueFileName, defaultPath)));
                imagePath = string.Format("~/{2}/{0}/{1}", subPath, uniqueFileName, defaultPath);
            }
            return string.IsNullOrEmpty(imagePath) ? imagePath = "~/default_product.png" : imagePath;
        }

        private void ValidateEndDate(DateTime currentEndDate)
        {
            if (currentEndDate < DateTime.Now)
            {
                ErrorSuccessNotifier.AddWarningMessage("End date must be at least 1 day in the future");
                Response.Redirect(Request.RawUrl);
            }
        }

        private void ValidateItemPrice(decimal currentPrice)
        {
            if (currentPrice == 0)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item price is invalid. Please fill in correct one.");
                Response.Redirect(Request.RawUrl);
            }

            if (currentPrice <= 0)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item price cannot be a negative number. Please fill in correct one.");
                Response.Redirect(Request.RawUrl);
            }
        }

        private void HandleDirectories(out string subPath, out string defaultPath)
        {
            defaultPath = DefaultFileUploadFolder;
            bool defaultPathExists = Directory.Exists(Server.MapPath(defaultPath));
            if (!defaultPathExists)
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/{0}", defaultPath)));
            }

            subPath = Context.User.Identity.Name;
            bool subPathExists = Directory.Exists(Server.MapPath(subPath));
            if (!subPathExists)
            {
                Directory.CreateDirectory(Server.MapPath(string.Format("~/{1}/{0}", subPath, defaultPath)));
            }
        }

        private void ValideItemDescription(string currentDescription)
        {
            if (string.IsNullOrEmpty(currentDescription))
            {
                ErrorSuccessNotifier.AddWarningMessage("Item description cannot be null or empty");
                Response.Redirect(Request.RawUrl);
            }

            if (currentDescription.Length < 50)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item description cannot be less than 50 symbols");
                Response.Redirect(Request.RawUrl);
            }

            if (currentDescription.Length > 250)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item description cannot be more than 250 symbols");
                Response.Redirect(Request.RawUrl);
            }

            if (currentDescription.Contains("script"))
            {
                ErrorSuccessNotifier.AddWarningMessage("Don't even try again");
                Response.Redirect(Request.RawUrl);
            }
        }

        private void ValidateCategory(int currentCategoryId)
        {
            if (currentCategoryId == 0)
            {
                ErrorSuccessNotifier.AddWarningMessage("Not exi");
                Response.Redirect(Request.RawUrl);
            }

            if (!this.data.Categories.All().Any(c => c.Id == currentCategoryId))
            {
                ErrorSuccessNotifier.AddWarningMessage("Don't cheat to add custom category. Call the admin.");
                Response.Redirect(Request.RawUrl);
            }
        }

        private void ValidateItemName(string currentItemName)
        {
            if (string.IsNullOrEmpty(currentItemName))
            {
                ErrorSuccessNotifier.AddWarningMessage("Item name cannot be null or empty");
                Response.Redirect(Request.RawUrl);
            }

            if (currentItemName.Length < 3)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item name is too short. It must be at least 3 symbols long.");
                Response.Redirect(Request.RawUrl);
            }

            if (currentItemName.Length > 40)
            {
                ErrorSuccessNotifier.AddWarningMessage("Item name is too long. Max allowed length is 40 symbols");
                Response.Redirect(Request.RawUrl);
            }

            if (currentItemName.Contains("script"))
            {
                ErrorSuccessNotifier.AddWarningMessage("Don't even try this!");
                Response.Redirect(Request.RawUrl);
            }
        }

        protected void ButtonCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default");
        }
    }
}