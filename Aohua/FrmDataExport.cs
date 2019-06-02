using Aohua.DAL;
using Aohua.Models;
using DevComponents.DotNetBar;
using Ryan.Framework.DBUtility;
using System.Data;
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

        /// <summary>
        /// 迁移数据
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BExportData_Click(object sender, System.EventArgs e)
        {
            //取出K3客户编号列表
            string K3IDList = GetCustIdList();
            //MessageBoxEx.Show(K3IDList);

            //写入客户信息表
            int ret1 = InsertCustInfo(K3IDList);
            MessageBoxEx.Show("写入客户信息表完成！" + ret1 +"条！");

            //写入ICStockbill表
            int ret2 = InsertBillInfo(K3IDList);
            MessageBoxEx.Show("写入出库单完成！" + ret2 + "条！"); 

            //写入ICStockBillEntry表
            //int ret3 = InsertBillEntryInfo(K3IDList);
            //MessageBoxEx.Show("写入出库单明细完成！" + ret3 + "条！");

            //写入ICItem表

            //写入单位表
            //int ret5 = InsertUnitInfo(K3IDList);
        }   

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private string GetCustIdList()
        {
            string ret = "";
            sql = "Select [FK3ID] from Ryan_CustCompare";
            dt = SqlHelper.ExecuteDataTable(connFin,sql);
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
        /// 
        /// </summary>
        /// <param name="ids"></param>
        private int InsertCustInfo(string ids)
        {
            sql = string.Format("Select * FROM [t_Organization] Where FItemid in({0})",ids);
            dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
            if (dt.Rows.Count > 0)
            {
                int ret = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    Organization organization = Organizations.GetModel(dr);
                    //记录不存在
                    if (Organizations.Exist(organization.FName,organization.FItemID) == false)
                    {
                        ret += Organizations.Insert(organization);
                    }
                }
                return ret;
            }
            else
            {
                //messagebox;
                return 0;
            }
        }

        private int InsertBillInfo(string ids)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   SELECT  FBrNo, FInterID, FTranType, FDate, FBillNo, FUse, FNote, FDCStockID, FSCStockID, FDeptID, FEmpID, FSupplyID, FPosterID, FCheckerID, FFManagerID, ");
            sb.Append("   FSManagerID, FBillerID, FReturnBillInterID, FSCBillNo, FHookInterID, FVchInterID, FPosted, FCheckSelect, FCurrencyID, FSaleStyle, FAcctID, FROB,");
            sb.Append("   FRSCBillNo, FStatus, FUpStockWhenSave, FCancellation, FOrgBillInterID, FBillTypeID, FPOStyle, FMultiCheckLevel1, FMultiCheckLevel2,");
            sb.Append("   FMultiCheckLevel3, FMultiCheckLevel4, FMultiCheckLevel5, FMultiCheckLevel6, FMultiCheckDate1, FMultiCheckDate2, FMultiCheckDate3,");
            sb.Append("   FMultiCheckDate4, FMultiCheckDate5, FMultiCheckDate6, FCurCheckLevel, FTaskID, FResourceID, FBackFlushed, FWBInterID, FTranStatus,");
            sb.Append("   FZPBillInterID, FRelateBrID, FPurposeID, FUUID, FRelateInvoiceID, FOperDate, FImport, FSystemType, FMarketingStyle, FPayBillID, FCheckDate,");
            sb.Append("   FExplanation, FFetchAdd, FFetchDate, FManagerID, FRefType, FSelTranType, FChildren, FHookStatus, FActPriceVchTplID, FPlanPriceVchTplID, FProcID,");
            sb.Append("   FActualVchTplID, FPlanVchTplID, FBrID, FVIPCardID, FVIPScore, FHolisticDiscountRate, FPOSName, FWorkShiftId, FCussentAcctID, FZanGuCount,");
            sb.Append("   FCOMHFreeItem1, FCOMHFreeItem2, FCOMHFreeItem3, FCOMHFreeItem4, FCOMHFreeItem5, FCOMHFreeItem6, FCOMHFreeItem7, FCOMHFreeItem8,");
            sb.Append("   FCOMHFreeItem9, FCOMHFreeItem10, FCOMHFreeItem11, FCOMHFreeItem12, FCOMHFreeItem13, FCOMHFreeItem15, FCOMHFreeItem18,");
            sb.Append("   FCOMHFreeItem19, FCOMHFreeItem20, FPOOrdBillNo, FLSSrcInterID, FSettleDate, FManageType, FOrderAffirm, FAutoCreType, FConsignee,");
            sb.Append("   FDrpRelateTranType, FPrintCount, FCOMHFreeItem17, FHeadSelfB0154");
            sb.Append("   FROM ICStockBill");
            sb.Append("   WHERE(FTranType = 21) AND(FSupplyID IN({0}))");
            sql = string.Format(sb.ToString(), ids);
            dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
            if (dt.Rows.Count > 0)
            {
                int retBill = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    ICStockBill iCStockBill = ICStockBills.GetModel(dr);
                    //记录不存在
                    if (ICStockBills.Exist(iCStockBill.FBillNo) == false)
                    {
                        //取种子函数
                        int InterID = int.Parse(GetMaxFInterID());
                        //反写种子函数
                        retBill += ICStockBills.Insert(iCStockBill,InterID);
                        InsertBillEntryInfo(iCStockBill.FInterID, InterID);
                    }
                }
                return retBill;
            }
            else
            {
                //messagebox;
                return 0;
            }
        }

        private int InsertBillEntryInfo(int OrginInterID,int NewInterID)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("   SELECT  ICStockBillEntry.FBrNo, ICStockBillEntry.FInterID, ICStockBillEntry.FEntryID, ICStockBillEntry.FItemID, ICStockBillEntry.FQtyMust, ICStockBillEntry.FQty, ");
            sb.Append("   ICStockBillEntry.FPrice, ICStockBillEntry.FBatchNo, ICStockBillEntry.FAmount, ICStockBillEntry.FNote, ICStockBillEntry.FSCBillInterID,");
            sb.Append("   ICStockBillEntry.FSCBillNo, ICStockBillEntry.FUnitID, ICStockBillEntry.FAuxPrice, ICStockBillEntry.FAuxQty, ICStockBillEntry.FAuxQtyMust,");
            sb.Append("   ICStockBillEntry.FQtyActual, ICStockBillEntry.FAuxQtyActual, ICStockBillEntry.FPlanPrice, ICStockBillEntry.FAuxPlanPrice,");
            sb.Append("   ICStockBillEntry.FSourceEntryID, ICStockBillEntry.FCommitQty, ICStockBillEntry.FAuxCommitQty, ICStockBillEntry.FKFDate, ICStockBillEntry.FKFPeriod,");
            sb.Append("   ICStockBillEntry.FDCSPID, ICStockBillEntry.FSCSPID, ICStockBillEntry.FConsignPrice, ICStockBillEntry.FConsignAmount, ICStockBillEntry.FProcessCost,");
            sb.Append("   ICStockBillEntry.FMaterialCost, ICStockBillEntry.FTaxAmount, ICStockBillEntry.FMapNumber, ICStockBillEntry.FMapName,");
            sb.Append("   ICStockBillEntry.FOrgBillEntryID, ICStockBillEntry.FOperID, ICStockBillEntry.FPlanAmount, ICStockBillEntry.FProcessPrice, ICStockBillEntry.FTaxRate,");
            sb.Append("   ICStockBillEntry.FSnListID, ICStockBillEntry.FAmtRef, ICStockBillEntry.FAuxPropID, ICStockBillEntry.FCost, ICStockBillEntry.FPriceRef,");
            sb.Append("   ICStockBillEntry.FAuxPriceRef, ICStockBillEntry.FFetchDate, ICStockBillEntry.FQtyInvoice, ICStockBillEntry.FQtyInvoiceBase, ICStockBillEntry.FUnitCost,");
            sb.Append("   ICStockBillEntry.FSecCoefficient, ICStockBillEntry.FSecQty, ICStockBillEntry.FSecCommitQty, ICStockBillEntry.FSourceTranType,");
            sb.Append("   ICStockBillEntry.FSourceInterId, ICStockBillEntry.FSourceBillNo, ICStockBillEntry.FContractInterID, ICStockBillEntry.FContractEntryID,");
            sb.Append("   ICStockBillEntry.FContractBillNo, ICStockBillEntry.FICMOBillNo, ICStockBillEntry.FICMOInterID, ICStockBillEntry.FPPBomEntryID,");
            sb.Append("   ICStockBillEntry.FOrderInterID, ICStockBillEntry.FOrderEntryID, ICStockBillEntry.FOrderBillNo, ICStockBillEntry.FAllHookQTY,");
            sb.Append("   ICStockBillEntry.FAllHookAmount, ICStockBillEntry.FCurrentHookQTY, ICStockBillEntry.FCurrentHookAmount, ICStockBillEntry.FStdAllHookAmount,");
            sb.Append("   ICStockBillEntry.FStdCurrentHookAmount, ICStockBillEntry.FSCStockID, ICStockBillEntry.FDCStockID, ICStockBillEntry.FPeriodDate,");
            sb.Append("   ICStockBillEntry.FCostObjGroupID, ICStockBillEntry.FCostOBJID, ICStockBillEntry.FDetailID, ICStockBillEntry.FMaterialCostPrice,");
            sb.Append("   ICStockBillEntry.FReProduceType, ICStockBillEntry.FBomInterID, ICStockBillEntry.FDiscountRate, ICStockBillEntry.FDiscountAmount,");
            sb.Append("   ICStockBillEntry.FSepcialSaleId, ICStockBillEntry.FOutCommitQty, ICStockBillEntry.FOutSecCommitQty, ICStockBillEntry.FDBCommitQty,");
            sb.Append("   ICStockBillEntry.FDBSecCommitQty, ICStockBillEntry.FAuxQtyInvoice, ICStockBillEntry.FOperSN, ICStockBillEntry.FCheckStatus,");
            sb.Append("   ICStockBillEntry.FSplitSecQty, ICStockBillEntry.FCOMBFreeItem1, ICStockBillEntry.FCOMBFreeItem2, ICStockBillEntry.FCOMBFreeItem3,");
            sb.Append("   ICStockBillEntry.FCOMBFreeItem4, ICStockBillEntry.FCOMBFreeItem5, ICStockBillEntry.FCOMBFreeItem7, ICStockBillEntry.FCOMBFreeItem10,");
            sb.Append("   ICStockBillEntry.FCOMBFreeItem11, ICStockBillEntry.FSaleCommitQty, ICStockBillEntry.FSaleSecCommitQty, ICStockBillEntry.FSaleAuxCommitQty,");
            sb.Append("   ICStockBillEntry.FInStockID, ICStockBillEntry.FSelectedProcID, ICStockBillEntry.FVWInStockQty, ICStockBillEntry.FAuxVWInStockQty,");
            sb.Append("   ICStockBillEntry.FSecVWInStockQty, ICStockBillEntry.FSecInvoiceQty, ICStockBillEntry.FCostCenterID, ICStockBillEntry.FPlanMode,");
            sb.Append("   ICStockBillEntry.FMTONo, ICStockBillEntry.FSecQtyActual, ICStockBillEntry.FSecQtyMust, ICStockBillEntry.FClientOrderNo,");
            sb.Append("   ICStockBillEntry.FClientEntryID, ICStockBillEntry.FRowClosed, ICStockBillEntry.FCostPercentage, ICStockBillEntry.FEntrySelfB0168,");
            sb.Append("   ICStockBillEntry.FEntrySelfB0169, ICStockBillEntry.FEntrySelfD0148, ICStockBillEntry.FCOMBFreeItem9");
            sb.Append("   FROM ICStockBillEntry ");
            sb.Append("   Where ICStockBillEntry.FInterID = {0}");
            sql = string.Format(sb.ToString(),OrginInterID);
            dt = SqlHelper.ExecuteDataTable(connK3Src, sql);
            if (dt.Rows.Count > 0)
            {
                int retEntry = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    ICStockBillEntry iCStockBillEntry = ICStockBillEntrys.GetModel(dr);
                    retEntry += ICStockBillEntrys.Insert(iCStockBillEntry,NewInterID);
                }
                return retEntry;
            }
            else
            {
                //messagebox;
                return 0;
            }
        }

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
    }
}