using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aohua.DAL
{
    public partial class Items
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemClassID"></param>
        /// <param name="FNumber"></param>
        /// <returns></returns>
        public static int GetItemIDByAccountIDFNumber(int AccountID, string Number)
        {
            sql = string.Format("select FItemID from t_item where fItemClassid = (select FItemClassID from t_ItemClass where FName = '20' + (select FName from t_account where FAccountID = {0})) and FNumber = '{1}'", AccountID, Number);
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
    }
}