using Aohua.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aohua.DAL
{
    public partial class ICStockBillEntrys
    {
        //private static string connK3Desc = SqlHelper.GetConnectionString("K3Desc");

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Insert(string conn, ICStockBillEntry iCStockBillEntry)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into iCStockBillEntry(");
            strSql.Append("FBrNo,FInterID,FEntryID,FItemID,FQtyMust,FQty,FPrice,FBatchNo,FAmount,FNote,FSCBillInterID,FSCBillNo,FUnitID,FAuxPrice,FAuxQty,FAuxQtyMust,FQtyActual,FAuxQtyActual,FPlanPrice,FAuxPlanPrice,FSourceEntryID,FCommitQty,FAuxCommitQty,FKFDate,FKFPeriod,FDCSPID,FSCSPID,FConsignPrice,FConsignAmount,FProcessCost,FMaterialCost,FTaxAmount,FMapNumber,FMapName,FOrgBillEntryID,FOperID,FPlanAmount,FProcessPrice,FTaxRate,FSnListID,FAmtRef,FAuxPropID,FCost,FPriceRef,FAuxPriceRef,FFetchDate,FQtyInvoice,FQtyInvoiceBase,FUnitCost,FSecCoefficient,FSecQty,FSecCommitQty,FSourceTranType,FSourceInterId,FSourceBillNo,FContractInterID,FContractEntryID,FContractBillNo,FICMOBillNo,FICMOInterID,FPPBomEntryID,FOrderInterID,FOrderEntryID,FOrderBillNo,FAllHookQTY,FAllHookAmount,FCurrentHookQTY,FCurrentHookAmount,FStdAllHookAmount,FStdCurrentHookAmount,FSCStockID,FDCStockID,FPeriodDate,FCostObjGroupID,FCostOBJID,FMaterialCostPrice,FReProduceType,FBomInterID,FDiscountRate,FDiscountAmount,FSepcialSaleId,FOutCommitQty,FOutSecCommitQty,FDBCommitQty,FDBSecCommitQty,FAuxQtyInvoice,FOperSN,FCheckStatus,FSplitSecQty,FCOMBFreeItem1,FCOMBFreeItem2,FCOMBFreeItem3,FCOMBFreeItem4,FCOMBFreeItem5,FCOMBFreeItem7,FCOMBFreeItem10,FCOMBFreeItem11,FSaleCommitQty,FSaleSecCommitQty,FSaleAuxCommitQty,FInStockID,FSelectedProcID,FVWInStockQty,FAuxVWInStockQty,FSecVWInStockQty,FSecInvoiceQty,FCostCenterID,FPlanMode,FMTONo,FSecQtyActual,FSecQtyMust,FClientOrderNo,FClientEntryID,FRowClosed,FCostPercentage,FEntrySelfB0168,FEntrySelfB0169,FEntrySelfD0148,FCOMBFreeItem9)");
            strSql.Append(" values (");
            strSql.Append("@FBrNo,@FInterID,@FEntryID,@FItemID,@FQtyMust,@FQty,@FPrice,@FBatchNo,@FAmount,@FNote,@FSCBillInterID,@FSCBillNo,@FUnitID,@FAuxPrice,@FAuxQty,@FAuxQtyMust,@FQtyActual,@FAuxQtyActual,@FPlanPrice,@FAuxPlanPrice,@FSourceEntryID,@FCommitQty,@FAuxCommitQty,@FKFDate,@FKFPeriod,@FDCSPID,@FSCSPID,@FConsignPrice,@FConsignAmount,@FProcessCost,@FMaterialCost,@FTaxAmount,@FMapNumber,@FMapName,@FOrgBillEntryID,@FOperID,@FPlanAmount,@FProcessPrice,@FTaxRate,@FSnListID,@FAmtRef,@FAuxPropID,@FCost,@FPriceRef,@FAuxPriceRef,@FFetchDate,@FQtyInvoice,@FQtyInvoiceBase,@FUnitCost,@FSecCoefficient,@FSecQty,@FSecCommitQty,@FSourceTranType,@FSourceInterId,@FSourceBillNo,@FContractInterID,@FContractEntryID,@FContractBillNo,@FICMOBillNo,@FICMOInterID,@FPPBomEntryID,@FOrderInterID,@FOrderEntryID,@FOrderBillNo,@FAllHookQTY,@FAllHookAmount,@FCurrentHookQTY,@FCurrentHookAmount,@FStdAllHookAmount,@FStdCurrentHookAmount,@FSCStockID,@FDCStockID,@FPeriodDate,@FCostObjGroupID,@FCostOBJID,@FMaterialCostPrice,@FReProduceType,@FBomInterID,@FDiscountRate,@FDiscountAmount,@FSepcialSaleId,@FOutCommitQty,@FOutSecCommitQty,@FDBCommitQty,@FDBSecCommitQty,@FAuxQtyInvoice,@FOperSN,@FCheckStatus,@FSplitSecQty,@FCOMBFreeItem1,@FCOMBFreeItem2,@FCOMBFreeItem3,@FCOMBFreeItem4,@FCOMBFreeItem5,@FCOMBFreeItem7,@FCOMBFreeItem10,@FCOMBFreeItem11,@FSaleCommitQty,@FSaleSecCommitQty,@FSaleAuxCommitQty,@FInStockID,@FSelectedProcID,@FVWInStockQty,@FAuxVWInStockQty,@FSecVWInStockQty,@FSecInvoiceQty,@FCostCenterID,@FPlanMode,@FMTONo,@FSecQtyActual,@FSecQtyMust,@FClientOrderNo,@FClientEntryID,@FRowClosed,@FCostPercentage,@FEntrySelfB0168,@FEntrySelfB0169,@FEntrySelfD0148,@FCOMBFreeItem9)");
            strSql.Append(";select @@IDENTITY");
            SqlParameter[] parameters = {
                    new SqlParameter("@FBrNo", SqlDbType.VarChar,10),
                    new SqlParameter("@FInterID", SqlDbType.Int,4),
                    new SqlParameter("@FEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FItemID", SqlDbType.Int,4),
                    new SqlParameter("@FQtyMust", SqlDbType.Decimal,13),
                    new SqlParameter("@FQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FBatchNo", SqlDbType.VarChar,200),
                    new SqlParameter("@FAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FNote", SqlDbType.VarChar,255),
                    new SqlParameter("@FSCBillInterID", SqlDbType.Int,4),
                    new SqlParameter("@FSCBillNo", SqlDbType.VarChar,30),
                    new SqlParameter("@FUnitID", SqlDbType.Int,4),
                    new SqlParameter("@FAuxPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxQtyMust", SqlDbType.Decimal,13),
                    new SqlParameter("@FQtyActual", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxQtyActual", SqlDbType.Decimal,13),
                    new SqlParameter("@FPlanPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxPlanPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FSourceEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FKFDate", SqlDbType.DateTime),
                    new SqlParameter("@FKFPeriod", SqlDbType.Int,4),
                    new SqlParameter("@FDCSPID", SqlDbType.Int,4),
                    new SqlParameter("@FSCSPID", SqlDbType.Int,4),
                    new SqlParameter("@FConsignPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FConsignAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FProcessCost", SqlDbType.Decimal,13),
                    new SqlParameter("@FMaterialCost", SqlDbType.Decimal,13),
                    new SqlParameter("@FTaxAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FMapNumber", SqlDbType.VarChar,80),
                    new SqlParameter("@FMapName", SqlDbType.NVarChar,256),
                    new SqlParameter("@FOrgBillEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FOperID", SqlDbType.Int,4),
                    new SqlParameter("@FPlanAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FProcessPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FTaxRate", SqlDbType.Decimal,13),
                    new SqlParameter("@FSnListID", SqlDbType.Int,4),
                    new SqlParameter("@FAmtRef", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxPropID", SqlDbType.Int,4),
                    new SqlParameter("@FCost", SqlDbType.Decimal,13),
                    new SqlParameter("@FPriceRef", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxPriceRef", SqlDbType.Decimal,13),
                    new SqlParameter("@FFetchDate", SqlDbType.DateTime),
                    new SqlParameter("@FQtyInvoice", SqlDbType.Decimal,13),
                    new SqlParameter("@FQtyInvoiceBase", SqlDbType.Decimal,13),
                    new SqlParameter("@FUnitCost", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecCoefficient", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSourceTranType", SqlDbType.Int,4),
                    new SqlParameter("@FSourceInterId", SqlDbType.Int,4),
                    new SqlParameter("@FSourceBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FContractInterID", SqlDbType.Int,4),
                    new SqlParameter("@FContractEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FContractBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FICMOBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FICMOInterID", SqlDbType.Int,4),
                    new SqlParameter("@FPPBomEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FOrderInterID", SqlDbType.Int,4),
                    new SqlParameter("@FOrderEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FOrderBillNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FAllHookQTY", SqlDbType.Decimal,13),
                    new SqlParameter("@FAllHookAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FCurrentHookQTY", SqlDbType.Decimal,13),
                    new SqlParameter("@FCurrentHookAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FStdAllHookAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FStdCurrentHookAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FSCStockID", SqlDbType.Int,4),
                    new SqlParameter("@FDCStockID", SqlDbType.Int,4),
                    new SqlParameter("@FPeriodDate", SqlDbType.DateTime),
                    new SqlParameter("@FCostObjGroupID", SqlDbType.Int,4),
                    new SqlParameter("@FCostOBJID", SqlDbType.Int,4),
                    new SqlParameter("@FMaterialCostPrice", SqlDbType.Decimal,13),
                    new SqlParameter("@FReProduceType", SqlDbType.Int,4),
                    new SqlParameter("@FBomInterID", SqlDbType.Int,4),
                    new SqlParameter("@FDiscountRate", SqlDbType.Decimal,13),
                    new SqlParameter("@FDiscountAmount", SqlDbType.Decimal,13),
                    new SqlParameter("@FSepcialSaleId", SqlDbType.Int,4),
                    new SqlParameter("@FOutCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FOutSecCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FDBCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FDBSecCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxQtyInvoice", SqlDbType.Decimal,13),
                    new SqlParameter("@FOperSN", SqlDbType.Int,4),
                    new SqlParameter("@FCheckStatus", SqlDbType.SmallInt,2),
                    new SqlParameter("@FSplitSecQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem1", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem2", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem3", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem4", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem5", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem7", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem10", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem11", SqlDbType.VarChar,255),
                    new SqlParameter("@FSaleCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSaleSecCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSaleAuxCommitQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FInStockID", SqlDbType.Int,4),
                    new SqlParameter("@FSelectedProcID", SqlDbType.Int,4),
                    new SqlParameter("@FVWInStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FAuxVWInStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecVWInStockQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecInvoiceQty", SqlDbType.Decimal,13),
                    new SqlParameter("@FCostCenterID", SqlDbType.Int,4),
                    new SqlParameter("@FPlanMode", SqlDbType.Int,4),
                    new SqlParameter("@FMTONo", SqlDbType.NVarChar,50),
                    new SqlParameter("@FSecQtyActual", SqlDbType.Decimal,13),
                    new SqlParameter("@FSecQtyMust", SqlDbType.Decimal,13),
                    new SqlParameter("@FClientOrderNo", SqlDbType.NVarChar,255),
                    new SqlParameter("@FClientEntryID", SqlDbType.Int,4),
                    new SqlParameter("@FRowClosed", SqlDbType.TinyInt,1),
                    new SqlParameter("@FCostPercentage", SqlDbType.Decimal,5),
                    new SqlParameter("@FEntrySelfB0168", SqlDbType.Decimal,13),
                    new SqlParameter("@FEntrySelfB0169", SqlDbType.VarChar,255),
                    new SqlParameter("@FEntrySelfD0148", SqlDbType.Decimal,13),
                    new SqlParameter("@FCOMBFreeItem9", SqlDbType.Decimal,13)};
            parameters[0].Value = iCStockBillEntry.FBrNo;
            parameters[1].Value = iCStockBillEntry.FInterID;
            parameters[2].Value = iCStockBillEntry.FEntryID;
            parameters[3].Value = iCStockBillEntry.FItemID;
            parameters[4].Value = iCStockBillEntry.FQtyMust;
            parameters[5].Value = iCStockBillEntry.FQty;
            parameters[6].Value = iCStockBillEntry.FPrice;
            parameters[7].Value = iCStockBillEntry.FBatchNo;
            parameters[8].Value = iCStockBillEntry.FAmount;
            parameters[9].Value = Common.SqlNull(iCStockBillEntry.FNote);
            parameters[10].Value = Common.SqlNull(iCStockBillEntry.FSCBillInterID);
            parameters[11].Value = Common.SqlNull(iCStockBillEntry.FSCBillNo);
            parameters[12].Value = iCStockBillEntry.FUnitID;
            parameters[13].Value = iCStockBillEntry.FAuxPrice;
            parameters[14].Value = iCStockBillEntry.FAuxQty;
            parameters[15].Value = iCStockBillEntry.FAuxQtyMust;
            parameters[16].Value = iCStockBillEntry.FQtyActual;
            parameters[17].Value = iCStockBillEntry.FAuxQtyActual;
            parameters[18].Value = iCStockBillEntry.FPlanPrice;
            parameters[19].Value = iCStockBillEntry.FAuxPlanPrice;
            parameters[20].Value = iCStockBillEntry.FSourceEntryID;
            parameters[21].Value = iCStockBillEntry.FCommitQty;
            parameters[22].Value = iCStockBillEntry.FAuxCommitQty;
            parameters[23].Value = Common.SqlNull(iCStockBillEntry.FKFDate);
            parameters[24].Value = iCStockBillEntry.FKFPeriod;
            parameters[25].Value = iCStockBillEntry.FDCSPID;
            parameters[26].Value = Common.SqlNull(iCStockBillEntry.FSCSPID);
            parameters[27].Value = iCStockBillEntry.FConsignPrice;
            parameters[28].Value = iCStockBillEntry.FConsignAmount;
            parameters[29].Value = iCStockBillEntry.FProcessCost;
            parameters[30].Value = iCStockBillEntry.FMaterialCost;
            parameters[31].Value = iCStockBillEntry.FTaxAmount;
            parameters[32].Value = iCStockBillEntry.FMapNumber;
            parameters[33].Value = Common.SqlNull(iCStockBillEntry.FMapName);
            parameters[34].Value = iCStockBillEntry.FOrgBillEntryID;
            parameters[35].Value = Common.SqlNull(iCStockBillEntry.FOperID);
            parameters[36].Value = iCStockBillEntry.FPlanAmount;
            parameters[37].Value = iCStockBillEntry.FProcessPrice;
            parameters[38].Value = iCStockBillEntry.FTaxRate;
            parameters[39].Value = Common.SqlNull(iCStockBillEntry.FSnListID);
            parameters[40].Value = iCStockBillEntry.FAmtRef;
            parameters[41].Value = iCStockBillEntry.FAuxPropID;
            parameters[42].Value = iCStockBillEntry.FCost;
            parameters[43].Value = iCStockBillEntry.FPriceRef;
            parameters[44].Value = iCStockBillEntry.FAuxPriceRef;
            parameters[45].Value = Common.SqlNull(iCStockBillEntry.FFetchDate);
            parameters[46].Value = iCStockBillEntry.FQtyInvoice;
            parameters[47].Value = iCStockBillEntry.FQtyInvoiceBase;
            parameters[48].Value = iCStockBillEntry.FUnitCost;
            parameters[49].Value = iCStockBillEntry.FSecCoefficient;
            parameters[50].Value = iCStockBillEntry.FSecQty;
            parameters[51].Value = iCStockBillEntry.FSecCommitQty;
            parameters[52].Value = iCStockBillEntry.FSourceTranType;
            parameters[53].Value = iCStockBillEntry.FSourceInterId;
            parameters[54].Value = iCStockBillEntry.FSourceBillNo;
            parameters[55].Value = iCStockBillEntry.FContractInterID;
            parameters[56].Value = iCStockBillEntry.FContractEntryID;
            parameters[57].Value = iCStockBillEntry.FContractBillNo;
            parameters[58].Value = iCStockBillEntry.FICMOBillNo;
            parameters[59].Value = iCStockBillEntry.FICMOInterID;
            parameters[60].Value = iCStockBillEntry.FPPBomEntryID;
            parameters[61].Value = iCStockBillEntry.FOrderInterID;
            parameters[62].Value = iCStockBillEntry.FOrderEntryID;
            parameters[63].Value = iCStockBillEntry.FOrderBillNo;
            parameters[64].Value = iCStockBillEntry.FAllHookQTY;
            parameters[65].Value = iCStockBillEntry.FAllHookAmount;
            parameters[66].Value = iCStockBillEntry.FCurrentHookQTY;
            parameters[67].Value = iCStockBillEntry.FCurrentHookAmount;
            parameters[68].Value = iCStockBillEntry.FStdAllHookAmount;
            parameters[69].Value = iCStockBillEntry.FStdCurrentHookAmount;
            parameters[70].Value = iCStockBillEntry.FSCStockID;
            parameters[71].Value = iCStockBillEntry.FDCStockID;
            parameters[72].Value = Common.SqlNull(iCStockBillEntry.FPeriodDate);
            parameters[73].Value = iCStockBillEntry.FCostObjGroupID;
            parameters[74].Value = iCStockBillEntry.FCostOBJID;
            parameters[75].Value = iCStockBillEntry.FMaterialCostPrice;
            parameters[76].Value = iCStockBillEntry.FReProduceType;
            parameters[77].Value = iCStockBillEntry.FBomInterID;
            parameters[78].Value = iCStockBillEntry.FDiscountRate;
            parameters[79].Value = iCStockBillEntry.FDiscountAmount;
            parameters[80].Value = iCStockBillEntry.FSepcialSaleId;
            parameters[81].Value = iCStockBillEntry.FOutCommitQty;
            parameters[82].Value = iCStockBillEntry.FOutSecCommitQty;
            parameters[83].Value = iCStockBillEntry.FDBCommitQty;
            parameters[84].Value = iCStockBillEntry.FDBSecCommitQty;
            parameters[85].Value = iCStockBillEntry.FAuxQtyInvoice;
            parameters[86].Value = iCStockBillEntry.FOperSN;
            parameters[87].Value = iCStockBillEntry.FCheckStatus;
            parameters[88].Value = Common.SqlNull(iCStockBillEntry.FSplitSecQty);
            parameters[89].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem1);
            parameters[90].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem2);
            parameters[91].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem3);
            parameters[92].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem4);
            parameters[93].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem5);
            parameters[94].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem7);
            parameters[95].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem10);
            parameters[96].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem11);
            parameters[97].Value = iCStockBillEntry.FSaleCommitQty;
            parameters[98].Value = iCStockBillEntry.FSaleSecCommitQty;
            parameters[99].Value = iCStockBillEntry.FSaleAuxCommitQty;
            parameters[100].Value = iCStockBillEntry.FInStockID;
            parameters[101].Value = iCStockBillEntry.FSelectedProcID;
            parameters[102].Value = iCStockBillEntry.FVWInStockQty;
            parameters[103].Value = iCStockBillEntry.FAuxVWInStockQty;
            parameters[104].Value = iCStockBillEntry.FSecVWInStockQty;
            parameters[105].Value = iCStockBillEntry.FSecInvoiceQty;
            parameters[106].Value = iCStockBillEntry.FCostCenterID;
            parameters[107].Value = iCStockBillEntry.FPlanMode;
            parameters[108].Value = iCStockBillEntry.FMTONo;
            parameters[109].Value = iCStockBillEntry.FSecQtyActual;
            parameters[110].Value = iCStockBillEntry.FSecQtyMust;
            parameters[111].Value = iCStockBillEntry.FClientOrderNo;
            parameters[112].Value = Common.SqlNull(iCStockBillEntry.FClientEntryID);
            parameters[113].Value = iCStockBillEntry.FRowClosed;
            parameters[114].Value = Common.SqlNull(iCStockBillEntry.FCostPercentage);
            parameters[115].Value = Common.SqlNull(iCStockBillEntry.FEntrySelfB0168);
            parameters[116].Value = Common.SqlNull(iCStockBillEntry.FEntrySelfB0169);
            parameters[117].Value = Common.SqlNull(iCStockBillEntry.FEntrySelfD0148);
            parameters[118].Value = Common.SqlNull(iCStockBillEntry.FCOMBFreeItem9);

            int ret = SqlHelper.ExecuteNonQuery(conn,strSql.ToString(), parameters);

            return ret;
        }


        /// <summary>
        /// 得到一个对象实体列表
        /// </summary>
        public static List<ICStockBillEntry> GetModelList(string conn, int FInterID)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select FBrNo,FInterID,FEntryID,FItemID,FQtyMust,FQty,FPrice,FBatchNo,FAmount,FNote,FSCBillInterID,FSCBillNo,FUnitID,FAuxPrice,FAuxQty,FAuxQtyMust,FQtyActual,FAuxQtyActual,FPlanPrice,FAuxPlanPrice,FSourceEntryID,FCommitQty,FAuxCommitQty,FKFDate,FKFPeriod,FDCSPID,FSCSPID,FConsignPrice,FConsignAmount,FProcessCost,FMaterialCost,FTaxAmount,FMapNumber,FMapName,FOrgBillEntryID,FOperID,FPlanAmount,FProcessPrice,FTaxRate,FSnListID,FAmtRef,FAuxPropID,FCost,FPriceRef,FAuxPriceRef,FFetchDate,FQtyInvoice,FQtyInvoiceBase,FUnitCost,FSecCoefficient,FSecQty,FSecCommitQty,FSourceTranType,FSourceInterId,FSourceBillNo,FContractInterID,FContractEntryID,FContractBillNo,FICMOBillNo,FICMOInterID,FPPBomEntryID,FOrderInterID,FOrderEntryID,FOrderBillNo,FAllHookQTY,FAllHookAmount,FCurrentHookQTY,FCurrentHookAmount,FStdAllHookAmount,FStdCurrentHookAmount,FSCStockID,FDCStockID,FPeriodDate,FCostObjGroupID,FCostOBJID,FDetailID,FMaterialCostPrice,FReProduceType,FBomInterID,FDiscountRate,FDiscountAmount,FSepcialSaleId,FOutCommitQty,FOutSecCommitQty,FDBCommitQty,FDBSecCommitQty,FAuxQtyInvoice,FOperSN,FCheckStatus,FSplitSecQty,FCOMBFreeItem1,FCOMBFreeItem2,FCOMBFreeItem3,FCOMBFreeItem4,FCOMBFreeItem5,FCOMBFreeItem7,FCOMBFreeItem10,FCOMBFreeItem11,FSaleCommitQty,FSaleSecCommitQty,FSaleAuxCommitQty,FInStockID,FSelectedProcID,FVWInStockQty,FAuxVWInStockQty,FSecVWInStockQty,FSecInvoiceQty,FCostCenterID,FPlanMode,FMTONo,FSecQtyActual,FSecQtyMust,FClientOrderNo,FClientEntryID,FRowClosed,FCostPercentage,FEntrySelfB0168,FEntrySelfB0169,FEntrySelfD0148,FCOMBFreeItem9 from ICStockBillEntry ");
            strSql.Append(" where FInterID=@FInterID");
            SqlParameter[] parameters = {
                    new SqlParameter("@FInterID", SqlDbType.Int,4)
            };
            parameters[0].Value = FInterID;

            List<ICStockBillEntry> list = new List<ICStockBillEntry>();
            DataTable dt = SqlHelper.ExecuteDataTable(conn, strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                foreach(DataRow dr in dt.Rows)
                {
                    list.Add(DataRowToModel(dr));
                }
            }
            return list;
        }

        private static ICStockBillEntry DataRowToModel(DataRow dr)
        {
            ICStockBillEntry iCStockBillEntry = new ICStockBillEntry();
            if (dr["FBrNo"] != null)
            {
                iCStockBillEntry.FBrNo = dr["FBrNo"].ToString();
            }
            if (dr["FInterID"] != null && dr["FInterID"].ToString() != "")
            {
                iCStockBillEntry.FInterID = int.Parse(dr["FInterID"].ToString());
            }
            if (dr["FEntryID"] != null && dr["FEntryID"].ToString() != "")
            {
                iCStockBillEntry.FEntryID = int.Parse(dr["FEntryID"].ToString());
            }
            if (dr["FItemID"] != null && dr["FItemID"].ToString() != "")
            {
                iCStockBillEntry.FItemID = int.Parse(dr["FItemID"].ToString());
            }
            if (dr["FQtyMust"] != null && dr["FQtyMust"].ToString() != "")
            {
                iCStockBillEntry.FQtyMust = decimal.Parse(dr["FQtyMust"].ToString());
            }
            if (dr["FQty"] != null && dr["FQty"].ToString() != "")
            {
                iCStockBillEntry.FQty = decimal.Parse(dr["FQty"].ToString());
            }
            if (dr["FPrice"] != null && dr["FPrice"].ToString() != "")
            {
                iCStockBillEntry.FPrice = decimal.Parse(dr["FPrice"].ToString());
            }
            if (dr["FBatchNo"] != null)
            {
                iCStockBillEntry.FBatchNo = dr["FBatchNo"].ToString();
            }
            if (dr["FAmount"] != null && dr["FAmount"].ToString() != "")
            {
                iCStockBillEntry.FAmount = decimal.Parse(dr["FAmount"].ToString());
            }
            if (dr["FNote"] != null)
            {
                iCStockBillEntry.FNote = dr["FNote"].ToString();
            }
            if (dr["FSCBillInterID"] != null && dr["FSCBillInterID"].ToString() != "")
            {
                iCStockBillEntry.FSCBillInterID = int.Parse(dr["FSCBillInterID"].ToString());
            }
            if (dr["FSCBillNo"] != null)
            {
                iCStockBillEntry.FSCBillNo = dr["FSCBillNo"].ToString();
            }
            if (dr["FUnitID"] != null && dr["FUnitID"].ToString() != "")
            {
                iCStockBillEntry.FUnitID = int.Parse(dr["FUnitID"].ToString());
            }
            if (dr["FAuxPrice"] != null && dr["FAuxPrice"].ToString() != "")
            {
                iCStockBillEntry.FAuxPrice = decimal.Parse(dr["FAuxPrice"].ToString());
            }
            if (dr["FAuxQty"] != null && dr["FAuxQty"].ToString() != "")
            {
                iCStockBillEntry.FAuxQty = decimal.Parse(dr["FAuxQty"].ToString());
            }
            if (dr["FAuxQtyMust"] != null && dr["FAuxQtyMust"].ToString() != "")
            {
                iCStockBillEntry.FAuxQtyMust = decimal.Parse(dr["FAuxQtyMust"].ToString());
            }
            if (dr["FQtyActual"] != null && dr["FQtyActual"].ToString() != "")
            {
                iCStockBillEntry.FQtyActual = decimal.Parse(dr["FQtyActual"].ToString());
            }
            if (dr["FAuxQtyActual"] != null && dr["FAuxQtyActual"].ToString() != "")
            {
                iCStockBillEntry.FAuxQtyActual = decimal.Parse(dr["FAuxQtyActual"].ToString());
            }
            if (dr["FPlanPrice"] != null && dr["FPlanPrice"].ToString() != "")
            {
                iCStockBillEntry.FPlanPrice = decimal.Parse(dr["FPlanPrice"].ToString());
            }
            if (dr["FAuxPlanPrice"] != null && dr["FAuxPlanPrice"].ToString() != "")
            {
                iCStockBillEntry.FAuxPlanPrice = decimal.Parse(dr["FAuxPlanPrice"].ToString());
            }
            if (dr["FSourceEntryID"] != null && dr["FSourceEntryID"].ToString() != "")
            {
                iCStockBillEntry.FSourceEntryID = int.Parse(dr["FSourceEntryID"].ToString());
            }
            if (dr["FCommitQty"] != null && dr["FCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FCommitQty = decimal.Parse(dr["FCommitQty"].ToString());
            }
            if (dr["FAuxCommitQty"] != null && dr["FAuxCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FAuxCommitQty = decimal.Parse(dr["FAuxCommitQty"].ToString());
            }
            if (dr["FKFDate"] != null && dr["FKFDate"].ToString() != "")
            {
                iCStockBillEntry.FKFDate = DateTime.Parse(dr["FKFDate"].ToString());
            }
            if (dr["FKFPeriod"] != null && dr["FKFPeriod"].ToString() != "")
            {
                iCStockBillEntry.FKFPeriod = int.Parse(dr["FKFPeriod"].ToString());
            }
            if (dr["FDCSPID"] != null && dr["FDCSPID"].ToString() != "")
            {
                iCStockBillEntry.FDCSPID = int.Parse(dr["FDCSPID"].ToString());
            }
            if (dr["FSCSPID"] != null && dr["FSCSPID"].ToString() != "")
            {
                iCStockBillEntry.FSCSPID = int.Parse(dr["FSCSPID"].ToString());
            }
            if (dr["FConsignPrice"] != null && dr["FConsignPrice"].ToString() != "")
            {
                iCStockBillEntry.FConsignPrice = decimal.Parse(dr["FConsignPrice"].ToString());
            }
            if (dr["FConsignAmount"] != null && dr["FConsignAmount"].ToString() != "")
            {
                iCStockBillEntry.FConsignAmount = decimal.Parse(dr["FConsignAmount"].ToString());
            }
            if (dr["FProcessCost"] != null && dr["FProcessCost"].ToString() != "")
            {
                iCStockBillEntry.FProcessCost = decimal.Parse(dr["FProcessCost"].ToString());
            }
            if (dr["FMaterialCost"] != null && dr["FMaterialCost"].ToString() != "")
            {
                iCStockBillEntry.FMaterialCost = decimal.Parse(dr["FMaterialCost"].ToString());
            }
            if (dr["FTaxAmount"] != null && dr["FTaxAmount"].ToString() != "")
            {
                iCStockBillEntry.FTaxAmount = decimal.Parse(dr["FTaxAmount"].ToString());
            }
            if (dr["FMapNumber"] != null)
            {
                iCStockBillEntry.FMapNumber = dr["FMapNumber"].ToString();
            }
            if (dr["FMapName"] != null)
            {
                iCStockBillEntry.FMapName = dr["FMapName"].ToString();
            }
            if (dr["FOrgBillEntryID"] != null && dr["FOrgBillEntryID"].ToString() != "")
            {
                iCStockBillEntry.FOrgBillEntryID = int.Parse(dr["FOrgBillEntryID"].ToString());
            }
            if (dr["FOperID"] != null && dr["FOperID"].ToString() != "")
            {
                iCStockBillEntry.FOperID = int.Parse(dr["FOperID"].ToString());
            }
            if (dr["FPlanAmount"] != null && dr["FPlanAmount"].ToString() != "")
            {
                iCStockBillEntry.FPlanAmount = decimal.Parse(dr["FPlanAmount"].ToString());
            }
            if (dr["FProcessPrice"] != null && dr["FProcessPrice"].ToString() != "")
            {
                iCStockBillEntry.FProcessPrice = decimal.Parse(dr["FProcessPrice"].ToString());
            }
            if (dr["FTaxRate"] != null && dr["FTaxRate"].ToString() != "")
            {
                iCStockBillEntry.FTaxRate = decimal.Parse(dr["FTaxRate"].ToString());
            }
            if (dr["FSnListID"] != null && dr["FSnListID"].ToString() != "")
            {
                iCStockBillEntry.FSnListID = int.Parse(dr["FSnListID"].ToString());
            }
            if (dr["FAmtRef"] != null && dr["FAmtRef"].ToString() != "")
            {
                iCStockBillEntry.FAmtRef = decimal.Parse(dr["FAmtRef"].ToString());
            }
            if (dr["FAuxPropID"] != null && dr["FAuxPropID"].ToString() != "")
            {
                iCStockBillEntry.FAuxPropID = int.Parse(dr["FAuxPropID"].ToString());
            }
            if (dr["FCost"] != null && dr["FCost"].ToString() != "")
            {
                iCStockBillEntry.FCost = decimal.Parse(dr["FCost"].ToString());
            }
            if (dr["FPriceRef"] != null && dr["FPriceRef"].ToString() != "")
            {
                iCStockBillEntry.FPriceRef = decimal.Parse(dr["FPriceRef"].ToString());
            }
            if (dr["FAuxPriceRef"] != null && dr["FAuxPriceRef"].ToString() != "")
            {
                iCStockBillEntry.FAuxPriceRef = decimal.Parse(dr["FAuxPriceRef"].ToString());
            }
            if (dr["FFetchDate"] != null && dr["FFetchDate"].ToString() != "")
            {
                iCStockBillEntry.FFetchDate = DateTime.Parse(dr["FFetchDate"].ToString());
            }
            if (dr["FQtyInvoice"] != null && dr["FQtyInvoice"].ToString() != "")
            {
                iCStockBillEntry.FQtyInvoice = decimal.Parse(dr["FQtyInvoice"].ToString());
            }
            if (dr["FQtyInvoiceBase"] != null && dr["FQtyInvoiceBase"].ToString() != "")
            {
                iCStockBillEntry.FQtyInvoiceBase = decimal.Parse(dr["FQtyInvoiceBase"].ToString());
            }
            if (dr["FUnitCost"] != null && dr["FUnitCost"].ToString() != "")
            {
                iCStockBillEntry.FUnitCost = decimal.Parse(dr["FUnitCost"].ToString());
            }
            if (dr["FSecCoefficient"] != null && dr["FSecCoefficient"].ToString() != "")
            {
                iCStockBillEntry.FSecCoefficient = decimal.Parse(dr["FSecCoefficient"].ToString());
            }
            if (dr["FSecQty"] != null && dr["FSecQty"].ToString() != "")
            {
                iCStockBillEntry.FSecQty = decimal.Parse(dr["FSecQty"].ToString());
            }
            if (dr["FSecCommitQty"] != null && dr["FSecCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FSecCommitQty = decimal.Parse(dr["FSecCommitQty"].ToString());
            }
            if (dr["FSourceTranType"] != null && dr["FSourceTranType"].ToString() != "")
            {
                iCStockBillEntry.FSourceTranType = int.Parse(dr["FSourceTranType"].ToString());
            }
            if (dr["FSourceInterId"] != null && dr["FSourceInterId"].ToString() != "")
            {
                iCStockBillEntry.FSourceInterId = int.Parse(dr["FSourceInterId"].ToString());
            }
            if (dr["FSourceBillNo"] != null)
            {
                iCStockBillEntry.FSourceBillNo = dr["FSourceBillNo"].ToString();
            }
            if (dr["FContractInterID"] != null && dr["FContractInterID"].ToString() != "")
            {
                iCStockBillEntry.FContractInterID = int.Parse(dr["FContractInterID"].ToString());
            }
            if (dr["FContractEntryID"] != null && dr["FContractEntryID"].ToString() != "")
            {
                iCStockBillEntry.FContractEntryID = int.Parse(dr["FContractEntryID"].ToString());
            }
            if (dr["FContractBillNo"] != null)
            {
                iCStockBillEntry.FContractBillNo = dr["FContractBillNo"].ToString();
            }
            if (dr["FICMOBillNo"] != null)
            {
                iCStockBillEntry.FICMOBillNo = dr["FICMOBillNo"].ToString();
            }
            if (dr["FICMOInterID"] != null && dr["FICMOInterID"].ToString() != "")
            {
                iCStockBillEntry.FICMOInterID = int.Parse(dr["FICMOInterID"].ToString());
            }
            if (dr["FPPBomEntryID"] != null && dr["FPPBomEntryID"].ToString() != "")
            {
                iCStockBillEntry.FPPBomEntryID = int.Parse(dr["FPPBomEntryID"].ToString());
            }
            if (dr["FOrderInterID"] != null && dr["FOrderInterID"].ToString() != "")
            {
                iCStockBillEntry.FOrderInterID = int.Parse(dr["FOrderInterID"].ToString());
            }
            if (dr["FOrderEntryID"] != null && dr["FOrderEntryID"].ToString() != "")
            {
                iCStockBillEntry.FOrderEntryID = int.Parse(dr["FOrderEntryID"].ToString());
            }
            if (dr["FOrderBillNo"] != null)
            {
                iCStockBillEntry.FOrderBillNo = dr["FOrderBillNo"].ToString();
            }
            if (dr["FAllHookQTY"] != null && dr["FAllHookQTY"].ToString() != "")
            {
                iCStockBillEntry.FAllHookQTY = decimal.Parse(dr["FAllHookQTY"].ToString());
            }
            if (dr["FAllHookAmount"] != null && dr["FAllHookAmount"].ToString() != "")
            {
                iCStockBillEntry.FAllHookAmount = decimal.Parse(dr["FAllHookAmount"].ToString());
            }
            if (dr["FCurrentHookQTY"] != null && dr["FCurrentHookQTY"].ToString() != "")
            {
                iCStockBillEntry.FCurrentHookQTY = decimal.Parse(dr["FCurrentHookQTY"].ToString());
            }
            if (dr["FCurrentHookAmount"] != null && dr["FCurrentHookAmount"].ToString() != "")
            {
                iCStockBillEntry.FCurrentHookAmount = decimal.Parse(dr["FCurrentHookAmount"].ToString());
            }
            if (dr["FStdAllHookAmount"] != null && dr["FStdAllHookAmount"].ToString() != "")
            {
                iCStockBillEntry.FStdAllHookAmount = decimal.Parse(dr["FStdAllHookAmount"].ToString());
            }
            if (dr["FStdCurrentHookAmount"] != null && dr["FStdCurrentHookAmount"].ToString() != "")
            {
                iCStockBillEntry.FStdCurrentHookAmount = decimal.Parse(dr["FStdCurrentHookAmount"].ToString());
            }
            if (dr["FSCStockID"] != null && dr["FSCStockID"].ToString() != "")
            {
                iCStockBillEntry.FSCStockID = int.Parse(dr["FSCStockID"].ToString());
            }
            if (dr["FDCStockID"] != null && dr["FDCStockID"].ToString() != "")
            {
                iCStockBillEntry.FDCStockID = int.Parse(dr["FDCStockID"].ToString());
            }
            if (dr["FPeriodDate"] != null && dr["FPeriodDate"].ToString() != "")
            {
                iCStockBillEntry.FPeriodDate = DateTime.Parse(dr["FPeriodDate"].ToString());
            }
            if (dr["FCostObjGroupID"] != null && dr["FCostObjGroupID"].ToString() != "")
            {
                iCStockBillEntry.FCostObjGroupID = int.Parse(dr["FCostObjGroupID"].ToString());
            }
            if (dr["FCostOBJID"] != null && dr["FCostOBJID"].ToString() != "")
            {
                iCStockBillEntry.FCostOBJID = int.Parse(dr["FCostOBJID"].ToString());
            }
            if (dr["FDetailID"] != null && dr["FDetailID"].ToString() != "")
            {
                iCStockBillEntry.FDetailID = int.Parse(dr["FDetailID"].ToString());
            }
            if (dr["FMaterialCostPrice"] != null && dr["FMaterialCostPrice"].ToString() != "")
            {
                iCStockBillEntry.FMaterialCostPrice = decimal.Parse(dr["FMaterialCostPrice"].ToString());
            }
            if (dr["FReProduceType"] != null && dr["FReProduceType"].ToString() != "")
            {
                iCStockBillEntry.FReProduceType = int.Parse(dr["FReProduceType"].ToString());
            }
            if (dr["FBomInterID"] != null && dr["FBomInterID"].ToString() != "")
            {
                iCStockBillEntry.FBomInterID = int.Parse(dr["FBomInterID"].ToString());
            }
            if (dr["FDiscountRate"] != null && dr["FDiscountRate"].ToString() != "")
            {
                iCStockBillEntry.FDiscountRate = decimal.Parse(dr["FDiscountRate"].ToString());
            }
            if (dr["FDiscountAmount"] != null && dr["FDiscountAmount"].ToString() != "")
            {
                iCStockBillEntry.FDiscountAmount = decimal.Parse(dr["FDiscountAmount"].ToString());
            }
            if (dr["FSepcialSaleId"] != null && dr["FSepcialSaleId"].ToString() != "")
            {
                iCStockBillEntry.FSepcialSaleId = int.Parse(dr["FSepcialSaleId"].ToString());
            }
            if (dr["FOutCommitQty"] != null && dr["FOutCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FOutCommitQty = decimal.Parse(dr["FOutCommitQty"].ToString());
            }
            if (dr["FOutSecCommitQty"] != null && dr["FOutSecCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FOutSecCommitQty = decimal.Parse(dr["FOutSecCommitQty"].ToString());
            }
            if (dr["FDBCommitQty"] != null && dr["FDBCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FDBCommitQty = decimal.Parse(dr["FDBCommitQty"].ToString());
            }
            if (dr["FDBSecCommitQty"] != null && dr["FDBSecCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FDBSecCommitQty = decimal.Parse(dr["FDBSecCommitQty"].ToString());
            }
            if (dr["FAuxQtyInvoice"] != null && dr["FAuxQtyInvoice"].ToString() != "")
            {
                iCStockBillEntry.FAuxQtyInvoice = decimal.Parse(dr["FAuxQtyInvoice"].ToString());
            }
            if (dr["FOperSN"] != null && dr["FOperSN"].ToString() != "")
            {
                iCStockBillEntry.FOperSN = int.Parse(dr["FOperSN"].ToString());
            }
            if (dr["FCheckStatus"] != null && dr["FCheckStatus"].ToString() != "")
            {
                iCStockBillEntry.FCheckStatus = int.Parse(dr["FCheckStatus"].ToString());
            }
            if (dr["FSplitSecQty"] != null && dr["FSplitSecQty"].ToString() != "")
            {
                iCStockBillEntry.FSplitSecQty = decimal.Parse(dr["FSplitSecQty"].ToString());
            }
            if (dr["FCOMBFreeItem1"] != null && dr["FCOMBFreeItem1"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem1 = decimal.Parse(dr["FCOMBFreeItem1"].ToString());
            }
            if (dr["FCOMBFreeItem2"] != null && dr["FCOMBFreeItem2"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem2 = decimal.Parse(dr["FCOMBFreeItem2"].ToString());
            }
            if (dr["FCOMBFreeItem3"] != null && dr["FCOMBFreeItem3"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem3 = decimal.Parse(dr["FCOMBFreeItem3"].ToString());
            }
            if (dr["FCOMBFreeItem4"] != null && dr["FCOMBFreeItem4"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem4 = decimal.Parse(dr["FCOMBFreeItem4"].ToString());
            }
            if (dr["FCOMBFreeItem5"] != null && dr["FCOMBFreeItem5"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem5 = decimal.Parse(dr["FCOMBFreeItem5"].ToString());
            }
            if (dr["FCOMBFreeItem7"] != null && dr["FCOMBFreeItem7"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem7 = decimal.Parse(dr["FCOMBFreeItem7"].ToString());
            }
            if (dr["FCOMBFreeItem10"] != null && dr["FCOMBFreeItem10"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem10 = decimal.Parse(dr["FCOMBFreeItem10"].ToString());
            }
            if (dr["FCOMBFreeItem11"] != null)
            {
                iCStockBillEntry.FCOMBFreeItem11 = dr["FCOMBFreeItem11"].ToString();
            }
            if (dr["FSaleCommitQty"] != null && dr["FSaleCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FSaleCommitQty = decimal.Parse(dr["FSaleCommitQty"].ToString());
            }
            if (dr["FSaleSecCommitQty"] != null && dr["FSaleSecCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FSaleSecCommitQty = decimal.Parse(dr["FSaleSecCommitQty"].ToString());
            }
            if (dr["FSaleAuxCommitQty"] != null && dr["FSaleAuxCommitQty"].ToString() != "")
            {
                iCStockBillEntry.FSaleAuxCommitQty = decimal.Parse(dr["FSaleAuxCommitQty"].ToString());
            }
            if (dr["FInStockID"] != null && dr["FInStockID"].ToString() != "")
            {
                iCStockBillEntry.FInStockID = int.Parse(dr["FInStockID"].ToString());
            }
            if (dr["FSelectedProcID"] != null && dr["FSelectedProcID"].ToString() != "")
            {
                iCStockBillEntry.FSelectedProcID = int.Parse(dr["FSelectedProcID"].ToString());
            }
            if (dr["FVWInStockQty"] != null && dr["FVWInStockQty"].ToString() != "")
            {
                iCStockBillEntry.FVWInStockQty = decimal.Parse(dr["FVWInStockQty"].ToString());
            }
            if (dr["FAuxVWInStockQty"] != null && dr["FAuxVWInStockQty"].ToString() != "")
            {
                iCStockBillEntry.FAuxVWInStockQty = decimal.Parse(dr["FAuxVWInStockQty"].ToString());
            }
            if (dr["FSecVWInStockQty"] != null && dr["FSecVWInStockQty"].ToString() != "")
            {
                iCStockBillEntry.FSecVWInStockQty = decimal.Parse(dr["FSecVWInStockQty"].ToString());
            }
            if (dr["FSecInvoiceQty"] != null && dr["FSecInvoiceQty"].ToString() != "")
            {
                iCStockBillEntry.FSecInvoiceQty = decimal.Parse(dr["FSecInvoiceQty"].ToString());
            }
            if (dr["FCostCenterID"] != null && dr["FCostCenterID"].ToString() != "")
            {
                iCStockBillEntry.FCostCenterID = int.Parse(dr["FCostCenterID"].ToString());
            }
            if (dr["FPlanMode"] != null && dr["FPlanMode"].ToString() != "")
            {
                iCStockBillEntry.FPlanMode = int.Parse(dr["FPlanMode"].ToString());
            }
            if (dr["FMTONo"] != null)
            {
                iCStockBillEntry.FMTONo = dr["FMTONo"].ToString();
            }
            if (dr["FSecQtyActual"] != null && dr["FSecQtyActual"].ToString() != "")
            {
                iCStockBillEntry.FSecQtyActual = decimal.Parse(dr["FSecQtyActual"].ToString());
            }
            if (dr["FSecQtyMust"] != null && dr["FSecQtyMust"].ToString() != "")
            {
                iCStockBillEntry.FSecQtyMust = decimal.Parse(dr["FSecQtyMust"].ToString());
            }
            if (dr["FClientOrderNo"] != null)
            {
                iCStockBillEntry.FClientOrderNo = dr["FClientOrderNo"].ToString();
            }
            if (dr["FClientEntryID"] != null && dr["FClientEntryID"].ToString() != "")
            {
                iCStockBillEntry.FClientEntryID = int.Parse(dr["FClientEntryID"].ToString());
            }
            if (dr["FRowClosed"] != null && dr["FRowClosed"].ToString() != "")
            {
                iCStockBillEntry.FRowClosed = int.Parse(dr["FRowClosed"].ToString());
            }
            if (dr["FCostPercentage"] != null && dr["FCostPercentage"].ToString() != "")
            {
                iCStockBillEntry.FCostPercentage = decimal.Parse(dr["FCostPercentage"].ToString());
            }
            if (dr["FEntrySelfB0168"] != null && dr["FEntrySelfB0168"].ToString() != "")
            {
                iCStockBillEntry.FEntrySelfB0168 = decimal.Parse(dr["FEntrySelfB0168"].ToString());
            }
            if (dr["FEntrySelfB0169"] != null)
            {
                iCStockBillEntry.FEntrySelfB0169 = dr["FEntrySelfB0169"].ToString();
            }
            if (dr["FEntrySelfD0148"] != null && dr["FEntrySelfD0148"].ToString() != "")
            {
                iCStockBillEntry.FEntrySelfD0148 = decimal.Parse(dr["FEntrySelfD0148"].ToString());
            }
            if (dr["FCOMBFreeItem9"] != null && dr["FCOMBFreeItem9"].ToString() != "")
            {
                iCStockBillEntry.FCOMBFreeItem9 = decimal.Parse(dr["FCOMBFreeItem9"].ToString());
            }

            return iCStockBillEntry;
        }

        ///// <summary>
        ///// 记录是否存在
        ///// </summary>
        ///// <param name="ItemId"></param>
        ///// <returns></returns>
        //public static bool Exist(int InterID,int entryID)
        //{
        //    bool retVal = false;
        //    string sql = string.Format("Select Count(*) From [ICStockBillEntry] Where FInterID = {0} and FEntryID ={1}", InterID,entryID);
        //    object obj = SqlHelper.ExecuteScalar(connK3Desc, sql);
        //    if (obj != null && int.Parse(obj.ToString())>0)
        //    {
        //        retVal = true;
        //    }
        //    return retVal;
        //}

        /// <summary>
        /// 替换物料编号,用长编码！
        /// </summary>
        /// <param name="OriginItemID"></param>
        /// <param name="SourceConnection"></param>
        /// <param name="DescConnection"></param>
        /// <returns></returns>
        public static int GetNewItemIDByOriginItemID(int OriginItemID, string SourceConnection, string DescConnection)
        {
            string sql = string.Format("select fnumber from t_icitem where FItemID ={0}", OriginItemID);
            string FFullNumber = Common.GetStringByExecuteScalar(SourceConnection, sql);
            if(FFullNumber != "")
            {
                sql = string.Format("select FItemID from t_icitem where fnumber ='{0}'", FFullNumber);
                string NewItemID = Common.GetStringByExecuteScalar(DescConnection, sql);
                if(NewItemID != "")
                {
                    return int.Parse(NewItemID.ToString());
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 替换单位编号,用长编码！
        /// </summary>
        /// <param name="OriginUnitID"></param>
        /// <param name="SourceConnection"></param>
        /// <param name="DescConnection"></param>
        /// <returns></returns>
        public static int GetNewUnitIDByOriginUnitID(int OriginUnitID, string SourceConnection, string DescConnection)
        {
            string sql = string.Format("select FNumber from t_MeasureUnit where FMeasureUnitID ={0}", OriginUnitID);
            string FNumber = Common.GetStringByExecuteScalar(SourceConnection, sql);
            if (FNumber != "")
            {
                sql = string.Format("select FMeasureUnitID from t_MeasureUnit where FNumber = '{0}'", FNumber);
                string NewUnitID = Common.GetStringByExecuteScalar(DescConnection, sql);
                if (NewUnitID != "")
                {
                    return int.Parse(NewUnitID.ToString());
                }
                else
                {
                    return -1;
                }
            }
            else
            {
                return -1;
            }
        }


        /// <summary>
        /// 更新物料编号
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="Entry"></param>
        /// <returns></returns>
        public static bool UpdateItemUnitID(string conn,ICStockBillEntry Entry)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update ICStockBillEntry set ");
            strSql.Append(" FItemID=@FItemID, FUnitID=@FUnitID ");
            strSql.Append(" WHERE FInterID=@FInterID ");
            strSql.Append(" AND FEntryID=@FEntryID ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FItemID", SqlDbType.Int,4),
                    new SqlParameter("@FUnitID", SqlDbType.Int,4),
                    new SqlParameter("@FInterID", SqlDbType.Int,4),
                    new SqlParameter("@FEntryID", SqlDbType.Int,4)};

            parameters[0].Value = Entry.FItemID;
            parameters[1].Value = Entry.FUnitID;
            parameters[2].Value = Entry.FInterID;
            parameters[3].Value = Entry.FEntryID;


            int rows = SqlHelper.ExecuteNonQuery(conn, strSql.ToString(), parameters);
            if (rows >= 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}