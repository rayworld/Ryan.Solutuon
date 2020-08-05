using System;
using System.Collections.Generic;
using System.Data;

namespace Ryan.Framework.DotNetFx40.ORM
{
    public static class ColumnType
    {
        /// <summary>
        /// System.Type数据类型转换成System.Data.SqlDbType类型
        /// </summary>
        /// <param name="t">System.Type数据类型</param>
        /// <returns></returns>
        public static SqlDbType Type2SqlDbType(Type type)
        {
            var typeMap = new Dictionary<Type, SqlDbType>
            {
                [typeof(string)] = SqlDbType.NVarChar,
                [typeof(char[])] = SqlDbType.NVarChar,
                [typeof(int)] = SqlDbType.Int,
                [typeof(Int32)] = SqlDbType.Int,
                [typeof(Int16)] = SqlDbType.SmallInt,
                [typeof(Int64)] = SqlDbType.BigInt,
                [typeof(Byte[])] = SqlDbType.VarBinary,
                [typeof(Boolean)] = SqlDbType.Bit,
                [typeof(DateTime)] = SqlDbType.DateTime2,
                [typeof(DateTimeOffset)] = SqlDbType.DateTimeOffset,
                [typeof(Decimal)] = SqlDbType.Decimal,
                [typeof(Double)] = SqlDbType.Float,
                [typeof(Decimal)] = SqlDbType.Money,
                [typeof(Byte)] = SqlDbType.TinyInt,
                [typeof(TimeSpan)] = SqlDbType.Time
            };

            return typeMap[(type)];
        }

        /// <summary>
        /// System.Data.SqlDbType数据类型转换成System.Type类型
        /// </summary>
        /// <param name="dbType">SqlDbType数据类型</param>
        /// <returns></returns>
        public static Type SqlDbType2Type(SqlDbType dbType)
        {
            Type type = typeof(DBNull);
            switch (dbType)
            {
                case SqlDbType.BigInt:
                    type = typeof(Int64);
                    break;
                case SqlDbType.Binary:
                    type = typeof(byte[]);
                    break;
                case SqlDbType.Bit:
                    type = typeof(Boolean);
                    break;
                case SqlDbType.Date:
                case SqlDbType.DateTime:
                case SqlDbType.Timestamp:
                case SqlDbType.SmallDateTime:
                case SqlDbType.Time:
                case SqlDbType.DateTime2:
                case SqlDbType.DateTimeOffset:
                    type = typeof(DateTime);
                    break;
                case SqlDbType.SmallMoney:
                case SqlDbType.Money:
                case SqlDbType.Decimal:
                    type = typeof(decimal);
                    break;
                case SqlDbType.Float:
                    type = typeof(double);
                    break;
                case SqlDbType.Image:
                    type = typeof(byte[]);
                    break;
                case SqlDbType.Int:
                    type = typeof(Int32);
                    break;

                case SqlDbType.Real:
                    type = typeof(Single);
                    break;
                case SqlDbType.SmallInt:
                    type = typeof(Int16);
                    break;
                case SqlDbType.TinyInt:
                    type = typeof(byte);
                    break;
                case SqlDbType.UniqueIdentifier:
                    type = typeof(Guid);
                    break;
                case SqlDbType.VarBinary:
                case SqlDbType.Structured:
                case SqlDbType.Xml:
                case SqlDbType.Udt:
                case SqlDbType.Variant:
                    type = typeof(object);
                    break;
                case SqlDbType.Char:
                case SqlDbType.NChar:
                case SqlDbType.NText:
                case SqlDbType.NVarChar:
                case SqlDbType.Text:
                case SqlDbType.VarChar:
                    type = typeof(string);
                    break;
                default:
                    type = typeof(string);
                    break;
            }
            return type;
        }

        /// <summary>
        /// sql server数据类型（如：varchar）转换为SqlDbType类型
        /// </summary>
        /// <param name="sqlDbTypeString">SqlServer数据类型文本</param>
        /// <returns></returns>
        public static SqlDbType DbType2SqlDbType(string sqlDbTypeString)
        {
            SqlDbType dbType = SqlDbType.Variant;//默认为Object

            switch (sqlDbTypeString.ToLower())
            {
                case "int":
                    dbType = SqlDbType.Int;
                    break;
                case "varchar":
                    dbType = SqlDbType.VarChar;
                    break;
                case "bit":
                    dbType = SqlDbType.Bit;
                    break;
                case "datetime":
                    dbType = SqlDbType.DateTime;
                    break;
                case "decimal":
                    dbType = SqlDbType.Decimal;
                    break;
                case "float":
                    dbType = SqlDbType.Float;
                    break;
                case "image":
                    dbType = SqlDbType.Image;
                    break;
                case "money":
                    dbType = SqlDbType.Money;
                    break;
                case "ntext":
                    dbType = SqlDbType.NText;
                    break;
                case "nvarchar":
                    dbType = SqlDbType.NVarChar;
                    break;
                case "smalldatetime":
                    dbType = SqlDbType.SmallDateTime;
                    break;
                case "smallint":
                    dbType = SqlDbType.SmallInt;
                    break;
                case "text":
                    dbType = SqlDbType.Text;
                    break;
                case "bigint":
                    dbType = SqlDbType.BigInt;
                    break;
                case "binary":
                    dbType = SqlDbType.Binary;
                    break;
                case "char":
                    dbType = SqlDbType.Char;
                    break;
                case "nchar":
                    dbType = SqlDbType.NChar;
                    break;
                case "numeric":
                    dbType = SqlDbType.Decimal;
                    break;
                case "real":
                    dbType = SqlDbType.Real;
                    break;
                case "smallmoney":
                    dbType = SqlDbType.SmallMoney;
                    break;
                case "sql_variant":
                    dbType = SqlDbType.Variant;
                    break;
                case "timestamp":
                    dbType = SqlDbType.Timestamp;
                    break;
                case "tinyint":
                    dbType = SqlDbType.TinyInt;
                    break;
                case "uniqueidentifier":
                    dbType = SqlDbType.UniqueIdentifier;
                    break;
                case "varbinary":
                    dbType = SqlDbType.VarBinary;
                    break;
                case "xml":
                    dbType = SqlDbType.Xml;
                    break;
            }
            return dbType;
        }
    }
}