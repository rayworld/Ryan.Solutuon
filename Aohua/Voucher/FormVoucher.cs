using Aohua.DAL;
using Aohua.K3.Models;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ryan.Framework.DotNetFx40.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace Aohua.VoucherApp
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
        //原凭证ID
        private static int OriginVoucherID = -1;
        //凭证主表
        private static Voucher voucherOrigin, voucherBlue, voucherRed;
        //凭证明细表
        private static List<VoucherEntry> voucherEntryOrigins, voucherEntryBlues, voucherEntryReds;
        //新ItemDetail 客户号
        private static int NewItemID = 0;
        //蓝字数据写入成功
        private static bool BlueSuccess = false;
        #endregion

        #region 私有过程
        /// <summary>
        /// 修改蓝字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Modify4Blue(Voucher voucherBlue, List<VoucherEntry> voucherEntryBlues, string AccountList)
        {
            
            //保留原凭证字ID
            OriginVoucherGroupID = voucherBlue.FGroupID;
            //保留源凭证内码
            OriginVoucherID = voucherBlue.FVoucherID;
            ///FVoucherID
            voucherBlue.FVoucherID = Vouchers.GetNewVoucherID();
            ///FGroupID
            voucherBlue.FGroupID = Vouchers.ReplaceGroupID(voucherBlue.FGroupID);
            //FYear
            voucherBlue.FYear = DateTime.Now.Year;
            //FPeriod
            voucherBlue.FPeriod = DateTime.Now.Month;
            //FNumber
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
            //FTransDate
            voucherBlue.FTransDate = DateTime.Now;

            //FAccountID
            foreach (VoucherEntry voucherEntryBlue in voucherEntryBlues)
            {
                voucherEntryBlue.FVoucherID = voucherBlue.FVoucherID;
                //string accountID = voucherEntryBlue.FAccountID.ToString();
                //string accountID2 = voucherEntryBlue.FAccountID2.ToString();
                int OriginAccountID = voucherEntryBlue.FAccountID;

                if (AccountList.IndexOf(OriginAccountID.ToString()) > -1)
                {
                    int NewAccountID = VoucherEntries.ReplaceAccountID(OriginAccountID);
                    voucherEntryBlue.FAccountID = NewAccountID;
                    string OriginCustomFNumber = VoucherEntries.GetOriginCustomFNumber(OriginVoucherID, voucherEntryBlue.FEntryID);
                    string MaxBlueCustomFNumber = VoucherEntries.GetNewAccountMaxFNumber(NewAccountID);
                    bool CustomFNumberExists = VoucherEntries.FNumberExists(NewAccountID, OriginCustomFNumber);
                    //int detailid = voucherEntryBlue.FDetailID;
                    //如果OriginCustomFNumber小于MaxBlueCustomFNumber
                    if ((int.Parse(OriginCustomFNumber) < int.Parse(MaxBlueCustomFNumber)) && CustomFNumberExists == true)
                    {
                        //直接用新科目下的OriginCustomFNumber
                        NewItemID = Aohua.DAL.Items.GetItemIDByAccountIDFNumber(NewAccountID, OriginCustomFNumber);
                    }
                    else
                    {
                        int NewItemClassID = ItemDetails.GetItemClassIDbyAccountID(voucherEntryBlue.FAccountID);
                        FormCustomNumberSelecter form = new FormCustomNumberSelecter(NewItemClassID)
                        {
                            StartPosition = FormStartPosition.CenterParent
                        };
                        if (form.ShowDialog() == DialogResult.OK)
                        {
                            NewItemID = int.Parse(form.ItemID.ToString());
                        }
                        //弹出窗口选最大的10个编号中的一个
                    }
                    //查横表看新客户下有没有同样的商品
                    //如果有VoucherEnryBlue.FDetailID = 这个ID
                    //否则在itemDetail和ItemDetailV新建一行
                    //voucherEntryBlue.FDetailID = 
                    //VoucherEnryBlue.FDetailID = 新ID
                    voucherEntryBlue.FDetailID = GetNewDetailID(OriginVoucherID, voucherBlue.FVoucherID,voucherEntryBlue.FEntryID, voucherEntryBlue.FAccountID, NewItemID, OriginAccountID);
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginVoucherID"></param>
        /// <param name="BlueVoucherID"></param>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public static int GetNewDetailID(int OriginVoucherID, int BlueVoucherID, int EntryID, int NewAccountID, int ItemID,int OriginAccountID)
        {
            int retDetailID = -1;
            //OriginDetailID = 115618
            int OriginDetailID = Vouchers.GetDetailIDByVoucherIDEntryID(OriginVoucherID, EntryID);
            //OriginAccountID = 27330;
            //int OriginAccountID = 27330;
            DataTable dt = ItemDetails.GetItemDetailByID(OriginDetailID, OriginAccountID);
            //FDetailID	FItemClassID	FItemID
            //115618    3046            9729
            ItemDetailV itemDetailVOrigin, itemDetailVNew;
            if (dt != null)
            {
                itemDetailVOrigin = new ItemDetailV()
                {
                    FDetailID = int.Parse(dt.Rows[0]["FDetailID"].ToString()),
                    FItemClassID = int.Parse(dt.Rows[0]["FItemClassID"].ToString()),
                    FItemID = int.Parse(dt.Rows[0]["FItemID"].ToString())
                };
            }
            else
            {
                itemDetailVOrigin = (ItemDetailV) null;
            }

            itemDetailVNew = new ItemDetailV()
            {
                FItemClassID = ItemDetails.GetItemClassIDbyAccountID(NewAccountID),
                FItemID = ItemID
            };

            //查横表得到DetailID
            retDetailID = ItemDetails.GetDetailID(itemDetailVOrigin.FItemClassID, itemDetailVOrigin.FItemID, itemDetailVNew.FItemClassID, itemDetailVNew.FItemID);

            int retDetail = 0, retDetailV = 0;
            if (retDetailID == -1 && itemDetailVOrigin.FItemClassID != -1 && itemDetailVOrigin.FItemID != -1 && itemDetailVNew.FItemClassID != -1 && itemDetailVNew.FItemID != -1)
            {
                //MAX(DetailID) + 1
                retDetailID = ItemDetails.GetNewItemDetailID();
                //写横表
                retDetail = ItemDetails.InsertItemDetail(retDetailID,itemDetailVOrigin.FItemClassID, itemDetailVOrigin.FItemID, itemDetailVNew.FItemClassID, itemDetailVNew.FItemID);
                //写纵表
                retDetailV = ItemDetails.InsertItemDetailV(retDetailID,itemDetailVOrigin.FItemClassID, itemDetailVOrigin.FItemID, itemDetailVNew.FItemClassID, itemDetailVNew.FItemID);

                return retDetail > 0 && retDetailV > 0 ? retDetailID : -1;
            }
            else
            {
                return retDetailID;
            } 
        }

        /// <summary>
        /// 写入蓝字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private void Insert4Blue(Voucher voucherBlue, List<VoucherEntry> voucherEntryBlues)
        {
            if (voucherBlue.FSerialNum == -1)
            {
                CustomDesktopAlert.H2("生成凭证序号出错！");
            }
            else if (voucherBlue.FVoucherID == -1)
            {
                CustomDesktopAlert.H2("生成凭证号内码出错！");
            }
            else if(voucherBlue.FNumber == -1)
            {
                CustomDesktopAlert.H2("生成凭证号出错！");
            }
            else if (voucherBlue.FGroupID == -1)
            {
                CustomDesktopAlert.H2("生成凭证字出错！");
            }
            else
            {
                //Voucher voucherBlue = vouchers[0];
                int ret = DAL.BaseDAL.Insert<Voucher>(voucherBlue);

                int retEntryBlue = 0;
                foreach (VoucherEntry voucherEntryBlue in voucherEntryBlues)
                {
                    if (voucherEntryBlue.FAccountID == -1)
                    {
                        CustomDesktopAlert.H2("查询科目编号出错！");
                    }
                    else if (voucherEntryBlue.FDetailID == -1)
                    {
                        CustomDesktopAlert.H2("查询明细编号出错！");
                    }
                    else
                    {
                        retEntryBlue += DAL.BaseDAL.Insert<VoucherEntry>(voucherEntryBlue);
                    }
                }

                if (ret > 0 && retEntryBlue > 0)
                {
                    CustomDesktopAlert.H2(string.Format("蓝字凭证{0}写入完成！", ComboBoxVoucherGroup.Text.Replace("转", "记") + "." + voucherBlue.FNumber));
                    BlueSuccess = true;
                }
                else
                {
                    BlueSuccess = false;
                }
            }
        }

        /// <summary>
        /// 写入红字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private void Insert4Red(Voucher voucherRed, List<VoucherEntry> voucherEntryReds)
        {
            if (BlueSuccess == true)
            {
                int retRed = DAL.BaseDAL.Insert<Voucher>(voucherRed);

                int retEntryRed = 0;
                foreach (VoucherEntry voucherEntryRed in voucherEntryReds)
                {
                    retEntryRed += BaseDAL.Insert<VoucherEntry>(voucherEntryRed);
                }

                if (retRed > 0 && retEntryRed > 0)
                {
                    CustomDesktopAlert.H2(string.Format("红字凭证{0}写入完成！", ComboBoxVoucherGroup.Text + "." + voucherRed.FNumber));
                }
            }
        }

        /// <summary>
        /// 修改红字凭证
        /// </summary>
        /// <param name="vouchers"></param>
        /// <param name="voucherEntries"></param>
        private static void Modify4Red(Voucher voucherRed, List<VoucherEntry> voucherEntryReds)
        {
            //FVoucherID
            voucherRed.FVoucherID = Vouchers.GetNewVoucherID();

            //FGroupID
            voucherRed.FGroupID = OriginVoucherGroupID;

            //FYear
            voucherRed.FYear = DateTime.Now.Year;

            //FPeriod
            voucherRed.FPeriod = DateTime.Now.Month;

            ///FNumber
            voucherRed.FNumber = Vouchers.GetNewFNumber(voucherRed.FYear, voucherRed.FPeriod, voucherRed.FGroupID);

            ///FSerialNum
            voucherRed.FSerialNum = Vouchers.GetNewSerialNum();

            //uuid
            voucherRed.UUID = Guid.NewGuid();

            //FDate
            voucherRed.FDate = DateTime.Now;

            //FTransDate
            voucherRed.FTransDate = DateTime.Now;

            foreach (VoucherEntry voucherEntryRed in voucherEntryReds)
            {
                //voucherEntryRed.FVoucherID = voucherRed.FVoucherID;
                //string accountID = voucherEntryRed.FAccountID.ToString();

                //if (AccountList.IndexOf(accountID) > -1)
                //{
                //    voucherEntryRed.FAccountID = VoucherEntries.ReplaceAccountID(voucherEntryRed.FAccountID);
                //}

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
                //DataGridViewX1.Columns["FVoucherID"].Visible = false;

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
                string VoucherID = DataGridViewX1.Rows.Count > 0 ? DataGridViewX1.Rows[0].Cells["FVoucherID"].Value.ToString() : "-1";
                voucherOrigin = BaseDAL.GetModel<Voucher>("FVoucherID", VoucherID)[0];
                voucherEntryOrigins = BaseDAL.GetModel<VoucherEntry>("FVoucherID", VoucherID);

                voucherBlue = voucherOrigin;
                voucherEntryBlues = voucherEntryOrigins;

                //修改蓝字凭证
                Modify4Blue(voucherBlue, voucherEntryBlues, AccountList);

                //写入蓝字凭证
                Insert4Blue(voucherBlue, voucherEntryBlues);

                
                voucherRed = voucherBlue;
                voucherEntryReds = voucherEntryBlues;

                //修改红字凭证
                Modify4Red(voucherRed, voucherEntryReds);

                //写入红字凭证
                Insert4Red(voucherRed, voucherEntryReds);
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
                combobox.SelectedIndex = 4;
            }
            else
            {
                //DataSource为空
            }
        }
        #endregion
    }
}