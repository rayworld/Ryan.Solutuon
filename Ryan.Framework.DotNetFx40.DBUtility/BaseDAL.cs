using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Ryan.Framework.DotNetFx40.DBUtility
{
    /// <summary>
    /// 只能应用在.Net 4.5以上
    /// </summary>
    public sealed class BaseDAL
    {
        #region GetModel

        /// <summary>
        /// 通过主键ID反射得到一个对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static List<T> GetModel<T>(
            Dictionary<string, object> WhereOptions = null,
            string conn = "SqlConnectionString"
            ) where T : class, new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            //string TableName = AttributeProcess.GetTableName(type);
            var TableName = CustomAttributeHelper.GetTableName<T>();
            PropertyInfo[] propertyInfos = type.GetProperties();

            //string strsql = "SELECT * FROM @Table WHERE ID=@id";
            //string ColumnList = string.Join(",", propertyInfos.Select(p => $"[{p.Name}]"));
            List<Attribute> list = new List<Attribute>();
            TimeSpanAttribute timeSpanAttribute = new TimeSpanAttribute();
            list.Add(timeSpanAttribute);
            string ColumnList = CustomAttributeHelper.GetAttributeList<T>(list.ToArray(), true);
            string sql = string.Format("SELECT {0} FROM {1} ", ColumnList, TableName);

            SqlParameter[] para = (SqlParameter[])null;
            if (WhereOptions != null)
            {
                sql += " WHERE ";
                sql += string.Join(",", WhereOptions.Select(p => $"[{p.Key}]" + "= " + $"@{p.Key}"));
                //para = BuildSqlParameter(WhereOptions);
                para = WhereOptions.Select(p => new SqlParameter($"@{p.Key}", p.Value?? DBNull.Value)).ToArray();
            }
            Console.WriteLine(sql);

            return SqlDataReader2List<T>(sql, propertyInfos, para, conn);

        }

        /// <summary>
        /// 通过主键ID反射得到一个对象
        /// 带WhereHelper、带参数的重载
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static List<T> GetModel<T>(
            string WhereOptions = "",
            SqlParameter[] sqlParameters = null,
            string conn = "SqlConnectionString"
            ) where T : class, new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            //string TableName = AttributeProcess.GetTableName(type);
            var TableName = CustomAttributeHelper.GetTableName<T>();
            PropertyInfo[] propertyInfos = type.GetProperties();

            //string strsql = "SELECT * FROM @Table WHERE ID=@id";
            //string ColumnList = string.Join(",", propertyInfos.Select(p => $"[{p.Name}]"));
            List<Attribute> list = new List<Attribute>();
            TimeSpanAttribute timeSpanAttribute = new TimeSpanAttribute();
            list.Add(timeSpanAttribute);
            string ColumnList = CustomAttributeHelper.GetAttributeList<T>(list.ToArray(), true);
            string sql = string.Format("SELECT {0} FROM {1} ", ColumnList, TableName);

            //SqlParameter[] para = (SqlParameter[])null;
            if (WhereOptions != "")
            {
                sql += " WHERE ";
                //sql += string.Join(",", WhereOptions.Select(p => $"[{p.Key}]" + "=" + $"@{p.Key}"));
                //para = BuildSqlParameter(WhereOptions);
                //para = WhereOptions.Select(p => new SqlParameter($"@{p.Key}", p.Value ?? DBNull.Value)).ToArray();
                sql += WhereOptions;
                //para = sqlParameters;
            }
            Console.WriteLine(sql);

            return SqlDataReader2List<T>(sql, propertyInfos, sqlParameters, conn);

        }
        
        #endregion

        #region Insert
        /// <summary>
        /// 完成数据插入
        /// 修改 SQL 语句 ，使得多条数据一次性完成，提高效率
        /// 在PropertyInfo中删除自增列或主键列
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="models"></param>
        /// <returns></returns>
        public static int Insert<T>(
            List<T> models,
            string conn = "SqlConnectionString"
            ) where T : new()
        {

            if (models.Count > 0)
            {
                //生成INSERT SQL
                Type type = typeof(T);
                string TableName = CustomAttributeHelper.GetTableName<T>();
                string UnIndentityColumnList = CustomAttributeHelper.GetIdentityList<T>(true);
                PropertyInfo[] propertyInfos = type.GetProperties();

                //string ColumnList = string.Join(",", propertyInfos.Select(p => $"[{p.Name}]").ToArray());
                string ColumnList = UnIndentityColumnList;
                string ParaList = $"@" + UnIndentityColumnList.Replace($", ", $", @");
                //string ParaList = string.Join(",", propertyInfos.Select(p => $"@{p.Name}").ToArray());

                string sql = string.Format("INSERT INTO {0} ({1}) VALUES ({2})", TableName, ColumnList, ParaList);

                Console.WriteLine(sql);
                List<SqlParameter> sqlParameters = new List<SqlParameter>();
                int retVal = 0;
                foreach (T model in models)
                {
                    foreach (PropertyInfo propertyInfo in propertyInfos)
                    {
                        if (UnIndentityColumnList.Contains(propertyInfo.Name))
                        {
                            SqlParameter sqlParameter = new SqlParameter($"@" + propertyInfo.Name, propertyInfo.GetValue(model, null) ?? DBNull.Value);
                            sqlParameters.Add(sqlParameter);
                        }
                    }
                    retVal += SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, sqlParameters.ToArray());
                }
                return retVal;
            }
            else
            {
                //未得到实体数据
                return -1;
            }
        }
        #endregion

        #region Update

        /// <summary>
        /// 通过字典修改数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="UpdateColumnList"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static int Update<T>(
            Dictionary<string, object> UpdateColumnList,
            Dictionary<string, object> WhereOptions = null,
            string conn = "SqlConnectionString"
            ) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            string TableName = CustomAttributeHelper.GetTableName<T>();

            string sql = string.Format("UPDATE {0} SET ", TableName);

            sql += string.Join(",", UpdateColumnList.Select(p => $"[{p.Key}]" + "=" + $"@{p.Key}"));

            SqlParameter[] wherePara = (SqlParameter[])null;
            SqlParameter[] colPara = (SqlParameter[])null;
            SqlParameter[] para = (SqlParameter[])null;
            colPara = UpdateColumnList.Select(p => new SqlParameter($"@{p.Key}", p.Value ?? DBNull.Value)).ToArray();

            if (WhereOptions != null)
            {
                sql += " WHERE ";
                sql += string.Join(",", WhereOptions.Select(p => $"[{p.Key}]" + "=" + $"@{p.Key}"));

                wherePara = (WhereOptions.Select(p => new SqlParameter($"@{p.Key}", p.Value ?? DBNull.Value))).ToArray();

            }

            para = wherePara != null ? colPara.Concat(wherePara).ToArray() : colPara.ToArray();

            //调用执行方法
            Console.WriteLine(sql);
            return SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, para);
        }

        /// <summary>
        /// 通过字典修改数据方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="UpdateColumnList"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static int Update<T>(
            Dictionary<string, object> UpdateColumnList,
            string WhereOptions = "",
            SqlParameter[] sqlParameters = null, 
            string conn = "SqlConnectionString"
            ) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            string TableName = CustomAttributeHelper.GetTableName<T>();

            string sql = string.Format("UPDATE {0} SET ", TableName);

            sql += string.Join(",", UpdateColumnList.Select(p => $"[{p.Key}]" + "=" + $"@{p.Key}"));

            SqlParameter[] wherePara = (SqlParameter[])null;
            SqlParameter[] colPara = (SqlParameter[])null;
            SqlParameter[] para = (SqlParameter[])null;
            colPara = UpdateColumnList.Select(p => new SqlParameter($"@{p.Key}", p.Value ?? DBNull.Value)).ToArray();

            if (WhereOptions != "")
            {
                //sql += " WHERE ";
                //sql += string.Join(",", WhereOptions.Select(p => $"[{p.Key}]" + "=" + $"@{p.Key}"));
                sql += WhereOptions;
                wherePara = sqlParameters;
            }

            para = wherePara != null ? colPara.Concat(wherePara).ToArray() : colPara.ToArray();

            //调用执行方法
            Console.WriteLine(sql);
            return SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, para);
        }

        #endregion

        #region Delete
        /// <summary>
        /// 删除记录方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static int Delete<T>(
            Dictionary<string, object> WhereOptions,
            string conn = "SqlConnectionString") where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            string TableName = CustomAttributeHelper.GetTableName<T>();

            string sql = string.Format("DELETE FROM {0} ", TableName);

            int retVal = 0;
            if (WhereOptions != null)
            {
                sql += "WHERE ";

                sql += string.Join(",", WhereOptions.Select(p => $"{p.Key}" + "=" + $"@{p.Key}"));

                SqlParameter[] sqlParameters = WhereOptions.Select(p => new SqlParameter($"@{p.Key}", p.Value ?? DBNull.Value)).ToArray();
                retVal += SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, sqlParameters);
            }
            else
            {
                retVal = -1;
            }

            return retVal;

        }

        /// <summary>
        /// 删除记录方法
        /// WhereHelper
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="conn"></param>
        /// <param name="WhereOptions"></param>
        /// <returns></returns>
        public static int Delete<T>(
            string WhereOptions = "",
            SqlParameter[] sqlParameters = null,
            string conn = "SqlConnectionString") where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            Type type = typeof(T);

            //TableName默认为type.Name，也可以自定义
            string TableName = CustomAttributeHelper.GetTableName<T>();

            string sql = string.Format("DELETE FROM {0} ", TableName);

            int retVal = 0;
            if (WhereOptions != "")
            {
                sql += WhereOptions;
                retVal += SqlHelper.ExecuteNonQuery(conn, CommandType.Text, sql, sqlParameters);
            }
            else
            {
                retVal = -1;
            }

            return retVal;

        }

        #endregion

        #region 私有过程

        private static List<T> SqlDataReader2List<T>(
            string sql, 
            PropertyInfo[] propertyInfos, 
            SqlParameter[] para = null,
            string conn = "SqlConnectionString") where T : new()
        {
            //调用执行方法
            SqlDataReader dr = SqlHelper.ExecuteReader(conn, CommandType.Text, sql, para);

            List<T> modellist = new List<T>();
            while (dr.Read())
            {
                //定义泛型对象
                T obj = new T();
                foreach (PropertyInfo propertyInfo in propertyInfos)
                {
                    //过滤TimeStamp列
                    if (propertyInfo.GetType().ToString().IndexOf("System.Nullable`1[System.Byte][]") < 0)
                    {
                        propertyInfo.SetValue(obj, dr[propertyInfo.Name] == DBNull.Value ? null : dr[propertyInfo.Name]);
                    }
                }
                modellist.Add(obj);
            }
            dr.Close();
            return modellist;
        }
        #endregion
    }
}