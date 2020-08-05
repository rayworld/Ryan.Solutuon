using Ryan.Framework.DotNetFx40.DBUtility;
using System;

namespace Aohua.DAL
{
    public partial class Common
    {
        public static object SqlNull(object obj)
        {
            if (obj == null || obj.ToString() == "")
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }

        public static string GetStringByExecuteScalar(string conn, string sql)
        {
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return obj.ToString();
            }
            else
            {
                return "";
            }
        }
    }
}
