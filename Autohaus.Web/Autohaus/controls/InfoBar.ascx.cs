using System;
using System.Web.UI;
using Autohaus.Custom.Bucketing;
using Autohaus.Data;

namespace Autohaus.Web.UI.Controls
{
    public partial class InfoBar : UserControl
    {
        protected string VersionInfo
        {
            get
            {
                Version webVersion = typeof (DataQueryControl).Assembly.GetName().Version;
                Version customVersion = typeof (GuidFolderPath).Assembly.GetName().Version;
                Version dataVersion = typeof (Config).Assembly.GetName().Version;
                const string message = "Autohaus.Web: {0} Autohaus.Custom: {1} Autohaus.Data: {2}";
                return string.Format(message, webVersion, customVersion, dataVersion);
            }
        }
    }
}