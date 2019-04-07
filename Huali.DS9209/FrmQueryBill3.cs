using DevComponents.DotNetBar;
using Ryan.Framework.Common;
using Ryan.Framework.DBUtility;
using System;
using System.Data;
using System.Windows.Forms;

namespace Huali.DS9209
{
    /// <summary>
    /// �ϲ���Ƭ/����Һ����
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
        private static readonly string conn = SqlHelper.GetConnectionString("DS9209");

        private void ButtonX1_Click(object sender, EventArgs e)
        {
            string startDate = dateTimeInput1.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dateTimeInput2.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            if (startDate != "0001-01-01" && endDate != "0001-01-01")
            {
                //string sqlDS9208 = string.Format("SELECT [����],[������λ],[���ݱ��],sum([ʵ������]) as Ӧɨ����, sum([FActQty]) as ʵɨ����  FROM [dbo].[icstock]  where [����] >= '{0} 00:00:00' and [����] <= '{1} 23:59:59' and [ʵ������] > 0 and [��Ʒ���] Like '02%' group by [����],[������λ],[���ݱ��] order by [����],[������λ],[���ݱ��]", startDate, endDate);
                string sqlDS9209 = string.Format("SELECT [����],[������λ], [���ݱ��], [��Ʒ����], [ʵ������] as Ӧɨ����, [FActQty] as ʵɨ����  FROM [dbo].[icstock]  where [����] >= '{0} 00:00:00' and [����] <= '{1} 23:59:59' and [ʵ������] > 0 order by [����], [������λ], [���ݱ��], [��Ʒ����]", startDate, endDate);
                sql =  sqlDS9209;
                dt = SqlHelper.ExecuteDataTable(conn,sql);
                dataGridViewX1.DataSource = dt;
                dataGridViewX1.Columns["������λ"].Width = 300;
                dataGridViewX1.Columns["����"].Width = 200;
                dataGridViewX1.Columns["��Ʒ����"].Width = 300;
                
                foreach (DataGridViewRow Datagridviewrow in dataGridViewX1.Rows)
                {
                    Datagridviewrow.Selected = false;

                    if (int.Parse(Datagridviewrow.Cells["Ӧɨ����"].Value.ToString()) != int.Parse(Datagridviewrow.Cells["ʵɨ����"].Value.ToString()))
                    {
                        Datagridviewrow.Selected = true;
                    }
                }
            }
            else
            {
                CustomDesktopAlert.H2("��������Ч�Ŀ�ʼʱ��ͽ���ʱ�䣡");
            }
        }
    }
}