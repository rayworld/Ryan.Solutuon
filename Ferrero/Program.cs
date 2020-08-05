using EAS2WISE.Model;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Collections.Generic;

namespace EAS2WISE
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //Application.EnableVisualStyles();
            //Application.SetCompatibleTextRenderingDefault(false);
            //Application.Run(new FormMain());
            string conn = SqlHelper.GetConnectionString("Ferrero.Dev.AIS20140715144316");
            int NewItemID = GetAndUpdateIdentity("t_Item",conn);
            bool IsSuccess_ICItemStandard = UpdateICItemStandard(NewItemID, conn);
            bool IsSuccess_ICItemQuality = UpdateICItemQuality(NewItemID, conn);
            bool IsSuccess_ICItemPlan = UpdateICItemPlan(NewItemID, conn);
            bool IsSuccess_ICItemMaterial = UpdateICItemMaterial(NewItemID, conn);
            bool IsSuccess_ICItemCustom = UpdateICItemCustom(NewItemID, conn);
            bool IsSuccess_ICItemCore = UpdateICItemCore(NewItemID, conn);
            bool IsSuccess_ICItemBase = UpdateICItemBase(NewItemID, conn);
            bool IsSuccess_BASE_ICItemEntrance = UpdateBASE_ICItemEntrance(NewItemID, conn);
        }
        #region function

        #region Identity
        /// <summary>
        /// 更新Identity
        /// </summary>
        /// <param name="ObjectName"></param>
        /// <param name="Connectionstring"></param>
        /// <returns></returns>
        private static int GetAndUpdateIdentity(string ObjectName,string Connectionstring)
        {
            int retVal = 0;
            //查Identify表，得到最大ID的值
            List<TIdentity> identities = new List<TIdentity>();
            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                {"FName",ObjectName }
            };
            identities = BaseDAL.GetModel<TIdentity>(dicWhere, Connectionstring);
            if (identities.Count > 0)
            {
                TIdentity tIdentity = identities[0];
                retVal = tIdentity.FNext;
                Console.WriteLine(retVal);
                //更新ID
                tIdentity.FNext = tIdentity.FNext + tIdentity.FStep;

                Dictionary<string, object> updateData = new Dictionary<string, object>()
                {
                    {"FNext",tIdentity.FNext }
                };

                Dictionary<string, object> WhereOptions = new Dictionary<string, object>()
                {
                    {"FName","t_Item" }
                };
                int i = BaseDAL.Update<TIdentity>(updateData, WhereOptions, Connectionstring);
                Console.WriteLine(i);
                if (i <= 0)
                {
                    retVal = -1;
                }
            }
            else
            {
                retVal = -1;
            }
            return retVal;
        }
        #endregion

        #region ICItemStandard
        /// <summary>
        /// ICItemStandard
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemStandard(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemStandard> iCItemStandards  = BaseDAL.GetModel<ICItemStandard>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if(iCItemStandards.Count > 0)
            {
                ICItemStandard iCItemStandard = iCItemStandards[0];
                iCItemStandard.FItemID += 1;
                List<ICItemStandard> List4Insert = new List<ICItemStandard>
                {
                    { iCItemStandard }
                };
                int i = BaseDAL.Insert<ICItemStandard>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #region ICItemQuality
        /// <summary>
        /// ICItemQuality
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemQuality(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemQuality> itemQualities = BaseDAL.GetModel<ICItemQuality>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (itemQualities.Count > 0)
            {
                ICItemQuality iCItemQuality = itemQualities[0];
                iCItemQuality.FItemID += 1;
                List<ICItemQuality> List4Insert = new List<ICItemQuality>()
                {
                    { iCItemQuality }
                };
                int i = BaseDAL.Insert<ICItemQuality>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #region ICItemPlan
        /// <summary>
        /// ICItemPlan
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemPlan(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemPlan> iCItemPlans = BaseDAL.GetModel<ICItemPlan>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (iCItemPlans.Count > 0)
            {
                ICItemPlan iCItemPlan = iCItemPlans[0];
                iCItemPlan.FItemID += 1;
                List<ICItemPlan> List4Insert = new List<ICItemPlan>()
                {
                    { iCItemPlan }
                };
                int i = BaseDAL.Insert<ICItemPlan>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #region ICItemMaterial
        /// <summary>
        /// ICItemMaterial
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemMaterial(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemMaterial> iCItemMaterials = BaseDAL.GetModel<ICItemMaterial>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (iCItemMaterials.Count > 0)
            {
                ICItemMaterial iCItemMaterial = iCItemMaterials[0];
                iCItemMaterial.FItemID += 1;
                List<ICItemMaterial> List4Insert = new List<ICItemMaterial>()
                {
                    { iCItemMaterial }
                };
                int i = BaseDAL.Insert<ICItemMaterial>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }

        #endregion

        #region ICItemCustom
        /// <summary>
        /// ICItemCustom
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemCustom(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemCustom> iCItemCustoms = BaseDAL.GetModel<ICItemCustom>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (iCItemCustoms.Count > 0)
            {
                ICItemCustom iCItemCustom = iCItemCustoms[0];
                iCItemCustom.FItemID += 1;
                List<ICItemCustom> List4Insert = new List<ICItemCustom>()
                {
                    { iCItemCustom }
                };
                int i = BaseDAL.Insert<ICItemCustom>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #region ICItemCore
        /// <summary>
        /// ICItemCustom
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemCore(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemCore> iCItemCores = BaseDAL.GetModel<ICItemCore>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (iCItemCores.Count > 0)
            {
                ICItemCore iCItemCore = iCItemCores[0];
                iCItemCore.FItemID += 1;
                iCItemCore.FName = "蓝罐";
                iCItemCore.FNumber = "16.05.001";
                iCItemCore.FShortNumber = "001";
                List<ICItemCore> List4Insert = new List<ICItemCore>()
                {
                    { iCItemCore }
                };
                int i = BaseDAL.Insert<ICItemCore>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }

        #endregion

        #region ICItemBase
        /// <summary>
        /// ICItemBase
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateICItemBase(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<ICItemBase> iCItemBases = BaseDAL.GetModel<ICItemBase>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (iCItemBases.Count > 0)
            {
                ICItemBase iCItemBase = iCItemBases[0];
                iCItemBase.FItemID += 1;
                iCItemBase.FFullName = "蓝罐_蓝罐_蓝罐";

                List<ICItemBase> List4Insert = new List<ICItemBase>()
                {
                    { iCItemBase }
                };
                int i = BaseDAL.Insert<ICItemBase>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #region BASE_ICItemEntrance
        /// <summary>
        /// BASE_ICItemEntrance
        /// </summary>
        /// <param name="NewItemID"></param>
        /// <param name="ConnectionString"></param>
        /// <returns></returns>
        private static bool UpdateBASE_ICItemEntrance(int NewItemID, string ConnectionString)
        {
            bool retVal = false;

            Dictionary<string, object> dicWhere = new Dictionary<string, object>()
            {
                { "fitemid",NewItemID }
            };
            List<BASE_ICItemEntrance> bASE_ICItemEntrances = BaseDAL.GetModel<BASE_ICItemEntrance>(dicWhere, ConnectionString);
            //Console.WriteLine(list.Count);
            if (bASE_ICItemEntrances.Count > 0)
            {
                BASE_ICItemEntrance bASE_ICItemEntrance = bASE_ICItemEntrances[0];
                bASE_ICItemEntrance.FItemID += 1;

                List<BASE_ICItemEntrance> List4Insert = new List<BASE_ICItemEntrance>()
                {
                    { bASE_ICItemEntrance }
                };
                int i = BaseDAL.Insert<BASE_ICItemEntrance>(List4Insert, ConnectionString);
                if (i > 0)
                {
                    retVal = true;
                    Console.WriteLine(i);
                }
            }
            return retVal;
        }
        #endregion

        #endregion
    }
}
