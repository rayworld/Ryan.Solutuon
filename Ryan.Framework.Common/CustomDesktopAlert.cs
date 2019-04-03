using DevComponents.DotNetBar.Controls;

namespace Ryan.Framework.Common
{
    public sealed class CustomDesktopAlert
    {
        public static void H2(string key)
        {
            DesktopAlert.Show(string.Format("<h2>{0}</h2>", key));
        }
    }
}
