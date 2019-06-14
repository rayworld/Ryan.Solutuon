using Aohua.models;
using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Common;
using Ryan.Framework.DotNetFx40.Config;
using Ryan.Framework.DotNetFx40.DBUtility;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace Aohua
{
    public partial class FrmDataCompare : Office2007Form
    {
        public FrmDataCompare()
        {
            InitializeComponent();
        }
        private static string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string connK3Src = SqlHelper.GetConnectionString("K3Src");
        private string sql = "";
        private DataTable dtFailData, dtSuccessData, dtK3;
        private List<ComparedResult> comparedResults = new List<ComparedResult>();
        
        /// <summary>
        /// 窗体启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmDataCompare_Load(object sender, System.EventArgs e)
        {
            string Year = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig,"Year");
            BindYearComb(Year);
            BindGridView(Year, true);
        }

        /// <summary>
        /// 绑定选定科目的财务数据
        /// </summary>
        /// <param name="ids"></param>
        public DataTable BindFailData(string Year)
        {
            if (Year == "2017" || Year == "2018" || Year == "2019" || Year == "2020")
            {
                sql = string.Format("select FItemID as 客户编号,fname as 财务系统客户名称 from t_Item where FItemClassID in (select fitemclassid from t_ItemClass where (fname like '{0}%' and fname not like '%内%')) and FItemID NOT IN(SELECT FFinID FROM Ryan_CustCompare) AND fname NOT LIKE 'YF%' ", Year);
                //ConfigHelper.UpdateOrCreateAppSetting(ConfigHelper.ConfigurationFile.AppConfig, "Year", "2030");
                return  SqlHelper.ExecuteDataTable(conn, sql, null);
            }
            else
            {
                CustomDesktopAlert.H4("年份输入错误！");
            }
            return (DataTable)null;
        }

        public DataTable BindSuccessData()
        {
            sql = string.Format("select finterid as 序号, ffinid  as 客户编号, ffinCustName as 财务系统客户名称, fK3id as 客户号, fk3CustName as 物流系统客户名称 from Ryan_CustCompare");
            return SqlHelper.ExecuteDataTable(conn, sql, null);
        }

        /// <summary>
        /// 绑定业务数据
        /// </summary>
        public DataTable BindK3Data()
        {
            sql = "select FItemID, fname from t_Organization";
            return SqlHelper.ExecuteDataTable(connK3Src, sql, null);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtFailData"></param>
        /// <param name="dtK3"></param>
        /// <returns></returns>
        public int CompareDataByNameAddress(DataTable dtFailData, DataTable dtK3)
        {
            int res = 0;
            foreach (DataRow drFail in this.dtFailData.Rows)
            {
                ComparedResult comparedResult = new ComparedResult
                {
                    FinId = drFail[0].ToString(),
                    FinCustName = drFail[1].ToString()
                };
                string Address = "";
                string Name = "";
                if (comparedResult.FinCustName.Contains("（") == true || comparedResult.FinCustName.Contains("(") == true)
                {
                    Address = SubAddress2(comparedResult.FinCustName);
                    Name = SubName2(comparedResult.FinCustName);
                }
                else
                {
                    continue;
                }

                foreach (DataRow drK3 in this.dtK3.Rows)
                {
                    comparedResult.K3Id = drK3[0].ToString();
                    comparedResult.K3CustName = drK3[1].ToString();

                    if (comparedResult.K3CustName.IndexOf(Address) > -1 && comparedResult.K3CustName.IndexOf(Name) > -1)
                    {
                        int RetVal = InsertData2DB(comparedResult);

                        //计数
                        if (RetVal > 0) res++;

                        break;
                    }
                }
            }
            return res;
        }

        /// <summary>
        /// 写入临时表
        /// </summary>
        /// <param name="comparedResult"></param>
        /// <returns></returns>
        private int InsertData2DB(ComparedResult comparedResult)
        {
            int ret = 0;
            sql = string.Format("INSERT INTO[dbo].[Ryan_CustCompare]([FFinID],[FFinCustName],[FK3ID],[FK3CustName])VALUES({0},'{1}',{2},'{3}')",comparedResult.FinId,comparedResult.FinCustName,comparedResult.K3Id,comparedResult.K3CustName);
            ret = SqlHelper.ExecuteNonQuery(conn, sql);
            return ret;
        }

        private void BtnCompare_Click(object sender, System.EventArgs e)
        {
            if (comboBoxEx1.SelectedIndex > 0)
            {
                //得到业务系统客户信息
                dtK3 = BindK3Data();

                string Year = comboBoxEx1.SelectedItem.ToString();
                BindGridView(Year,false);
            }
            else
            {
                CustomDesktopAlert.H4("请先选择年份！");
            }                
        }
        #region 显示表格行号
        private void DataGridViewX2_RowPostPaint(object sender, System.Windows.Forms.DataGridViewRowPostPaintEventArgs e)
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

        /// <summary>
        /// 显示行号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void DataGridViewX1_CellDoubleClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                string FinId = DataGridViewX1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string FinName = DataGridViewX1.Rows[e.RowIndex].Cells[1].Value.ToString();

                FrmDataQuery frmDataQuery = new FrmDataQuery(FinId, FinName);
                if (frmDataQuery.ShowDialog() == DialogResult.OK)
                {
                    ComparedResult comparedResult = new ComparedResult
                    {
                        FinId = frmDataQuery.Finid,
                        FinCustName = frmDataQuery.FinCustName,
                        K3Id = frmDataQuery.K3Id,
                        K3CustName = frmDataQuery.K3CustName
                    };
                    //保存到数据库
                    InsertData2DB(comparedResult);
                    //刷新界面
                    string Year = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "Year");
                    BindGridView(Year, true);
                }
            }
        }

        #endregion

        #region 比对


        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string SubAddress2(string Key)
        {
            int BeginPosition = 0, EndPosition = 0, NumPosition = 0;
            //开始位置定义，如果字符串包含中文版大括号，起始位置为中文版大括号位置加1，否则为英文版大括号位置加1
            BeginPosition = Key.Contains("（") ? Key.IndexOf("（") + 1 : Key.IndexOf("(") + 1;

            if (Key.Contains("）"))
            {
                EndPosition = Key.LastIndexOf("）");
            }
            else if (Key.Contains(")"))
            {
                EndPosition = Key.LastIndexOf(")");
            }
            else
            {
                EndPosition = Key.Length;
            }

            Key = EndPosition == Key.Length ? Key.Substring(BeginPosition).Trim() : Key.Substring(BeginPosition, EndPosition - BeginPosition).Trim();

            NumPosition = GetNumPosition(Key);

            if (GetNumPosition(Key) > -1)
            {
                Key = Key.Substring(0, NumPosition);
            }

            return Key.Trim();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="Key"></param>
        /// <returns></returns>
        public string SubName2(string Key)
        {
            Key = Key.Contains("(") ? Key.Substring(0, Key.IndexOf("(")).Trim(): Key.Substring(0, Key.IndexOf("（")).Trim();
            return Key.Replace("YF", "").Replace("*", "").Replace("A", "");
        }
        
        #endregion

        /// <summary>
        /// 改年限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxEx1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            DevComponents.Editors.ComboItem comboItem = (DevComponents.Editors.ComboItem)comboBoxEx1.SelectedItem;
            string selectedYear = comboItem.Text;
            if (selectedYear == "2017"|| selectedYear == "2018"|| selectedYear == "2019"|| selectedYear == "2020")
            {
                ConfigHelper.UpdateOrCreateAppSetting(ConfigHelper.ConfigurationFile.AppConfig, "Year", selectedYear);
            }
            else
            {
                CustomDesktopAlert.H4("年份输入错误！");
            }
        }

        private void DataGridViewX2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if(MessageBoxEx.Show("确定删除这个数据？","系统警告",MessageBoxButtons.YesNo,MessageBoxIcon.Warning,MessageBoxDefaultButton.Button2) == DialogResult.Yes )
            {
                string finid = DataGridViewX2.Rows[e.RowIndex].Cells[1].Value.ToString();
                string k3id = DataGridViewX2.Rows[e.RowIndex].Cells[3].Value.ToString();
                sql = string.Format("Delete From Ryan_CustCompare where ffinid='{0}' And fK3id = '{1}'",finid,k3id);
                int res = SqlHelper.ExecuteNonQuery(conn, sql);
                if(res ==1 )
                {
                    CustomDesktopAlert.H4("数据删除成功！");
                }
                else
                {
                    CustomDesktopAlert.H4("数据删除失败！");
                }
                string Year = ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "Year");
                BindGridView(Year, true);

            }
        }

        /// <summary>
        /// 绑定两个表格控件
        /// </summary>
        /// <param name="Year"></param>
        /// <param name="RunAtStartup"></param>
        private void BindGridView(string Year, bool RunAtStartup)
        {
            //生成财务客户数据
            dtFailData = BindFailData(Year);

            if (RunAtStartup)
            {
                dtSuccessData = BindSuccessData();
                int TotalCount = dtFailData.Rows.Count;
                //CustomDesktopAlert.H4("查询到相关数据" + TotalCount.ToString() + "条");
                pFailData.Text = "未匹配成功(" + TotalCount.ToString() + ")";
                int successCount = dtSuccessData.Rows.Count;
                //CustomDesktopAlert.H4("比对成功的有" + successCount.ToString() + "条");
                pSuccessData.Text = "已匹配成功(" + successCount.ToString() + ")";
            }
            else
            {
                int TotalCount = dtFailData.Rows.Count;
                pFailData.Text = "未匹配成功(" + TotalCount.ToString() + ")";
                int successCount = CompareDataByNameAddress(dtFailData, dtK3);
                CustomDesktopAlert.H4("比对成功的有" + successCount.ToString() + "条");
                dtSuccessData = BindSuccessData();
                int totalSuccessCount = dtSuccessData.Rows.Count;
                pSuccessData.Text = "已匹配成功(" + totalSuccessCount.ToString() + ")";
                //生成财务客户数据
                dtFailData = BindFailData(Year);
            }
            DataGridViewX1.DataSource = dtFailData;
            DataGridViewX1.Columns[0].Width = 80;
            DataGridViewX1.Columns[1].Width = 260;

            DataGridViewX2.DataSource = dtSuccessData;
            DataGridViewX2.Columns[0].Visible = false;
            DataGridViewX2.Columns[1].Width = 80;
            DataGridViewX2.Columns[2].Width = 260;
            DataGridViewX2.Columns[3].Width = 80;
            DataGridViewX2.Columns[4].Width = 260;
        }

        /// <summary>
        /// 
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

        /// <summary>
        /// 在窗体启动时绑定combo控件
        /// </summary>
        /// <param name="Year">年份</param>
        private void BindYearComb(string Year)
        {
            foreach (DevComponents.Editors.ComboItem comboItem in comboBoxEx1.Items)
            {
                if(comboItem.Text == Year)
                {
                    comboBoxEx1.SelectedItem = comboItem;
                }
            }
        }

        /// <summary>
        /// 得到第一个数字在字符串中的位子
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetNumPosition(string input)
        {
            if (string.IsNullOrEmpty(input))
                return -1;
            for (int i = 0; i < input.Length; i++)
                if (char.IsDigit(input[i]))
                    return i;
            return -1;
        }

    }
}