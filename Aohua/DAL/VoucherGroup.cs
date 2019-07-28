using Ryan.Framework.DotNetFx40.DBUtility;
using System.Data;

namespace Aohua.DAL
{
    public partial class VoucherGroups
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";

        /// <summary>
        /// 只显示“转”字凭证
        /// </summary>
        /// <returns>转字凭证列表</returns>
        public static DataTable BindComboBoxVoucherGroupData()
        {
            sql = "select FGroupID,FName from t_VoucherGroup where fname Like '%转' and FGroupID <> 2";
            return SqlHelper.ExecuteDataTable(conn, sql);
        }
    }
}