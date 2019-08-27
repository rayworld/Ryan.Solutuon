using Ryan.Framework.DotNetFx40.Common;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Data;
using System.Text;

namespace Aohua.DAL
{
    public partial class Vouchers
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";

        public static DateTime GetServerTime()
        {
            sql = "select convert(varchar(10),getdate(),120) as serverTime";
            return DateTime.Parse(BaseDAL.Sql2NotNullString(conn, sql));   
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="conn"></param>
        /// <returns></returns>
        public static int GetNewVoucherID()
        {
            int VoucherID = 0;
            sql = "select FMaxNum from ICMaxNum where FTableName = 't_Voucher'";
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if(obj != null && obj.ToString() != "")
            {
                VoucherID = int.Parse(obj.ToString());
            }

            if (VoucherID > 0)
            {
                sql = " Update ICMaxNum set FMaxNum = FMaxNum + 1 where FTableName = 't_Voucher'";
                int ret = SqlHelper.ExecuteNonQuery(conn, sql);
                return ret > 0 ? VoucherID : -1;
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
        /// <param name="year"></param>
        /// <param name="period"></param>
        /// <returns></returns>
        public static int GetNewFNumber(int year, int period,int groupid)
        {
            int NewFNumber = 1;
            sql = string.Format("select max(FNumber) from t_voucher where fyear = {0} and FPeriod = {1} AND FGroupID = {2}",year.ToString(),period.ToString(),groupid.ToString());
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                NewFNumber = int.Parse(obj.ToString()) + 1;
            }
            else
            {
                NewFNumber = 1;
            }
            return NewFNumber >= 1 ? NewFNumber : -1;
        }

        public static int GetOwnerGroupIDByPreparerID(int PreparerID)
        {
            sql = string.Format("select top 1 FOwnerGroupID from t_voucher where FPreparerID = {0}",PreparerID);
            return BaseDAL.Sql2Int(conn, sql);
        }

        public static int GetNewSerialNum()
        {
            int NewSerialNum = 0;
            sql = "select max(a.FSerialNum) from(select FSerialNum from t_voucher union all select FSerialNum from t_VoucherAdjust union all select FSerialNum from t_VoucherBlankOut) as a";
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if(obj !=null && obj.ToString() != "")
            {
                NewSerialNum = int.Parse(obj.ToString()) + 1;
            }

            return NewSerialNum > 1 ? NewSerialNum : -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OrgionalGroupID"></param>
        /// <returns></returns>
        public static int ReplaceGroupID_OLD(int OrgionalGroupID)
        {
            //去掉“记”，“转”凭证字
            if (OrgionalGroupID > 2)
            {
                sql = string.Format("select FName from t_VoucherGroup where FGroupID = {0}", OrgionalGroupID);
                object obj = SqlHelper.ExecuteScalar(conn, sql);
                if(obj != null && obj.ToString() != "")
                {
                    string OriginGroupName = obj.ToString();
                    string NewGroupName = OriginGroupName.Replace("转", "记");
                    sql = string.Format("Select FGroupID from t_VoucherGroup where FName = '{0}'", NewGroupName);
                    object obj1 = SqlHelper.ExecuteScalar(conn, sql);
                    if(obj1 != null && obj1.ToString() != "")
                    {
                        return int.Parse(obj1.ToString());
                    }
                    return -1;
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
        /// <param name="OrgionalGroupID"></param>
        /// <returns></returns>
        public static int ReplaceGroupID(int OrgionalGroupID)
        {
            //去掉“记”，“转”凭证字
            if (OrgionalGroupID > 2)
            {
                sql = string.Format("SELECT FGroupID FROM t_VoucherGroup WHERE FName = (SELECT replace(FName,'转','记') FROM t_VoucherGroup WHERE FGroupID = {0})", OrgionalGroupID);
                object obj = SqlHelper.ExecuteScalar(conn, sql);
                if (obj != null && obj.ToString() != "")
                {
                    return int.Parse(obj.ToString());
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
        /// 过滤凭证
        /// </summary>
        /// <param name="WhereOption"></param>
        /// <returns></returns>
        public static DataTable GetFilterData(string WhereOption)
        {
            StringBuilder sb = new StringBuilder();
            //
            sb.Append(" Select v.*,FMgBudVchHook = IsNull(H.FVoucherID, 0) ");
            sb.Append(" from(SELECT v.FVoucherID, Cast(v.FYear as varchar(4)) +'.'+ Cast(v.FPeriod as varchar(2)) as 会计期间, v.FDate, v.FTransDate, v.Fexplanation FexplanationHead, ");
            sb.Append("  v.FGroupID, v.FNumber, IsNull(v.FReference, '') as FReference, ");
            sb.Append("  FAttachments =case when v.FAttachments = 0 then '' else v.FAttachments end, ");
            sb.Append("  v.FEntryCount, v.FDebitTotal, v.FCreditTotal, v.FInternalInd, v.FPosted, v.FChecked, ");
            sb.Append("  v.FPreparerID, FPreparer = IsNull(u1.FName, ''), ");
            sb.Append("  v.FCheckerID, FChecker = IsNull(u2.FName, '') ");
            sb.Append("  , v.FPosterID, FPoster = IsNull(u3.FName, '') ");
            sb.Append("  , v.FCashierID, FCashier = IsNull(u4.FName, '') ");
            sb.Append("  , IsNull(v.FHandler, '') as FHandler, v.FOwnerGroupID, v.FObjectName, v.FBlankOutFlag, v.FVoucherAdjust, ");
            sb.Append("  v.FParameter, v.FTranType, v.FSerialNum, IsNull(tp.FTplTypeName ");
            sb.Append("  , '') FTplTypeName, IsNull(tp.FModuleName, '') FModuleName, ");
            sb.Append("  e.FAccountID, a.FNumber FAccountNumber, e.FCurrencyID, e.FDetailID, e.FExchangeRate, e.FDC, e.FAmountFor, e.FAmount, ");
            sb.Append("  e.FQuantity, e.FMeasureUnitID, e.FUnitPrice, e.FInternalInd AS FEntryInternalInd, ");
            sb.Append("  e.FAccountID2, e.FExplanation, FSettleTypeName = IsNull(it.FName, '') ");
            sb.Append("  , e.FSettleNo, IsNull(e.FTransNo, '') as FTransNo, e.FCashFlowItem, e.FReSourceID, e.FTaskID, e.FEntryID, v.FApproveID, ");
            sb.Append("  FApprover = IsNull(u8.FName, ''), v.FFootNote, ");
            sb.Append("  PrimaryIndex = CONVERT(int, 0), FAccountName = CONVERT(VARCHAR(1024), SPACE(0)) FROM(select *, 0 as FBlankOutFlag, 0 as FVoucherAdjust from t_Voucher ");
            sb.Append("          union all ");
            sb.Append("  select *, 1 as FBlankOutFlag, 0 as FVoucherAdjust  from t_VoucherBlankout  where FPeriod <= 12   ) v ");
            sb.Append("  Left Join t_VoucherEntry e  ON v.FVoucherID = e.FVoucherID ");
            sb.Append("  Left Join t_Account a ON e.FAccountID = a.FAccountID ");
            sb.Append("  Left outer join t_Settle it on it.FitemID > 0 And e.FSettleTypeID = it.FitemID ");
            sb.Append("  Left outer join t_Account a1 ON e.FAccountID2 = a1.FAccountID ");
            sb.Append("  Left outer join t_User u1 on u1.FUserID > 0 And v.FPreparerID = u1.FUserID ");
            sb.Append("  Left outer join t_User u2 on u2.FUserID > 0 And v.FCheckerID = u2.FUserID ");
            sb.Append("  Left outer join t_User u3 on u3.FUserID > 0 And v.FPosterID = u3.FUserID ");
            sb.Append("  Left outer join t_User u4 on u4.FUserID > 0 And v.FCashierID = u4.FUserID ");
            sb.Append("  Left outer join t_User u8 on u8.FUserID > 0 And v.FApproveID = u8.FUserID ");
            sb.Append("  Left Outer Join t_VoucherTplType tp on v.FTranType = tp.FTplTypeID ");
            sb.Append("  WHERE v.FVoucherID IN(SELECT  v.FVoucherID  FROM(select *, 0 as FBlankOutFlag, 0 as FVoucherAdjust from t_Voucher ");
            sb.Append("  union all ");
            sb.Append("  select *, 1 as FBlankOutFlag, 0 as FVoucherAdjust  from t_VoucherBlankout  where FPeriod <= 12   ) v ");
            sb.Append("  Left Join t_VoucherEntry e  ON v.FVoucherID = e.FVoucherID ");
            sb.Append("  Left Join t_Account a ON e.FAccountID = a.FAccountID ");
            sb.Append("  Left outer join t_Settle it on it.FitemID > 0 And e.FSettleTypeID = it.FitemID ");
            sb.Append("  Left outer join t_Account a1 ON e.FAccountID2 = a1.FAccountID ");
            sb.Append("  Left outer join t_User u1 on u1.FUserID > 0 And v.FPreparerID = u1.FUserID ");
            sb.Append("  Left outer join t_User u2 on u2.FUserID > 0 And v.FCheckerID = u2.FUserID ");
            sb.Append("  Left outer join t_User u3 on u3.FUserID > 0 And v.FPosterID = u3.FUserID ");
            sb.Append("  Left outer join t_User u4 on u4.FUserID > 0 And v.FCashierID = u4.FUserID ");
            sb.Append("  Left outer join t_User u8 on u8.FUserID > 0 And v.FApproveID = u8.FUserID ");
            sb.Append("  Left Outer Join t_VoucherTplType tp on v.FTranType = tp.FTplTypeID ");
            sb.Append("  Left Join t_ItemDetailV iv ON iv.FDetailID = e.FDetailID ");
            sb.Append("  INNER JOIN t_Item i ON iv.FItemID = i.FItemID ");
            sb.Append("  {0} group by v.FVoucherID)) as v ");
            sb.Append("  Left Outer Join(select distinct FVoucherID, FEntryid from t_MgBudVchHook) H On v.FVoucherID = H.FVoucherID and v.FEntryid = H.FEntryid ");

            return SqlHelper.ExecuteDataTable(conn, string.Format(sb.ToString(), WhereOption));
        }


        public static string GetAccountList4Upgrad()
        {
            string retAccountList = "";
            sql = "SELECT FAccountID FROM t_Account WHERE (FNumber LIKE '4018.%' OR FNumber LIKE '4019.%' OR FNumber LIKE '4020.%') AND FNumber NOT LIKE '%.006'";
            DataTable dtTemp = SqlHelper.ExecuteDataTable(conn, sql);
            if(dtTemp.Rows .Count> 0)
            {
                foreach(DataRow dr in dtTemp.Rows)
                {
                    retAccountList += dr[0].ToString() + ";";
                }
                return retAccountList.Length > 0 ? retAccountList.Substring(0, retAccountList.Length - 1) : "";
            }
            return "";
        }

        public  static int GetDetailIDByVoucherIDEntryID(int VoucherID, int EntryID)
        {
            sql = string.Format("select FDetailID from t_VoucherEntry where FVoucherID = {0} and FEntryID = {1}", VoucherID, EntryID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if(obj != null && obj.ToString() != "")
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        #region 2.0
        public static int UpdateEntryCount(int EntryCount,int VoucherID)
        {
            sql = string.Format("Update t_voucher set fentrycount = {0} where fvoucherID = {1}", EntryCount, VoucherID);
            return SqlHelper.ExecuteNonQuery(conn, sql);
        }
        #endregion

    }
}
