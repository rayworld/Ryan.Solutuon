using Aohua.DAL;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Aohua.VoucherApp
{
    public partial class FormCustomNumberSelecterV2 : Office2007Form
    {
        public string CustomName { get; set; }
        public string CustomAddress { get; set; }
        public string CustomArea { get; set; }
        public int AccountID { get; set; }
        public int ItemClassID { get; set; }
        public int CustomID { get; set; }
        public DataTable dt = new DataTable();

        public FormCustomNumberSelecterV2(string customName, string customAddress , string customArea)
        {
            InitializeComponent();
            CustomName = customName;
            CustomAddress = customAddress;
            CustomArea = customArea;
        }

        private void DataGridViewX1_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridViewX)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                               dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font,
                rect, e.InheritedRowStyle.ForeColor,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter
                );
            }
        }

        private void DataGridViewX1_MouseDoubleClick(object sender, MouseEventArgs e)
        {



        }

        private void FormCustomNumberSelecterV2_Load(object sender, System.EventArgs e)
        {
            //用客户名称查询
            TextBoxXCustName.Text = CustomName;
            dt = VoucherEntries.GetCustomListByCustomNameQueryStringCustomArea(TextBoxXCustName.Text, CustomArea);
            DataGridViewXQueryData.DataSource = dt;
        }

        private void ButtonXQuery_Click(object sender, System.EventArgs e)
        {
            dt= VoucherEntries.GetCustomListByCustomNameQueryStringCustomArea(TextBoxXCustName.Text, CustomArea);
            DataGridViewXQueryData.DataSource = dt;
        }


        #region 私有过程

        #endregion

        private void DataGridViewXQueryData_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            CustomID = int.Parse(DataGridViewXQueryData.Rows[e.RowIndex].Cells["客户编号"].Value.ToString());
            ItemClassID = int.Parse(DataGridViewXQueryData.Rows[e.RowIndex].Cells["客户类型号"].Value.ToString());
            AccountID = int.Parse(VoucherEntries.GetAccountIDByItemClassID(ItemClassID.ToString())); 
            if (CustomID > 0)
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
