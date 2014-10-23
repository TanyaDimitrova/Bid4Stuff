namespace Bid4Stuff.App
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web.UI.WebControls;
    
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

                //TODO: add validations validations and fileupload
                if (this.ItemImageInput.HasFile)
                {
                    string filename = Path.GetFileName(this.ItemImageInput.FileName);

                    string defaultPath = DefaultFileUploadFolder;
                    bool defaultPathExists = Directory.Exists(Server.MapPath(defaultPath));
                    if (!defaultPathExists)
                    {
                        Directory.CreateDirectory(Server.MapPath(string.Format("~/{0}", defaultPath)));
                    }

                    string subPath = Context.User.Identity.Name;
                    bool subPathExists = Directory.Exists(Server.MapPath(subPath));
                    if (!subPathExists)
                    {
                        Directory.CreateDirectory(Server.MapPath(string.Format("~/{1}/{0}", subPath, defaultPath)));
                    }

                    this.ItemImageInput.SaveAs(Server.MapPath(string.Format("~/{2}/{0}/{1}", subPath, filename, defaultPath)));
                    imagePath = string.Format("~/{2}/{0}/{1}", subPath, filename, defaultPath);
                }

                var user = this.data.Users.SearchFor(x => x.UserName == this.User.Identity.Name).FirstOrDefault();
                var item = new Item()
                {
                    Name = this.ItemNameInput.Text,
                    CategoryId = int.Parse(this.DropDownListCategory.SelectedValue),
                    Description = this.ItemDescriptionInput.Text,
                    Price = decimal.Parse(this.ItemPriceInput.Text),
                    ImagePath = imagePath,
                    OwnerId = user.Id,
                    StartDate = DateTime.Now,
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