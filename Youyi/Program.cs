using Ryan.Framework.DotNetFx20.AutoUpdate;
using Ryan.Framework.DotNetFx20.Common;
using System;
using System.Net;
using System.Windows.Forms;
using System.Xml;

namespace Youyi
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            AutoUpdater au = new AutoUpdater();
            try
            {
                au.Update();
            }
            catch (WebException exp)
            {
                CustomDesktopAlert.H4(String.Format("无法找到指定资源\n\n{0}", exp.Message));
            }
            catch (XmlException exp)
            {
                CustomDesktopAlert.H4(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (NotSupportedException exp)
            {
                CustomDesktopAlert.H4(String.Format("升级地址配置错误\n\n{0}", exp.Message));
            }
            catch (ArgumentException exp)
            {
                CustomDesktopAlert.H4(String.Format("下载的升级文件有错误\n\n{0}", exp.Message));
            }
            catch (Exception exp)
            {
                CustomDesktopAlert.H4(String.Format("升级过程中发生错误\n\n{0}", exp.Message));
            }

            Application.Run(new FrmMain());

        }
    }
}
