﻿using DevComponents.DotNetBar;
using Ryan.Framework.Common;
using Ryan.Framework.Config;
using Ryan.Framework.Encrypt;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Huali
{
    public partial class FrmMain : Office2007Form
    {
        public FrmMain()
        {
            //全屏后不遮挡任务栏
            this.StartPosition = FormStartPosition.Manual;
            InitializeComponent();
            //全屏后不遮挡任务栏
            this.MaximizedBounds = Screen.PrimaryScreen.WorkingArea;
            //必加，不加也不会实现
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
        }

        #region 事件

        /// <summary>
        /// 启动程序时执行
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form_Main_Load(object sender, EventArgs e)
        {
            //得到应用标题
            this.ribbonControl1.TitleText = EncryptHelper.Decrypt(ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "AppName"));
            ////获取窗口样式
            GetStyleSetting();
            LoadModule();

            //用户登录
            FrmLogin login = new FrmLogin();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
            else
            {
                this.Close();
            }
        }

        /// <summary>
        /// 改变样式命令
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AppCommandTheme_Executed(object sender, EventArgs e)
        {
            ICommandSource source = sender as ICommandSource;
            if (source.CommandParameter is string)
            {
                eStyle style = (eStyle)Enum.Parse(typeof(eStyle), source.CommandParameter.ToString());
                // Using StyleManager change the style and color tinting
                if (StyleManager.IsMetro(style))
                {
                    // More customization is needed for Metro
                    // Capitalize App Button and tab
                    //buttonFile.Text = buttonFile.Text.ToUpper();
                    //foreach (BaseItem item in RibbonControl.Items)
                    //{
                    //    // Ribbon Control may contain items other than tabs so that needs to be taken in account
                    //    RibbonTabItem tab = item as RibbonTabItem;
                    //    if (tab != null)
                    //        tab.Text = tab.Text.ToUpper();
                    //}

                    //buttonFile.BackstageTabEnabled = true; // Use Backstage for Metro

                    ribbonControl1.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (style == eStyle.Metro)
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;

                    // Adjust size of switch button to match Metro styling
                    //switchButtonItem1.SwitchWidth = 16;
                    //switchButtonItem1.ButtonWidth = 48;
                    //switchButtonItem1.ButtonHeight = 19;

                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Metro;

                    StyleManager.Style = style; // BOOM
                }
                else
                {
                    // If previous style was Metro we need to update other properties as well
                    //if (StyleManager.IsMetro(StyleManager.Style))
                    //{
                    //    ribbonControl1.RibbonStripFont = null;
                    //    // Fix capitalization App Button and tab
                    //    //buttonFile.Text = ToTitleCase(buttonFile.Text);
                    //foreach (BaseItem item in RibbonControl.Items)
                    //{
                    //    // Ribbon Control may contain items other than tabs so that needs to be taken in account
                    //    RibbonTabItem tab = item as RibbonTabItem;
                    //    if (tab != null)
                    //        tab.Text = ToTitleCase(tab.Text);
                    //}
                    //    // Adjust size of switch button to match Office styling
                    //    switchButtonItem1.SwitchWidth = 28;
                    //    switchButtonItem1.ButtonWidth = 62;
                    //    switchButtonItem1.ButtonHeight = 20;
                    //}
                    // Adjust tab strip style
                    //tabStrip1.Style = eTabStripStyle.Office2007Document;
                    StyleManager.ChangeStyle(style, Color.Empty);
                    //if (style == eStyle.Office2007Black || style == eStyle.Office2007Blue || style == eStyle.Office2007Silver || style == eStyle.Office2007VistaGlass)
                    //    buttonFile.BackstageTabEnabled = false;
                    //else
                    //    buttonFile.BackstageTabEnabled = true;
                }
            }
            else if (source.CommandParameter is Color)
            {
                if (StyleManager.IsMetro(StyleManager.Style))
                    StyleManager.MetroColorGeneratorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(Color.White, (Color)source.CommandParameter);
                else
                    StyleManager.ColorTint = (Color)source.CommandParameter;
            }
            //保存用户设置
            ConfigHelper.UpdateOrCreateAppSetting(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle", source.CommandParameter.ToString());
        }

        #region DS9209


        private void Bi9209BillImport_Click(object sender, EventArgs e)
        {
            SetMdiForm("导入单据", typeof(Huali.DS9209.FrmImportBill));
        }

        private void Bi9209DelByBill_Click(object sender, EventArgs e)
        {
            SetMdiForm("删除单据", typeof(Huali.DS9209.FrmDeleteByBill));
        }

        private void Bi9209Sate_Click(object sender, EventArgs e)
        {
            SetMdiForm("二维码统计", typeof(Huali.DS9209.FrmStatistics));
        }

        private void Bi9209DelByQRCode_Click(object sender, EventArgs e)
        {
            SetMdiForm("删除二维码", typeof(Huali.DS9209.FrmDeleteByQRCode));
        }

        private void Bi9209QueryBill3_Click(object sender, EventArgs e)
        {
            SetMdiForm("单据完成情况", typeof(Huali.DS9209.FrmQueryBill3));
        }

        private void Bi9209QueryScanedQRCode_Click(object sender, EventArgs e)
        {
            SetMdiForm("所有扫过码的单", typeof(Huali.DS9209.FrmQueryFinishedBill));
        }

        private void Bi9209QueryByQRCode_Click(object sender, EventArgs e)
        {
            SetMdiForm("按二维码查询", typeof(Huali.DS9209.FrmQueryByQRCode));
        }

        private void Bi9209QueryByBill_Click(object sender, EventArgs e)
        {
            SetMdiForm("按订单查询", typeof(Huali.DS9209.FrmQueryByBill));
        }

        private void Bi9209QRCodeScan_Click(object sender, EventArgs e)
        {
            SetMdiForm("扫描二维码", typeof(Huali.DS9209.FrmQRCodeScan));
        }








        #endregion

        #region EDI2
        /// <summary>
        /// 日立订单导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem14_Click(object sender, EventArgs e)
        {
            SetMdiForm("日立订单导入", typeof(Huali.EDI2.FrmSEOutStock));
        }
        /// <summary>
        /// 其它订单导入
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonItem15_Click(object sender, EventArgs e)
        {
            SetMdiForm("其它订单导入", typeof(Huali.EDI2.FrmSEOutStock));
        }
        #endregion

        #region EDI

        private void ButtonItem18_Click(object sender, EventArgs e)
        {
            SetMdiForm("导入收货通知单", typeof(Huali.EDI.FrmImport));
        }

        private void ButtonItem19_Click(object sender, EventArgs e)
        {
            SetMdiForm("导出EDI数据", typeof(Huali.EDI.FrmExport));
        }

        private void ButtonItem20_Click(object sender, EventArgs e)
        {
            SetMdiForm("确认到货通知", typeof(Huali.EDI.FrmPOAcception));
        }
        #endregion

        #region DS9208


        private void ButtonItem25_Click(object sender, EventArgs e)
        {
            SetMdiForm("所有扫过码的单", typeof(Huali.DS9208.FrmQueryFinishedBill));
        }

        private void ButtonItem26_Click(object sender, EventArgs e)
        {
            SetMdiForm("单据完成情况", typeof(Huali.DS9208.FrmQueryBill3));
        }

        private void ButtonItem29_Click(object sender, EventArgs e)
        {
            SetMdiForm("删除二维码", typeof(Huali.DS9208.FrmDeleteByQRCode));
        }

        private void ButtonItem28_Click(object sender, EventArgs e)
        {
            SetMdiForm("删除单据", typeof(Huali.DS9208.FrmDeleteByBill));
        }

        private void ButtonItem27_Click(object sender, EventArgs e)
        {
            SetMdiForm("导入单据", typeof(Huali.DS9208.FrmImportBill));
        }

        private void ButtonItem24_Click(object sender, EventArgs e)
        {
            SetMdiForm("按二维码查询", typeof(Huali.DS9208.FrmQueryByQRCode));
        }

        private void ButtonItem23_Click(object sender, EventArgs e)
        {
            SetMdiForm("按订单查询", typeof(Huali.DS9208.FrmQueryByBill));
        }

        private void ButtonItem21_Click(object sender, EventArgs e)
        {
            SetMdiForm("生成二维码", typeof(Huali.DS9208.FrmBuildQRCode));
        }

        private void ButtonItem22_Click(object sender, EventArgs e)
        {
            SetMdiForm("扫描二维码", typeof(Huali.DS9208.FrmQRCodeScan));
        }

        private void ButtonItem30_Click(object sender, EventArgs e)
        {
            SetMdiForm("二维码统计", typeof(Huali.DS9208.FrmStatistics));
        }

        private void ButtonItem31_Click(object sender, EventArgs e)
        {
            SetMdiForm("查询核销状态", typeof(Huali.DS9208.FrmQueryCheckState));
        }

        #endregion


        #endregion

        #region 私有过程

        private void LoadModule()
        {
            string myModules = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "Modules");
            if (!string.IsNullOrWhiteSpace(myModules))
            {
                string[] myModule = myModules.Split(';');
                foreach (string module in myModule)
                {
                    if (module.ToLower() == ModuleName.EDI.ToString().ToLower())
                    {
                        rtiEDI.Visible = true;
                        rtiEDI.Select();
                    }
                    else if (module.ToLower() == ModuleName.EDI2.ToString().ToLower())
                    {
                        rtiEDI2.Visible = true;
                        rtiEDI2.Select();
                    }
                    else if (module.ToLower() == ModuleName.DS9208.ToString().ToLower())
                    {
                        rti9208.Visible = true;
                        rti9208.Select();
                    }
                    else if (module.ToLower() == ModuleName.DS9209.ToString().ToLower())
                    {
                        rti9209.Visible = true;
                        rti9209.Select();
                    }
                    else
                    {
                        CustomDesktopAlert.H2(module.ToLower() + "不能识别的应用模块！");
                    }
                }

            }
            else
            {
                CustomDesktopAlert.H2("应用程序加载模块出错！");
            }
        }


        /// <summary>
        /// 创建或者显示一个多文档界面页面
        /// </summary>
        /// <param name="caption">窗体标题</param>
        /// <param name="formType">窗体类型</param>
        public void SetMdiForm(string caption, Type formType)
        {
            bool IsOpened = false;

            //遍历现有的Tab页面，如果存在，那么设置为选中即可
            foreach (SuperTabItem tabitem in NavTabControl.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    NavTabControl.SelectedTab = tabitem;
                    IsOpened = true;
                    break;
                }
            }

            //如果在现有Tab页面中没有找到，那么就要初始化了Tab页面了
            if (!IsOpened)
            {
                //为了方便管理，调用LoadMdiForm函数来创建一个新的窗体，并作为MDI的子窗体
                //然后分配给SuperTab控件，创建一个SuperTabItem并显示
                DevComponents.DotNetBar.Office2007Form form = ChildWinManagement.LoadMdiForm(this, formType)
                    as DevComponents.DotNetBar.Office2007Form;

                SuperTabItem tabItem = NavTabControl.CreateTab(caption);
                tabItem.Name = caption;
                tabItem.Text = caption;

                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                //tabItem.Icon = form.Icon;
                tabItem.AttachedControl.Controls.Add(form);

                NavTabControl.SelectedTab = tabItem;
            }
        }

        /// <summary>
        /// 窗体加载时，检查样式
        /// </summary>
        private void GetStyleSetting()
        {
            this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
            string managerStyle = this.styleManager1.ManagerStyle.ToString();
            for (int i = 0; i < buttonItem1.SubItems.Count - 1; i++)
            {
                if (managerStyle is string && managerStyle == buttonItem1.SubItems[i].CommandParameter.ToString())
                {
                    ButtonItem bi = (ButtonItem)buttonItem1.SubItems[i];
                    bi.Checked = true;
                }
            }

        }






        #endregion

    }
    public enum ModuleName
    {
        EDI,
        EDI2,
        DS9208,
        DS9209,
        checkmailstat,
    }
}
