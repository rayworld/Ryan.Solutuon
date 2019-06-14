using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Common;
using Ryan.Framework.DotNetFx40.Config;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Data;

namespace Aohua
{
    public partial class FrmDataQuery : Office2007Form
    {
        public string Finid { get; set; }

        public string FinCustName { get; set; }

        public string K3Id { get; set; }

        public string K3CustName { get; set; }

        private string sql = "";
        private static string connK3Src = SqlHelper.GetConnectionString("K3Src");

        public FrmDataQuery(string finId ,string finName)
        {
            InitializeComponent();
            Finid = finId;
            FinCustName = finName;

        }

        private void FrmDataQuery_Load(object sender, System.EventArgs e)
        {
            tbFinId.Text = Finid;
            tbFinName.Text = FinCustName;
            this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
            string CustName = tbFinName.Text;
            int Position = 0;
            if(CustName.IndexOf("(") > -1)
            {
                Position = CustName.IndexOf("(");
            }
            else if(CustName.IndexOf("（") > -1)
            {
                Position  = CustName.IndexOf("（");
            }
            else
            {
                Position = CustName.Length;
            }
            CustName = CustName.Substring(0, Position);
            tbFinName.Text = CustName.Replace("YF","").Replace("A","");
            DoQuery(CustName);
        }

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            //tbFinName.Text = FinCustName;
            DoQuery(this.FinCustName);
        }

        private void DataGridViewX1_CellDoubleClick(object sender, System.Windows.Forms.DataGridViewCellEventArgs e)
        {
            K3Id  = dataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
            K3CustName = dataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        private void DoQuery(string queryString)
        {
            if (!string.IsNullOrEmpty(queryString))
            {
                dataGridViewX1.DataSource = null;
                sql = string.Format("select FItemID as 客户号, fname as 物流客户名称 from t_Organization Where fname like '%{0}%'", queryString);
                DataTable dtQuery = SqlHelper.ExecuteDataTable(connK3Src, sql, null);
                if (dtQuery.Rows.Count > 0)
                {
                    dataGridViewX1.DataSource = dtQuery;
                    dataGridViewX1.Columns[0].Width = 80;
                    dataGridViewX1.Columns[1].Width = 260;
                }
                else
                {
                    CustomDesktopAlert.H4("没有查到任何数据！");
                }
            }
            else
            {
                CustomDesktopAlert.H4("请设置查询条件！");
            }
        }

        private void TbFinName_MouseDoubleClick(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            tbFinName.Text = this.FinCustName;
        }
    }
}
