﻿namespace EAS2WISE
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.RibbonControlMain = new DevComponents.DotNetBar.RibbonControl();
            this.ButtonItemTheme = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2016 = new DevComponents.DotNetBar.ButtonItem();
            this.CommandTheme = new DevComponents.DotNetBar.Command(this.components);
            this.ButtonItemThemeMetro = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2010Silver = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2010Black = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeVisualStudio2010Blue = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeWindows7Blue = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2007Blue = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2007Black = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2007Silver = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeOffice2007VistaGlass = new DevComponents.DotNetBar.ButtonItem();
            this.ButtonItemThemeVisualStudio2012Light = new DevComponents.DotNetBar.ButtonItem();
            this.ColorPickerDropDownMoreStyle = new DevComponents.DotNetBar.ColorPickerDropDown();
            this.SwitchButtonItemRibbonState = new DevComponents.DotNetBar.SwitchButtonItem();
            this.CommandRibbonState = new DevComponents.DotNetBar.Command(this.components);
            this.StyleManagerMain = new DevComponents.DotNetBar.StyleManager(this.components);
            this.BarStatus = new DevComponents.DotNetBar.Bar();
            this.SuperTabControlNavi = new DevComponents.DotNetBar.SuperTabControl();
            this.biWhanInCome = new DevComponents.DotNetBar.ButtonItem();
            this.buttonItem1 = new DevComponents.DotNetBar.ButtonItem();
            this.tiVoucherExchange = new DevComponents.DotNetBar.RibbonTabItem();
            this.ribbonPanel1 = new DevComponents.DotNetBar.RibbonPanel();
            this.ribbonBar1 = new DevComponents.DotNetBar.RibbonBar();
            this.buttonItem2 = new DevComponents.DotNetBar.ButtonItem();
            this.RibbonControlMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperTabControlNavi)).BeginInit();
            this.ribbonPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // RibbonControlMain
            // 
            this.RibbonControlMain.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            // 
            // 
            // 
            this.RibbonControlMain.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.RibbonControlMain.CaptionVisible = true;
            this.RibbonControlMain.Controls.Add(this.ribbonPanel1);
            this.RibbonControlMain.Dock = System.Windows.Forms.DockStyle.Top;
            this.RibbonControlMain.ForeColor = System.Drawing.Color.Black;
            this.RibbonControlMain.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.tiVoucherExchange,
            this.ButtonItemTheme,
            this.SwitchButtonItemRibbonState});
            this.RibbonControlMain.KeyTipsFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RibbonControlMain.Location = new System.Drawing.Point(0, 0);
            this.RibbonControlMain.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.RibbonControlMain.Name = "RibbonControlMain";
            this.RibbonControlMain.RibbonStripFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.RibbonControlMain.Size = new System.Drawing.Size(1517, 164);
            this.RibbonControlMain.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.RibbonControlMain.SystemText.MaximizeRibbonText = "&Maximize the Ribbon";
            this.RibbonControlMain.SystemText.MinimizeRibbonText = "Mi&nimize the Ribbon";
            this.RibbonControlMain.SystemText.QatAddItemText = "&Add to Quick Access Toolbar";
            this.RibbonControlMain.SystemText.QatCustomizeMenuLabel = "<b>Customize Quick Access Toolbar</b>";
            this.RibbonControlMain.SystemText.QatCustomizeText = "&Customize Quick Access Toolbar...";
            this.RibbonControlMain.SystemText.QatDialogAddButton = "&Add >>";
            this.RibbonControlMain.SystemText.QatDialogCancelButton = "Cancel";
            this.RibbonControlMain.SystemText.QatDialogCaption = "Customize Quick Access Toolbar";
            this.RibbonControlMain.SystemText.QatDialogCategoriesLabel = "&Choose commands from:";
            this.RibbonControlMain.SystemText.QatDialogOkButton = "OK";
            this.RibbonControlMain.SystemText.QatDialogPlacementCheckbox = "&Place Quick Access Toolbar below the Ribbon";
            this.RibbonControlMain.SystemText.QatDialogRemoveButton = "&Remove";
            this.RibbonControlMain.SystemText.QatPlaceAboveRibbonText = "&Place Quick Access Toolbar above the Ribbon";
            this.RibbonControlMain.SystemText.QatPlaceBelowRibbonText = "&Place Quick Access Toolbar below the Ribbon";
            this.RibbonControlMain.SystemText.QatRemoveItemText = "&Remove from Quick Access Toolbar";
            this.RibbonControlMain.TabGroupHeight = 14;
            this.RibbonControlMain.TabIndex = 0;
            this.RibbonControlMain.Text = "ribbonControl";
            // 
            // ButtonItemTheme
            // 
            this.ButtonItemTheme.AutoExpandOnClick = true;
            this.ButtonItemTheme.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.ButtonItemTheme.Name = "ButtonItemTheme";
            this.ButtonItemTheme.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.ButtonItemThemeOffice2016,
            this.ButtonItemThemeMetro,
            this.ButtonItemThemeOffice2010Blue,
            this.ButtonItemThemeOffice2010Silver,
            this.ButtonItemThemeOffice2010Black,
            this.ButtonItemThemeVisualStudio2010Blue,
            this.ButtonItemThemeWindows7Blue,
            this.ButtonItemThemeOffice2007Blue,
            this.ButtonItemThemeOffice2007Black,
            this.ButtonItemThemeOffice2007Silver,
            this.ButtonItemThemeOffice2007VistaGlass,
            this.ButtonItemThemeVisualStudio2012Light,
            this.ColorPickerDropDownMoreStyle});
            this.ButtonItemTheme.Text = "样式";
            // 
            // ButtonItemThemeOffice2016
            // 
            this.ButtonItemThemeOffice2016.Checked = true;
            this.ButtonItemThemeOffice2016.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2016.CommandParameter = "Office2016";
            this.ButtonItemThemeOffice2016.Name = "ButtonItemThemeOffice2016";
            this.ButtonItemThemeOffice2016.OptionGroup = "style";
            this.ButtonItemThemeOffice2016.Text = "Office 2016";
            // 
            // CommandTheme
            // 
            this.CommandTheme.Name = "CommandTheme";
            this.CommandTheme.Executed += new System.EventHandler(this.AppCommandTheme_Executed);
            // 
            // ButtonItemThemeMetro
            // 
            this.ButtonItemThemeMetro.Command = this.CommandTheme;
            this.ButtonItemThemeMetro.CommandParameter = "Metro";
            this.ButtonItemThemeMetro.Name = "ButtonItemThemeMetro";
            this.ButtonItemThemeMetro.OptionGroup = "style";
            this.ButtonItemThemeMetro.Text = "Metro/Office 2013";
            // 
            // ButtonItemThemeOffice2010Blue
            // 
            this.ButtonItemThemeOffice2010Blue.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2010Blue.CommandParameter = "Office2010Blue";
            this.ButtonItemThemeOffice2010Blue.Name = "ButtonItemThemeOffice2010Blue";
            this.ButtonItemThemeOffice2010Blue.OptionGroup = "style";
            this.ButtonItemThemeOffice2010Blue.Text = "Office 2010 Blue";
            // 
            // ButtonItemThemeOffice2010Silver
            // 
            this.ButtonItemThemeOffice2010Silver.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2010Silver.CommandParameter = "Office2010Silver";
            this.ButtonItemThemeOffice2010Silver.Name = "ButtonItemThemeOffice2010Silver";
            this.ButtonItemThemeOffice2010Silver.OptionGroup = "style";
            this.ButtonItemThemeOffice2010Silver.Text = "Office 2010 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // ButtonItemThemeOffice2010Black
            // 
            this.ButtonItemThemeOffice2010Black.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2010Black.CommandParameter = "Office2010Black";
            this.ButtonItemThemeOffice2010Black.Name = "ButtonItemThemeOffice2010Black";
            this.ButtonItemThemeOffice2010Black.OptionGroup = "style";
            this.ButtonItemThemeOffice2010Black.Text = "Office 2010 Black";
            // 
            // ButtonItemThemeVisualStudio2010Blue
            // 
            this.ButtonItemThemeVisualStudio2010Blue.Command = this.CommandTheme;
            this.ButtonItemThemeVisualStudio2010Blue.CommandParameter = "VisualStudio2010Blue";
            this.ButtonItemThemeVisualStudio2010Blue.Name = "ButtonItemThemeVisualStudio2010Blue";
            this.ButtonItemThemeVisualStudio2010Blue.OptionGroup = "style";
            this.ButtonItemThemeVisualStudio2010Blue.Text = "Visual Studio 2010";
            // 
            // ButtonItemThemeWindows7Blue
            // 
            this.ButtonItemThemeWindows7Blue.Command = this.CommandTheme;
            this.ButtonItemThemeWindows7Blue.CommandParameter = "Windows7Blue";
            this.ButtonItemThemeWindows7Blue.Name = "ButtonItemThemeWindows7Blue";
            this.ButtonItemThemeWindows7Blue.OptionGroup = "style";
            this.ButtonItemThemeWindows7Blue.Text = "Windows 7";
            // 
            // ButtonItemThemeOffice2007Blue
            // 
            this.ButtonItemThemeOffice2007Blue.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2007Blue.CommandParameter = "Office2007Blue";
            this.ButtonItemThemeOffice2007Blue.Name = "ButtonItemThemeOffice2007Blue";
            this.ButtonItemThemeOffice2007Blue.OptionGroup = "style";
            this.ButtonItemThemeOffice2007Blue.Text = "Office 2007 <font color=\"Blue\"><b>Blue</b></font>";
            // 
            // ButtonItemThemeOffice2007Black
            // 
            this.ButtonItemThemeOffice2007Black.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2007Black.CommandParameter = "Office2007Black";
            this.ButtonItemThemeOffice2007Black.Name = "ButtonItemThemeOffice2007Black";
            this.ButtonItemThemeOffice2007Black.OptionGroup = "style";
            this.ButtonItemThemeOffice2007Black.Text = "Office 2007 <font color=\"black\"><b>Black</b></font>";
            // 
            // ButtonItemThemeOffice2007Silver
            // 
            this.ButtonItemThemeOffice2007Silver.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2007Silver.CommandParameter = "Office2007Silver";
            this.ButtonItemThemeOffice2007Silver.Name = "ButtonItemThemeOffice2007Silver";
            this.ButtonItemThemeOffice2007Silver.OptionGroup = "style";
            this.ButtonItemThemeOffice2007Silver.Text = "Office 2007 <font color=\"Silver\"><b>Silver</b></font>";
            // 
            // ButtonItemThemeOffice2007VistaGlass
            // 
            this.ButtonItemThemeOffice2007VistaGlass.Command = this.CommandTheme;
            this.ButtonItemThemeOffice2007VistaGlass.CommandParameter = "Office2007VistaGlass";
            this.ButtonItemThemeOffice2007VistaGlass.Name = "ButtonItemThemeOffice2007VistaGlass";
            this.ButtonItemThemeOffice2007VistaGlass.OptionGroup = "style";
            this.ButtonItemThemeOffice2007VistaGlass.Text = "Vista Glass";
            // 
            // ButtonItemThemeVisualStudio2012Light
            // 
            this.ButtonItemThemeVisualStudio2012Light.Command = this.CommandTheme;
            this.ButtonItemThemeVisualStudio2012Light.CommandParameter = "VisualStudio2012Light";
            this.ButtonItemThemeVisualStudio2012Light.Name = "ButtonItemThemeVisualStudio2012Light";
            this.ButtonItemThemeVisualStudio2012Light.OptionGroup = "style";
            this.ButtonItemThemeVisualStudio2012Light.Text = "Visual Studio 2012 Light";
            // 
            // ColorPickerDropDownMoreStyle
            // 
            this.ColorPickerDropDownMoreStyle.BeginGroup = true;
            this.ColorPickerDropDownMoreStyle.Name = "ColorPickerDropDownMoreStyle";
            this.ColorPickerDropDownMoreStyle.Text = "自定义";
            this.ColorPickerDropDownMoreStyle.Tooltip = "Custom color scheme is created based on currently selected color table. Try selec" +
    "ting Silver or Blue color table and then creating custom color scheme.";
            // 
            // SwitchButtonItemRibbonState
            // 
            this.SwitchButtonItemRibbonState.ButtonHeight = 24;
            this.SwitchButtonItemRibbonState.ButtonWidth = 80;
            this.SwitchButtonItemRibbonState.Command = this.CommandRibbonState;
            this.SwitchButtonItemRibbonState.ItemAlignment = DevComponents.DotNetBar.eItemAlignment.Far;
            this.SwitchButtonItemRibbonState.Margin.Bottom = 2;
            this.SwitchButtonItemRibbonState.Margin.Left = 4;
            this.SwitchButtonItemRibbonState.Name = "SwitchButtonItemRibbonState";
            this.SwitchButtonItemRibbonState.OffText = "隐藏";
            this.SwitchButtonItemRibbonState.OnText = "显示";
            this.SwitchButtonItemRibbonState.SwitchBackColor = System.Drawing.Color.Aqua;
            this.SwitchButtonItemRibbonState.Tooltip = "展开/隐藏功能面板";
            // 
            // CommandRibbonState
            // 
            this.CommandRibbonState.Name = "CommandRibbonState";
            this.CommandRibbonState.Executed += new System.EventHandler(this.CmdRibbonState_Executed);
            // 
            // StyleManagerMain
            // 
            this.StyleManagerMain.ManagerStyle = DevComponents.DotNetBar.eStyle.Office2016;
            this.StyleManagerMain.MetroColorParameters = new DevComponents.DotNetBar.Metro.ColorTables.MetroColorGeneratorParameters(System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255))))), System.Drawing.Color.FromArgb(((int)(((byte)(1)))), ((int)(((byte)(115)))), ((int)(((byte)(199))))));
            // 
            // BarStatus
            // 
            this.BarStatus.AccessibleDescription = "DotNetBar Bar (BarStatus)";
            this.BarStatus.AccessibleName = "DotNetBar Bar";
            this.BarStatus.AccessibleRole = System.Windows.Forms.AccessibleRole.StatusBar;
            this.BarStatus.AntiAlias = true;
            this.BarStatus.BarType = DevComponents.DotNetBar.eBarType.StatusBar;
            this.BarStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.BarStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BarStatus.GrabHandleStyle = DevComponents.DotNetBar.eGrabHandleStyle.ResizeHandle;
            this.BarStatus.IsMaximized = false;
            this.BarStatus.ItemSpacing = 2;
            this.BarStatus.Location = new System.Drawing.Point(0, 931);
            this.BarStatus.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.BarStatus.Name = "BarStatus";
            this.BarStatus.PaddingBottom = 0;
            this.BarStatus.PaddingTop = 0;
            this.BarStatus.Size = new System.Drawing.Size(1517, 26);
            this.BarStatus.Stretch = true;
            this.BarStatus.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BarStatus.TabIndex = 8;
            this.BarStatus.TabStop = false;
            this.BarStatus.Text = "barStatus";
            // 
            // SuperTabControlNavi
            // 
            this.SuperTabControlNavi.BackColor = System.Drawing.Color.White;
            this.SuperTabControlNavi.CloseButtonOnTabsVisible = true;
            // 
            // 
            // 
            // 
            // 
            // 
            this.SuperTabControlNavi.ControlBox.CloseBox.Name = "";
            // 
            // 
            // 
            this.SuperTabControlNavi.ControlBox.MenuBox.Name = "";
            this.SuperTabControlNavi.ControlBox.Name = "";
            this.SuperTabControlNavi.ControlBox.SubItems.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.SuperTabControlNavi.ControlBox.MenuBox,
            this.SuperTabControlNavi.ControlBox.CloseBox});
            this.SuperTabControlNavi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SuperTabControlNavi.ForeColor = System.Drawing.Color.Black;
            this.SuperTabControlNavi.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.SuperTabControlNavi.Location = new System.Drawing.Point(0, 164);
            this.SuperTabControlNavi.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.SuperTabControlNavi.Name = "SuperTabControlNavi";
            this.SuperTabControlNavi.ReorderTabsEnabled = true;
            this.SuperTabControlNavi.SelectedTabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SuperTabControlNavi.SelectedTabIndex = -1;
            this.SuperTabControlNavi.Size = new System.Drawing.Size(1517, 767);
            this.SuperTabControlNavi.TabFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.SuperTabControlNavi.TabIndex = 11;
            this.SuperTabControlNavi.Text = "superTabControl1";
            // 
            // biWhanInCome
            // 
            this.biWhanInCome.Name = "biWhanInCome";
            this.biWhanInCome.SubItemsExpandWidth = 14;
            this.biWhanInCome.Text = "商品入库单";
            // 
            // buttonItem1
            // 
            this.buttonItem1.Name = "buttonItem1";
            this.buttonItem1.SubItemsExpandWidth = 14;
            this.buttonItem1.Text = "销售出库单";
            // 
            // tiVoucherExchange
            // 
            this.tiVoucherExchange.Checked = true;
            this.tiVoucherExchange.Name = "tiVoucherExchange";
            this.tiVoucherExchange.Panel = this.ribbonPanel1;
            this.tiVoucherExchange.Text = "K3凭证转换";
            // 
            // ribbonPanel1
            // 
            this.ribbonPanel1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonPanel1.Controls.Add(this.ribbonBar1);
            this.ribbonPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ribbonPanel1.Location = new System.Drawing.Point(0, 87);
            this.ribbonPanel1.Name = "ribbonPanel1";
            this.ribbonPanel1.Padding = new System.Windows.Forms.Padding(3, 0, 3, 3);
            this.ribbonPanel1.Size = new System.Drawing.Size(1517, 77);
            // 
            // 
            // 
            this.ribbonPanel1.Style.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseDown.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonPanel1.StyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonPanel1.TabIndex = 1;
            // 
            // ribbonBar1
            // 
            this.ribbonBar1.AutoOverflowEnabled = true;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundMouseOverStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.ribbonBar1.ContainerControlProcessDialogKey = true;
            this.ribbonBar1.Dock = System.Windows.Forms.DockStyle.Left;
            this.ribbonBar1.DragDropSupport = true;
            this.ribbonBar1.Items.AddRange(new DevComponents.DotNetBar.BaseItem[] {
            this.buttonItem2});
            this.ribbonBar1.LicenseKey = "F962CEC7-CD8F-4911-A9E9-CAB39962FC1F";
            this.ribbonBar1.Location = new System.Drawing.Point(3, 0);
            this.ribbonBar1.Name = "ribbonBar1";
            this.ribbonBar1.Size = new System.Drawing.Size(152, 74);
            this.ribbonBar1.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.ribbonBar1.TabIndex = 0;
            this.ribbonBar1.Text = "凭证转换";
            // 
            // 
            // 
            this.ribbonBar1.TitleStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // 
            // 
            this.ribbonBar1.TitleStyleMouseOver.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            // 
            // buttonItem2
            // 
            this.buttonItem2.Name = "buttonItem2";
            this.buttonItem2.SubItemsExpandWidth = 14;
            this.buttonItem2.Text = "EAS转WISE";
            this.buttonItem2.Click += new System.EventHandler(this.ButtonItem2_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 28F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CaptionFont = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.ClientSize = new System.Drawing.Size(1517, 957);
            this.Controls.Add(this.SuperTabControlNavi);
            this.Controls.Add(this.BarStatus);
            this.Controls.Add(this.RibbonControlMain);
            this.DoubleBuffered = true;
            this.EnableGlass = false;
            this.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Margin = new System.Windows.Forms.Padding(7, 7, 7, 7);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form_Main_Load);
            this.RibbonControlMain.ResumeLayout(false);
            this.RibbonControlMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.BarStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.SuperTabControlNavi)).EndInit();
            this.ribbonPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.RibbonControl RibbonControlMain;
        private DevComponents.DotNetBar.StyleManager StyleManagerMain;
        private DevComponents.DotNetBar.ButtonItem ButtonItemTheme;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2016;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeMetro;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2010Blue;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2010Silver;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2010Black;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeVisualStudio2010Blue;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeWindows7Blue;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2007Blue;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2007Black;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2007Silver;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeOffice2007VistaGlass;
        private DevComponents.DotNetBar.ButtonItem ButtonItemThemeVisualStudio2012Light;
        private DevComponents.DotNetBar.ColorPickerDropDown ColorPickerDropDownMoreStyle;
        private DevComponents.DotNetBar.Command CommandTheme;
        private DevComponents.DotNetBar.Bar BarStatus;
        private DevComponents.DotNetBar.SuperTabControl SuperTabControlNavi;
        private DevComponents.DotNetBar.SwitchButtonItem SwitchButtonItemRibbonState;
        private DevComponents.DotNetBar.Command CommandRibbonState;
        private DevComponents.DotNetBar.ButtonItem biWhanInCome;
        private DevComponents.DotNetBar.ButtonItem buttonItem1;
        private DevComponents.DotNetBar.RibbonPanel ribbonPanel1;
        private DevComponents.DotNetBar.RibbonBar ribbonBar1;
        private DevComponents.DotNetBar.RibbonTabItem tiVoucherExchange;
        private DevComponents.DotNetBar.ButtonItem buttonItem2;
    }
}