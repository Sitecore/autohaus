using System.Collections.Generic;
using System.Web.UI;
using Autohaus.Data;
using Autohaus.Data.Models;

namespace Autohaus.Web.UI.Controls
{
    public partial class MainNav : UserControl
    {
        protected IEnumerable<NavigationItem> NavigationItems
        {
            get { return NavigationService.GetNavigationItems(); }
        }
    }
}