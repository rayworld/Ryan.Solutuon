using Aohua.DAL;
using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Config;
using System;
using System.Data;

namespace Aohua.VoucherApp
{
    public partial class FormCustomNumberSelecter : Office2007Form
    {
        public int ItemID { get; set; }
        public int AccountID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="accountID"></param>
        public FormCustomNumberSelecter(int accountID)
        {
            InitializeComponent();
            AccountID = accountID;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormCustomNumberSelecter_Load(object sender, EventArgs e)
        {
            this.StyleManagerMain.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
            //CustomDesktopAlert.H2(AccountID.ToString());
            DataTable dt = VoucherEntries.GetNewItemClassIDLast20Item(AccountID);
            dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].Visible = false;
            dataGridViewX1.Columns[1].Width = 260;
            dataGridViewX1.Columns[2].Width = 460;
        }

        private void DataGridViewX1_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            ItemID = int.Parse(dataGridViewX1.SelectedRows[0].Cells[0].Value.ToString());
            if(ItemID > 0)
            {
                this.DialogResult = System.Windows.Forms.DialogResult.OK;
                this.Close();
            }
        }
    }
}