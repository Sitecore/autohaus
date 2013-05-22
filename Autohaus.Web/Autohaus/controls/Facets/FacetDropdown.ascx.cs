using Sitecore.Buckets.Util;

namespace Autohaus.Web.UI.Controls.Facets
{
    public partial class FacetDropdown : SitecoreUserControl
    {
        protected string Key
        {
            get { return DataSourceItem[Constants.FacetParameters]; }
        }
    }
}