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
            int MaxRowsCount = 10000;
            string startDate = dtiBeginDate.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string endDate = dtiEndDate.Value.ToString("yyyy-MM-dd").Substring(0, 10);
            string BillStart = txtBillNoBegin.Text;
            string BillEnd = txtBillNoEnd.Text;
            string CustomName = txtCustName.Text;

            //生成条件Sql
            WhereOption = " Where 1=1 ";

            if (startDate != "0001-01-01")
            {
                WhereOption += " And s.FDate >= '" + startDate + "' ";
            }

            if (endDate != "0001-01-01")
            {
                WhereOption += " And s.FDate <= '" + endDate + "' ";
            }

            if (BillStart != "")
            {
                WhereOption += " And s.FBillNo >= 'ZSEFP" + BillStart + "' ";
            }

            if (BillEnd != "")
            {
                WhereOption += " And s.FBillNo <= 'ZSEFP" + BillEnd + "' ";
            }

            if (txtCustName.Text != "")
            {
                WhereOption += " And o.FName Like '%" + CustomName + "%' ";
            }

            //限制记录条数
            object obj = SqlHelper.ExecuteScalar(BuildCountSql(WhereOption));
            int RowsCount = obj != null ? int.Parse(obj.ToString()) : 0;

            if (RowsCount > MaxRowsCount)
            {
                CustomDesktopAlert.H2(RowsCount.ToString() + " 条记录，已超过记录上限，<br/>系统将截取前 " + MaxRowsCount + " 条记录！");
                TopOption = " Top " + MaxRowsCount.ToString();
            }

            //执行统计
            dt = SqlHelper.ExecuteDataTable(BuildSqlV4(TopOption, WhereOption));
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
            sb.Append(" COUNT(数量) AS 数量, ");
            sb.Append(" SUM(金额) AS 金额 ");
            sb.Append(" FROM( ");
            sb.Append(" SELECT a.FDate AS 发票日期, a.FBillNo AS 发票号, a.FQty AS 数量, a.FStdAmount AS 金额, a.FName1 AS 商品名称, a.FFullNumber AS 商品全代码, a.FNumber1 AS 大类编号, t_Item_1.FName AS 大类名称, a.custName AS 客户名称 ");
            sb.Append(" FROM( ");
            sb.Append(" SELECT {0} ICSale.FDate, ICSale.FBillNo, ICSaleEntry.FQty, ICSaleEntry.FStdAmount, t_Item.fname AS FName1, t_Item.FFullNumber, CASE LEN(t_Item.FFullNumber) - LEN(REPLACE(t_Item.FFullNumber, '.', '')) WHEN 2 THEN substring(t_Item.FFullNumber, 0, LEN(t_Item.FFullNumber) - 3) ELSE t_Item.FFullNumber END AS FNumber1, t_OrganizatiON.fname AS custName ");
            sb.Append(" FROM ICSale INNER JOIN ");
            sb.Append(" ICSaleEntry ON ICSale.FInterID = ICSaleEntry.FInterID INNER JOIN ");
            sb.Append(" t_Item ON ICSaleEntry.FItemID = t_Item.FItemID INNER JOIN ");
            sb.Append(" t_OrganizatiON ON ICSale.FCustID = t_OrganizatiON.FItemID {1}) AS a INNER JOIN ");
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
            sb.Append(" Count(数量) AS 数量, ");
            sb.Append(" sum(金额) AS 金额 ");
            sb.Append(" FROM(SELECT   a.FDate AS 发票日期, a.FBillNo AS 发票号, a.FQty AS 数量, a.FStdAmount AS 金额, a.FName1 AS 商品名称, a.FFullNumber AS 商品全代码, a.FNumber1 AS 大类编号, t_Item_1.FName AS 大类名称, a.custName AS 客户名称 ");
            sb.Append(" FROM(SELECT {0} ICSale.FDate, ICSale.FBillNo, ICSaleEntry.FQty, ICSaleEntry.FStdAmount, t_Item.fname AS FName1, t_Item.FFullNumber, ");
            sb.Append("    CASE len(t_Item.FFullNumber) - len(replace(t_Item.FFullNumber, '.', '')) WHEN 2 THEN substring(t_Item.FFullNumber, 0, ");
            sb.Append("    len(t_Item.FFullNumber) - 3) ELSE t_Item.FFullNumber END AS FNumber1, t_OrganizatiON.fname AS custName ");
            sb.Append(" FROM      ICSale INNER JOIN ");
            sb.Append("    ICSaleEntry ON ICSale.FInterID = ICSaleEntry.FInterID LEFT JOIN ");
            sb.Append("    t_Item ON ICSaleEntry.FItemID = t_Item.FItemID LEFT JOIN ");
            sb.Append("    t_OrganizatiON ON ICSale.FCustID = t_OrganizatiON.FItemID {1}) AS a INNER JOIN ");
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

        private string BuildSqlV3(string top, string where)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(" select  ");
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
            sb.Append(" from(select a.FDate AS 发票日期, a.FBillNo AS 发票号, a.FQty AS 数量, a.FStdAmount AS 金额, a.FName AS 商品名称, a.FFullNumber AS 商品全代码, a.cata AS 大类编号, a.custName AS 客户名称, tt1.FName  AS 大类名称 ");
            sb.Append(" from(select {0} s.FDate, s.FBillNo, fqty, FStdAmount, o.fname as custName, i.FName, i.FFullNumber, CASE LEN(i.FFullNumber) - LEN(REPLACE(i.FFullNumber, '.', '')) WHEN 2 THEN substring(i.FFullNumber, 0, LEN(i.FFullNumber) - 3) ELSE i.FFullNumber END AS cata ");
            sb.Append(" from ICSale s ");
            sb.Append(" Inner ");
            sb.Append(" join ICSaleEntry e on s.FInterID = e.FInterID ");
            sb.Append(" left ");
            sb.Append(" join t_Organization o on s.FCustID = o.FItemID ");
            sb.Append(" left ");
            sb.Append(" join t_Item i on e.FItemID = i.FItemID ");
            sb.Append(" {1} ) as a left join(SELECT * FROM t_Item where fitemclassid = 4) as tt1 on a.cata = tt1.FFullNumber) as e ");
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
        /// 加成本显示t_icitem fOrderPrice
        /// </summary>
        /// <param name="top"></param>
        /// <param name="where"></param>
        /// <returns></returns>
        private string BuildSqlV4(string top, string where)
        {
            StringBuilder sb = new StringBuilder();

            //sb.Append(" --ver 1.3 ");
            sb.Append(" select ");
            sb.Append(" CASE ");
            sb.Append(" WHEN grouping(g.大类名称) = '1' THEN '总计' ");
            sb.Append(" WHEN grouping(g.大类名称) = '0' AND grouping(g.商品名称) = '1' THEN g.大类名称 + ' 小计' ");
            sb.Append(" ELSE g.大类名称 ");
            sb.Append(" END 大类, ");
            sb.Append(" CASE ");
            sb.Append(" WHEN grouping(g.商品名称) = '1' THEN '' ");
            sb.Append(" WHEN grouping(g.商品名称) = '0' AND grouping(g.客户名称) = '1' THEN g.商品名称 + ' 小计' ");
            sb.Append(" ELSE g.商品名称 ");
            sb.Append(" END 商品名称, ");
            sb.Append(" CASE ");
            sb.Append(" WHEN grouping(g.客户名称) = '1' THEN '' ");
            sb.Append(" WHEN grouping(g.客户名称) = '0' AND grouping(g.发票号) = '1'  THEN g.客户名称 + ' 小计' ");
            sb.Append(" ELSE g.客户名称 ");
            sb.Append(" END 客户名称,   ");
            sb.Append(" CASE ");
            sb.Append(" WHEN grouping(g.发票号) = '1' THEN '' ");
            sb.Append(" WHEN grouping(g.发票号) = '0' AND grouping(g.成本) = '1'  THEN g.发票号 + ' 小计' ");
            sb.Append(" ELSE 发票号 ");
            sb.Append(" END 发票号, ");
            sb.Append(" CASE ");
            sb.Append(" WHEN grouping(g.成本) = '1' THEN '' ");
            sb.Append(" ELSE 成本 ");
            sb.Append(" END 成本, ");
            sb.Append(" SUM(g.数量) as 数量, ");
            sb.Append(" SUM(g.金额) as 金额 ");
            sb.Append(" from( ");
            sb.Append(" select ");
            sb.Append(" a.FDate AS 发票日期, ");
            sb.Append(" a.FBillNo AS 发票号, ");
            sb.Append(" a.数量 AS 数量, ");
            sb.Append(" a.FStdAmount AS 金额, ");
            sb.Append(" a.FName AS 商品名称, ");
            sb.Append(" a.FOrderPrice AS 成本, ");
            sb.Append(" a.FFullNumber AS 商品全代码, ");
            sb.Append(" a.cata AS 大类编号, ");
            sb.Append(" a.custName AS 客户名称, ");
            sb.Append(" tt1.FName  AS 大类名称 ");
            sb.Append(" from( ");
            sb.Append(" select {0} ");
            sb.Append(" s.FDate, ");
            sb.Append(" s.FBillNo, ");
            sb.Append(" e.fqty as 数量, ");
            sb.Append(" e.FStdAmount, ");
            sb.Append(" CAST(c.FOrderPrice / 1.13 AS nvarchar(20)) as Forderprice, ");
            sb.Append(" o.fname as custName, ");
            sb.Append(" i.FName, ");
            sb.Append(" i.FFullNumber, ");
            sb.Append(" CASE LEN(i.FFullNumber) - LEN(REPLACE(i.FFullNumber, '.', '')) ");
            sb.Append(" WHEN 2 THEN substring(i.FFullNumber, 0, LEN(i.FFullNumber) - 3) ");
            sb.Append(" ELSE i.FFullNumber ");
            sb.Append(" END AS cata ");
            sb.Append(" from ");
            sb.Append(" ICSale s ");
            sb.Append(" Inner join ICSaleEntry e on s.FInterID = e.FInterID ");
            sb.Append(" left join t_Organization o on s.FCustID = o.FItemID ");
            sb.Append(" left join t_icitem c on e.FItemID = c.FItemID ");
            sb.Append(" left join t_Item i on e.FItemID = i.FItemID  {1} ");
            sb.Append(" ) as a ");
            sb.Append(" left join(SELECT * FROM t_Item where fitemclassid = 4) as tt1 on a.cata = tt1.FFullNumber ");
            sb.Append(" ) as g ");
            sb.Append(" GROUP BY ");
            sb.Append(" g.大类名称, ");
            sb.Append(" g.商品名称, ");
            sb.Append(" g.客户名称, ");
            sb.Append(" g.发票号, ");
            sb.Append(" g.成本 ");
            sb.Append(" WITH ROLLUP ");
            sb.Append(" ORDER BY ");
            sb.Append(" g.大类名称 DESC, ");
            sb.Append(" g.商品名称 DESC, ");
            sb.Append(" g.客户名称 DESC, ");
            sb.Append(" g.发票号 DESC, ");
            sb.Append(" g.成本 DESC ");

            return string.Format(sb.ToString(), top, where);

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
            sb.Append(" FROM ICSale s INNER JOIN ");
            sb.Append("    ICSaleEntry e ON s.FInterID = e.FInterID LEFT JOIN ");
            sb.Append("    t_Item i ON e.FItemID = i.FItemID LEFT JOIN ");
            sb.Append("    t_Organization o ON s.FCustID = o.FItemID {0}");
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
