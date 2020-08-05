using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Common;
using Ryan.Framework.DotNetFx40.Config;
using Ryan.Framework.DotNetFx40.Encrypt;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace EAS2WISE
{
    public partial class FormMain : Office2007Form
    {
        public FormMain()
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
            //this.RibbonControlMain.TitleText = EncryptHelper.Decrypt(ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "AppName"));
            ////获取窗口样式
            //GetStyleSetting();
            //LoadModule();
            UserLogin();
            //xia
            //ButtonItem1_Click(sender, e);
            //xu
            //ButtonItemVoucherImport_Click(sender, e);
            //suai
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

                    RibbonControlMain.RibbonStripFont = new System.Drawing.Font("Segoe UI", 9.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                    if (style == eStyle.Metro)
                        StyleManager.MetroColorGeneratorParameters = DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters.DarkBlue;

                    // Adjust size of switch button to match Metro styling
                    SwitchButtonItemRibbonState.SwitchWidth = 16;
                    SwitchButtonItemRibbonState.ButtonWidth = 48;
                    SwitchButtonItemRibbonState.ButtonHeight = 19;

                    // Adjust tab strip style
                    //TabStrip1.Style = eTabStripStyle.Metro;

                    StyleManager.Style = style; // BOOM
                }
                else
                {
                    // If previous style was Metro we need to update other properties as well
                    if (StyleManager.IsMetro(StyleManager.Style))
                    {
                        RibbonControlMain.RibbonStripFont = null;
                        // Fix capitalization App Button and tab
                        //buttonFile.Text = ToTitleCase(buttonFile.Text);
                    foreach (BaseItem item in RibbonControl.Items)
                    {
                        // Ribbon Control may contain items other than tabs so that needs to be taken in account
                        //RibbonTabItem tab = item as RibbonTabItem;
                        //if (tab != null)
                        //    tab.Text = ToTitleCase(tab.Text);
                    }
                        // Adjust size of switch button to match Office styling
                        SwitchButtonItemRibbonState.SwitchWidth = 28;
                        SwitchButtonItemRibbonState.ButtonWidth = 62;
                        SwitchButtonItemRibbonState.ButtonHeight = 20;
                    }
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
                    if (module.ToLower() == "客户信息迁移")
                    {
                        //RibbonBarMain.Visible = true;
                        //ButtonItemDataUpgard.FixedSize = new Size(120, 180);
                        //ButtonItemDataComp.FixedSize = new Size(120, 180);
                        //rtiEDI.Select();
                    }
                    else if (module.ToLower() == "凭证迁移")
                    {
                        //ribbonBar1.Visible = true;
                        //buttonItemVoucherUpdate.FixedSize = new Size(120, 180);
                        //rtiEDI2.Select();
                    }
                    else if (module.ToLower() == "导入凭证")
                    {
                        //ribbonBar2.Visible = true;
                        //ButtonItemVoucherImport.FixedSize = new Size(120, 180);
                        //rti9208.Select();
                        
                    }
                    else
                    {
                        CustomDesktopAlert.H4(module.ToLower() + "不能识别的应用模块！");
                    }
                }

            }
            else
            {
                CustomDesktopAlert.H4("应用程序加载模块出错！");
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
            foreach (SuperTabItem tabitem in SuperTabControlNavi.Tabs)
            {
                if (tabitem.Name == caption)
                {
                    SuperTabControlNavi.SelectedTab = tabitem;
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

                SuperTabItem tabItem = SuperTabControlNavi.CreateTab(caption);
                tabItem.Name = caption;
                tabItem.Text = caption;

                form.FormBorderStyle = FormBorderStyle.None;
                form.TopLevel = false;
                form.Visible = true;
                form.Dock = DockStyle.Fill;
                //tabItem.Icon = form.Icon;
                tabItem.AttachedControl.Controls.Add(form);

                SuperTabControlNavi.SelectedTab = tabItem;
            }
        }

        /// <summary>
        /// 窗体加载时，检查样式
        /// </summary>
        private void GetStyleSetting()
        {
            this.StyleManagerMain.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
            string managerStyle = this.StyleManagerMain.ManagerStyle.ToString();
            for (int i = 0; i < ButtonItemTheme.SubItems.Count - 1; i++)
            {
                if (managerStyle is string && managerStyle == ButtonItemTheme.SubItems[i].CommandParameter.ToString())
                {
                    ButtonItem bi = (ButtonItem)ButtonItemTheme.SubItems[i];
                    bi.Checked = true;
                }
            }

        }






        #endregion

        private void BiDateComp_Click(object sender, EventArgs e)
        {
            ///SetMdiForm("数据对比", typeof(FrmDataCompare));
            CmdRibbonState_Executed(sender, e);
        }

        private void ButtonItem15_Click(object sender, EventArgs e)
        {
            ///SetMdiForm("数据迁移", typeof(FrmDataExport));
            CmdRibbonState_Executed(sender, e);
        }


        /// <summary>
        /// 控制是否显示RibbonControl
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CmdRibbonState_Executed(object sender, EventArgs e)
        {
            RibbonControlMain.Expanded = CommandRibbonState.Checked;
            CommandRibbonState.Checked = !CommandRibbonState.Checked;
        }

        private void ButtonItem1_Click(object sender, EventArgs e)
        {
            ///SetMdiForm("凭证迁移", typeof(FormVoucher));
            CmdRibbonState_Executed(sender, e);
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        public void UserLogin()
        {
            //用户登录
            FormLogin login = new FormLogin();
            if (login.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
            }
            else
            {
                this.Close();
            }
        }

        private void ButtonItemVoucherImport_Click(object sender, EventArgs e)
        {
            //SetMdiForm("凭证导入", typeof(FormVoucherImport));
            CmdRibbonState_Executed(sender, e);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void biWHStockIn_Click(object sender, EventArgs e)
        {
            SetMdiForm("导入武汉分公司商品入库单", typeof(FormStockIn));
            //CmdRibbonState_Executed(sender, e);
        }
    }
}