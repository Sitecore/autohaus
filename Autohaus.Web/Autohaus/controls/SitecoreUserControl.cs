using System;
using System.Collections.Specialized;
using System.Web.UI;
using Sitecore.Data.Fields;
using Sitecore.Data.Items;
using Sitecore.Diagnostics;
using Sitecore.Web;
using Sitecore.Web.UI.WebControls;

namespace Autohaus.Web.UI.Controls
{
    public class SitecoreUserControl : UserControl
    {
        private string _datasource;
        private Item _datasourceItem;
        private NameValueCollection _parameters;
        private string uniqueControlId;

        protected string UniqueControlId
        {
            get
            {
                if (uniqueControlId == null)
                {
                    var sublayout = (Sublayout) Parent;
                    Assert.IsNotNull(sublayout, "Cannot get parent sublayout");
                    uniqueControlId = sublayout.GetUserControl().ClientID;
                }

                return uniqueControlId;
            }
        }

        protected Item DataSourceItem
        {
            get
            {
                if (_datasourceItem == null)
                {
                    var sublayout = (Sublayout) Parent;
                    Assert.IsNotNull(sublayout, "Cannot get parent sublayout");
                    _datasourceItem = Sitecore.Context.Database.GetItem(sublayout.DataSource);
                }

                return _datasourceItem;
            }
        }

        protected string DataSource
        {
            get
            {
                if (_datasource == null)
                {
                    var sublayout = (Sublayout) Parent;
                    Assert.IsNotNull(sublayout, "Cannot get parent sublayout");
                    _datasource = sublayout.DataSource;
                }

                return _datasource;
            }
        }

        protected NameValueCollection Parameters
        {
            get
            {
                if (_parameters == null)
                {
                    var sublayout = (Sublayout) Parent;
                    Assert.IsNotNull(sublayout, "Cannot get parent sublayout");
                    _parameters = WebUtil.ParseUrlParameters(sublayout.Parameters);

                    Item datasource = DataSourceItem;

                    if (datasource != null)
                    {
                        datasource.Fields.ReadAll();
                        string prefix = datasource.TemplateName.ToLowerInvariant();
                        foreach (Field field in datasource.Fields)
                        {
                            if (!field.Name.StartsWith("__"))
                            {
                                _parameters.Add(prefix + "_" + field.Name, field.Value);
                            }
                        }
                    }
                }

                return _parameters;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.DataBind();
        }
    }
}