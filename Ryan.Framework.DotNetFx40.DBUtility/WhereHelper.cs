using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace Ryan.Framework.DotNetFx40.DBUtility
{
    public class WhereHelper
    {
        #region 常量
        private static readonly string[] Logics = new string[] { "", "AND", "OR" };
        private static readonly string[] Opers = new string[] { ">", "<", "<=", ">=", "=", "<>", "like", "not like", "in", "not in" };
        private static readonly string[] Ls = new string[] { "", "(", "((", "(((", "((((" };
        private static readonly string[] Rs = new string[] { "", ")", "))", ")))", "))))" };
        #endregion

        #region 属性
        /// <summary>
        /// 比较符
        /// </summary>
        public string Oper { get; set; }

        /// <summary>
        /// 列名
        /// </summary>
        public  string ColumnName { get; set; }

        /// <summary>
        /// 参数名
        /// </summary>
        public static string TemplateName { get; set; }

        /// <summary>
        /// 列数据类型
        /// </summary>
        public  string DataType { get ; set; }

        /// <summary>
        /// 比较值
        /// </summary>
        public  object Val { get; set; }

        /// <summary>
        /// 连接逻辑
        /// </summary>
        public string Logic { get; set; }

        /// <summary>
        /// 左括号
        /// </summary>
        public string L { get; set; }
        
        /// <summary>
        /// 右括号
        /// </summary>
        public string R { get; set; }

        /// <summary>
        /// Sql参数名称
        /// </summary>
        public string ParaName { get; set; }
        #endregion

        #region 构造函数
        public  WhereHelper() { }

        /// <summary>
        /// 不带参数
        /// </summary>
        /// <param name="ls">左括号</param>
        /// <param name="columnName">列名</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="compareOper">比较符</param>
        /// <param name="val">值</param>
        /// <param name="rs">右括号</param>
        /// <param name="logicOper">连接符</param>
        public WhereHelper(LOpers ls, string columnName, string dataType, CompareOper compareOper, object val, ROpers rs, LogicOper logicOper = LogicOper.None)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.Val = val;
            this.Logic = Logics[(int)logicOper];
            this.L = Ls[(int)ls];
            this.R = Rs[(int)rs];
        }


        /// <summary>
        /// 不带参数、不带括号的重载
        /// /// </summary>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        /// <param name="compareOper"></param>
        /// <param name="val"></param>
        /// <param name="logicOper"></param>
        public WhereHelper(string columnName, string dataType, CompareOper compareOper, object val, LogicOper logicOper = LogicOper.None)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.Val = val;
            this.Logic = Logics[(int)logicOper];
            this.L = Ls[0];
            this.R = Rs[0];
        }

        /// <summary>
        /// 不带参数、括号、链接符的重载
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        /// <param name="compareOper"></param>
        /// <param name="val"></param>
        public WhereHelper(string columnName, string dataType, CompareOper compareOper, object val)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.Val = val;
            this.Logic = Logics[0];
            this.L = Ls[0];
            this.R = Rs[0];
        }

        /// <summary>
        /// 带参数
        /// </summary>
        /// <param name="ls">左括号</param>
        /// <param name="columnName">列名</param>
        /// <param name="dataType">数据类型</param>
        /// <param name="compareOper">比较符</param>
        /// <param name="val">值</param>
        /// <param name="paraName">参数名</param>
        /// <param name="rs">右括号</param>
        /// <param name="logicOper">连接符</param>
        public WhereHelper(LOpers ls, string columnName, string dataType, CompareOper compareOper, object val,  ROpers rs, LogicOper logicOper = LogicOper.None, string paraName = "")
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.ParaName = paraName;
            this.Logic = Logics[(int)logicOper];
            this.L = Ls[(int)ls];
            this.R = Rs[(int)rs];
            this.Val = val;
        }

        /// <summary>
        /// 带参数、不带括号重载
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        /// <param name="compareOper"></param>
        /// <param name="val"></param>
        /// <param name="paraName"></param>
        /// <param name="logicOper"></param>
        public WhereHelper(string columnName, string dataType, CompareOper compareOper, object val, string paraName, LogicOper logicOper = LogicOper.None)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.ParaName = paraName;
            this.Logic = Logics[(int)logicOper];
            this.L = Ls[0];
            this.R = Rs[0];
            this.Val = val;
        }

        /// <summary>
        /// 带参数、不带括号、连接符重载
        /// </summary>
        /// <param name="columnName"></param>
        /// <param name="dataType"></param>
        /// <param name="compareOper"></param>
        /// <param name="val"></param>
        /// <param name="paraName"></param>
        public WhereHelper(string columnName, string dataType, CompareOper compareOper, object val, string paraName)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.Oper = Opers[(int)compareOper];
            this.ParaName = paraName;
            this.Logic = Logics[0];
            this.L = Ls[0];
            this.R = Rs[0];
            this.Val = val;
        }
        #endregion

        #region 枚举
        public enum LogicOper : int
        {
            None = 0,
            And = 1,
            Or = 2,
        }

        public enum LOpers : int
        {
            None = 0,
            L = 1,
            LL = 2,
            LLL = 3,
            LLLL = 4,
        }

        public enum ROpers : int
        {
            None = 0,
            R = 1,
            RR= 2,
            RRR = 3,
            RRRR = 4,
        }

        public enum CompareOper : int
        {
            大于 = 0,
            小于 = 1,
            不大于 = 2,
            不小于 = 3,
            等于 = 4,
            不等于 = 5,
            包含 = 6,
            不包含 = 7,
            包括 = 8,
            不包括 = 9,
            在之间 = 10,
        }
        #endregion

        /// <summary>
        /// 生成条件语句文本
        /// </summary>
        /// <param name="whereHelpers">条件列表</param>
        /// <returns>条件语句文本</returns>
        public string  ToSqlText(List<WhereHelper> whereHelpers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("WHERE ");
            if(whereHelpers.Count >0 )
            {
                foreach(WhereHelper whereHelper in whereHelpers)
                {
                    if (whereHelper.ColumnName != null && whereHelper.Val != null && whereHelper.Logic != null)
                    {
                        sb.Append(whereHelper.L).Append(" ");
                        sb.Append(whereHelper.ColumnName).Append(" ");
                        sb.Append(whereHelper.Oper).Append(" ");
                        if (whereHelper.DataType.ToLower() == "int"
                        || whereHelper.DataType.ToLower() == "float"
                        || whereHelper.DataType.ToLower() == "double"
                        || whereHelper.DataType.ToLower() == "bool"
                        || whereHelper.DataType.ToLower() == "number"
                        )
                        {
                            sb.Append(whereHelper.Val);
                        }
                        else if (whereHelper.DataType.ToLower() == "string")
                        {
                            string tmp = (string)Val;
                            sb.Append("'" + tmp.Replace("'", "''") + "'");
                        }
                        else if (whereHelper.DataType.ToLower() == "date")
                        {
                            DateTime dateTime = DateTime.Parse(whereHelper.Val.ToString());
                            sb.Append("'" + dateTime.ToString("yyyy-MM-dd") + "'");
                        }
                        else if (whereHelper.DataType.ToLower() == "datetime")
                        {
                            DateTime dateTime = DateTime.Parse(whereHelper.Val.ToString());
                            sb.Append("'" + dateTime.ToString("yyyy-MM-dd hh:mm:ss.fff") + "'");
                        }
                        else
                        {
                            string tmp = whereHelper.Val.ToString();
                            sb.Append("'" + tmp.Replace("'", "''") + "'");
                        }
                        sb.Append(" ");
                        sb.Append(whereHelper.R).Append(" ");
                        sb.Append(whereHelper.Logic).Append(" ");
                    }
                }
            }
            return sb.ToString();
        }

        /// <summary>
        /// 生成带Sql参数条件语句
        /// </summary>
        /// <param name="whereHelpers">条件列表</param>
        /// <returns>Sql语句条件</returns>
        public string ToSqlPara(List<WhereHelper> whereHelpers)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("WHERE ");
            if (whereHelpers.Count > 0)
            {
                foreach (WhereHelper whereHelper in whereHelpers)
                {
                    if (whereHelper.ColumnName != null && whereHelper.Val != null && whereHelper.Logic != null)
                    {
                        sb.Append(whereHelper.L).Append(" ")
                        .Append(whereHelper.ColumnName).Append(" ")
                        .Append(whereHelper.Oper).Append(" ")
                        .Append($"@" + whereHelper.ParaName).Append(" ")
                        .Append(whereHelper.R).Append(" ")
                        .Append(whereHelper.Logic).Append(" ");
                    }
                }
            }
            Console.WriteLine(sb.ToString());
            return sb.ToString();
        }

        /// <summary>
        /// 生成Sql参数列表
        /// </summary>
        /// <param name="whereHelpers">条件列表</param>
        /// <returns>Sql参数列表</returns>
        public SqlParameter[] GetSqlParameters(List<WhereHelper> whereHelpers)
        {
            List<SqlParameter>sqlParameters = new List<SqlParameter>();
            if (whereHelpers.Count > 0)
            {
                foreach (WhereHelper whereHelper in whereHelpers)
                {
                    if (whereHelper.ColumnName != null && whereHelper.Val != null)
                    {
                        sqlParameters.Add(new SqlParameter("@" + whereHelper.ParaName, whereHelper.Val ?? DBNull.Value));
                    }
                }
            }
            return sqlParameters.ToArray();
        }
    }
}