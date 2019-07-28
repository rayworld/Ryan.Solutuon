using Ryan.Framework.DotNetFx40.DBUtility;

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
    }
}