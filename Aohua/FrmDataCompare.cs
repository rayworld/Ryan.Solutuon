using DevComponents.DotNetBar;
using Ryan.Framework.DBUtility;
using System.Data;

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
        string sql = "select fitemclassid from t_ItemClass where (fname like '2017%' or fname like '2018%' or fname like '2019%' and fname not like '%内%') order by fname";

        private void FrmDataCompare_Load(object sender, System.EventArgs e)
        {
            //dataGridViewX1.DataSource = SqlHelper.ExecuteDataTable(conn, sql, null);
            DataTable dt = SqlHelper.ExecuteDataTable(conn, sql, null);
            string classids = "";
            foreach(DataRow dr in dt.Rows)
            {
                classids += dr[0].ToString() + ",";
            }

            classids = classids.Substring(0, classids.Length - 1);           

            sql = string.Format("select FItemID,fname from t_Item where FItemClassID in ({0})",classids);
            DataTable dt1 = SqlHelper.ExecuteDataTable(conn, sql, null);
            dataGridViewX1.DataSource = dt1;
            dataGridViewX1.Columns[0].Width = 300;
            dataGridViewX1.Columns[1].Width = 300;
            //Ryan.Framework.Common.CustomDesktopAlert.H2(dt1.Rows.Count.ToString());
            sql = "select FItemID, fname from t_Organization";
            DataTable dt2 = SqlHelper.ExecuteDataTable(connK3Src, sql, null);
            dataGridViewX2.DataSource = dt2;
            dataGridViewX2.Columns[0].Width = 300;
            dataGridViewX2.Columns[1].Width = 300;
            int res = 0;
            foreach(DataRow dr1 in dt1.Rows)
            {
                string FinData = dr1[1].ToString().IndexOf("（") > 0 ? dr1[1].ToString().Substring(0, dr1[1].ToString().IndexOf("（")) : dr1[1].ToString();
                foreach(DataRow dr2 in dt2.Rows)
                {
                    if(dr2[1].ToString().IndexOf(FinData) > -1)
                    {
                        //dr1.Delete();
                        //Ryan.Framework.Common.CustomDesktopAlert.H2(FinData);
                        res++;
                    }
                }
            }
            Ryan.Framework.Common.CustomDesktopAlert.H2(res.ToString());
        }
    }
}
