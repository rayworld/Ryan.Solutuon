using Aohua.DAL;
using Aohua.K3.Models;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Aohua
{
    public partial class FormVoucher : Office2007Form
    {

        public FormVoucher()
        {
            InitializeComponent();

        }

        #region 成员变量
        private static DataTable dt = (DataTable)null;
        //需要变化的科目列表
        private static string AccountList = "";
        //原凭证字ID
        private static int OriginVoucherGroupID = -1;
        //蓝字凭证主表
        private static Voucher voucherBlue, voucherRed;
        #endregion

        #region 私有过程
        /// <summary>
        /// 修改蓝字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Modify4Blue(List<Voucher> vouchers, List<VoucherEntry> voucherEntries, string AccountList)
        {
            voucherBlue = vouchers[0];

            //保留原凭证字ID
            OriginVoucherGroupID = voucherBlue.FGroupID;

            ///FVoucherID
            voucherBlue.FVoucherID = Vouchers.GetNewVoucherID();

            ///FGroupID
            voucherBlue.FGroupID = Vouchers.ReplaceGroupID(voucherBlue.FGroupID);

            ///FNumber
            voucherBlue.FNumber = Vouchers.GetNewFNumber(voucherBlue.FYear, voucherBlue.FPeriod, voucherBlue.FGroupID);

            ///FSerialNum
            voucherBlue.FSerialNum = Vouchers.GetNewSerialNum();

            ///FPosted
            voucherBlue.FPosted = false;

            ///FPosterID
            voucherBlue.FPosterID = -1;

            ///FChecked 
            voucherBlue.FChecked = false;

            ///FCheckerID
            voucherBlue.FCheckerID = -1;

            //uuid
            voucherBlue.UUID = Guid.NewGuid();

            //FDate
            voucherBlue.FDate = DateTime.Now;

            //FAccountID
            foreach (VoucherEntry voucherEntryBlue in voucherEntries)
            {
                voucherEntryBlue.FVoucherID = voucherBlue.FVoucherID;
                string accountID = voucherEntryBlue.FAccountID.ToString();
                //string accountID2 = voucherEntryBlue.FAccountID2.ToString();

                if (AccountList.IndexOf(accountID) > -1)
                {
                    voucherEntryBlue.FAccountID = VoucherEntries.ReplaceAccountID(voucherEntryBlue.FAccountID);
                }

                //if (AccountList.IndexOf(accountID2) > -1)
                //{
                //    voucherEntryBlue.FAccountID2 = DAL.VoucherEntry.ReplaceAccountID(voucherEntryBlue.FAccountID2);
                //}
            }
        }

        /// <summary>
        /// 写入蓝字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Insert4Blue(List<Voucher> vouchers, List<VoucherEntry> voucherEntries)
        {
            //Voucher voucherBlue = vouchers[0];
            int ret = DAL.BaseDAL.Insert<Voucher>(voucherBlue);

            int retEntryBlue = 0;
            foreach (VoucherEntry voucherEntry in voucherEntries)
            {
                retEntryBlue += DAL.BaseDAL.Insert<VoucherEntry>(voucherEntry);
            }
        }

        /// <summary>
        /// 写入红字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Insert4Red(List<Voucher> vouchers, List<VoucherEntry> voucherEntries)
        {
            //Voucher voucherRed = vouchers[0];
            int retRed = DAL.BaseDAL.Insert<Voucher>(voucherRed);

            int retEntryRed = 0;
            foreach (VoucherEntry voucherEntry in voucherEntries)
            {
                retEntryRed += DAL.BaseDAL.Insert<VoucherEntry>(voucherEntry);
            }
        }

        /// <summary>
        /// 修改红字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Modify4Red(List<VoucherEntry> voucherEntries)
        {

            voucherRed = voucherBlue;

            ///FVoucherID
            voucherRed.FVoucherID = Vouchers.GetNewVoucherID();

            //FGroupID
            voucherRed.FGroupID = OriginVoucherGroupID;

            ///FNumber
            voucherRed.FNumber = Vouchers.GetNewFNumber(voucherRed.FYear, voucherRed.FPeriod, voucherRed.FGroupID);

            ///FSerialNum
            voucherRed.FSerialNum = Vouchers.GetNewSerialNum();

            //uuid
            voucherRed.UUID = Guid.NewGuid();


            foreach (VoucherEntry voucherEntryRed in voucherEntries)
            {
                voucherEntryRed.FVoucherID = voucherRed.FVoucherID;
                string accountID = voucherEntryRed.FAccountID.ToString();

                if (AccountList.IndexOf(accountID) > -1)
                {
                    voucherEntryRed.FAccountID = VoucherEntries.ReplaceAccountID(voucherEntryRed.FAccountID);
                }

                voucherEntryRed.FVoucherID = voucherRed.FVoucherID;
                voucherEntryRed.FAmount = -1 * voucherEntryRed.FAmount;
                voucherEntryRed.FAmountFor = -1 * voucherEntryRed.FAmountFor;
                voucherEntryRed.FQuantity = -1 * voucherEntryRed.FQuantity;
                voucherEntryRed.FUnitPrice = -1 * voucherEntryRed.FUnitPrice;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dataGridViewX"></param>
        private static void HightLightData(DataGridViewX dataGridViewX)
        {
            int HasKey = 0;
            foreach (DataGridViewRow dr in dataGridViewX.Rows)
            {
                dataGridViewX.Rows[dr.Index].Selected = false;
            }

            for (int i = 0; i < dataGridViewX.Rows.Count; i++)
            {
                string CellAccountID = dataGridViewX.Rows[i].Cells["FAccountID"].Value.ToString();
                if (AccountList.IndexOf(CellAccountID) > -1)
                {
                    dataGridViewX.Rows[i].Selected = true;
                    HasKey++;
                }
            }

            string msg = HasKey == 0 ? "未发现有效记录" : "共找到" + HasKey + "条相关记录";
            Ryan.Framework.DotNetFx40.Common.CustomDesktopAlert.H2(msg);
        }
        #endregion

        #region 事件
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVoucher_Load(object sender, EventArgs e)
        {
            if (CheckBoxOnlyShowCurrentPeriod.Checked)
            {
                TextBoxYear.Text = DateTime.Now.Year.ToString();
                TextBoxYear.Enabled = false;
                TextBoxPeriod.Text = (DateTime.Now.Month).ToString();
                TextBoxPeriod.Enabled = false;
            }

            //绑定凭证字控件
            BindComboBox(ComboBoxVoucherGroup);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CheckBoxOnlyShowCurrentPeriod_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBoxOnlyShowCurrentPeriod.Checked)
            {
                TextBoxYear.Text = DateTime.Now.Year.ToString();
                TextBoxYear.Enabled = false;
                TextBoxPeriod.Text = (DateTime.Now.Month).ToString();
                TextBoxPeriod.Enabled = false;
            }
            else
            {
                TextBoxPeriod.Enabled = true;
                TextBoxYear.Enabled = true;
            }
        }

        /// <summary>
        /// 查询凭证
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonXQuery_Click(object sender, System.EventArgs e)
        {
            string QueryString = " Where 1 = 1 ";

            if (TextBoxVoucherFNumber.Text != "" && ComboBoxVoucherGroup.SelectedIndex != -1)
            {
                string sYear = "", sPeriod = "";
                if (CheckBoxOnlyShowCurrentPeriod.Checked)
                {
                    sYear = DateTime.Now.Year.ToString();
                    sPeriod = DateTime.Now.Month.ToString();
                }
                else
                {
                    sYear = TextBoxYear.Text;
                    sPeriod = TextBoxPeriod.Text;
                }

                QueryString += string.Format(" AND v.FYear = {0} AND v.FPeriod = {1} ", sYear, sPeriod);
                QueryString += string.Format(" AND v.FGroupID = {0} ", ComboBoxVoucherGroup.SelectedValue.ToString());
                QueryString += string.Format(" AND v.FNumber = {0}", TextBoxVoucherFNumber.Text);

                dt = Vouchers.GetFilterData(QueryString);
                DataGridViewX1.DataSource = dt;

                //得到要替换的科目列表
                AccountList = Vouchers.GetAccountList4Upgrad();

                HightLightData(DataGridViewX1);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonXCreateVoucher_Click(object sender, System.EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                //得到现有凭证
                //string[] VoucherIDs = GetDistinctVoucherID(dt,"FVoucherID").Split(';');
                //foreach(string VoucherID in VoucherIDs)
                //{
                //取得凭证
                string VoucherID = DataGridViewX1.Rows.Count > 0 ? DataGridViewX1.Rows[0].Cells["FAccountID"].Value.ToString() : "-1";
                List<Voucher> vouchers = DAL.BaseDAL.GetModel<Voucher>("FVoucherID", VoucherID);
                List<VoucherEntry> voucherEntries = DAL.BaseDAL.GetModel<VoucherEntry>("FVoucherID", VoucherID);

                //修改蓝字凭证
                Modify4Blue(vouchers, voucherEntries, AccountList);

                //写入蓝字凭证
                Insert4Blue(vouchers, voucherEntries);

                //修改红字凭证
                Modify4Red(voucherEntries);

                //写入红字凭证
                Insert4Red(vouchers, voucherEntries);
                //}
            }
            else
            {
                // no record
            }
        }
        #endregion

        #region Unused
        /// <summary>
        /// 得到不同的VoucherID
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="VoucherIDFieldName"></param>
        /// <returns></returns>
        //private string GetDistinctVoucherID(DataTable dt, string VoucherIDFieldName)
        //{
        //    string tempBillNo = "";
        //    string VoucherID = "";
        //    string retVal = "";

        //    for (int i = 0; i < dt.Rows.Count; i++)
        //    {
        //        VoucherID = dt.Rows[i][VoucherIDFieldName].ToString();
        //        if (VoucherID != tempBillNo)
        //        {
        //            retVal += VoucherID + ";";
        //            tempBillNo = VoucherID;
        //        }
        //    }

        //    //去掉最后一个分号
        //    return retVal.Substring(0, retVal.Length - 1);
        //}
        #endregion

        #region 准备入库
        /// <summary>
        /// 绑定Combo控件
        /// </summary>
        /// <param name="combobox"></param>
        private static void BindComboBox(ComboBoxEx combobox)
        {
            combobox.DataSource = VoucherGroups.BindComboBoxVoucherGroupData();
            combobox.DisplayMember = "FName";
            combobox.ValueMember = "FGroupID";
            //设置默认值
            if (combobox.DataSource != null)
            {
                combobox.SelectedIndex = 0;
            }
            else
            {
                //DataSource为空
            }
        }
        #endregion
    }
}