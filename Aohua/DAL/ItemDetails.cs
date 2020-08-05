using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Data;

namespace Aohua.DAL
{
    public partial class ItemDetails
    {
        private static readonly string conn = SqlHelper.GetConnectionString("FinSrc");
        private static string sql = "";

        /// <summary>
        /// 查横表得到DetailID
        /// </summary>
        /// <param name="OriginItemClassID"></param>
        /// <param name="OriginItemID"></param>
        /// <param name="NewItemClassID"></param>
        /// <param name="NewItemID"></param>
        /// <returns></returns>
        public static int GetDetailID(int OriginItemClassID , int OriginItemID, int NewItemClassID,int NewItemID)
        {
            sql = string.Format("select fDetailID from t_ItemDetail where f{2} = {3} and f{0}= {1}", OriginItemClassID, OriginItemID, NewItemClassID, NewItemID);
            object obj = SqlHelper.ExecuteScalar(conn,sql);
            if(obj != null && obj.ToString() != "")
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }            
        }

        /// <summary>
        /// 通过科目ID得到ItemClassID
        /// 注意：“2020”还是“2020年”
        /// </summary>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static int GetItemClassIDbyAccountID(int AccountID)
        {
            sql = string.Format("select distinct FItemClassID from t_ItemDetailV where FItemClassID in (select FItemClassID from t_itemclass where fname = '20' +(select FName from t_account where FAccountID = {0}))",AccountID);
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="DetailID"></param>
        /// <param name="AccountID"></param>
        /// <returns></returns>
        public static DataTable GetItemDetailByID(int DetailID,int AccountID)
        {
            sql = string.Format("select * from t_ItemDetailV where FdetailID ={0} and FItemClassID  Not in (select FItemClassID from t_itemclass where fname = '20' +(select FName from t_account where FAccountID = {1}))", DetailID, AccountID);
            DataTable dt = SqlHelper.ExecuteDataTable(conn, sql);
            return dt.Rows.Count > 0 ? dt : (DataTable)null;
        }

        /// <summary>
        /// Max ID + 1
        /// </summary>
        /// <returns></returns>
        public static int GetNewItemDetailID()
        {
            sql = string.Format("select Max(FDetailID) + 1 from t_ItemDetail");
            object obj = SqlHelper.ExecuteScalar(conn, sql);
            if (obj != null && obj.ToString() != "")
            {
                return int.Parse(obj.ToString());
            }
            else
            {
                return -1;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewDetailID"></param>
        /// <param name="OriginItemClassID"></param>
        /// <param name="OriginItemID"></param>
        /// <param name="NewItemClassID"></param>
        /// <param name="NewItemID"></param>
        /// <returns></returns>
        internal static int InsertItemDetail(int NewDetailID, int OriginItemClassID, int OriginItemID, int NewItemClassID, int NewItemID)
        {
            int retVal = 0;
            sql = string.Format("INSERT INTO [t_ItemDetail]([FDetailID],[FDetailCount],[F{1}],[F{3}])VALUES({0},2,{2},{4})", NewDetailID, OriginItemClassID, OriginItemID, NewItemClassID, NewItemID);
            retVal = SqlHelper.ExecuteNonQuery(conn, sql);
            return retVal > 0 ? retVal : -1;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="NewDetailID"></param>
        /// <param name="OriginItemClassID"></param>
        /// <param name="OriginItemID"></param>
        /// <param name="NewItemClassID"></param>
        /// <param name="NewItemID"></param>
        /// <returns></returns>
        internal static int InsertItemDetailV(int NewDetailID ,int OriginItemClassID, int OriginItemID, int NewItemClassID, int NewItemID)
        {
            int retVal = 0;
            sql = string.Format("INSERT INTO [t_ItemDetailV]([FDetailID],[FItemClassID],[FItemID]) VALUES({0},{1},{2});INSERT INTO [t_ItemDetailV]([FDetailID],[FItemClassID],[FItemID]) VALUES({0},{3},{4})", NewDetailID, OriginItemClassID, OriginItemID, NewItemClassID, NewItemID);
            retVal = SqlHelper.ExecuteNonQuery(conn, sql);
            return retVal > 0 ? retVal : -1;
        }

        #region 2.0
        public static int GetDetailIDByItemClassIDItemID(int ItemClassID, int ItemID)
        {
            sql = string.Format("select FDetailID from t_itemdetail where F{0} = {1} and FDetailCount = 1 ",ItemClassID,ItemID);
            return BaseDAL.Sql2Int(conn, sql);
        }


        /// <returns></returns>
        internal static int InsertItemDetailV2(int NewDetailID, int ItemClassID, int ItemID)
        {
            int retVal = 0;
            sql = string.Format("INSERT INTO [t_ItemDetail]([FDetailID],[FDetailCount],[F{1}])VALUES({0},1,{2})", NewDetailID, ItemClassID, ItemID);
            retVal = SqlHelper.ExecuteNonQuery(conn, sql);
            return retVal > 0 ? retVal : -1;
        }
        #endregion
    }
}