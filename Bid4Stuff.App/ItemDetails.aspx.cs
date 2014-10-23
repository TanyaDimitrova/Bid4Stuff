using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Bid4Stuff.Data;
using Bid4Stuff.Data.Contracts;
using Bid4Stuff.Models; 

namespace Bid4Stuff.App
{
    public partial class ItemDetails : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var data = new Bid4StuffData();

            List<Item> items = data.Items.All().ToList();

            var requestedId = int.Parse(Request.Params["Id"]);
            if (requestedId == null)
            {
                Response.Redirect("~/ListAllItems.aspx");
            }

            if (this.IsPostBack)
            {
                return;
            }

            var itemsEnumerable = items.Where(i => i.Id == requestedId);
            this.DetailsViewItems.DataSource = itemsEnumerable;

            var item = itemsEnumerable.First();
            DetailsViewItems.HeaderText = "<h1>" + 
                                               Server.HtmlEncode(item.Name).PadLeft(10) +
                                               " " + 
                                               " <span class=\"pull-right\">" +
                                               Server.HtmlEncode(string.Format("{0:c}",item.Price)) +
                                               "</span></h1>";
            this.DataBind();
        }
    }
}