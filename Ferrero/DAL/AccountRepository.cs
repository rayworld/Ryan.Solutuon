﻿using Ryan.Framework.DotNetFx40.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace EAS2WISE.DAL
{
    /// <summary>
    /// 数据访问类:t_User
    /// </summary>
    public partial class AccountRepository
    {
        #region  BasicMethod

        #endregion  BasicMethod

        #region  ExtensionMethod
        /// <summary>
        /// 获得数据列表
        /// </summary>
        public int UserLogin(string sConnectionString, string userName, string password)
        {
            ///PassService pass = new PassService();
            if (!string.IsNullOrEmpty(sConnectionString))
            {
                //string connectionString = EncryptHelper.Decrypt("77052300",ConfigurationManager.ConnectionStrings[connectionName].ConnectionString);
                StringBuilder strSql = new StringBuilder();
                strSql.Append("select Count(*) ");
                strSql.Append(" FROM t_User ");
                //strSql.Append(" where t_User.FName = @FName and t_User.FSID = @FSID ");
                strSql.Append(" where t_User.FName = @FName ");

                SqlParameter[] parameters = {
				new SqlParameter("@FName", SqlDbType.NVarChar , 255)
				//new SqlParameter("@FSID", SqlDbType.NVarChar , 255)
				};
                parameters[0].Value = userName;
                //parameters[1].Value = password;
                object obj = SqlHelper.ExecuteScalar(sConnectionString, strSql.ToString(), parameters);
                return obj != null ? int.Parse(obj.ToString()) : 0;
            }
            else
            {
                return 0;
            }

        }
        #endregion  ExtensionMethod
    }
}

