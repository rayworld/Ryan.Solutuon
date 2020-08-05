using Aohua.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aohua.DAL
{
    public partial class ICStockBills
    {
        //private static string connK3Desc = SqlHelper.GetConnectionString("K3Desc");
        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Insert(string conn,ICStockBill iCStockBill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into ICStockBill(");
            strSql.Append("FBrNo,FDeptID,FCOMHFreeItem15,FCOMHFreeItem18,FCOMHFreeItem19,FCOMHFreeItem20,FPOOrdBillNo,FLSSrcInterID,FSettleDate,FManageType,FEmpID,FOrderAffirm,FAutoCreType,FConsignee,FDrpRelateTranType,FPrintCount,FCOMHFreeItem17,FHeadSelfB0154,FSupplyID,FPosterID,FCheckerID,FFManagerID,FSManagerID,FBillerID,FReturnBillInterID,FSCBillNo,FInterID,FHookInterID,FVchInterID,FPosted,FCheckSelect,FCurrencyID,FSaleStyle,FAcctID,FROB,FRSCBillNo,FStatus,FTranType,FUpStockWhenSave,FCancellation,FOrgBillInterID,FBillTypeID,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FDate,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FTaskID,FResourceID,FBillNo,FBackFlushed,FWBInterID,FTranStatus,FZPBillInterID,FRelateBrID,FPurposeID,FRelateInvoiceID,FImport,FUse,FSystemType,FMarketingStyle,FPayBillID,FCheckDate,FExplanation,FFetchAdd,FFetchDate,FManagerID,FRefType,FSelTranType,FNote,FChildren,FHookStatus,FActPriceVchTplID,FPlanPriceVchTplID,FProcID,FActualVchTplID,FPlanVchTplID,FBrID,FVIPCardID,FVIPScore,FDCStockID,FHolisticDiscountRate,FPOSName,FWorkShiftId,FCussentAcctID,FZanGuCount,FCOMHFreeItem1,FCOMHFreeItem2,FCOMHFreeItem3,FCOMHFreeItem4,FSCStockID,FCOMHFreeItem5,FCOMHFreeItem6,FCOMHFreeItem7,FCOMHFreeItem8,FCOMHFreeItem9,FCOMHFreeItem10,FCOMHFreeItem11,FCOMHFreeItem12,FCOMHFreeItem13");
            strSql.Append(") values (");
            strSql.Append("@FBrNo,@FDeptID,@FCOMHFreeItem15,@FCOMHFreeItem18,@FCOMHFreeItem19,@FCOMHFreeItem20,@FPOOrdBillNo,@FLSSrcInterID,@FSettleDate,@FManageType,@FEmpID,@FOrderAffirm,@FAutoCreType,@FConsignee,@FDrpRelateTranType,@FPrintCount,@FCOMHFreeItem17,@FHeadSelfB0154,@FSupplyID,@FPosterID,@FCheckerID,@FFManagerID,@FSManagerID,@FBillerID,@FReturnBillInterID,@FSCBillNo,@FInterID,@FHookInterID,@FVchInterID,@FPosted,@FCheckSelect,@FCurrencyID,@FSaleStyle,@FAcctID,@FROB,@FRSCBillNo,@FStatus,@FTranType,@FUpStockWhenSave,@FCancellation,@FOrgBillInterID,@FBillTypeID,@FPOStyle,@FMultiCheckLevel1,@FMultiCheckLevel2,@FMultiCheckLevel3,@FMultiCheckLevel4,@FMultiCheckLevel5,@FDate,@FMultiCheckLevel6,@FMultiCheckDate1,@FMultiCheckDate2,@FMultiCheckDate3,@FMultiCheckDate4,@FMultiCheckDate5,@FMultiCheckDate6,@FCurCheckLevel,@FTaskID,@FResourceID,@FBillNo,@FBackFlushed,@FWBInterID,@FTranStatus,@FZPBillInterID,@FRelateBrID,@FPurposeID,@FRelateInvoiceID,@FImport,@FUse,@FSystemType,@FMarketingStyle,@FPayBillID,@FCheckDate,@FExplanation,@FFetchAdd,@FFetchDate,@FManagerID,@FRefType,@FSelTranType,@FNote,@FChildren,@FHookStatus,@FActPriceVchTplID,@FPlanPriceVchTplID,@FProcID,@FActualVchTplID,@FPlanVchTplID,@FBrID,@FVIPCardID,@FVIPScore,@FDCStockID,@FHolisticDiscountRate,@FPOSName,@FWorkShiftId,@FCussentAcctID,@FZanGuCount,@FCOMHFreeItem1,@FCOMHFreeItem2,@FCOMHFreeItem3,@FCOMHFreeItem4,@FSCStockID,@FCOMHFreeItem5,@FCOMHFreeItem6,@FCOMHFreeItem7,@FCOMHFreeItem8,@FCOMHFreeItem9,@FCOMHFreeItem10,@FCOMHFreeItem11,@FCOMHFreeItem12,@FCOMHFreeItem13");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@FBrNo", SqlDbType.VarChar,10) ,
                        new SqlParameter("@FDeptID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem15", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem18", SqlDbType.DateTime) ,
                        new SqlParameter("@FCOMHFreeItem19", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem20", SqlDbType.Int,4) ,
                        new SqlParameter("@FPOOrdBillNo", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FLSSrcInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSettleDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FManageType", SqlDbType.Int,4) ,
                        new SqlParameter("@FEmpID", SqlDbType.Int,4) ,
                        new SqlParameter("@FOrderAffirm", SqlDbType.Int,4) ,
                        new SqlParameter("@FAutoCreType", SqlDbType.TinyInt,1) ,
                        new SqlParameter("@FConsignee", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FDrpRelateTranType", SqlDbType.Int,4) ,
                        new SqlParameter("@FPrintCount", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FCOMHFreeItem17", SqlDbType.Int,4) ,
                        new SqlParameter("@FHeadSelfB0154", SqlDbType.Int,4) ,
                        new SqlParameter("@FSupplyID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPosterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCheckerID", SqlDbType.Int,4) ,
                        new SqlParameter("@FFManagerID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSManagerID", SqlDbType.Int,4) ,
                        new SqlParameter("@FBillerID", SqlDbType.Int,4) ,
                        new SqlParameter("@FReturnBillInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSCBillNo", SqlDbType.VarChar,30) ,
                        new SqlParameter("@FInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FHookInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FVchInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPosted", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FCheckSelect", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FCurrencyID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSaleStyle", SqlDbType.Int,4) ,
                        new SqlParameter("@FAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FROB", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FRSCBillNo", SqlDbType.VarChar,30) ,
                        new SqlParameter("@FStatus", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FTranType", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FUpStockWhenSave", SqlDbType.Bit,1) ,
                        new SqlParameter("@FCancellation", SqlDbType.Bit,1) ,
                        new SqlParameter("@FOrgBillInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FBillTypeID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPOStyle", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckLevel1", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckLevel2", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckLevel3", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckLevel4", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckLevel5", SqlDbType.Int,4) ,
                        new SqlParameter("@FDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckLevel6", SqlDbType.Int,4) ,
                        new SqlParameter("@FMultiCheckDate1", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckDate2", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckDate3", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckDate4", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckDate5", SqlDbType.DateTime) ,
                        new SqlParameter("@FMultiCheckDate6", SqlDbType.DateTime) ,
                        new SqlParameter("@FCurCheckLevel", SqlDbType.Int,4) ,
                        new SqlParameter("@FTaskID", SqlDbType.Int,4) ,
                        new SqlParameter("@FResourceID", SqlDbType.Int,4) ,
                        new SqlParameter("@FBillNo", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FBackFlushed", SqlDbType.Bit,1) ,
                        new SqlParameter("@FWBInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FTranStatus", SqlDbType.Int,4) ,
                        new SqlParameter("@FZPBillInterID", SqlDbType.Int,4) ,
                        new SqlParameter("@FRelateBrID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPurposeID", SqlDbType.Int,4) ,
                        //new SqlParameter("@FUUID", SqlDbType.UniqueIdentifier,16) ,
                        new SqlParameter("@FRelateInvoiceID", SqlDbType.Int,4) ,
                        new SqlParameter("@FImport", SqlDbType.Int,4) ,
                        new SqlParameter("@FUse", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FSystemType", SqlDbType.Int,4) ,
                        new SqlParameter("@FMarketingStyle", SqlDbType.Int,4) ,
                        new SqlParameter("@FPayBillID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCheckDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FExplanation", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FFetchAdd", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FFetchDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FManagerID", SqlDbType.Int,4) ,
                        new SqlParameter("@FRefType", SqlDbType.Int,4) ,
                        new SqlParameter("@FSelTranType", SqlDbType.Int,4) ,
                        new SqlParameter("@FNote", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FChildren", SqlDbType.Int,4) ,
                        new SqlParameter("@FHookStatus", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FActPriceVchTplID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPlanPriceVchTplID", SqlDbType.Int,4) ,
                        new SqlParameter("@FProcID", SqlDbType.Int,4) ,
                        new SqlParameter("@FActualVchTplID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPlanVchTplID", SqlDbType.Int,4) ,
                        new SqlParameter("@FBrID", SqlDbType.Int,4) ,
                        new SqlParameter("@FVIPCardID", SqlDbType.Int,4) ,
                        new SqlParameter("@FVIPScore", SqlDbType.Decimal,13) ,
                        new SqlParameter("@FDCStockID", SqlDbType.Int,4) ,
                        new SqlParameter("@FHolisticDiscountRate", SqlDbType.Decimal,13) ,
                        new SqlParameter("@FPOSName", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FWorkShiftId", SqlDbType.Int,4) ,
                        new SqlParameter("@FCussentAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FZanGuCount", SqlDbType.Bit,1) ,
                        new SqlParameter("@FCOMHFreeItem1", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem2", SqlDbType.DateTime) ,
                        new SqlParameter("@FCOMHFreeItem3", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FCOMHFreeItem4", SqlDbType.DateTime) ,
                        new SqlParameter("@FSCStockID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem5", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem6", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem7", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem8", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem9", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FCOMHFreeItem10", SqlDbType.Int,4) ,
                        new SqlParameter("@FCOMHFreeItem11", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FCOMHFreeItem12", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FCOMHFreeItem13", SqlDbType.Int,4)
            };

            parameters[0].Value = iCStockBill.FBrNo;
            parameters[1].Value = Common.SqlNull(iCStockBill.FDeptID);
            parameters[2].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem15);
            parameters[3].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem18);
            parameters[4].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem19);
            parameters[5].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem20);
            parameters[6].Value = Common.SqlNull(iCStockBill.FPOOrdBillNo);
            parameters[7].Value = iCStockBill.FLSSrcInterID;
            parameters[8].Value = Common.SqlNull(iCStockBill.FSettleDate);
            parameters[9].Value = Common.SqlNull(iCStockBill.FManageType);
            parameters[10].Value = Common.SqlNull(iCStockBill.FEmpID);
            parameters[11].Value = Common.SqlNull(iCStockBill.FOrderAffirm);
            parameters[12].Value = iCStockBill.FAutoCreType;
            parameters[13].Value = Common.SqlNull(iCStockBill.FConsignee);
            parameters[14].Value = iCStockBill.FDrpRelateTranType;
            parameters[15].Value = iCStockBill.FPrintCount;
            parameters[16].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem17);
            parameters[17].Value = Common.SqlNull(iCStockBill.FHeadSelfB0154);
            parameters[18].Value = iCStockBill.FSupplyID;
            parameters[19].Value = Common.SqlNull(iCStockBill.FPosterID);
            parameters[20].Value = iCStockBill.FCheckerID;
            parameters[21].Value = Common.SqlNull(iCStockBill.FFManagerID);
            parameters[22].Value = Common.SqlNull(iCStockBill.FSManagerID);
            parameters[23].Value = Common.SqlNull(iCStockBill.FBillerID);
            parameters[24].Value = Common.SqlNull(iCStockBill.FReturnBillInterID);
            parameters[25].Value = Common.SqlNull(iCStockBill.FSCBillNo);
            parameters[26].Value = iCStockBill.FInterID;
            parameters[27].Value = iCStockBill.FHookInterID;
            parameters[28].Value = iCStockBill.FVchInterID;
            parameters[29].Value = iCStockBill.FPosted;
            parameters[30].Value = Common.SqlNull(iCStockBill.FCheckSelect);
            parameters[31].Value = Common.SqlNull(iCStockBill.FCurrencyID);
            parameters[32].Value = Common.SqlNull(iCStockBill.FSaleStyle);
            parameters[33].Value = Common.SqlNull(iCStockBill.FAcctID);
            parameters[34].Value = iCStockBill.FROB;
            parameters[35].Value = Common.SqlNull(iCStockBill.FRSCBillNo);
            parameters[36].Value = iCStockBill.FStatus;
            parameters[37].Value = iCStockBill.FTranType;
            parameters[38].Value = iCStockBill.FUpStockWhenSave;
            parameters[39].Value = iCStockBill.FCancellation;
            parameters[40].Value = iCStockBill.FOrgBillInterID;
            parameters[41].Value = Common.SqlNull(iCStockBill.FBillTypeID);
            parameters[42].Value = Common.SqlNull(iCStockBill.FPOStyle);
            parameters[43].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel1);
            parameters[44].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel2);
            parameters[45].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel3);
            parameters[46].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel4);
            parameters[47].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel5);
            parameters[48].Value = iCStockBill.FDate;
            parameters[49].Value = Common.SqlNull(iCStockBill.FMultiCheckLevel6);
            parameters[50].Value = Common.SqlNull(iCStockBill.FMultiCheckDate1);
            parameters[51].Value = Common.SqlNull(iCStockBill.FMultiCheckDate2);
            parameters[52].Value = Common.SqlNull(iCStockBill.FMultiCheckDate3);
            parameters[53].Value = Common.SqlNull(iCStockBill.FMultiCheckDate4);
            parameters[54].Value = Common.SqlNull(iCStockBill.FMultiCheckDate5);
            parameters[55].Value = Common.SqlNull(iCStockBill.FMultiCheckDate6);
            parameters[56].Value = Common.SqlNull(iCStockBill.FCurCheckLevel);
            parameters[57].Value = Common.SqlNull(iCStockBill.FTaskID);
            parameters[58].Value = Common.SqlNull(iCStockBill.FResourceID);
            parameters[59].Value = iCStockBill.FBillNo;
            parameters[60].Value = iCStockBill.FBackFlushed;
            parameters[61].Value = iCStockBill.FWBInterID;
            parameters[62].Value = iCStockBill.FTranStatus;
            parameters[63].Value = Common.SqlNull(iCStockBill.FZPBillInterID);
            parameters[64].Value = Common.SqlNull(iCStockBill.FRelateBrID);
            parameters[65].Value = iCStockBill.FPurposeID;
            //parameters[66].Value = Guid.NewGuid();
            parameters[66].Value = iCStockBill.FRelateInvoiceID;
            parameters[67].Value = Common.SqlNull(iCStockBill.FImport);
            parameters[68].Value = Common.SqlNull(iCStockBill.FUse);
            parameters[69].Value = Common.SqlNull(iCStockBill.FSystemType);
            parameters[70].Value = iCStockBill.FMarketingStyle;
            parameters[71].Value = iCStockBill.FPayBillID;
            parameters[72].Value = Common.SqlNull(iCStockBill.FCheckDate);
            parameters[73].Value = iCStockBill.FExplanation;
            parameters[74].Value = iCStockBill.FFetchAdd;
            parameters[75].Value = Common.SqlNull(iCStockBill.FFetchDate);
            parameters[76].Value = iCStockBill.FManagerID;
            parameters[77].Value = iCStockBill.FRefType;
            parameters[78].Value = iCStockBill.FSelTranType;
            parameters[79].Value = iCStockBill.FNote;
            parameters[80].Value = iCStockBill.FChildren;
            parameters[81].Value = iCStockBill.FHookStatus;
            parameters[82].Value = iCStockBill.FActPriceVchTplID;
            parameters[83].Value = iCStockBill.FPlanPriceVchTplID;
            parameters[84].Value = iCStockBill.FProcID;
            parameters[85].Value = iCStockBill.FActualVchTplID;
            parameters[86].Value = iCStockBill.FPlanVchTplID;
            parameters[87].Value = Common.SqlNull(iCStockBill.FBrID);
            parameters[88].Value = iCStockBill.FVIPCardID;
            parameters[89].Value = iCStockBill.FVIPScore;
            parameters[90].Value = Common.SqlNull(iCStockBill.FDCStockID);
            parameters[91].Value = iCStockBill.FHolisticDiscountRate;
            parameters[92].Value = iCStockBill.FPOSName;
            parameters[93].Value = iCStockBill.FWorkShiftId;
            parameters[94].Value = iCStockBill.FCussentAcctID;
            parameters[95].Value = iCStockBill.FZanGuCount;
            parameters[96].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem1);
            parameters[97].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem2);
            parameters[98].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem3);
            parameters[99].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem4);
            parameters[100].Value = Common.SqlNull(iCStockBill.FSCStockID);
            parameters[101].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem5);
            parameters[102].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem6);
            parameters[103].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem7);
            parameters[104].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem8);
            parameters[105].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem9);
            parameters[106].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem10);
            parameters[107].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem11);
            parameters[108].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem12);
            parameters[109].Value = Common.SqlNull(iCStockBill.FCOMHFreeItem13);
            //DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            int ret = SqlHelper.ExecuteNonQuery(conn,strSql.ToString(), parameters);
            return ret;
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public static ICStockBill GetModel(string conn, string FBillNo)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 FBrNo,FInterID,FTranType,FDate,FBillNo,FUse,FNote,FDCStockID,FSCStockID,FDeptID,FEmpID,FSupplyID,FPosterID,FCheckerID,FFManagerID,FSManagerID,FBillerID,FReturnBillInterID,FSCBillNo,FHookInterID,FVchInterID,FPosted,FCheckSelect,FCurrencyID,FSaleStyle,FAcctID,FROB,FRSCBillNo,FStatus,FUpStockWhenSave,FCancellation,FOrgBillInterID,FBillTypeID,FPOStyle,FMultiCheckLevel1,FMultiCheckLevel2,FMultiCheckLevel3,FMultiCheckLevel4,FMultiCheckLevel5,FMultiCheckLevel6,FMultiCheckDate1,FMultiCheckDate2,FMultiCheckDate3,FMultiCheckDate4,FMultiCheckDate5,FMultiCheckDate6,FCurCheckLevel,FTaskID,FResourceID,FBackFlushed,FWBInterID,FTranStatus,FZPBillInterID,FRelateBrID,FPurposeID,FUUID,FRelateInvoiceID,FOperDate,FImport,FSystemType,FMarketingStyle,FPayBillID,FCheckDate,FExplanation,FFetchAdd,FFetchDate,FManagerID,FRefType,FSelTranType,FChildren,FHookStatus,FActPriceVchTplID,FPlanPriceVchTplID,FProcID,FActualVchTplID,FPlanVchTplID,FBrID,FVIPCardID,FVIPScore,FHolisticDiscountRate,FPOSName,FWorkShiftId,FCussentAcctID,FZanGuCount,FCOMHFreeItem1,FCOMHFreeItem2,FCOMHFreeItem3,FCOMHFreeItem4,FCOMHFreeItem5,FCOMHFreeItem6,FCOMHFreeItem7,FCOMHFreeItem8,FCOMHFreeItem9,FCOMHFreeItem10,FCOMHFreeItem11,FCOMHFreeItem12,FCOMHFreeItem13,FCOMHFreeItem15,FCOMHFreeItem18,FCOMHFreeItem19,FCOMHFreeItem20,FPOOrdBillNo,FLSSrcInterID,FSettleDate,FManageType,FOrderAffirm,FAutoCreType,FConsignee,FDrpRelateTranType,FPrintCount,FCOMHFreeItem17,FHeadSelfB0154 from ICStockBill ");
            strSql.Append(" where FBillNo=@FBillNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FBillNo", SqlDbType.NVarChar,255)           };
            parameters[0].Value = FBillNo;

            ICStockBill model = new ICStockBill();
            DataTable dt = SqlHelper.ExecuteDataTable(conn,strSql.ToString(), parameters);
            if (dt.Rows.Count > 0)
            {
                return DataRowToModel(dt.Rows[0]);
            }
            else
            {
                return null;
            }
        }

        public static ICStockBill DataRowToModel(DataRow dr)
        {
            ICStockBill iCStockBill = new ICStockBill();

            if (dr["FDeptID"].ToString() != "")
            {
                iCStockBill.FDeptID = int.Parse(dr["FDeptID"].ToString());
            }
            iCStockBill.FBrNo = dr["FBrNo"].ToString();
            if (dr["FCOMHFreeItem15"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem15 = int.Parse(dr["FCOMHFreeItem15"].ToString());
            }
            if (dr["FCOMHFreeItem18"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem18 = DateTime.Parse(dr["FCOMHFreeItem18"].ToString());
            }
            if (dr["FCOMHFreeItem19"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem19 = int.Parse(dr["FCOMHFreeItem19"].ToString());
            }
            if (dr["FCOMHFreeItem20"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem20 = int.Parse(dr["FCOMHFreeItem20"].ToString());
            }
            iCStockBill.FPOOrdBillNo = dr["FPOOrdBillNo"].ToString();
            if (dr["FLSSrcInterID"].ToString() != "")
            {
                iCStockBill.FLSSrcInterID = int.Parse(dr["FLSSrcInterID"].ToString());
            }
            if (dr["FSettleDate"].ToString() != "")
            {
                iCStockBill.FSettleDate = DateTime.Parse(dr["FSettleDate"].ToString());
            }
            if (dr["FManageType"].ToString() != "")
            {
                iCStockBill.FManageType = int.Parse(dr["FManageType"].ToString());
            }
            if (dr["FEmpID"].ToString() != "")
            {
                iCStockBill.FEmpID = int.Parse(dr["FEmpID"].ToString());
            }
            if (dr["FOrderAffirm"].ToString() != "")
            {
                iCStockBill.FOrderAffirm = int.Parse(dr["FOrderAffirm"].ToString());
            }
            if (dr["FAutoCreType"].ToString() != "")
            {
                iCStockBill.FAutoCreType = int.Parse(dr["FAutoCreType"].ToString());
            }
            iCStockBill.FConsignee = dr["FConsignee"].ToString();
            if (dr["FDrpRelateTranType"].ToString() != "")
            {
                iCStockBill.FDrpRelateTranType = int.Parse(dr["FDrpRelateTranType"].ToString());
            }
            if (dr["FPrintCount"].ToString() != "")
            {
                iCStockBill.FPrintCount = int.Parse(dr["FPrintCount"].ToString());
            }
            if (dr["FCOMHFreeItem17"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem17 = int.Parse(dr["FCOMHFreeItem17"].ToString());
            }
            if (dr["FHeadSelfB0154"].ToString() != "")
            {
                iCStockBill.FHeadSelfB0154 = int.Parse(dr["FHeadSelfB0154"].ToString());
            }
            if (dr["FSupplyID"].ToString() != "")
            {
                iCStockBill.FSupplyID = int.Parse(dr["FSupplyID"].ToString());
            }
            if (dr["FPosterID"].ToString() != "")
            {
                iCStockBill.FPosterID = int.Parse(dr["FPosterID"].ToString());
            }
            if (dr["FCheckerID"].ToString() != "")
            {
                iCStockBill.FCheckerID = int.Parse(dr["FCheckerID"].ToString());
            }
            if (dr["FFManagerID"].ToString() != "")
            {
                iCStockBill.FFManagerID = int.Parse(dr["FFManagerID"].ToString());
            }
            if (dr["FSManagerID"].ToString() != "")
            {
                iCStockBill.FSManagerID = int.Parse(dr["FSManagerID"].ToString());
            }
            if (dr["FBillerID"].ToString() != "")
            {
                iCStockBill.FBillerID = int.Parse(dr["FBillerID"].ToString());
            }
            if (dr["FReturnBillInterID"].ToString() != "")
            {
                iCStockBill.FReturnBillInterID = int.Parse(dr["FReturnBillInterID"].ToString());
            }
            iCStockBill.FSCBillNo = dr["FSCBillNo"].ToString();
            if (dr["FInterID"].ToString() != "")
            {
                iCStockBill.FInterID = int.Parse(dr["FInterID"].ToString());
            }
            if (dr["FHookInterID"].ToString() != "")
            {
                iCStockBill.FHookInterID = int.Parse(dr["FHookInterID"].ToString());
            }
            if (dr["FVchInterID"].ToString() != "")
            {
                iCStockBill.FVchInterID = int.Parse(dr["FVchInterID"].ToString());
            }
            if (dr["FPosted"].ToString() != "")
            {
                iCStockBill.FPosted = int.Parse(dr["FPosted"].ToString());
            }
            if (dr["FCheckSelect"].ToString() != "")
            {
                iCStockBill.FCheckSelect = int.Parse(dr["FCheckSelect"].ToString());
            }
            if (dr["FCurrencyID"].ToString() != "")
            {
                iCStockBill.FCurrencyID = int.Parse(dr["FCurrencyID"].ToString());
            }
            if (dr["FSaleStyle"].ToString() != "")
            {
                iCStockBill.FSaleStyle = int.Parse(dr["FSaleStyle"].ToString());
            }
            if (dr["FAcctID"].ToString() != "")
            {
                iCStockBill.FAcctID = int.Parse(dr["FAcctID"].ToString());
            }
            if (dr["FROB"].ToString() != "")
            {
                iCStockBill.FROB = int.Parse(dr["FROB"].ToString());
            }
            iCStockBill.FRSCBillNo = dr["FRSCBillNo"].ToString();
            if (dr["FStatus"].ToString() != "")
            {
                iCStockBill.FStatus = int.Parse(dr["FStatus"].ToString());
            }
            if (dr["FTranType"].ToString() != "")
            {
                iCStockBill.FTranType = int.Parse(dr["FTranType"].ToString());
            }
            if (dr["FUpStockWhenSave"].ToString() != "")
            {
                if ((dr["FUpStockWhenSave"].ToString() == "1") || (dr["FUpStockWhenSave"].ToString().ToLower() == "true"))
                {
                    iCStockBill.FUpStockWhenSave = true;
                }
                else
                {
                    iCStockBill.FUpStockWhenSave = false;
                }
            }
            if (dr["FCancellation"].ToString() != "")
            {
                if ((dr["FCancellation"].ToString() == "1") || (dr["FCancellation"].ToString().ToLower() == "true"))
                {
                    iCStockBill.FCancellation = true;
                }
                else
                {
                    iCStockBill.FCancellation = false;
                }
            }
            if (dr["FOrgBillInterID"].ToString() != "")
            {
                iCStockBill.FOrgBillInterID = int.Parse(dr["FOrgBillInterID"].ToString());
            }
            if (dr["FBillTypeID"].ToString() != "")
            {
                iCStockBill.FBillTypeID = int.Parse(dr["FBillTypeID"].ToString());
            }
            if (dr["FPOStyle"].ToString() != "")
            {
                iCStockBill.FPOStyle = int.Parse(dr["FPOStyle"].ToString());
            }
            if (dr["FMultiCheckLevel1"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel1 = int.Parse(dr["FMultiCheckLevel1"].ToString());
            }
            if (dr["FMultiCheckLevel2"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel2 = int.Parse(dr["FMultiCheckLevel2"].ToString());
            }
            if (dr["FMultiCheckLevel3"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel3 = int.Parse(dr["FMultiCheckLevel3"].ToString());
            }
            if (dr["FMultiCheckLevel4"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel4 = int.Parse(dr["FMultiCheckLevel4"].ToString());
            }
            if (dr["FMultiCheckLevel5"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel5 = int.Parse(dr["FMultiCheckLevel5"].ToString());
            }
            if (dr["FDate"].ToString() != "")
            {
                iCStockBill.FDate = DateTime.Parse(dr["FDate"].ToString());
            }
            if (dr["FMultiCheckLevel6"].ToString() != "")
            {
                iCStockBill.FMultiCheckLevel6 = int.Parse(dr["FMultiCheckLevel6"].ToString());
            }
            if (dr["FMultiCheckDate1"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate1 = DateTime.Parse(dr["FMultiCheckDate1"].ToString());
            }
            if (dr["FMultiCheckDate2"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate2 = DateTime.Parse(dr["FMultiCheckDate2"].ToString());
            }
            if (dr["FMultiCheckDate3"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate3 = DateTime.Parse(dr["FMultiCheckDate3"].ToString());
            }
            if (dr["FMultiCheckDate4"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate4 = DateTime.Parse(dr["FMultiCheckDate4"].ToString());
            }
            if (dr["FMultiCheckDate5"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate5 = DateTime.Parse(dr["FMultiCheckDate5"].ToString());
            }
            if (dr["FMultiCheckDate6"].ToString() != "")
            {
                iCStockBill.FMultiCheckDate6 = DateTime.Parse(dr["FMultiCheckDate6"].ToString());
            }
            if (dr["FCurCheckLevel"].ToString() != "")
            {
                iCStockBill.FCurCheckLevel = int.Parse(dr["FCurCheckLevel"].ToString());
            }
            if (dr["FTaskID"].ToString() != "")
            {
                iCStockBill.FTaskID = int.Parse(dr["FTaskID"].ToString());
            }
            if (dr["FResourceID"].ToString() != "")
            {
                iCStockBill.FResourceID = int.Parse(dr["FResourceID"].ToString());
            }
            iCStockBill.FBillNo = dr["FBillNo"].ToString();
            if (dr["FBackFlushed"].ToString() != "")
            {
                if ((dr["FBackFlushed"].ToString() == "1") || (dr["FBackFlushed"].ToString().ToLower() == "true"))
                {
                    iCStockBill.FBackFlushed = true;
                }
                else
                {
                    iCStockBill.FBackFlushed = false;
                }
            }
            if (dr["FWBInterID"].ToString() != "")
            {
                iCStockBill.FWBInterID = int.Parse(dr["FWBInterID"].ToString());
            }
            if (dr["FTranStatus"].ToString() != "")
            {
                iCStockBill.FTranStatus = int.Parse(dr["FTranStatus"].ToString());
            }
            if (dr["FZPBillInterID"].ToString() != "")
            {
                iCStockBill.FZPBillInterID = int.Parse(dr["FZPBillInterID"].ToString());
            }
            if (dr["FRelateBrID"].ToString() != "")
            {
                iCStockBill.FRelateBrID = int.Parse(dr["FRelateBrID"].ToString());
            }
            if (dr["FPurposeID"].ToString() != "")
            {
                iCStockBill.FPurposeID = int.Parse(dr["FPurposeID"].ToString());
            }
            //if (dr["FUUID"].ToString() != "")
            //{
            //    iCStockBill.FUUID = dr["FUUID"].ToString();
            //}
            if (dr["FRelateInvoiceID"].ToString() != "")
            {
                iCStockBill.FRelateInvoiceID = int.Parse(dr["FRelateInvoiceID"].ToString());
            }
            if (dr["FImport"].ToString() != "")
            {
                iCStockBill.FImport = int.Parse(dr["FImport"].ToString());
            }
            iCStockBill.FUse = dr["FUse"].ToString();
            if (dr["FSystemType"].ToString() != "")
            {
                iCStockBill.FSystemType = int.Parse(dr["FSystemType"].ToString());
            }
            if (dr["FMarketingStyle"].ToString() != "")
            {
                iCStockBill.FMarketingStyle = int.Parse(dr["FMarketingStyle"].ToString());
            }
            if (dr["FPayBillID"].ToString() != "")
            {
                iCStockBill.FPayBillID = int.Parse(dr["FPayBillID"].ToString());
            }
            if (dr["FCheckDate"].ToString() != "")
            {
                iCStockBill.FCheckDate = DateTime.Parse(dr["FCheckDate"].ToString());
            }
            iCStockBill.FExplanation = dr["FExplanation"].ToString();
            iCStockBill.FFetchAdd = dr["FFetchAdd"].ToString();
            if (dr["FFetchDate"].ToString() != "")
            {
                iCStockBill.FFetchDate = DateTime.Parse(dr["FFetchDate"].ToString());
            }
            if (dr["FManagerID"].ToString() != "")
            {
                iCStockBill.FManagerID = int.Parse(dr["FManagerID"].ToString());
            }
            if (dr["FRefType"].ToString() != "")
            {
                iCStockBill.FRefType = int.Parse(dr["FRefType"].ToString());
            }
            if (dr["FSelTranType"].ToString() != "")
            {
                iCStockBill.FSelTranType = int.Parse(dr["FSelTranType"].ToString());
            }
            iCStockBill.FNote = dr["FNote"].ToString();
            if (dr["FChildren"].ToString() != "")
            {
                iCStockBill.FChildren = int.Parse(dr["FChildren"].ToString());
            }
            if (dr["FHookStatus"].ToString() != "")
            {
                iCStockBill.FHookStatus = int.Parse(dr["FHookStatus"].ToString());
            }
            if (dr["FActPriceVchTplID"].ToString() != "")
            {
                iCStockBill.FActPriceVchTplID = int.Parse(dr["FActPriceVchTplID"].ToString());
            }
            if (dr["FPlanPriceVchTplID"].ToString() != "")
            {
                iCStockBill.FPlanPriceVchTplID = int.Parse(dr["FPlanPriceVchTplID"].ToString());
            }
            if (dr["FProcID"].ToString() != "")
            {
                iCStockBill.FProcID = int.Parse(dr["FProcID"].ToString());
            }
            if (dr["FActualVchTplID"].ToString() != "")
            {
                iCStockBill.FActualVchTplID = int.Parse(dr["FActualVchTplID"].ToString());
            }
            if (dr["FPlanVchTplID"].ToString() != "")
            {
                iCStockBill.FPlanVchTplID = int.Parse(dr["FPlanVchTplID"].ToString());
            }
            if (dr["FBrID"].ToString() != "")
            {
                iCStockBill.FBrID = int.Parse(dr["FBrID"].ToString());
            }
            if (dr["FVIPCardID"].ToString() != "")
            {
                iCStockBill.FVIPCardID = int.Parse(dr["FVIPCardID"].ToString());
            }
            if (dr["FVIPScore"].ToString() != "")
            {
                iCStockBill.FVIPScore = decimal.Parse(dr["FVIPScore"].ToString());
            }
            if (dr["FDCStockID"].ToString() != "")
            {
                iCStockBill.FDCStockID = int.Parse(dr["FDCStockID"].ToString());
            }
            if (dr["FHolisticDiscountRate"].ToString() != "")
            {
                iCStockBill.FHolisticDiscountRate = decimal.Parse(dr["FHolisticDiscountRate"].ToString());
            }
            iCStockBill.FPOSName = dr["FPOSName"].ToString();
            if (dr["FWorkShiftId"].ToString() != "")
            {
                iCStockBill.FWorkShiftId = int.Parse(dr["FWorkShiftId"].ToString());
            }
            if (dr["FCussentAcctID"].ToString() != "")
            {
                iCStockBill.FCussentAcctID = int.Parse(dr["FCussentAcctID"].ToString());
            }
            if (dr["FZanGuCount"].ToString() != "")
            {
                if ((dr["FZanGuCount"].ToString() == "1") || (dr["FZanGuCount"].ToString().ToLower() == "true"))
                {
                    iCStockBill.FZanGuCount = true;
                }
                else
                {
                    iCStockBill.FZanGuCount = false;
                }
            }
            if (dr["FCOMHFreeItem1"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem1 = int.Parse(dr["FCOMHFreeItem1"].ToString());
            }
            if (dr["FCOMHFreeItem2"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem2 = DateTime.Parse(dr["FCOMHFreeItem2"].ToString());
            }
            iCStockBill.FCOMHFreeItem3 = dr["FCOMHFreeItem3"].ToString();
            if (dr["FCOMHFreeItem4"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem4 = DateTime.Parse(dr["FCOMHFreeItem4"].ToString());
            }
            if (dr["FSCStockID"].ToString() != "")
            {
                iCStockBill.FSCStockID = int.Parse(dr["FSCStockID"].ToString());
            }
            if (dr["FCOMHFreeItem5"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem5 = int.Parse(dr["FCOMHFreeItem5"].ToString());
            }
            if (dr["FCOMHFreeItem6"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem6 = int.Parse(dr["FCOMHFreeItem6"].ToString());
            }
            if (dr["FCOMHFreeItem7"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem7 = int.Parse(dr["FCOMHFreeItem7"].ToString());
            }
            if (dr["FCOMHFreeItem8"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem8 = int.Parse(dr["FCOMHFreeItem8"].ToString());
            }
            iCStockBill.FCOMHFreeItem9 = dr["FCOMHFreeItem9"].ToString();
            if (dr["FCOMHFreeItem10"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem10 = int.Parse(dr["FCOMHFreeItem10"].ToString());
            }
            iCStockBill.FCOMHFreeItem11 = dr["FCOMHFreeItem11"].ToString();
            iCStockBill.FCOMHFreeItem12 = dr["FCOMHFreeItem12"].ToString();
            if (dr["FCOMHFreeItem13"].ToString() != "")
            {
                iCStockBill.FCOMHFreeItem13 = int.Parse(dr["FCOMHFreeItem13"].ToString());
            }
            return iCStockBill;
        }

        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        public static bool Exist(string conn,string billNo)
        {
            bool retVal = false;
            string sql = string.Format("Select Count(*) From [ICStockBill] Where FBillNo = '{0}' and FTranType = 21", billNo);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && int.Parse(obj.ToString()) > 0)
            {
                retVal = true;
            }
            return retVal;
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public static bool UpdateSupplyID(string conn, ICStockBill stockBill)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append(" update ICStockBill set ");
            strSql.Append(" FSupplyID=@FSupplyID");
            strSql.Append(" where FBillNo=@FBillNo ");
            SqlParameter[] parameters = {
                    new SqlParameter("@FSupplyID", SqlDbType.Int,4),
                    new SqlParameter("@FBillNo", SqlDbType.NVarChar,255)};

            parameters[0].Value = stockBill.FSupplyID;
            parameters[1].Value = stockBill.FBillNo;


            int rows = SqlHelper.ExecuteNonQuery(conn, strSql.ToString(), parameters);
            if (rows > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 替换客户编号
        /// </summary>
        /// <param name="SupplyID"></param>
        /// <param name="SourceConn"></param>
        /// <param name="DescConn"></param>
        /// <returns></returns>
        public static int GetNewSupplyIDByOriSupplyID(int OriginSupplyID,string SourceConn, string DescConn)
        {
            string sql = string.Format("select fname from t_Organization where fitemid = {0}", OriginSupplyID);
            string SupplyName = Common.GetStringByExecuteScalar(SourceConn, sql);
            if (SupplyName != "")
            {
                sql = string.Format("select fitemid from t_Organization where fname = '{0}'", SupplyName);
                string NewSupplyID = Common.GetStringByExecuteScalar(DescConn, sql);
                if(NewSupplyID != "")
                {
                    return int.Parse(NewSupplyID.ToString());
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
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="billNo"></param>
        /// <returns></returns>
        public static int GetInterIDByBillNo(string conn, string billNo)
        {
            int retVal = -1;
            string sql = string.Format("Select FInterID From [ICStockBill] Where FBillNo = '{0}' and FTranType = 21", billNo);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && int.Parse(obj.ToString()) > 0)
            {
                retVal = int.Parse(obj.ToString());
            }
            return retVal;
        }
    }
}
