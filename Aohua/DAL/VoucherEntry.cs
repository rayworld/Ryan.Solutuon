using Ryan.Framework.DotNetFx40.DBUtility;
using System.Data;

namespace Aohua.DAL
{
    public partial class VoucherEntries
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";

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
            sql = string.Format("Select FName From t_Account where FAccountID = {0}",OriginalAccountID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                OriginAccountName = obj.ToString();
                NewAccountName = OriginAccountName.Replace("10%", "").Replace("11%","").Replace("客户","内部客户");
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="OriginalAccountID"></param>
        /// <returns></returns>
        public static int ReplaceAccountID(int OriginalAccountID)
        {
            sql = string.Format("select FAccountID from t_Account where FName = ( Select CASE WHEN fname like '18%' then replace((fname + '11%'),'内部客户','客户') else replace((fname + '10%'),'内部客户','客户') end From t_Account WHERE FAccountID = {0})", OriginalAccountID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return int.Parse(obj.ToString()) > 0 ? int.Parse(obj.ToString()) : -1;
            }
            else
            {
                return -1;
            }
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
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if(obj != null && obj.ToString() != "")
            {
                return obj.ToString();
            }
            else
            {
                return "-1";
            }
        }

        /// <summary>
        /// 得到新科目下的最大客户编号
        /// </summary>
        /// <param name="NewAccountID"></param>
        /// <returns></returns>
        public static string GetNewAccountMaxFNumber(int NewAccountID)
        {
            sql = string.Format("select Max(FNumber) from t_item where fItemClassid = (select FItemClassID from t_ItemClass where FName = '20' + (select FName from t_account where FAccountID ={0}))",NewAccountID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return obj.ToString();
            }
            else
            {
                return "-1";
            }
        }

        public static bool FNumberExists(int NewAccountID,string FNumber)
        {
            sql = string.Format("select FNumber from t_item where fItemClassid = (select FItemClassID from t_ItemClass where FName = '20' + (select FName from t_account where FAccountID ={0})) and FNumber ='{1}'", NewAccountID,FNumber);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewItemClassID"></param>
        /// <returns></returns>
        public static DataTable GetNewItemClassIDLast20Item(int NewItemClassID)
        {
            sql = string.Format("select Top 20 FItemID as 客户编号,FNumber as 客户代码,FName as 客户名称 from t_item where fItemClassid ={0} Order By FNumber Desc", NewItemClassID);
            DataTable retDT = SqlHelper.ExecuteDataTable(conn, sql);
            return retDT;
        }
    }
}