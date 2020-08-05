using Aohua.DAL;
using Aohua.Models;
using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Common;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aohua
{
    public partial class FrmDataExport : Office2007Form
    {
        private string sql = "";
        private DataTable dt = (DataTable)null;
        private static string connFin = SqlHelper.GetConnectionString("FinSrc");
        private static string connK3Src = SqlHelper.GetConnectionString("K3Src");
        private static string connK3Desc = SqlHelper.GetConnectionString("K3Desc");

        public FrmDataExport()
        {
            InitializeComponent();
        }

        #region unUsed

        /// <summary>
        /// 迁移数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void BExportData_Click(object sender, System.EventArgs e)
        //{
        //取出K3客户编号列表
        //string K3IDList = GetCustIdList();
        //MessageBoxEx.Show(K3IDList);

        //写入客户信息表
        //int ret1 = InsertCustInfo(K3IDList);
        //MessageBoxEx.Show("写入客户信息表完成！" + ret1 +"条！");

        //写入ICStockbill表
        //int ret2 = InsertBillInfo(K3IDList);
        //MessageBoxEx.Show("写入出库单完成！" + ret2 + "条！"); 

        //写入ICStockBillEntry表
        //int ret3 = InsertBillEntryInfo(K3IDList);
        //MessageBoxEx.Show("写入出库单明细完成！" + ret3 + "条！");

        //写入ICItem表

        //写入单位表
        //int ret5 = InsertUnitInfo(K3IDList);
        //}   

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        //private string GetCustIdList()
        //{
        //    string ret = "";
        //    sql = "Select [FK3ID] from Ryan_CustCompare";
        //    dt = SqlHelper.ExecuteDataTable(connFin,sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ret += dr[0].ToString() + ",";
        //        }
        //        return ret.Substring(0, ret.Length - 1);
        //    }
        //    else
        //    {
        //        //messagebox 
        //        return "";
        //    }
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ids"></param>
        //private int InsertCustInfo(string ids)
        //{
        //    sql = string.Format("Select * FROM [t_Organization] Where FItemid in({0})",ids);
        //    dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        int ret = 0;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            Organization organization = Organizations.GetModel(dr);
        //            //记录不存在
        //            if (Organizations.Exist(organization.FName,organization.FItemID) == false)
        //            {
        //                ret += Organizations.Insert(organization);
        //            }
        //        }
        //        return ret;
        //    }
        //    else
        //    {
        //        //messagebox;
        //        return 0;
        //    }
        //}

        //private int InsertBillInfo(string ids)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("   SELECT  FBrNo, FInterID, FTranType, FDate, FBillNo, FUse, FNote, FDCStockID, FSCStockID, FDeptID, FEmpID, FSupplyID, FPosterID, FCheckerID, FFManagerID, ");
        //    sb.Append("   FSManagerID, FBillerID, FReturnBillInterID, FSCBillNo, FHookInterID, FVchInterID, FPosted, FCheckSelect, FCurrencyID, FSaleStyle, FAcctID, FROB,");
        //    sb.Append("   FRSCBillNo, FStatus, FUpStockWhenSave, FCancellation, FOrgBillInterID, FBillTypeID, FPOStyle, FMultiCheckLevel1, FMultiCheckLevel2,");
        //    sb.Append("   FMultiCheckLevel3, FMultiCheckLevel4, FMultiCheckLevel5, FMultiCheckLevel6, FMultiCheckDate1, FMultiCheckDate2, FMultiCheckDate3,");
        //    sb.Append("   FMultiCheckDate4, FMultiCheckDate5, FMultiCheckDate6, FCurCheckLevel, FTaskID, FResourceID, FBackFlushed, FWBInterID, FTranStatus,");
        //    sb.Append("   FZPBillInterID, FRelateBrID, FPurposeID, FUUID, FRelateInvoiceID, FOperDate, FImport, FSystemType, FMarketingStyle, FPayBillID, FCheckDate,");
        //    sb.Append("   FExplanation, FFetchAdd, FFetchDate, FManagerID, FRefType, FSelTranType, FChildren, FHookStatus, FActPriceVchTplID, FPlanPriceVchTplID, FProcID,");
        //    sb.Append("   FActualVchTplID, FPlanVchTplID, FBrID, FVIPCardID, FVIPScore, FHolisticDiscountRate, FPOSName, FWorkShiftId, FCussentAcctID, FZanGuCount,");
        //    sb.Append("   FCOMHFreeItem1, FCOMHFreeItem2, FCOMHFreeItem3, FCOMHFreeItem4, FCOMHFreeItem5, FCOMHFreeItem6, FCOMHFreeItem7, FCOMHFreeItem8,");
        //    sb.Append("   FCOMHFreeItem9, FCOMHFreeItem10, FCOMHFreeItem11, FCOMHFreeItem12, FCOMHFreeItem13, FCOMHFreeItem15, FCOMHFreeItem18,");
        //    sb.Append("   FCOMHFreeItem19, FCOMHFreeItem20, FPOOrdBillNo, FLSSrcInterID, FSettleDate, FManageType, FOrderAffirm, FAutoCreType, FConsignee,");
        //    sb.Append("   FDrpRelateTranType, FPrintCount, FCOMHFreeItem17, FHeadSelfB0154");
        //    sb.Append("   FROM ICStockBill");
        //    sb.Append("   WHERE(FTranType = 21) AND(FSupplyID IN({0}))");
        //    sql = string.Format(sb.ToString(), ids);
        //    dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        int retBill = 0;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ICStockBill iCStockBill = ICStockBills.GetModel(dr);
        //            //记录不存在
        //            if (ICStockBills.Exist(iCStockBill.FBillNo) == false)
        //            {
        //                //取种子函数
        //                int InterID = int.Parse(GetMaxFInterID());
        //                //反写种子函数
        //                retBill += ICStockBills.Insert(iCStockBill,InterID);
        //                InsertBillEntryInfo(iCStockBill.FInterID, InterID);
        //            }
        //        }
        //        return retBill;
        //    }
        //    else
        //    {
        //        //messagebox;
        //        return 0;
        //    }
        //}

        //private int InsertBillEntryInfo(int OrginInterID,int NewInterID)
        //{
        //    StringBuilder sb = new StringBuilder();
        //    sb.Append("   SELECT  ICStockBillEntry.FBrNo, ICStockBillEntry.FInterID, ICStockBillEntry.FEntryID, ICStockBillEntry.FItemID, ICStockBillEntry.FQtyMust, ICStockBillEntry.FQty, ");
        //    sb.Append("   ICStockBillEntry.FPrice, ICStockBillEntry.FBatchNo, ICStockBillEntry.FAmount, ICStockBillEntry.FNote, ICStockBillEntry.FSCBillInterID,");
        //    sb.Append("   ICStockBillEntry.FSCBillNo, ICStockBillEntry.FUnitID, ICStockBillEntry.FAuxPrice, ICStockBillEntry.FAuxQty, ICStockBillEntry.FAuxQtyMust,");
        //    sb.Append("   ICStockBillEntry.FQtyActual, ICStockBillEntry.FAuxQtyActual, ICStockBillEntry.FPlanPrice, ICStockBillEntry.FAuxPlanPrice,");
        //    sb.Append("   ICStockBillEntry.FSourceEntryID, ICStockBillEntry.FCommitQty, ICStockBillEntry.FAuxCommitQty, ICStockBillEntry.FKFDate, ICStockBillEntry.FKFPeriod,");
        //    sb.Append("   ICStockBillEntry.FDCSPID, ICStockBillEntry.FSCSPID, ICStockBillEntry.FConsignPrice, ICStockBillEntry.FConsignAmount, ICStockBillEntry.FProcessCost,");
        //    sb.Append("   ICStockBillEntry.FMaterialCost, ICStockBillEntry.FTaxAmount, ICStockBillEntry.FMapNumber, ICStockBillEntry.FMapName,");
        //    sb.Append("   ICStockBillEntry.FOrgBillEntryID, ICStockBillEntry.FOperID, ICStockBillEntry.FPlanAmount, ICStockBillEntry.FProcessPrice, ICStockBillEntry.FTaxRate,");
        //    sb.Append("   ICStockBillEntry.FSnListID, ICStockBillEntry.FAmtRef, ICStockBillEntry.FAuxPropID, ICStockBillEntry.FCost, ICStockBillEntry.FPriceRef,");
        //    sb.Append("   ICStockBillEntry.FAuxPriceRef, ICStockBillEntry.FFetchDate, ICStockBillEntry.FQtyInvoice, ICStockBillEntry.FQtyInvoiceBase, ICStockBillEntry.FUnitCost,");
        //    sb.Append("   ICStockBillEntry.FSecCoefficient, ICStockBillEntry.FSecQty, ICStockBillEntry.FSecCommitQty, ICStockBillEntry.FSourceTranType,");
        //    sb.Append("   ICStockBillEntry.FSourceInterId, ICStockBillEntry.FSourceBillNo, ICStockBillEntry.FContractInterID, ICStockBillEntry.FContractEntryID,");
        //    sb.Append("   ICStockBillEntry.FContractBillNo, ICStockBillEntry.FICMOBillNo, ICStockBillEntry.FICMOInterID, ICStockBillEntry.FPPBomEntryID,");
        //    sb.Append("   ICStockBillEntry.FOrderInterID, ICStockBillEntry.FOrderEntryID, ICStockBillEntry.FOrderBillNo, ICStockBillEntry.FAllHookQTY,");
        //    sb.Append("   ICStockBillEntry.FAllHookAmount, ICStockBillEntry.FCurrentHookQTY, ICStockBillEntry.FCurrentHookAmount, ICStockBillEntry.FStdAllHookAmount,");
        //    sb.Append("   ICStockBillEntry.FStdCurrentHookAmount, ICStockBillEntry.FSCStockID, ICStockBillEntry.FDCStockID, ICStockBillEntry.FPeriodDate,");
        //    sb.Append("   ICStockBillEntry.FCostObjGroupID, ICStockBillEntry.FCostOBJID, ICStockBillEntry.FDetailID, ICStockBillEntry.FMaterialCostPrice,");
        //    sb.Append("   ICStockBillEntry.FReProduceType, ICStockBillEntry.FBomInterID, ICStockBillEntry.FDiscountRate, ICStockBillEntry.FDiscountAmount,");
        //    sb.Append("   ICStockBillEntry.FSepcialSaleId, ICStockBillEntry.FOutCommitQty, ICStockBillEntry.FOutSecCommitQty, ICStockBillEntry.FDBCommitQty,");
        //    sb.Append("   ICStockBillEntry.FDBSecCommitQty, ICStockBillEntry.FAuxQtyInvoice, ICStockBillEntry.FOperSN, ICStockBillEntry.FCheckStatus,");
        //    sb.Append("   ICStockBillEntry.FSplitSecQty, ICStockBillEntry.FCOMBFreeItem1, ICStockBillEntry.FCOMBFreeItem2, ICStockBillEntry.FCOMBFreeItem3,");
        //    sb.Append("   ICStockBillEntry.FCOMBFreeItem4, ICStockBillEntry.FCOMBFreeItem5, ICStockBillEntry.FCOMBFreeItem7, ICStockBillEntry.FCOMBFreeItem10,");
        //    sb.Append("   ICStockBillEntry.FCOMBFreeItem11, ICStockBillEntry.FSaleCommitQty, ICStockBillEntry.FSaleSecCommitQty, ICStockBillEntry.FSaleAuxCommitQty,");
        //    sb.Append("   ICStockBillEntry.FInStockID, ICStockBillEntry.FSelectedProcID, ICStockBillEntry.FVWInStockQty, ICStockBillEntry.FAuxVWInStockQty,");
        //    sb.Append("   ICStockBillEntry.FSecVWInStockQty, ICStockBillEntry.FSecInvoiceQty, ICStockBillEntry.FCostCenterID, ICStockBillEntry.FPlanMode,");
        //    sb.Append("   ICStockBillEntry.FMTONo, ICStockBillEntry.FSecQtyActual, ICStockBillEntry.FSecQtyMust, ICStockBillEntry.FClientOrderNo,");
        //    sb.Append("   ICStockBillEntry.FClientEntryID, ICStockBillEntry.FRowClosed, ICStockBillEntry.FCostPercentage, ICStockBillEntry.FEntrySelfB0168,");
        //    sb.Append("   ICStockBillEntry.FEntrySelfB0169, ICStockBillEntry.FEntrySelfD0148, ICStockBillEntry.FCOMBFreeItem9");
        //    sb.Append("   FROM ICStockBillEntry ");
        //    sb.Append("   Where ICStockBillEntry.FInterID = {0}");
        //    sql = string.Format(sb.ToString(),OrginInterID);
        //    dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
        //    if (dt.Rows.Count > 0)
        //    {
        //        int retEntry = 0;
        //        foreach (DataRow dr in dt.Rows)
        //        {
        //            ICStockBillEntry iCStockBillEntry = ICStockBillEntrys.GetModel(dr);
        //            retEntry += ICStockBillEntrys.Insert(iCStockBillEntry,NewInterID);
        //        }
        //        return retEntry;
        //    }
        //    else
        //    {
        //        //messagebox;
        //        return 0;
        //    }
        //}

        //public string GetMaxFInterID()
        //{
        //    sql = "UPDATE ICMaxNum SET FMaxNum = FMaxNum + 1 WHERE FTableName = 'ICStockBill'";
        //    int retVal = SqlHelper.ExecuteNonQuery(connK3Desc, sql);
        //    if (retVal > 0)
        //    {
        //        sql = "SELECT FMaxNum FROM ICMaxNum WHERE FTableName = 'ICStockBill'";
        //        object obj = SqlHelper.ExecuteScalar(connK3Desc, sql);

        //        return obj != null ? obj.ToString() : "";
        //    }
        //    else
        //    {
        //        return "";
        //    }
        //}
        #endregion    

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnUnMark_Click(object sender, System.EventArgs e)
        {
            int ret = UNMarkK3Data(GetCustIdList());
            MessageBoxEx.Show(ret.ToString());
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnMark_Click(object sender, System.EventArgs e)
        {
            int ret = MarkK3Data(GetCustIdList());
            MessageBoxEx.Show(ret.ToString());
        }

        /// <summary>
        ///  得到已经匹配成功的业务系统 客户ID 列表
        /// </summary>
        /// <returns></returns>
        private string GetCustIdList()
        {
            string ret = "";
            sql = "Select [FK3ID] from Ryan_CustCompare";
            dt = SqlHelper.ExecuteDataTable(connFin, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ret += dr[0].ToString() + ",";
                }
                return ret.Substring(0, ret.Length - 1);
            }
            else
            {
                //messagebox 
                return "";
            }
        }

        /// <summary>
        /// 把匹配成功的客户名称加上AH，用以标记客户
        /// </summary>
        /// <param name = "ids" ></ param >
        private int MarkK3Data(string ids)
        {
            sql = string.Format("UPDATE [t_Organization] SET [FEMail] = 'AH' WHERE FItemid IN({0})", ids);
            return SqlHelper.ExecuteNonQuery(connK3Src, sql);
        }

        /// <summary>
        /// 把匹配成功的客户名称加上AH，用以标记客户
        /// </summary>
        /// <param name = "ids" ></ param >
        private int UNMarkK3Data(string ids)
        {
            sql = string.Format("UPDATE [t_Organization] SET [FEMail] =@FEMail WHERE FItemid IN({0})", ids);
            SqlParameter[] para = new SqlParameter[] { new SqlParameter("@FEMail", DBNull.Value) };
            return SqlHelper.ExecuteNonQuery(connK3Src, sql, para);
        }

        private void BExpData_Click(object sender, EventArgs e)
        {
            //查询源数据库，得到需要升迁客户ID的列表
            string ids = GetCustIdList2020();
            Console.WriteLine("ids:" + ids);

            string StartDate = dtiStartDate.Value.ToString("yyyy-MM-dd") + " 00:00:00";
            string EndDate = dtiEndDate.Value.ToString("yyyy-MM-dd") + " 23:59:59";

            //查询源数据库，得到升迁单据数据列表，
            string BillList = GetBillList(ids,StartDate,EndDate);
            if (BillList == "")
            {
                CustomDesktopAlert.H2("没有可导入的记录。");
            }
            else
            {
                Console.WriteLine("BillNos:" + BillList);
                string[] BillNos = BillList.Split(',');
                //注意Entry表一定要包括物料长代码和客户全名
                int ret = InsertOrUpdateBillInfo2020(BillNos);
                CustomDesktopAlert.H2(string.Format("总共{0}条,成功完成{1}条", BillNos.Length, ret.ToString()));
            }
        }
        #region 2020

        private string GetCustIdList2020()
        {
            string ret = "";
            sql = "Select [FK3ID] from Ryan_CustCompare";
            dt = SqlHelper.ExecuteDataTable(connFin, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ret += dr[0].ToString() + ",";
                }
                return ret.Substring(0, ret.Length - 1);
            }
            else
            {
                //messagebox 
                return "";
            }
        }

        /// <summary>
        /// 根据客户编号列表查询相关出库单编号列表
        /// </summary>
        /// <param name="ids">客户编号列表</param>
        /// <returns>出库单编号列表</returns>
        private string GetBillList(string ids,string StartDate, string EndDate)
        {
            string ret = "";
            StringBuilder sb = new StringBuilder();
            sb.Append(" SELECT DISTINCT FBillNo");
            sb.Append(" FROM ICStockBill");
            sb.Append(" WHERE(FTranType = 21) ");
            sb.Append(" AND FSupplyID IN({0})");
            sb.Append(" AND FDate > '" + StartDate + "'");
            sb.Append(" AND FDate < '" + EndDate + "'");
            sql = string.Format(sb.ToString(), ids);
            dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
            if (dt.Rows.Count > 0)
            {
                foreach (DataRow dr in dt.Rows)
                {
                    ret += dr[0].ToString() + ",";
                }
                return ret.Substring(0, ret.Length - 1);
            }
            else
            {
                //messagebox 
                return "";
            }
        }

        private int InsertOrUpdateBillInfo2020(string[] BillNos)
        {

            if (BillNos.Length > 0)
            {
                int isUpdate = 0;
                int isInsert = 0;
 
                Console.WriteLine("bill count :" + BillNos.Length);

                foreach (string BillNo in BillNos)
                {
                    //查询得到源数据主表信息
                    ICStockBill iCStockBill = ICStockBills.GetModel(connK3Src, BillNo);

                    //替换客户编号
                    iCStockBill = ReplaceSupplyID(iCStockBill);

                    //查询得到源数据明细表信息
                    List<ICStockBillEntry> EntryList = ICStockBillEntrys.GetModelList(connK3Src, iCStockBill.FInterID);

                    //替换各明细行的物料编码
                    EntryList = ReplaceItemUnitID(EntryList);

                    //记录存在就更新
                    if (ICStockBills.Exist(connK3Desc, iCStockBill.FBillNo) == true)
                    {
                        //取得目标数据表某单号的单据内码
                        int InterID = ICStockBills.GetInterIDByBillNo(connK3Desc, iCStockBill.FBillNo);

                        //更新主表内码
                        iCStockBill.FInterID = InterID;

                        //更新明细表内码
                        foreach (ICStockBillEntry Entry in EntryList)
                        {
                            Entry.FInterID = InterID;
                        }

                        //更新数据库主表
                        if (ICStockBills.UpdateSupplyID(connK3Desc, iCStockBill) == true)
                        {
                            int succEntry = 0;
                            foreach(ICStockBillEntry Entry in EntryList)
                            {
                                //更新数据库明细表
                                if (ICStockBillEntrys.UpdateItemUnitID(connK3Desc, Entry) == true)
                                {
                                    succEntry++;
                                }
                            }

                            //判断是否全部完成成功
                            if (succEntry == EntryList.Count)
                            {
                                isUpdate++;
                            }
                            else
                            {
                                //报错：写明细表失败
                                CustomDesktopAlert.H4(string.Format("单号【{0}】写明细表失败!", iCStockBill.FBillNo));
                            }
                        }
                        else
                        {
                            //报错：写主表失败
                            CustomDesktopAlert.H4(string.Format("单号【{0}】写主表失败!", iCStockBill.FBillNo));
                        }
                    }
                    else //否则，追加
                    {
                        //取种子函数
                        int InterID = int.Parse(GetMaxFInterID());

                        //更新主表内码
                        iCStockBill.FInterID = InterID;

                        //更新明细表内码
                        foreach (ICStockBillEntry Entry in EntryList)
                        {
                            Entry.FInterID = InterID;
                        }

                        //插入数据库主表
                        if (ICStockBills.Insert(connK3Desc, iCStockBill) > 0)
                        {
                            int succEntry = 0;
                            foreach (ICStockBillEntry Entry in EntryList)
                            {
                                //插入各明细表
                                if (ICStockBillEntrys.Insert(connK3Desc, Entry) > 0)
                                {
                                    succEntry++;
                                }
                            }
                            //判断是否全部完成成功
                            if (succEntry == EntryList.Count)
                            {
                                isInsert++;
                            }
                            else
                            {
                                //报错：写明细表失败
                                CustomDesktopAlert.H4(string.Format("单号【{0}】写明细表失败!", iCStockBill.FBillNo));
                            }
                        }
                        else
                        {
                            //报错：写主表失败
                            CustomDesktopAlert.H4(string.Format("单号【{0}】写主表失败!", iCStockBill.FBillNo));
                        }

                    }
                    
                }
                Console.WriteLine("isUpdate:" + isUpdate + ", isInsert" + isInsert);
                return isInsert + isUpdate;
            }
            else
            {
                //messagebox;
                CustomDesktopAlert.H4("未查询到相关单据，请检查设置条件！");
                return -1;
            }
        }

        /// <summary>
        /// 更新单据内码ID
        /// </summary>
        /// <returns></returns>
        public string GetMaxFInterID()
        {
            sql = "UPDATE ICMaxNum SET FMaxNum = FMaxNum + 1 WHERE FTableName = 'ICStockBill'";
            int retVal = SqlHelper.ExecuteNonQuery(connK3Desc, sql);
            if (retVal > 0)
            {
                sql = "SELECT FMaxNum FROM ICMaxNum WHERE FTableName = 'ICStockBill'";
                object obj = SqlHelper.ExecuteScalar(connK3Desc, sql);

                return obj != null ? obj.ToString() : "";
            }
            else
            {
                return "";
            }
        }

        /// <summary>
        /// 替换客户编号
        /// </summary>
        /// <param name="iCStockBill"></param>
        /// <returns></returns>
        private ICStockBill ReplaceSupplyID(ICStockBill iCStockBill)
        {
            //替换成新客户ID
            int OriginSupplyId = iCStockBill.FSupplyID;
            int NewSupplyId = ICStockBills.GetNewSupplyIDByOriSupplyID(iCStockBill.FSupplyID, connK3Src, connK3Desc);

            //For Test
            if (NewSupplyId != OriginSupplyId)
            {
                Console.WriteLine("NewSupplyId:" + NewSupplyId + "; OriginSupplyId:" + OriginSupplyId);
            }
            iCStockBill.FSupplyID = NewSupplyId;

            return iCStockBill;
        }

        /// <summary>
        /// 更新明细表中的物料编号
        /// </summary>
        /// <param name="EntryList"></param>
        /// <returns></returns>
        private List<ICStockBillEntry> ReplaceItemUnitID(List<ICStockBillEntry> EntryList)
        {
            foreach (ICStockBillEntry Entry in EntryList)
            {
                //替换物料编号
                int OriginItemID = Entry.FItemID;
                int NewItemID = ICStockBillEntrys.GetNewItemIDByOriginItemID(OriginItemID, connK3Src, connK3Desc);

                //For Test
                if (NewItemID == -1)
                {
                    Console.WriteLine("OriginItemID:" + OriginItemID + "; NewItemID:" + NewItemID);
                }
                //For Test

                Entry.FItemID = NewItemID;

                //替换单位编号
                int OriginUnitID = Entry.FUnitID;
                int NewUnitID = ICStockBillEntrys.GetNewUnitIDByOriginUnitID(OriginUnitID, connK3Src, connK3Desc);

                //For Test
                if (NewUnitID == -1)
                {
                    Console.WriteLine("OriginItemID:" + OriginUnitID + "; NewItemID:" + NewUnitID);
                }
                //For Test

                Entry.FUnitID = NewUnitID;
            }
            return EntryList;
        }
        #endregion


    }
}