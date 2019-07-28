﻿using Aohua.K3.Models;
using Aohua.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;
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
            int TimeSpanColumnCount = GetTimeSpanColumns<T>() != "" ? GetTimeSpanColumns<T>().Split(';').Length : 0;

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
        /// 反射查询方法
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> GetModel<T>(string IDColumnName, string ID) where T : new()
        {
            //获取Type对象，反射操作基本都是用Type进行的
            type = typeof(T);
            string cols = GetNoTimeSpanColumns<T>().Replace(";", ",");
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
                    if(item.Name == "FModifyTime")
                    { }
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

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetNoTimeSpanColumns<T>() where T : new()
        {
            string ret = "";
            Type type = typeof(T);
            PropertyInfo[] info = type.GetProperties();
            foreach (PropertyInfo item in info)
            {
                object[] objAttrs = item.GetCustomAttributes(typeof(TimeSpanColumnAttribute), true);
                if (objAttrs.Length <= 0)
                {
                    ret += item.Name + ";";
                }
            }
            return ret.Substring(0, ret.Length - 1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        private static string GetTimeSpanColumns<T>() where T : new()
        {
            string ret = "";
            Type type = typeof(T);
            PropertyInfo[] info = type.GetProperties();
            foreach (PropertyInfo item in info)
            {
                object[] objAttrs = item.GetCustomAttributes(typeof(TimeSpanColumnAttribute), true);
                if (objAttrs.Length > 0)
                {
                    ret += item.Name + ";";
                }
            }
            return ret.Length > 0 ? ret.Substring(0, ret.Length - 1) : "";
        }
    }
}
