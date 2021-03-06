using DevComponents.DotNetBar;
using Huali.Common;
using Ryan.Framework.DotNetFx20.Common;
using Ryan.Framework.DotNetFx20.DBUtility;
using System;
using System.Data;
using System.Windows.Forms;

namespace Huali.DS9208
{
    /// <summary>
    /// 合并镜片/护理液程序
    /// 
    /// </summary>
    public partial class FrmQueryBill3 : Office2007Form
    {
        public FrmQueryBill3()
        {
            InitializeComponent();
        }
        string sql = "";
        DataTable dt = new DataTable();
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");


        private void ButtonX1_Click(object sender, EventArgs e)
        {
            string startDate = dateTimeInput1.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dateTimeInput2.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            if (startDate != "0001-01-01" && endDate != "0001-01-01")
            {
                string sqlDS9208 = string.Format("SELECT [日期],[购货单位],[单据编号],sum([实发数量]) as 应扫数量, sum([FActQty]) as 实扫数量  FROM [dbo].[icstock]  where [日期] >= '{0} 00:00:00' and [日期] <= '{1} 23:59:59' and [实发数量] > 0 and [产品编号] Like '02%' group by [日期],[购货单位],[单据编号] order by [日期],[购货单位],[单据编号]", startDate, endDate);
                //string sqlDS9209 = string.Format("SELECT [日期],[购货单位], [单据编号], [产品名称], [实发数量] as 应扫数量, [FActQty] as 实扫数量  FROM [dbo].[icstock]  where [日期] >= '{0} 00:00:00' and [日期] <= '{1} 23:59:59' and [实发数量] > 0 order by [日期], [购货单位], [单据编号], [产品名称]", startDate, endDate);
                sql = sqlDS9208;
                dt = SqlHelper.ExecuteDataTable(conn,sql);
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["购货单位"].Width = 300;
                dataGridViewX1.Columns["日期"].Width = 200;
                if (CommonProcess.ModuleIsExist("9209") == true)
                {
                    dataGridViewX1.Columns["产品名称"].Width = 300;
                }
                
                foreach (DataGridViewRow Datagridviewrow in dataGridViewX1.Rows)
                {
                    Datagridviewrow.Selected = false;

                    if (int.Parse(Datagridviewrow.Cells["应扫数量"].Value.ToString()) != int.Parse(Datagridviewrow.Cells["实扫数量"].Value.ToString()))
                    {
                        Datagridviewrow.Selected = true;
                    }
                }
            }
            else
            {
                CustomDesktopAlert.H2("请输入有效的开始时间和结束时间！");
            }
        }
    }
}