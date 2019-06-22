using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx20.Common;
using Ryan.Framework.DotNetFx20.Config;
using Ryan.Framework.DotNetFx20.Converter;
using Ryan.Framework.DotNetFx20.DBUtility;
using System;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Youyi
{
    public partial class FrmCollect : Office2007Form
    {
        DataTable dt = new DataTable();
        public FrmCollect()
        {
            InitializeComponent();
        }

        private void FrmCollect_Load(object sender, System.EventArgs e)
        {
            //加载样式
            this.styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
        }

        /// <summary>
        /// 汇总
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX2_Click(object sender, EventArgs e)
        {
            string WhereOption = "";
            string TopOption = "";
            int Top = 100;
            string startDate = dtiBeginDate.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dtiEndDate.Value.ToString("yyyy-MM-dd").Substring(0, 10);
 
            //生成条件Sql
            WhereOption = " Where 1=1 ";

            if (startDate != "0001-01-01")
            {
                WhereOption += " And ICSale.FDate >= '" + startDate + "' ";
            }

            if (endDate != "0001-01-01")
            {
                WhereOption += " And ICSale.FDate <= '" + endDate + "' ";
            }

            if (txtBillNoBegin.Text != "")
            {
                WhereOption += " And ICSale.FBillNo >= 'ZSEFP" + txtBillNoBegin.Text + "' ";
            }

            if (txtBillNoEnd.Text != "")
            {
                WhereOption += " And ICSale.FBillNo <= 'ZSEFP" + txtBillNoEnd.Text + "' ";
            }

            if (txtCustName.Text != "")
            {
                WhereOption += " And t_Organization.FName Like '%" + txtCustName.Text + "%' ";
            }

            //限制记录条数
            object obj = SqlHelper.ExecuteScalar(BuildCountSql(WhereOption));
            int RowsCount = obj != null ? int.Parse(obj.ToString()) : 0;

            if (RowsCount > Top)
            {
                CustomDesktopAlert.H2(RowsCount.ToString() + " 条记录，已超过记录上限，<br/>系统将截取前 " + Top + " 条记录！");
                TopOption = " Top " + Top.ToString();
            }

            //执行统计
            dt = SqlHelper.ExecuteDataTable(BuildSqlV2(TopOption, WhereOption));
            this.dataGridViewX1.DataSource = dt;
            dataGridViewX1.Columns[0].Width = 340;
            dataGridViewX1.Columns[1].Width = 440;
            dataGridViewX1.Columns[2].Width = 200;
            dataGridViewX1.Columns[5].Width = 200;
            dataGridViewX1.Columns[4].DefaultCellStyle = new DataGridViewCellStyle { Alignment = DataGridViewContentAlignment.MiddleRight };
            dataGridViewX1.Columns[5].DefaultCellStyle = new DataGridViewCellStyle {Alignment = DataGridViewContentAlignment.MiddleRight };
        }

        private string BuildSqlV2(string top ,string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT ");
            sb.Append(" CASE WHEN grouping(e.大类名称) = '1' THEN '总计' ");
            sb.Append(" WHEN grouping(e.大类名称) = '0' AND grouping(e.商品名称) = '1' THEN e.大类名称 + ' 小计' ");
            sb.Append(" ELSE e.大类名称 ");
            sb.Append(" END 大类, ");
            sb.Append(" CASE WHEN grouping(e.商品名称) = '1' THEN '' ");
            sb.Append(" WHEN grouping(e.商品名称) = '0' AND grouping(e.客户名称) = '1'  THEN e.商品名称 + ' 小计' ");
            sb.Append(" ELSE e.商品名称 ");
            sb.Append(" END 商品名称, ");
            sb.Append(" CASE WHEN grouping(e.客户名称) = '1' THEN '' ");
            sb.Append(" WHEN grouping(e.客户名称) = '0' AND grouping(e.发票号) = '1'  THEN e.客户名称 + ' 小计' ");
            sb.Append(" ELSE e.客户名称 ");
            sb.Append(" END 客户名称, ");
            sb.Append(" CASE WHEN grouping(e.发票号) = '1' THEN '' ");
            sb.Append(" ELSE 发票号 ");
            sb.Append(" END 单号, ");
            sb.Append(" COUNT(数量) as 数量, ");
            sb.Append(" SUM(金额) as 金额 ");
            sb.Append(" FROM( ");
            sb.Append(" SELECT a.FDate AS 发票日期, a.FBillNo AS 发票号, a.FQty AS 数量, a.FAmount AS 金额, a.FName1 AS 商品名称, a.FFullNumber AS 商品全代码, a.FNumber1 AS 大类编号, t_Item_1.FName AS 大类名称, a.custName AS 客户名称 ");
            sb.Append(" FROM( ");
            sb.Append(" SELECT {0} ICSale.FDate, ICSale.FBillNo, ICSaleEntry.FQty, ICSaleEntry.FAmount, t_Item.fname as FName1, t_Item.FFullNumber, CASE LEN(t_Item.FFullNumber) - LEN(REPLACE(t_Item.FFullNumber, '.', '')) WHEN 2 THEN substring(t_Item.FFullNumber, 0, LEN(t_Item.FFullNumber) - 3) ELSE t_Item.FFullNumber END AS FNumber1, t_Organization.fname AS custName ");
            sb.Append(" FROM ICSale INNER JOIN ");
            sb.Append(" ICSaleEntry ON ICSale.FInterID = ICSaleEntry.FInterID INNER JOIN ");
            sb.Append(" t_Item ON ICSaleEntry.FItemID = t_Item.FItemID INNER JOIN ");
            sb.Append(" t_Organization ON ICSale.FCustID = t_Organization.FItemID {1}) AS a INNER JOIN ");
            sb.Append(" dbo.t_Item AS t_Item_1 ON a.FNumber1 = t_Item_1.FFullNumber) e ");
            sb.Append(" GROUP BY ");
            sb.Append(" e.大类名称, ");
            sb.Append(" e.商品名称, ");
            sb.Append(" e.客户名称, ");
            sb.Append(" e.发票号 ");
            sb.Append(" WITH ROLLUP ");
            sb.Append(" ORDER BY ");
            sb.Append(" e.大类名称 DESC, ");
            sb.Append(" e.商品名称 DESC, ");
            sb.Append(" e.客户名称 DESC, ");
            sb.Append(" e.发票号 DESC ");
            return string.Format(sb.ToString(), top, where);
        }

        /// <summary>
        /// 版本1.0
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private string BuildSql(string top, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT  ");
            sb.Append(" CASE WHEN grouping(e.大类名称) = '1' THEN '总计' ");
            sb.Append("    WHEN grouping(e.大类名称) = '0' AND grouping(e.商品名称) = '1' THEN e.大类名称 + ' 小计' ");
            sb.Append("    ELSE e.大类名称 ");
            sb.Append(" END 大类, ");
            sb.Append(" CASE WHEN grouping(e.商品名称) = '1' THEN '' ");
            sb.Append("    WHEN grouping(e.商品名称) = '0' AND grouping(e.发票号) = '1' THEN e.商品名称 + ' 小计' ");
            sb.Append("    ELSE e.商品名称 ");
            sb.Append(" END 名称, ");
            sb.Append(" CASE WHEN grouping(e.发票号) = '1' THEN '' ");
            sb.Append(" ELSE 发票号 ");
            sb.Append(" END 单号, ");
            sb.Append(" Count(数量) as 数量, ");
            sb.Append(" sum(金额) as 金额 ");
            sb.Append(" from(SELECT   a.FDate as 发票日期, a.FBillNo as 发票号, a.FQty as 数量, a.FAmount as 金额, a.FName1 as 商品名称, a.FFullNumber as 商品全代码, a.FNumber1 as 大类编号, t_Item_1.FName AS 大类名称, a.custName as 客户名称 ");
            sb.Append(" FROM(SELECT {0} ICSale.FDate, ICSale.FBillNo, ICSaleEntry.FQty, ICSaleEntry.FAmount, t_Item.fname as FName1, t_Item.FFullNumber, ");
            sb.Append("    CASE len(t_Item.FFullNumber) - len(replace(t_Item.FFullNumber, '.', '')) WHEN 2 THEN substring(t_Item.FFullNumber, 0, ");
            sb.Append("    len(t_Item.FFullNumber) - 3) ELSE t_Item.FFullNumber END AS FNumber1, t_Organization.fname as custName ");
            sb.Append(" FROM      ICSale INNER JOIN ");
            sb.Append("    ICSaleEntry ON ICSale.FInterID = ICSaleEntry.FInterID INNER JOIN ");
            sb.Append("    t_Item ON ICSaleEntry.FItemID = t_Item.FItemID INNER JOIN ");
            sb.Append("    t_Organization ON ICSale.FCustID = t_Organization.FItemID {1}) AS a INNER JOIN ");
            sb.Append("    dbo.t_Item AS t_Item_1 ON a.FNumber1 = t_Item_1.FFullNumber) e ");
            sb.Append(" group by ");
            sb.Append("    e.大类名称, ");
            sb.Append("    e.商品名称, ");
            sb.Append("    e.发票号 ");
            sb.Append("    with rollup ");
            sb.Append(" order by ");
            sb.Append("    e.大类名称 desc, ");
            sb.Append("    e.商品名称 desc, ");
            sb.Append("    e.发票号 desc ");
            return string.Format(sb.ToString(),top, where);
        }

        /// <summary>
        /// 生成计数信息
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        private string BuildCountSql(string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT Count(*) ");
            sb.Append(" FROM ICSale INNER JOIN ");
            sb.Append("    ICSaleEntry ON ICSale.FInterID = ICSaleEntry.FInterID INNER JOIN ");
            sb.Append("    t_Item ON ICSaleEntry.FItemID = t_Item.FItemID INNER JOIN ");
            sb.Append("    t_Organization ON ICSale.FCustID = t_Organization.FItemID {0}");
            return string.Format(sb.ToString(), where);
        }

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            if(dataGridViewX1.Rows.Count > 0)
            {
                SaveFileDialog kk = new SaveFileDialog
                {
                    Title = "保存EXECL文件",
                    Filter = "EXECL文件(*.xls) |*.xls |所有文件(*.*) |*.*",
                    FilterIndex = 1
                };

                if (kk.ShowDialog() == DialogResult.OK)
                {
                    string FileName = kk.FileName;
                    DataTableTo.DataTable2Excel(dt, FileName);

                }
            }
        }


        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewX1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
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
    }
}
