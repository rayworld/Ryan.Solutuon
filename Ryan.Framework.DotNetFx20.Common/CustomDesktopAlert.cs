using DevComponents.DotNetBar.Controls;

namespace Ryan.Framework.DotNetFx20.Common
{
    public sealed class CustomDesktopAlert
    {

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H2(string key)
        {
            DesktopAlert.Show(string.Format("<h2>{0}</h2>", key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H3(string key)
        {
            DesktopAlert.Show(string.Format("<h3>{0}</h3>", key));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="key"></param>
        public static void H4(string key)
        {
            DesktopAlert.Show(string.Format("<h4>{0}</h4>", key));
        }
    }
}
