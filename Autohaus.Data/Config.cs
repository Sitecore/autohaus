using Sitecore.Configuration;

namespace Autohaus.Data
{
    public static class Config
    {
        public static string SiteName
        {
            get { return Settings.GetSetting("Autohaus.SiteName", "autohaus"); }
        }

        public static string WebIndexName
        {
            get { return Settings.GetSetting("Autohaus.WebIndexName", "sitecore_web_index"); }
        }
    }
}