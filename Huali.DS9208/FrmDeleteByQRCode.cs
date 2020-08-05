using DevComponents.DotNetBar;
using DevComponents.Editors;
using Ryan.Framework.DotNetFx20.Common;
using Ryan.Framework.DotNetFx20.DBUtility;
using Ryan.Framework.DotNetFx20.Encrypt;
using System;
using System.Data;
using System.Windows.Forms;

namespace Huali.DS9208
{
    /// <summary>
    /// 合并镜片/护理液程序
    /// 只显示和删除“XOUT”/“QOUT”类型单据
    /// 产品类型强制成大写“DS9208”/“DS9209”
    /// </summary>
    public partial class FrmDeleteByQRCode : Office2007Form
    {
        
        public FrmDeleteByQRCode()
        {
            InitializeComponent();
        }
        DataTable dt = new DataTable();
        string sql = "";
        private static readonly string conn = SqlHelper.GetConnectionString("ALiClouds");

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form7_Load(object sender, EventArgs e)
        {
            comboBoxEx2.SelectedIndex = 0;
        }

        /// <summary>
        /// 得到产品信息列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxX1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //dataGridViewX1.Rows.Clear();
                //得到单据编号
                ComboItem ciBillType = (ComboItem)comboBoxEx2.SelectedItem;
                string billType = ciBillType.Value.ToString();
                string billNo = billType + textBoxX1.Text;
                sql = string.Format("SELECT [产品名称] AS Disp , [FEntryID] AS Val FROM [dbo].[icstock] WHERE [单据编号] = '{0}'", billNo);
                dt = SqlHelper.ExecuteDataTable(conn, sql);
                DataRow dr = dt.NewRow();
                dr[0] = "";
                dr[1] = 0;
                dt.Rows.InsertAt(dr, 0);
                comboBoxEx1.DataSource = dt;
                comboBoxEx1.DisplayMember = "Disp";
                comboBoxEx1.ValueMember = "Val";
                comboBoxEx1.Focus();
            }
        }

        /// <summary>
        /// 用户选择了具体的列表
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxEx1_SelectedIndexChanged(object sender, EventArgs e)
        {
            textBoxX2.Focus();
        }

        /// <summary>
        ///回车删除一个唯一码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TextBoxX2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ComboItem ciBillType = (ComboItem)comboBoxEx2.SelectedItem;
                string billType = ciBillType.Value.ToString();
                string billNo = billType + textBoxX1.Text;
                string QRCode = textBoxX2.Text;
                string mingQRCode = EncryptHelper.Decrypt(QRCode);
                string EntryID = comboBoxEx1.SelectedValue.ToString();
                string interID = billNo + comboBoxEx1.SelectedValue.ToString().PadLeft(4, '0');
                string tableName = "t_QRCode" + mingQRCode.Substring(0, 4);
                int retValDetail = 0;
                int retValTotal = 0;
                sql = string.Format("DELETE FROM " + tableName + "  WHERE [FQRCode] = '" + mingQRCode + "' AND [FEntryID] = '" + interID + "'");
                retValDetail = SqlHelper.ExecuteNonQuery(conn, sql);
                sql = string.Format("UPDATE [icstock] SET [FActQty] = [FActQty] - 1 WHERE  [单据编号] = '{0}' AND [FActQty] > 0 AND [FEntryID] = {1}", billNo, EntryID.ToString());
                retValTotal = SqlHelper.ExecuteNonQuery(conn, sql);
                if (retValTotal > 0 && retValDetail > 0)
                {
                    CustomDesktopAlert.H2("二维码删除成功！");
                }
                else if (retValDetail < 1)
                {
                    CustomDesktopAlert.H2("二维码不存在！");
                }
                else
                {
                    CustomDesktopAlert.H2("二维码删除失败！");
                }

                //清空二维码框
                textBoxX2.Text = "";
            }
        }
    }
}
