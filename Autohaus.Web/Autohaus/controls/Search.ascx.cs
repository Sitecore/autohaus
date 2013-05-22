using System;
using System.Web.UI;
using Autohaus.Data;

namespace Autohaus.Web.UI.Controls
{
    public partial class Search : UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && !Sitecore.Context.Item.ID.Equals(Constants.Items.Search))
            {
                Controls.Add(Page.LoadControl("~/Autohaus/controls/searchbox.ascx"));
            }
        }
    }
}