namespace Aohua
{
    partial class FrmDataExport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.panelEx1 = new DevComponents.DotNetBar.PanelEx();
            this.labelX2 = new DevComponents.DotNetBar.LabelX();
            this.labelX1 = new DevComponents.DotNetBar.LabelX();
            this.dtiStartDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.dtiEndDate = new DevComponents.Editors.DateTimeAdv.DateTimeInput();
            this.BExpData = new DevComponents.DotNetBar.ButtonX();
            this.BtnUnMark = new DevComponents.DotNetBar.ButtonX();
            this.BtnMark = new DevComponents.DotNetBar.ButtonX();
            this.dataGridViewX1 = new DevComponents.DotNetBar.Controls.DataGridViewX();
            this.panelEx1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtiStartDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiEndDate)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).BeginInit();
            this.SuspendLayout();
            // 
            // panelEx1
            // 
            this.panelEx1.CanvasColor = System.Drawing.SystemColors.Control;
            this.panelEx1.ColorSchemeStyle = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.panelEx1.Controls.Add(this.labelX2);
            this.panelEx1.Controls.Add(this.labelX1);
            this.panelEx1.Controls.Add(this.dtiStartDate);
            this.panelEx1.Controls.Add(this.dtiEndDate);
            this.panelEx1.Controls.Add(this.BExpData);
            this.panelEx1.Controls.Add(this.BtnUnMark);
            this.panelEx1.Controls.Add(this.BtnMark);
            this.panelEx1.DisabledBackColor = System.Drawing.Color.Empty;
            this.panelEx1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelEx1.Location = new System.Drawing.Point(0, 0);
            this.panelEx1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelEx1.Name = "panelEx1";
            this.panelEx1.Size = new System.Drawing.Size(2510, 134);
            this.panelEx1.Style.Alignment = System.Drawing.StringAlignment.Center;
            this.panelEx1.Style.BackColor1.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.panelEx1.Style.Border = DevComponents.DotNetBar.eBorderType.SingleLine;
            this.panelEx1.Style.BorderColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBorder;
            this.panelEx1.Style.ForeColor.ColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelText;
            this.panelEx1.Style.GradientAngle = 90;
            this.panelEx1.TabIndex = 0;
            // 
            // labelX2
            // 
            // 
            // 
            // 
            this.labelX2.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX2.Location = new System.Drawing.Point(678, 44);
            this.labelX2.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelX2.Name = "labelX2";
            this.labelX2.Size = new System.Drawing.Size(180, 46);
            this.labelX2.TabIndex = 7;
            this.labelX2.Text = "结束时间：";
            // 
            // labelX1
            // 
            // 
            // 
            // 
            this.labelX1.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.labelX1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelX1.Location = new System.Drawing.Point(36, 44);
            this.labelX1.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.labelX1.Name = "labelX1";
            this.labelX1.Size = new System.Drawing.Size(178, 46);
            this.labelX1.TabIndex = 6;
            this.labelX1.Text = "起始时间：";
            // 
            // dtiStartDate
            // 
            // 
            // 
            // 
            this.dtiStartDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiStartDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiStartDate.ButtonDropDown.Visible = true;
            this.dtiStartDate.CustomFormat = "yyyy-MM-dd";
            this.dtiStartDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtiStartDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiStartDate.IsPopupCalendarOpen = false;
            this.dtiStartDate.Location = new System.Drawing.Point(246, 40);
            this.dtiStartDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiStartDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiStartDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiStartDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 4, 1, 0, 0, 0, 0);
            this.dtiStartDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtiStartDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiStartDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiStartDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiStartDate.MonthCalendar.TodayButtonVisible = true;
            this.dtiStartDate.Name = "dtiStartDate";
            this.dtiStartDate.Size = new System.Drawing.Size(400, 44);
            this.dtiStartDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiStartDate.TabIndex = 5;
            // 
            // dtiEndDate
            // 
            // 
            // 
            // 
            this.dtiEndDate.BackgroundStyle.Class = "DateTimeInputBackground";
            this.dtiEndDate.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndDate.ButtonDropDown.Shortcut = DevComponents.DotNetBar.eShortcut.AltDown;
            this.dtiEndDate.ButtonDropDown.Visible = true;
            this.dtiEndDate.CustomFormat = "yyyy-MM-dd";
            this.dtiEndDate.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dtiEndDate.Format = DevComponents.Editors.eDateTimePickerFormat.Custom;
            this.dtiEndDate.IsPopupCalendarOpen = false;
            this.dtiEndDate.Location = new System.Drawing.Point(890, 40);
            this.dtiEndDate.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            // 
            // 
            // 
            // 
            // 
            // 
            this.dtiEndDate.MonthCalendar.BackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndDate.MonthCalendar.CalendarDimensions = new System.Drawing.Size(1, 1);
            this.dtiEndDate.MonthCalendar.ClearButtonVisible = true;
            // 
            // 
            // 
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground2;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarBackground;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTop = DevComponents.DotNetBar.eStyleBorderType.Solid;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.BarDockedBorder;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.BorderTopWidth = 1;
            this.dtiEndDate.MonthCalendar.CommandsBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndDate.MonthCalendar.DisplayMonth = new System.DateTime(2020, 4, 1, 0, 0, 0, 0);
            this.dtiEndDate.MonthCalendar.FirstDayOfWeek = System.DayOfWeek.Monday;
            // 
            // 
            // 
            this.dtiEndDate.MonthCalendar.NavigationBackgroundStyle.BackColor2SchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground2;
            this.dtiEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorGradientAngle = 90;
            this.dtiEndDate.MonthCalendar.NavigationBackgroundStyle.BackColorSchemePart = DevComponents.DotNetBar.eColorSchemePart.PanelBackground;
            this.dtiEndDate.MonthCalendar.NavigationBackgroundStyle.CornerType = DevComponents.DotNetBar.eCornerType.Square;
            this.dtiEndDate.MonthCalendar.TodayButtonVisible = true;
            this.dtiEndDate.Name = "dtiEndDate";
            this.dtiEndDate.Size = new System.Drawing.Size(400, 44);
            this.dtiEndDate.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.dtiEndDate.TabIndex = 4;
            // 
            // BExpData
            // 
            this.BExpData.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BExpData.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BExpData.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BExpData.Location = new System.Drawing.Point(1838, 32);
            this.BExpData.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BExpData.Name = "BExpData";
            this.BExpData.Size = new System.Drawing.Size(226, 70);
            this.BExpData.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BExpData.TabIndex = 3;
            this.BExpData.Text = "升迁数据";
            this.BExpData.Click += new System.EventHandler(this.BExpData_Click);
            // 
            // BtnUnMark
            // 
            this.BtnUnMark.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnUnMark.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnUnMark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnUnMark.Location = new System.Drawing.Point(1580, 32);
            this.BtnUnMark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnUnMark.Name = "BtnUnMark";
            this.BtnUnMark.Size = new System.Drawing.Size(226, 70);
            this.BtnUnMark.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnUnMark.TabIndex = 2;
            this.BtnUnMark.Text = "取消标记";
            this.BtnUnMark.Click += new System.EventHandler(this.BtnUnMark_Click);
            // 
            // BtnMark
            // 
            this.BtnMark.AccessibleRole = System.Windows.Forms.AccessibleRole.PushButton;
            this.BtnMark.ColorTable = DevComponents.DotNetBar.eButtonColor.OrangeWithBackground;
            this.BtnMark.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.BtnMark.Location = new System.Drawing.Point(1322, 32);
            this.BtnMark.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.BtnMark.Name = "BtnMark";
            this.BtnMark.Size = new System.Drawing.Size(226, 70);
            this.BtnMark.Style = DevComponents.DotNetBar.eDotNetBarStyle.StyleManagerControlled;
            this.BtnMark.TabIndex = 1;
            this.BtnMark.Text = "标记数据";
            this.BtnMark.Click += new System.EventHandler(this.BtnMark_Click);
            // 
            // dataGridViewX1
            // 
            this.dataGridViewX1.AllowUserToAddRows = false;
            this.dataGridViewX1.AllowUserToDeleteRows = false;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewX1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewX1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewX1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewX1.EnableHeadersVisualStyles = false;
            this.dataGridViewX1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.dataGridViewX1.Location = new System.Drawing.Point(0, 134);
            this.dataGridViewX1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridViewX1.Name = "dataGridViewX1";
            this.dataGridViewX1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewX1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewX1.RowTemplate.Height = 30;
            this.dataGridViewX1.Size = new System.Drawing.Size(2510, 862);
            this.dataGridViewX1.TabIndex = 4;
            // 
            // FrmDataExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(2510, 996);
            this.Controls.Add(this.dataGridViewX1);
            this.Controls.Add(this.panelEx1);
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FrmDataExport";
            this.Text = "FrmDataExport";
            this.panelEx1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtiStartDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dtiEndDate)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewX1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private DevComponents.DotNetBar.PanelEx panelEx1;
        private DevComponents.DotNetBar.Controls.DataGridViewX dataGridViewX1;
        private DevComponents.DotNetBar.ButtonX BtnUnMark;
        private DevComponents.DotNetBar.ButtonX BtnMark;
        private DevComponents.DotNetBar.ButtonX BExpData;
        private DevComponents.DotNetBar.LabelX labelX2;
        private DevComponents.DotNetBar.LabelX labelX1;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiStartDate;
        private DevComponents.Editors.DateTimeAdv.DateTimeInput dtiEndDate;
    }
}