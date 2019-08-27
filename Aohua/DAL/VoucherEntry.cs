using Ryan.Framework.DotNetFx40.DBUtility;
using System.Data;

namespace Aohua.DAL
{
    public partial class VoucherEntries
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = ""; 

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalAccountID"></param>
        /// <returns></returns>
        public static int ReplaceAccountID(int OriginalAccountID)
        {
            sql = string.Format("select FAccountID from t_Account where FName = ( Select CASE WHEN fname like '18%' then replace((fname + '11%'),'内部客户','客户') else replace((fname + '10%'),'内部客户','客户') end From t_Account WHERE FAccountID = {0})", OriginalAccountID);
            return BaseDAL.GetIntBySql(sql); 
            //object obj = SqlHelper.ExecuteScalar(conn, sql);
            //if (obj != null && obj.ToString() != "")
            //{
            //    return int.Parse(obj.ToString()) > 0 ? int.Parse(obj.ToString()) : -1;
            //}
            //else
            //{
            //    return -1;
            //}
        }

        /// <summary>
        /// 得到原凭证客户编号
        /// </summary>
        /// <param name="VoucherID"></param>
        /// <param name="EntryID"></param>
        /// <returns></returns>
        public static string GetOriginCustomFNumber(int VoucherID,int EntryID)
        {
            sql = string.Format("select FNumber from t_Item where FItemID = (select FItemID from t_ItemDetailV where FDetailID = (select FDetailID from t_VoucherEntry where FVoucherID = {0} and FEntryID ={1}) and FItemClassID =(select FItemClassID from t_itemclass where fname = '20' +(select FName from t_account where FAccountID =(select FAccountID from t_VoucherEntry where FVoucherID = {0} and FEntryID ={1}))))", VoucherID, EntryID);
            return BaseDAL.GetNotNullStringBySql(sql);
            //object obj = SqlHelper.ExecuteScalar(conn, sql);
            //if(obj != null && obj.ToString() != "")
            //{
            //    return obj.ToString();
            //}
            //else
            //{
            //    return "-1";
            //}
        }

        /// <summary>
        /// 得到新科目下的最大客户编号
        /// </summary>
        /// <param name="NewAccountID"></param>
        /// <returns></returns>
        public static string GetNewAccountMaxFNumber(int NewAccountID)
        {
            sql = string.Format("select Max(FNumber) from t_item where fItemClassid = (select FItemClassID from t_ItemClass where FName = '20' + (select FName from t_account where FAccountID ={0}))",NewAccountID);
            return BaseDAL.GetNotNullStringBySql(sql);
            //object obj = SqlHelper.ExecuteScalar(conn, sql);
            //if (obj != null && obj.ToString() != "")
            //{
            //    return obj.ToString();
            //}
            //else
            //{
            //    return "-1";
            //}
        }

        public static bool FNumberExists(int NewAccountID,string FNumber)
        {
            sql = string.Format("select FNumber from t_item where fItemClassid = (select FItemClassID from t_ItemClass where FName = '20' + (select FName from t_account where FAccountID ={0})) and FNumber ='{1}'", NewAccountID,FNumber);
            return BaseDAL.GetNotNullStringBySql(sql) != "" ? true : false;
            //object obj = SqlHelper.ExecuteScalar(conn, sql);
            //if (obj != null && obj.ToString() != "")
            //{
            //    return true;
            //}
            //else
            //{
            //    return false;
            //}
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewItemClassID"></param>
        /// <returns></returns>
        public static DataTable GetNewItemClassIDLast20Item(int NewItemClassID)
        {
            sql = string.Format("select Top 20 FItemID as 客户编号,FNumber as 客户代码,FName as 客户名称 from t_item where fItemClassid ={0} Order By FNumber Desc", NewItemClassID);
            //DataTable retDT = SqlHelper.ExecuteDataTable(conn, sql);
            return BaseDAL.GetDataTableBySql(sql);
        }

        #region 2.0

        public static int GetMaxEntryID(int voucherID)
        {
            sql = string.Format("Select Max(FEntryID) + 1 from t_voucherEntry where FvoucherID = {0}",voucherID);
            return BaseDAL.Sql2Int(conn, sql);
        }

        public static DataTable GetCustomListByCustomNameQueryStringCustomArea(string QueryString,string CustomArea)
        {
            sql = string.Format("select FName as 客户名称, cast(fitemid as varchar) as 客户编号, cast(FItemClassID as varchar) as 客户类型号 from t_Item where FItemClassID in (select FItemClassID from t_ItemClass where replace(FName,'年','') in (select replace(FName,'年','') from t_Account where FParentID in (27225,27320,27385) and fname not like '%内部%'and fname like '%{1}%')) and fname like '%{0}%'", QueryString, CustomArea);
            return BaseDAL.GetDataTableBySql(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="custName"></param>
        /// <param name="custaddress"></param>
        /// <param name="area"></param>
        /// <returns></returns>
        public static string GetItemIDItemClassIDByCustomNameCustomAddressCustomArea(string custName, string custaddress,string area)
        {
            sql = string.Format("select cast(fitemid as varchar)  + ',' + cast(FItemClassID as varchar) from t_Item where FItemClassID in (select FItemClassID from t_ItemClass where replace(FName,'年','') in (select replace(FName,'年','') from t_Account where FParentID in (27225,27320,27385) and fname not like '%内部%'and fname like '%{2}%')) and fname like '%{0}%' and fname like '%{1}%'",custName,custaddress,area);
            return BaseDAL.GetNotNullStringBySql(sql);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="itemClassID"></param>
        /// <returns></returns>
        public static string GetAccountIDByItemClassID(string itemClassID)
        {
            sql = string.Format("select FAccountID from t_Account where replace(fname,'年','') = (select replace(fname,'年','') from t_itemclass where FItemClassID = {0})", itemClassID);
            return BaseDAL.GetNotNullStringBySql(sql);

        }
        #endregion

        #region 2.0
        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static string GetAccountNameByAccountID(int AccountID)
        {
            sql = string.Format("select FName from t_Account where FAccountID = {0}",AccountID);
            return BaseDAL.GetNotNullStringBySql(sql);
        }
        #endregion

        #region UnUseed
        /// <summary>
        /// 替换科目
        /// </summary>
        /// <param name="OriginalAccountID"></param>
        /// <returns></returns>
        public static int ReplaceAccountID_OLD(int OriginalAccountID)
        {
            string NewAccountName = "";
            string OriginAccountName = "";
            int retAccountID = 0;
            sql = string.Format("Select FName From t_Account where FAccountID = {0}", OriginalAccountID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                OriginAccountName = obj.ToString();
                NewAccountName = OriginAccountName.Replace("10%", "").Replace("11%", "").Replace("客户", "内部客户");
                sql = string.Format("Select FAccountID From t_Account where FName = '{0}'", NewAccountName);
                object ObjectNewAccountID = SqlHelper.ExecuteScalar(conn, sql);
                if (ObjectNewAccountID != null && ObjectNewAccountID.ToString() != "")
                {
                    retAccountID = int.Parse(ObjectNewAccountID.ToString());
                    return retAccountID > 0 ? retAccountID : -1;
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
        #endregion
    }
}