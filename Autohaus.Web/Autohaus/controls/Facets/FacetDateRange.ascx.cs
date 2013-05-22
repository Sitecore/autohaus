namespace Autohaus.Web.UI.Controls.Facets
{
    public partial class FacetDateRange : SitecoreUserControl
    {
        protected string FromSelector
        {
            get { return "from_" + UniqueControlId; }
        }

        protected string ToSelector
        {
            get { return "to_" + UniqueControlId; }
        }
    }
}