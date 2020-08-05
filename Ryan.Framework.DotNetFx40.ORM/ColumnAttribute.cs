using System;

namespace Ryan.Framework.DotNetFx40.ORM
{
    [AttributeUsage(AttributeTargets.Field|AttributeTargets.Property, AllowMultiple =false,Inherited =false)]
    public class ColumnAttribute:Attribute
    {
        /// <summary>
        /// 列名称
        /// </summary>
        public string ColumnName = "";

        /// <summary>
        /// 列描述
        /// </summary>
        public string ColumnDesc = "";

        /// <summary>
        /// 数据库数据类型
        /// </summary>
        public string DataType = "";

        /// <summary>
        /// 默认值
        /// </summary>
        public string DefaultValue = "";

        /// <summary>
        /// 是否为主键
        /// </summary>
        public bool IsPrimaryKey = false;

        /// <summary>
        /// 是否为自增列
        /// </summary>
        public bool IsAutoIncrement = false;

        /// <summary>
        /// 是否为时间戳列
        /// </summary>
        public bool IsTimeStamp = false;
    }
}
