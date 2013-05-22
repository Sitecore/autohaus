using Autohaus.Data.ViewModels;

namespace Autohaus.Web.UI.Controls
{
    public partial class CarDetails : SitecoreUserControl
    {
        protected DisplayCar Model
        {
            get
            {
                return DisplayCar.CreateFromItem(DataSourceItem ?? Sitecore.Context.Item);
            }
        }
    }
}