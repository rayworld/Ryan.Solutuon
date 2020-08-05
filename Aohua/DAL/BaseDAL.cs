using Aohua.K3.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;

namespace Aohua.DAL
{
    public sealed class BaseDAL
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";
        private static Type type;

        #region CRUD
        /// <summary>
        /// 反射添加方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model">实体</param>
        /// <param name="conn">数据库连接</param>
        /// <returns>插入成功的条数</returns>
        public static int Insert<T>(T model) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            type = typeof(T);
            sql = string.Format("INSERT INTO t_{0} ", type.Name);
            string column = "(";
            string val = "VALUES(";
            string link = "";
            int index = 0;
            //获取Type对象所有公共属性
            PropertyInfo[] propertyInfos  = type.GetProperties();
            //得到自增列个数
            //int TimeSpanColumnCount = GetAttributeList<T>()[0].Split(',').Length > 0 ? GetAttributeList<T>()[0].Split(',').Length : 0;
            string TimeSpanColumnList = GetAttributeList<T>(typeof(TimeSpanColumnAttribute))[0];
            int TimeSpanColumnCount = TimeSpanColumnList != "" ? TimeSpanColumnList.Split(',').Length : 0;

            SqlParameter[] p = new SqlParameter[propertyInfos.Count() - TimeSpanColumnCount];
            foreach (PropertyInfo pi in propertyInfos)
            {
                object[] objAttrs = pi.GetCustomAttributes(typeof(TimeSpanColumnAttribute), true);
                if (objAttrs.Length > 0)
                {
                    continue;
                }

                column += link + pi.Name;//定义需要添加的字段
                val += link + " @" + pi.Name;//定义字段变量
                //给字段变量赋值
                p[index++] = new SqlParameter("@" + pi.Name, pi.GetValue(model) ?? DBNull.Value);
                link = ",";
            }
            column += ")";
            val += ")";
            sql += column + val;
            
            //调用执行方法
            return SqlHelper.ExecuteNonQuery(conn,sql, p);
        }

        /// <summary>
        /// 反射修改方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="model"></param>
        /// <returns></returns>
        public static int Update<T>(T model, string id) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            type = typeof(T);
            sql = string.Format("UPDATE {0} SET ", type.Name);
            //获取Type对象所有公共属性
            PropertyInfo[] propertyInfos = type.GetProperties();
            string link = "";
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                object val = propertyInfo.GetValue(model);
                if (val != null)
                {
                    //更新修改字段的值
                    sql += link + propertyInfo.Name + "='" + val + "'";
                    link = ",";
                }
            }
            sql += string.Format(" WHERE ID='{0}'", id);
            //调用执行方法
            return SqlHelper.ExecuteNonQuery(conn,sql);
        }

        /// <summary>
        /// 反射删除方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static int Delete<T>(string id,string conn) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            type = typeof(T);
            sql = string.Format("DELETE FROM {0} WHERE ID='{1}'", type.Name, id);
            //调用执行方法
            return SqlHelper.ExecuteNonQuery(conn,sql);

        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="IDColumnName"></param>
        /// <param name="ID"></param>
        /// <returns></returns>
        public static List<T> GetModel<T>(string IDColumnName, string ID) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            type = typeof(T);
            string cols = GetAttributeList<T>(typeof(TimeSpanColumnAttribute))[1];
            string tableName = "t_"  + type.Name;
            sql = string.Format("SELECT {1} FROM {2} WHERE {0}=@{0}",IDColumnName,cols, tableName);
            SqlParameter[] sqlParameters = {new SqlParameter("@" + IDColumnName,ID)};
            //调用执行方法
            SqlDataReader sqlDataReader = SqlHelper.ExecuteReader(conn,sql, sqlParameters);
            //获取Type对象的所有公共属性
            PropertyInfo[] propertyInfos = type.GetProperties();
            List<T> modellist = new List<T>();
            //定义泛型对象
            T obj = default(T);
            while (sqlDataReader.Read())
            {
                obj = new T();
                foreach (PropertyInfo item in propertyInfos)
                {
                    if (GetAttributeList<T>(typeof(TimeSpanColumnAttribute))[0].IndexOf(item.Name) > -1)
                    {
                    }
                    else if(sqlDataReader[item.Name] == null || sqlDataReader[item.Name] == System.DBNull.Value)
                    {
                        item.SetValue(obj, null);
                    }
                    else
                    {
                        item.SetValue(obj, sqlDataReader[item.Name]);
                    }
                }
                modellist.Add(obj);
            }
            sqlDataReader.Close();
            return modellist;
        }
        #endregion

        #region 特殊列的处理

        /// <summary>
        /// 得到实体含有属性的列表
        /// </summary>
        /// <typeparam name="T">实体</typeparam>
        /// <param name="type">属性类型</param>
        /// <returns>[0]是含有属性的列表;[1]是不含有属性的列表</returns>
        private static string[] GetAttributeList<T>(Type attributeType) where T : new()
        {
            string[] ret = new string[2];
            Type type = typeof(T);
            PropertyInfo[] info = type.GetProperties();
            string AttributeList = "";
            string NonAttributeList = "";
            foreach (PropertyInfo item in info)
            {
                object[] objAttrs = item.GetCustomAttributes(attributeType, true);
                if (objAttrs.Length > 0)
                {
                    //要去掉最后一个“，”
                    AttributeList += item.Name + ",";
                }
                else
                {
                    //要去掉最后一个“，”
                    NonAttributeList += item.Name + ",";
                }
            }
            ret[0] = AttributeList.Length > 0 ? AttributeList.Substring(0, AttributeList.Length - 1) : "";
            ret[1] = NonAttributeList.Length > 0 ? NonAttributeList.Substring(0, NonAttributeList.Length - 1) : "";
            return ret;
        }

        #endregion

        #region 简化从数据库中取值 GetValueBySql

        /// <summary>
        /// 得到一个非空String型结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static string GetNotNullStringBySql(string sql)
        {
            object obj = GetObjectBySql(sql);
            if (obj != null && obj.ToString() != "")
            {
                return obj.ToString();
            }
            else
            {
                return "-1";
            }
        }

        /// <summary>
        /// 得到一个Int型结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static int GetIntBySql(string sql)
        {
            object obj = GetObjectBySql(sql);
            if (obj != null && obj.ToString()!= "")
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 得到一个Float型结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static float GetFloatBySql(string sql)
        {
            object obj = GetObjectBySql(sql);
            if (obj != null && obj.ToString() != "")
            {
                return float.Parse(obj.ToString());
            }
            else
            {
                return float.Parse("-1");
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>Object</returns>
        public static object GetObjectBySql(string sql)
        {
            object retVal = (Object)null;
            if (sql != "")
            {
                retVal = SqlHelper.ExecuteScalar(conn, sql);
            }
            else
            {
                retVal = (Object)null;
            }
            return retVal;
        }

        /// <summary>
        /// 得到一个DataTable型结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public static DataTable GetDataTableBySql(string sql)
        {
            return sql != "" ? SqlHelper.ExecuteDataTable(conn, sql) : (DataTable)null;

        }
        #endregion

        #region Sql2DataTable
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable Sql2DataTable(string con ,string sql)
        {
            return sql != "" ? SqlHelper.ExecuteDataTable(con, sql) : (DataTable)null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static DataTable Sql2DataTable(string sql)
        {
            return Sql2DataTable(conn, sql);
        }
        #endregion

        #region Sql2Object
        /// <summary>
        /// 
        /// </summary>
        /// <param name="con"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Sql2Object(string con,string sql)
        {
            object retVal = (Object)null;
            if (sql != "")
            {
                retVal = SqlHelper.ExecuteScalar(con, sql);
            }
            else
            {
                retVal = (Object)null;
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public static object Sql2Object(string sql)
        {
            return Sql2Object(conn, sql);
        }

        #endregion

        #region Sql2String
        public static string Sql2NotNullString(string con,string sql)
        {
            return Sql2Object(con, sql).ToString() != "" ? Sql2Object(con, sql).ToString() : "-1";
        }

        public static string Sql2NotNullString(string sql)
        {
            return Sql2Object(sql).ToString() != "" ? Sql2Object(sql).ToString() : "-1";
        }
        #endregion

        #region Sql2Int
        public static int Sql2Int(string con, string sql)
        {
            object obj = Sql2Object(con, sql);
            return obj != null ? int.Parse(obj.ToString()) : -1;
        }

        public static int Sql2Int(string sql)
        {
            object obj = Sql2Object(sql);
            return obj != null ? int.Parse(obj.ToString()) : -1;
        }
        #endregion

        #region Sql2Float
        public static float Sql2Float(string con, string sql)
        {
            return Sql2Object(con, sql).ToString() != "" ? float.Parse(Sql2Object(con, sql).ToString()) : float.Parse("-1");
        }

        public static float Sql2Float(string sql)
        {
            return Sql2Object(sql).ToString() != "" ? float.Parse(Sql2Object(sql).ToString()) : float.Parse("-1");
        }
        #endregion

    }
}