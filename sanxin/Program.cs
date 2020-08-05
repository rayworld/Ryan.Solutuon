using Ryan.Framework.DotNetFx40.DBUtility;
using SanXin.KIS.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace SanXin
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            int total = 20;
            for(int i = 0;i<=total;i++)
            {
                int s = i * 200 / total;
                Console.WriteLine(new string('|', s));
            }
        }
        static void Main1()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new Form1());
            //var TableName = typeof(Voucher).GetCustomAttributeValue<TableAttribute>(x => x.TableName);
            //Console.WriteLine(TableName);
            //var columnName = "";
            //Type t = typeof(Voucher);
            //PropertyInfo[] propertyInfos = t.GetProperties();
            //foreach (PropertyInfo pi in propertyInfos)
            //{
            //    columnName += typeof(Voucher).GetCustomAttributeValue<ColumnAttribute>(x => x.ColumnDesc + x.ColumnDesc + x.IsPrimaryKey, pi.Name) + ", ";
            //}
            //Console.WriteLine(columnName);
            //string ColumnList = string.Join(",", propertyInfos.Select(p => $"[{p.Name}]").ToArray());
            //Console.WriteLine(ColumnList);

            //得到表名
            //string tableName =CustomAttributeHelper.GetTableName<Voucher>();
            //Console.WriteLine(tableName);

            //非自增列
            //string columnsList = CustomAttributeHelper.GetIdentityList<Voucher>(true);
            //Console.WriteLine(columnsList);

            //特定属性
            //Attribute[] attributes = new Attribute[] {
            //    new TimeSpanAttribute(),
            //    new PrimaryKeyAttribute(),
            //    new AutoIncrementAttribute()
            //};

            //string columnsList = CustomAttributeHelper.GetAttributeList<Voucher>(attributes, false);
            //Console.WriteLine(columnsList);
            //List<Voucher> vouchers = new List<Voucher>()
            //{
            //    new Voucher(){
            //    FVoucherID = 1000,
            //    FApproveID = 0,
            //    FBrNo = "",
            //    FCashierID = 0,
            //    FChecked = false,
            //    FCheckerID = 0,
            //    FCreditTotal = 0,
            //    FDate = DateTime.Now,
            //    FDebitTotal = 0,
            //    FEntryCount = 1,
            //    FExplanation = "sdfa",
            //    FFootNote = "",
            //    FFrameWorkID = 0,
            //    FGroupID = 0,
            //    FHandler = "",
            //    FInternalInd = "",
            //    FNumber = 10000,
            //    FObjectName = "",
            //    FOwnerGroupID = 0,
            //    FParameter = "",
            //    FPeriod = 1,
            //    FPosted = false,
            //    FPosterID = 0,
            //    FPreparerID = 0,
            //    FReference = "",
            //    FSerialNum = 0,
            //    FTranType = 1,
            //    FYear = 2020
            //    }
            //};
            string conn = SqlHelper.GetConnectionString("Aohua.Test.AIS20110212144120");
            //int ret = BaseDAL.Insert<Voucher>(conn, vouchers);
            //Dictionary<string, object> WhereOptions = new Dictionary<string, object>
            //{
            //    { "FVoucherID", 1000 }
            //};

            //int ret = BaseDAL.Delete<Voucher>(WhereOptions, conn);
            //Dictionary<string, object> WhereOptions = new Dictionary<string, object>
            //{
            //    { "FVoucherID", 45313 }
            //};
            //List<Voucher> list = BaseDAL.GetModel<Voucher>(conn, WhereOptions);

            //Console.WriteLine(list.Count + list[0].FVoucherID.ToString());

            Console.WriteLine(GetModelWithWhereHelper(conn).Count);
        }

        private static List<Voucher> GetModelWithWhereHelper(string conn)
        {
            List<WhereHelper> list = new List<WhereHelper>()
            {
                new WhereHelper(WhereHelper.LOpers.L,"FVoucherID","Int",WhereHelper.CompareOper.等于 ,45313,WhereHelper.ROpers.None,WhereHelper.LogicOper.Or,"FVoucherID"),
                new WhereHelper(WhereHelper.LOpers.None,"FVoucherID","Int",WhereHelper.CompareOper.等于 ,45314,WhereHelper.ROpers.None,WhereHelper.LogicOper.Or,"FVoucherID1"),
                new WhereHelper(WhereHelper.LOpers.None,"FVoucherID","Int",WhereHelper.CompareOper.等于 ,45315,WhereHelper.ROpers.R,WhereHelper.LogicOper.And,"FVoucherID2"),
                new WhereHelper("FDate", "date",WhereHelper.CompareOper.不等于 , "2020-06-13","FDate")
            };
            //Console.WriteLine(new WhereHelper().ToSqlPara(list));
            //SqlParameter[] sqlParameters= new WhereHelper().GetSqlParameters(list);
            //Console.WriteLine(sqlParameters.ToString() + sqlParameters.GetValue(1).ToString());
            List<Voucher> vouchers = BaseDAL.GetModel<Voucher>(
                new WhereHelper().ToSqlPara(list),
                new WhereHelper().GetSqlParameters(list),
                conn);

            //List<Voucher> vouchers = BaseDAL.GetModel<Voucher>(conn,
            //    new WhereHelper().ToSqlText(list),
            //    null);
            return vouchers;
            //Console.WriteLine(vouchers.Count);
           

        }
    }
}
