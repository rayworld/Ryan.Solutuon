using Aohua.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aohua.DAL
{
    public partial class Organizations
    {
        private static string connK3Desc = SqlHelper.GetConnectionString("K3Desc");

        /// <summary>
        ///  
        /// </summary>
        /// <param name="dr"></param>
        /// <returns></returns>
        public static Organization GetModel(DataRow dr)
        {
            Organization t_Organization = new Organization();
            if (dr["FItemID"].ToString() != "")
            {
                t_Organization.FItemID = int.Parse(dr["FItemID"].ToString());
            }
            t_Organization.FHomePage = dr["FHomePage"].ToString();
            if (dr["FPreAPAcctID"].ToString() != "")
            {
                t_Organization.FPreAPAcctID = int.Parse(dr["FPreAPAcctID"].ToString());
            }
            t_Organization.FHelpCode = dr["FHelpCode"].ToString();
            t_Organization.FNameEN = dr["FNameEN"].ToString();
            t_Organization.FAddrEn = dr["FAddrEn"].ToString();
            t_Organization.FCIQCode = dr["FCIQCode"].ToString();
            if (dr["FRegion"].ToString() != "")
            {
                t_Organization.FRegion = int.Parse(dr["FRegion"].ToString());
            }
            t_Organization.FMobilePhone = dr["FMobilePhone"].ToString();
            if (dr["FPayCondition"].ToString() != "")
            {
                t_Organization.FPayCondition = int.Parse(dr["FPayCondition"].ToString());
            }
            if (dr["FManageType"].ToString() != "")
            {
                t_Organization.FManageType = int.Parse(dr["FManageType"].ToString());
            }
            if (dr["FClass"].ToString() != "")
            {
                t_Organization.FClass = int.Parse(dr["FClass"].ToString());
            }
            t_Organization.FCreditLimit = dr["FCreditLimit"].ToString();
            t_Organization.FValue = dr["FValue"].ToString();
            if (dr["FRegUserID"].ToString() != "")
            {
                t_Organization.FRegUserID = int.Parse(dr["FRegUserID"].ToString());
            }
            if (dr["FLastModifyDate"].ToString() != "")
            {
                t_Organization.FLastModifyDate = DateTime.Parse(dr["FLastModifyDate"].ToString());
            }
            if (dr["FRecentContactDate"].ToString() != "")
            {
                t_Organization.FRecentContactDate = DateTime.Parse(dr["FRecentContactDate"].ToString());
            }
            if (dr["FRegDate"].ToString() != "")
            {
                t_Organization.FRegDate = DateTime.Parse(dr["FRegDate"].ToString());
            }
            if (dr["FFlat"].ToString() != "")
            {
                t_Organization.FFlat = int.Parse(dr["FFlat"].ToString());
            }
            if (dr["FClassTypeID"].ToString() != "")
            {
                t_Organization.FClassTypeID = int.Parse(dr["FClassTypeID"].ToString());
            }
            if (dr["FCoSupplierID"].ToString() != "")
            {
                t_Organization.FCoSupplierID = int.Parse(dr["FCoSupplierID"].ToString());
            }
            if (dr["FShareStatus"].ToString() != "")
            {
                t_Organization.FShareStatus = int.Parse(dr["FShareStatus"].ToString());
            }
            //if (dr["F_102"].ToString() != "")
            //{
            //    t_Organization.F_102 = int.Parse(dr["F_102"].ToString());
            //}
            t_Organization.FTaxID = dr["FTaxID"].ToString();
            t_Organization.FBank = dr["FBank"].ToString();
            t_Organization.FAccount = dr["FAccount"].ToString();
            t_Organization.FBankNumber = dr["FBankNumber"].ToString();
            t_Organization.FBrNo = dr["FBrNo"].ToString();
            if (dr["FBoundAttr"].ToString() != "")
            {
                t_Organization.FBoundAttr = int.Parse(dr["FBoundAttr"].ToString());
            }
            if (dr["FErpClsID"].ToString() != "")
            {
                t_Organization.FErpClsID = int.Parse(dr["FErpClsID"].ToString());
            }
            t_Organization.FShortName = dr["FShortName"].ToString();
            t_Organization.FAddress = dr["FAddress"].ToString();
            if (dr["FPriorityID"].ToString() != "")
            {
                t_Organization.FPriorityID = int.Parse(dr["FPriorityID"].ToString());
            }
            if (dr["FPOGroupID"].ToString() != "")
            {
                t_Organization.FPOGroupID = int.Parse(dr["FPOGroupID"].ToString());
            }
            if (dr["FStatus"].ToString() != "")
            {
                t_Organization.FStatus = int.Parse(dr["FStatus"].ToString());
            }
            if (dr["FLanguageID"].ToString() != "")
            {
                t_Organization.FLanguageID = int.Parse(dr["FLanguageID"].ToString());
            }
            if (dr["FRegionID"].ToString() != "")
            {
                t_Organization.FRegionID = int.Parse(dr["FRegionID"].ToString());
            }
            if (dr["FTrade"].ToString() != "")
            {
                t_Organization.FTrade = int.Parse(dr["FTrade"].ToString());
            }
            if (dr["FMinPOValue"].ToString() != "")
            {
                t_Organization.FMinPOValue = decimal.Parse(dr["FMinPOValue"].ToString());
            }
            if (dr["FMaxDebitDate"].ToString() != "")
            {
                t_Organization.FMaxDebitDate = decimal.Parse(dr["FMaxDebitDate"].ToString());
            }
            t_Organization.FLegalPerson = dr["FLegalPerson"].ToString();
            t_Organization.FContact = dr["FContact"].ToString();
            t_Organization.FCity = dr["FCity"].ToString();
            t_Organization.FContactAcct = dr["FContactAcct"].ToString();
            t_Organization.FPhoneAcct = dr["FPhoneAcct"].ToString();
            t_Organization.FFaxAcct = dr["FFaxAcct"].ToString();
            t_Organization.FZipAcct = dr["FZipAcct"].ToString();
            t_Organization.FEmailAcct = dr["FEmailAcct"].ToString();
            t_Organization.FAddrAcct = dr["FAddrAcct"].ToString();
            if (dr["FTax"].ToString() != "")
            {
                t_Organization.FTax = decimal.Parse(dr["FTax"].ToString());
            }
            if (dr["FCyID"].ToString() != "")
            {
                t_Organization.FCyID = int.Parse(dr["FCyID"].ToString());
            }
            if (dr["FSetID"].ToString() != "")
            {
                t_Organization.FSetID = int.Parse(dr["FSetID"].ToString());
            }
            if (dr["FSetDLineID"].ToString() != "")
            {
                t_Organization.FSetDLineID = int.Parse(dr["FSetDLineID"].ToString());
            }
            t_Organization.FProvince = dr["FProvince"].ToString();
            t_Organization.FTaxNum = dr["FTaxNum"].ToString();
            if (dr["FPriceClsID"].ToString() != "")
            {
                t_Organization.FPriceClsID = int.Parse(dr["FPriceClsID"].ToString());
            }
            if (dr["FOperID"].ToString() != "")
            {
                t_Organization.FOperID = int.Parse(dr["FOperID"].ToString());
            }
            t_Organization.FCIQNumber = dr["FCIQNumber"].ToString();
            if (dr["FDeleted"].ToString() != "")
            {
                t_Organization.FDeleted = int.Parse(dr["FDeleted"].ToString());
            }
            if (dr["FSaleMode"].ToString() != "")
            {
                t_Organization.FSaleMode = int.Parse(dr["FSaleMode"].ToString());
            }
            t_Organization.FName = dr["FName"].ToString();
            t_Organization.FNumber = dr["FNumber"].ToString();
            if (dr["FParentID"].ToString() != "")
            {
                t_Organization.FParentID = int.Parse(dr["FParentID"].ToString());
            }
            t_Organization.FShortNumber = dr["FShortNumber"].ToString();
            t_Organization.FCountry = dr["FCountry"].ToString();
            if (dr["FARAccountID"].ToString() != "")
            {
                t_Organization.FARAccountID = int.Parse(dr["FARAccountID"].ToString());
            }
            if (dr["FAPAccountID"].ToString() != "")
            {
                t_Organization.FAPAccountID = int.Parse(dr["FAPAccountID"].ToString());
            }
            if (dr["FpreAcctID"].ToString() != "")
            {
                t_Organization.FpreAcctID = int.Parse(dr["FpreAcctID"].ToString());
            }
            if (dr["FlastTradeAmount"].ToString() != "")
            {
                t_Organization.FlastTradeAmount = decimal.Parse(dr["FlastTradeAmount"].ToString());
            }
            if (dr["FlastRPAmount"].ToString() != "")
            {
                t_Organization.FlastRPAmount = decimal.Parse(dr["FlastRPAmount"].ToString());
            }
            t_Organization.FfavorPolicy = dr["FfavorPolicy"].ToString();
            if (dr["Fdepartment"].ToString() != "")
            {
                t_Organization.Fdepartment = int.Parse(dr["Fdepartment"].ToString());
            }
            if (dr["Femployee"].ToString() != "")
            {
                t_Organization.Femployee = int.Parse(dr["Femployee"].ToString());
            }
            t_Organization.Fcorperate = dr["Fcorperate"].ToString();
            if (dr["FbeginTradeDate"].ToString() != "")
            {
                t_Organization.FbeginTradeDate = DateTime.Parse(dr["FbeginTradeDate"].ToString());
            }
            t_Organization.FPostalCode = dr["FPostalCode"].ToString();
            if (dr["FendTradeDate"].ToString() != "")
            {
                t_Organization.FendTradeDate = DateTime.Parse(dr["FendTradeDate"].ToString());
            }
            if (dr["FlastTradeDate"].ToString() != "")
            {
                t_Organization.FlastTradeDate = DateTime.Parse(dr["FlastTradeDate"].ToString());
            }
            if (dr["FlastReceiveDate"].ToString() != "")
            {
                t_Organization.FlastReceiveDate = DateTime.Parse(dr["FlastReceiveDate"].ToString());
            }
            t_Organization.FcashDiscount = dr["FcashDiscount"].ToString();
            if (dr["FcurrencyID"].ToString() != "")
            {
                t_Organization.FcurrencyID = int.Parse(dr["FcurrencyID"].ToString());
            }
            if (dr["FmaxDealAmount"].ToString() != "")
            {
                t_Organization.FmaxDealAmount = decimal.Parse(dr["FmaxDealAmount"].ToString());
            }
            if (dr["FminForeReceiveRate"].ToString() != "")
            {
                t_Organization.FminForeReceiveRate = decimal.Parse(dr["FminForeReceiveRate"].ToString());
            }
            if (dr["FminReserverate"].ToString() != "")
            {
                t_Organization.FminReserverate = decimal.Parse(dr["FminReserverate"].ToString());
            }
            if (dr["FdebtLevel"].ToString() != "")
            {
                t_Organization.FdebtLevel = int.Parse(dr["FdebtLevel"].ToString());
            }
            if (dr["FCarryingAOS"].ToString() != "")
            {
                t_Organization.FCarryingAOS = int.Parse(dr["FCarryingAOS"].ToString());
            }
            t_Organization.FPhone = dr["FPhone"].ToString();
            if (dr["FIsCreditMgr"].ToString() != "")
            {
                if ((dr["FIsCreditMgr"].ToString() == "1") || (dr["FIsCreditMgr"].ToString().ToLower() == "true"))
                {
                    t_Organization.FIsCreditMgr = true;
                }
                else
                {
                    t_Organization.FIsCreditMgr = false;
                }
            }
            if (dr["FCreditPeriod"].ToString() != "")
            {
                t_Organization.FCreditPeriod = int.Parse(dr["FCreditPeriod"].ToString());
            }
            if (dr["FCreditLevel"].ToString() != "")
            {
                t_Organization.FCreditLevel = int.Parse(dr["FCreditLevel"].ToString());
            }
            if (dr["FPayTaxAcctID"].ToString() != "")
            {
                t_Organization.FPayTaxAcctID = int.Parse(dr["FPayTaxAcctID"].ToString());
            }
            if (dr["FValueAddRate"].ToString() != "")
            {
                t_Organization.FValueAddRate = decimal.Parse(dr["FValueAddRate"].ToString());
            }
            //if (dr["FModifyTime"].ToString() != "")
            //{
            //    string temp = dr["FModifyTime"].ToString();
            //    t_Organization.FModifyTime = DateTime.Parse(dr["FModifyTime"].ToString());
            //}
            if (dr["FTypeID"].ToString() != "")
            {
                t_Organization.FTypeID = int.Parse(dr["FTypeID"].ToString());
            }
            if (dr["FCreditDays"].ToString() != "")
            {
                t_Organization.FCreditDays = int.Parse(dr["FCreditDays"].ToString());
            }
            if (dr["FCreditAmount"].ToString() != "")
            {
                t_Organization.FCreditAmount = decimal.Parse(dr["FCreditAmount"].ToString());
            }
            if (dr["FStockIDAssign"].ToString() != "")
            {
                t_Organization.FStockIDAssign = int.Parse(dr["FStockIDAssign"].ToString());
            }
            t_Organization.FFax = dr["FFax"].ToString();
            if (dr["FStockIDInst"].ToString() != "")
            {
                t_Organization.FStockIDInst = int.Parse(dr["FStockIDInst"].ToString());
            }
            if (dr["FStockIDKeep"].ToString() != "")
            {
                t_Organization.FStockIDKeep = int.Parse(dr["FStockIDKeep"].ToString());
            }
            if (dr["FPaperPeriod"].ToString() != "")
            {
                t_Organization.FPaperPeriod = DateTime.Parse(dr["FPaperPeriod"].ToString());
            }
            if (dr["FAlarmPeriod"].ToString() != "")
            {
                t_Organization.FAlarmPeriod = int.Parse(dr["FAlarmPeriod"].ToString());
            }
            t_Organization.FLicence = dr["FLicence"].ToString();
            t_Organization.FPermit = dr["FPermit"].ToString();
            t_Organization.FCertify = dr["FCertify"].ToString();
            if (dr["FLicAndPermit"].ToString() != "")
            {
                if ((dr["FLicAndPermit"].ToString() == "1") || (dr["FLicAndPermit"].ToString().ToLower() == "true"))
                {
                    t_Organization.FLicAndPermit = true;
                }
                else
                {
                    t_Organization.FLicAndPermit = false;
                }
            }
            t_Organization.FGSortMem = dr["FGSortMem"].ToString();
            t_Organization.FGEng = dr["FGEng"].ToString();
            t_Organization.FEmail = dr["FEmail"].ToString();
            t_Organization.FGAbove = dr["FGAbove"].ToString();
            if (dr["FGProp"].ToString() != "")
            {
                t_Organization.FGProp = int.Parse(dr["FGProp"].ToString());
            }
            if (dr["FGManageMode"].ToString() != "")
            {
                t_Organization.FGManageMode = int.Parse(dr["FGManageMode"].ToString());
            }
            if (dr["FGCharterVal"].ToString() != "")
            {
                t_Organization.FGCharterVal = DateTime.Parse(dr["FGCharterVal"].ToString());
            }
            if (dr["FGPermissVal"].ToString() != "")
            {
                t_Organization.FGPermissVal = DateTime.Parse(dr["FGPermissVal"].ToString());
            }
            if (dr["FGCertifiVal"].ToString() != "")
            {
                t_Organization.FGCertifiVal = DateTime.Parse(dr["FGCertifiVal"].ToString());
            }
            if (dr["FGInitialApproveFlag"].ToString() != "")
            {
                if ((dr["FGInitialApproveFlag"].ToString() == "1") || (dr["FGInitialApproveFlag"].ToString().ToLower() == "true"))
                {
                    t_Organization.FGInitialApproveFlag = true;
                }
                else
                {
                    t_Organization.FGInitialApproveFlag = false;
                }
            }
            if (dr["FSaleID"].ToString() != "")
            {
                t_Organization.FSaleID = int.Parse(dr["FSaleID"].ToString());
            }
            if (dr["FOtherARAcctID"].ToString() != "")
            {
                t_Organization.FOtherARAcctID = int.Parse(dr["FOtherARAcctID"].ToString());
            }
            if (dr["FOtherAPAcctID"].ToString() != "")
            {
                t_Organization.FOtherAPAcctID = int.Parse(dr["FOtherAPAcctID"].ToString());
            }
            return t_Organization;
        }


        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Insert(Organization t_Organization)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_Organization(");
            strSql.Append("FItemID,FHomePage,FPreAPAcctID,FHelpCode,FNameEN,FAddrEn,FCIQCode,FRegion,FMobilePhone,FPayCondition,FManageType,FClass,FCreditLimit,FValue,FRegUserID,FLastModifyDate,FRecentContactDate,FRegDate,FFlat,FClassTypeID,FCoSupplierID,FShareStatus,FTaxID,FBank,FAccount,FBankNumber,FBrNo,FBoundAttr,FErpClsID,FShortName,FAddress,FPriorityID,FPOGroupID,FStatus,FLanguageID,FRegionID,FTrade,FMinPOValue,FMaxDebitDate,FLegalPerson,FContact,FCity,FContactAcct,FPhoneAcct,FFaxAcct,FZipAcct,FEmailAcct,FAddrAcct,FTax,FCyID,FSetID,FSetDLineID,FProvince,FTaxNum,FPriceClsID,FOperID,FCIQNumber,FDeleted,FSaleMode,FName,FNumber,FParentID,FShortNumber,FCountry,FARAccountID,FAPAccountID,FpreAcctID,FlastTradeAmount,FlastRPAmount,FfavorPolicy,Fdepartment,Femployee,Fcorperate,FbeginTradeDate,FPostalCode,FendTradeDate,FlastTradeDate,FlastReceiveDate,FcashDiscount,FcurrencyID,FmaxDealAmount,FminForeReceiveRate,FminReserverate,FdebtLevel,FCarryingAOS,FPhone,FIsCreditMgr,FCreditPeriod,FCreditLevel,FPayTaxAcctID,FValueAddRate,FTypeID,FCreditDays,FCreditAmount,FStockIDAssign,FFax,FStockIDInst,FStockIDKeep,FPaperPeriod,FAlarmPeriod,FLicence,FPermit,FCertify,FLicAndPermit,FGSortMem,FGEng,FEmail,FGAbove,FGProp,FGManageMode,FGCharterVal,FGPermissVal,FGCertifiVal,FGInitialApproveFlag,FSaleID,FOtherARAcctID,FOtherAPAcctID");
            strSql.Append(") values (");
            strSql.Append("@FItemID,@FHomePage,@FPreAPAcctID,@FHelpCode,@FNameEN,@FAddrEn,@FCIQCode,@FRegion,@FMobilePhone,@FPayCondition,@FManageType,@FClass,@FCreditLimit,@FValue,@FRegUserID,@FLastModifyDate,@FRecentContactDate,@FRegDate,@FFlat,@FClassTypeID,@FCoSupplierID,@FShareStatus,@FTaxID,@FBank,@FAccount,@FBankNumber,@FBrNo,@FBoundAttr,@FErpClsID,@FShortName,@FAddress,@FPriorityID,@FPOGroupID,@FStatus,@FLanguageID,@FRegionID,@FTrade,@FMinPOValue,@FMaxDebitDate,@FLegalPerson,@FContact,@FCity,@FContactAcct,@FPhoneAcct,@FFaxAcct,@FZipAcct,@FEmailAcct,@FAddrAcct,@FTax,@FCyID,@FSetID,@FSetDLineID,@FProvince,@FTaxNum,@FPriceClsID,@FOperID,@FCIQNumber,@FDeleted,@FSaleMode,@FName,@FNumber,@FParentID,@FShortNumber,@FCountry,@FARAccountID,@FAPAccountID,@FpreAcctID,@FlastTradeAmount,@FlastRPAmount,@FfavorPolicy,@Fdepartment,@Femployee,@Fcorperate,@FbeginTradeDate,@FPostalCode,@FendTradeDate,@FlastTradeDate,@FlastReceiveDate,@FcashDiscount,@FcurrencyID,@FmaxDealAmount,@FminForeReceiveRate,@FminReserverate,@FdebtLevel,@FCarryingAOS,@FPhone,@FIsCreditMgr,@FCreditPeriod,@FCreditLevel,@FPayTaxAcctID,@FValueAddRate,@FTypeID,@FCreditDays,@FCreditAmount,@FStockIDAssign,@FFax,@FStockIDInst,@FStockIDKeep,@FPaperPeriod,@FAlarmPeriod,@FLicence,@FPermit,@FCertify,@FLicAndPermit,@FGSortMem,@FGEng,@FEmail,@FGAbove,@FGProp,@FGManageMode,@FGCharterVal,@FGPermissVal,@FGCertifiVal,@FGInitialApproveFlag,@FSaleID,@FOtherARAcctID,@FOtherAPAcctID");
            strSql.Append(") ");

            SqlParameter[] parameters = {
                        new SqlParameter("@FItemID", SqlDbType.Int,4) ,
                        new SqlParameter("@FHomePage", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FPreAPAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FHelpCode", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FNameEN", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FAddrEn", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FCIQCode", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FRegion", SqlDbType.Int,4) ,
                        new SqlParameter("@FMobilePhone", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FPayCondition", SqlDbType.Int,4) ,
                        new SqlParameter("@FManageType", SqlDbType.Int,4) ,
                        new SqlParameter("@FClass", SqlDbType.Int,4) ,
                        new SqlParameter("@FCreditLimit", SqlDbType.VarChar,20) ,
                        new SqlParameter("@FValue", SqlDbType.NVarChar,255) ,
                        new SqlParameter("@FRegUserID", SqlDbType.Int,4) ,
                        new SqlParameter("@FLastModifyDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FRecentContactDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FRegDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FFlat", SqlDbType.Int,4) ,
                        new SqlParameter("@FClassTypeID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCoSupplierID", SqlDbType.Int,4) ,
                        new SqlParameter("@FShareStatus", SqlDbType.Int,4) ,
                        new SqlParameter("@FTaxID", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FBank", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FAccount", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FBankNumber", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FBrNo", SqlDbType.VarChar,10) ,
                        new SqlParameter("@FBoundAttr", SqlDbType.Int,4) ,
                        new SqlParameter("@FErpClsID", SqlDbType.Int,4) ,
                        new SqlParameter("@FShortName", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FAddress", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FPriorityID", SqlDbType.Int,4) ,
                        new SqlParameter("@FPOGroupID", SqlDbType.Int,4) ,
                        new SqlParameter("@FStatus", SqlDbType.Int,4) ,
                        new SqlParameter("@FLanguageID", SqlDbType.Int,4) ,
                        new SqlParameter("@FRegionID", SqlDbType.Int,4) ,
                        new SqlParameter("@FTrade", SqlDbType.Int,4) ,
                        new SqlParameter("@FMinPOValue", SqlDbType.Float,8) ,
                        new SqlParameter("@FMaxDebitDate", SqlDbType.Float,8) ,
                        new SqlParameter("@FLegalPerson", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FContact", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FCity", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FContactAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FPhoneAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FFaxAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FZipAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FEmailAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FAddrAcct", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FTax", SqlDbType.Real,4) ,
                        new SqlParameter("@FCyID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSetID", SqlDbType.Int,4) ,
                        new SqlParameter("@FSetDLineID", SqlDbType.Int,4) ,
                        new SqlParameter("@FProvince", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FTaxNum", SqlDbType.VarChar,50) ,
                        new SqlParameter("@FPriceClsID", SqlDbType.Int,4) ,
                        new SqlParameter("@FOperID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCIQNumber", SqlDbType.VarChar,20) ,
                        new SqlParameter("@FDeleted", SqlDbType.SmallInt,2) ,
                        new SqlParameter("@FSaleMode", SqlDbType.Int,4) ,
                        new SqlParameter("@FName", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FNumber", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FParentID", SqlDbType.Int,4) ,
                        new SqlParameter("@FShortNumber", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FCountry", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FARAccountID", SqlDbType.Int,4) ,
                        new SqlParameter("@FAPAccountID", SqlDbType.Int,4) ,
                        new SqlParameter("@FpreAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FlastTradeAmount", SqlDbType.Money,8) ,
                        new SqlParameter("@FlastRPAmount", SqlDbType.Money,8) ,
                        new SqlParameter("@FfavorPolicy", SqlDbType.VarChar,255) ,
                        new SqlParameter("@Fdepartment", SqlDbType.Int,4) ,
                        new SqlParameter("@Femployee", SqlDbType.Int,4) ,
                        new SqlParameter("@Fcorperate", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FbeginTradeDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FPostalCode", SqlDbType.VarChar,20) ,
                        new SqlParameter("@FendTradeDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FlastTradeDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FlastReceiveDate", SqlDbType.DateTime) ,
                        new SqlParameter("@FcashDiscount", SqlDbType.VarChar,255) ,
                        new SqlParameter("@FcurrencyID", SqlDbType.Int,4) ,
                        new SqlParameter("@FmaxDealAmount", SqlDbType.Float,8) ,
                        new SqlParameter("@FminForeReceiveRate", SqlDbType.Float,8) ,
                        new SqlParameter("@FminReserverate", SqlDbType.Float,8) ,
                        new SqlParameter("@FdebtLevel", SqlDbType.Int,4) ,
                        new SqlParameter("@FCarryingAOS", SqlDbType.Int,4) ,
                        new SqlParameter("@FPhone", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FIsCreditMgr", SqlDbType.Bit,1) ,
                        new SqlParameter("@FCreditPeriod", SqlDbType.Int,4) ,
                        new SqlParameter("@FCreditLevel", SqlDbType.Int,4) ,
                        new SqlParameter("@FPayTaxAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FValueAddRate", SqlDbType.Decimal,13) ,
                        new SqlParameter("@FTypeID", SqlDbType.Int,4) ,
                        new SqlParameter("@FCreditDays", SqlDbType.Int,4) ,
                        new SqlParameter("@FCreditAmount", SqlDbType.Decimal,9) ,
                        new SqlParameter("@FStockIDAssign", SqlDbType.Int,4) ,
                        new SqlParameter("@FFax", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FStockIDInst", SqlDbType.Int,4) ,
                        new SqlParameter("@FStockIDKeep", SqlDbType.Int,4) ,
                        new SqlParameter("@FPaperPeriod", SqlDbType.DateTime) ,
                        new SqlParameter("@FAlarmPeriod", SqlDbType.Int,4) ,
                        new SqlParameter("@FLicence", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FPermit", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FCertify", SqlDbType.VarChar,80) ,
                        new SqlParameter("@FLicAndPermit", SqlDbType.Bit,1) ,
                        new SqlParameter("@FGSortMem", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FGEng", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FEmail", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FGAbove", SqlDbType.VarChar,40) ,
                        new SqlParameter("@FGProp", SqlDbType.Int,4) ,
                        new SqlParameter("@FGManageMode", SqlDbType.Int,4) ,
                        new SqlParameter("@FGCharterVal", SqlDbType.DateTime) ,
                        new SqlParameter("@FGPermissVal", SqlDbType.DateTime) ,
                        new SqlParameter("@FGCertifiVal", SqlDbType.DateTime) ,
                        new SqlParameter("@FGInitialApproveFlag", SqlDbType.Bit,1) ,
                        new SqlParameter("@FSaleID", SqlDbType.Int,4) ,
                        new SqlParameter("@FOtherARAcctID", SqlDbType.Int,4) ,
                        new SqlParameter("@FOtherAPAcctID", SqlDbType.Int,4)

            };

            parameters[0].Value = t_Organization.FItemID;
            parameters[1].Value = Common.SqlNull(t_Organization.FHomePage);
            parameters[2].Value = t_Organization.FPreAPAcctID;
            parameters[3].Value = Common.SqlNull(t_Organization.FHelpCode);
            parameters[4].Value = Common.SqlNull(t_Organization.FNameEN);
            parameters[5].Value = Common.SqlNull(t_Organization.FAddrEn);
            parameters[6].Value = Common.SqlNull(t_Organization.FCIQCode);
            parameters[7].Value = Common.SqlNull(t_Organization.FRegion);
            parameters[8].Value = Common.SqlNull(t_Organization.FMobilePhone);
            parameters[9].Value = Common.SqlNull(t_Organization.FPayCondition);
            parameters[10].Value = Common.SqlNull(t_Organization.FManageType);
            parameters[11].Value = t_Organization.FClass;
            parameters[12].Value = Common.SqlNull(t_Organization.FCreditLimit);
            parameters[13].Value = t_Organization.FValue;
            parameters[14].Value = t_Organization.FRegUserID;
            parameters[15].Value = Common.SqlNull(t_Organization.FLastModifyDate);
            parameters[16].Value = Common.SqlNull(t_Organization.FRecentContactDate);
            parameters[17].Value = Common.SqlNull(t_Organization.FRegDate);
            parameters[18].Value = t_Organization.FFlat;
            parameters[19].Value = t_Organization.FClassTypeID;
            parameters[20].Value = Common.SqlNull(t_Organization.FCoSupplierID);
            parameters[21].Value = t_Organization.FShareStatus;
            //parameters[22].Value = Common.SqlNull(t_Organization.F_102);
            parameters[22].Value = Common.SqlNull(t_Organization.FTaxID);
            parameters[23].Value = Common.SqlNull(t_Organization.FBank);
            parameters[24].Value = Common.SqlNull(t_Organization.FAccount);
            parameters[25].Value = Common.SqlNull(t_Organization.FBankNumber);
            parameters[26].Value = Common.SqlNull(t_Organization.FBrNo);
            parameters[27].Value = Common.SqlNull(t_Organization.FBoundAttr);
            parameters[28].Value = Common.SqlNull(t_Organization.FErpClsID);
            parameters[29].Value = Common.SqlNull(t_Organization.FShortName);
            parameters[30].Value = Common.SqlNull(t_Organization.FAddress);
            parameters[31].Value = Common.SqlNull(t_Organization.FPriorityID);
            parameters[32].Value = Common.SqlNull(t_Organization.FPOGroupID);
            parameters[33].Value = Common.SqlNull(t_Organization.FStatus);
            parameters[34].Value = Common.SqlNull(t_Organization.FLanguageID);
            parameters[35].Value = Common.SqlNull(t_Organization.FRegionID);
            parameters[36].Value = Common.SqlNull(t_Organization.FTrade);
            parameters[37].Value = Common.SqlNull(t_Organization.FMinPOValue);
            parameters[38].Value = Common.SqlNull(t_Organization.FMaxDebitDate);
            parameters[39].Value = Common.SqlNull(t_Organization.FLegalPerson);
            parameters[40].Value = Common.SqlNull(t_Organization.FContact);
            parameters[41].Value = Common.SqlNull(t_Organization.FCity);
            parameters[42].Value = Common.SqlNull(t_Organization.FContactAcct);
            parameters[43].Value = Common.SqlNull(t_Organization.FPhoneAcct);
            parameters[44].Value = Common.SqlNull(t_Organization.FFaxAcct);
            parameters[45].Value = Common.SqlNull(t_Organization.FZipAcct);
            parameters[46].Value = Common.SqlNull(t_Organization.FEmailAcct);
            parameters[47].Value = Common.SqlNull(t_Organization.FAddrAcct);
            parameters[48].Value = Common.SqlNull(t_Organization.FTax);
            parameters[49].Value = Common.SqlNull(t_Organization.FCyID);
            parameters[50].Value = Common.SqlNull(t_Organization.FSetID);
            parameters[51].Value = Common.SqlNull(t_Organization.FSetDLineID);
            parameters[52].Value = Common.SqlNull(t_Organization.FProvince);
            parameters[53].Value = Common.SqlNull(t_Organization.FTaxNum);
            parameters[54].Value = Common.SqlNull(t_Organization.FPriceClsID);
            parameters[55].Value = Common.SqlNull(t_Organization.FOperID);
            parameters[56].Value = Common.SqlNull(t_Organization.FCIQNumber);
            parameters[57].Value = t_Organization.FDeleted;
            parameters[58].Value = t_Organization.FSaleMode;
            parameters[59].Value = Common.SqlNull(t_Organization.FName);
            parameters[60].Value = Common.SqlNull(t_Organization.FNumber);
            parameters[61].Value = t_Organization.FParentID;
            parameters[62].Value = Common.SqlNull(t_Organization.FShortNumber);
            parameters[63].Value = Common.SqlNull(t_Organization.FCountry);
            parameters[64].Value = t_Organization.FARAccountID;
            parameters[65].Value = t_Organization.FAPAccountID;
            parameters[66].Value = t_Organization.FpreAcctID;
            parameters[67].Value = t_Organization.FlastTradeAmount;
            parameters[68].Value = t_Organization.FlastRPAmount;
            parameters[69].Value = Common.SqlNull(t_Organization.FfavorPolicy);
            parameters[70].Value = t_Organization.Fdepartment;
            parameters[71].Value = t_Organization.Femployee;
            parameters[72].Value = Common.SqlNull(t_Organization.Fcorperate);
            parameters[73].Value = Common.SqlNull(t_Organization.FbeginTradeDate);
            parameters[74].Value = Common.SqlNull(t_Organization.FPostalCode);
            parameters[75].Value = Common.SqlNull(t_Organization.FendTradeDate);
            parameters[76].Value = Common.SqlNull(t_Organization.FlastTradeDate);
            parameters[77].Value = Common.SqlNull(t_Organization.FlastReceiveDate);
            parameters[78].Value = t_Organization.FcashDiscount;
            parameters[79].Value = t_Organization.FcurrencyID;
            parameters[80].Value = t_Organization.FmaxDealAmount;
            parameters[81].Value = t_Organization.FminForeReceiveRate;
            parameters[82].Value = t_Organization.FminReserverate;
            parameters[83].Value = t_Organization.FdebtLevel;
            parameters[84].Value = t_Organization.FCarryingAOS;
            parameters[85].Value = Common.SqlNull(t_Organization.FPhone);
            parameters[86].Value = t_Organization.FIsCreditMgr;
            parameters[87].Value = t_Organization.FCreditPeriod;
            parameters[88].Value = t_Organization.FCreditLevel;
            parameters[89].Value = t_Organization.FPayTaxAcctID;
            parameters[90].Value = Common.SqlNull(t_Organization.FValueAddRate);
            parameters[91].Value = t_Organization.FTypeID;
            parameters[92].Value = Common.SqlNull(t_Organization.FCreditDays);
            parameters[93].Value = Common.SqlNull(t_Organization.FCreditAmount);
            parameters[94].Value = t_Organization.FStockIDAssign;
            parameters[95].Value = Common.SqlNull(t_Organization.FFax);
            parameters[96].Value = t_Organization.FStockIDInst;
            parameters[97].Value = Common.SqlNull(t_Organization.FStockIDKeep);
            parameters[98].Value = Common.SqlNull(t_Organization.FPaperPeriod);
            parameters[99].Value = Common.SqlNull(t_Organization.FAlarmPeriod);
            parameters[100].Value = Common.SqlNull(t_Organization.FLicence);
            parameters[101].Value = Common.SqlNull(t_Organization.FPermit);
            parameters[102].Value = Common.SqlNull(t_Organization.FCertify);
            parameters[103].Value = t_Organization.FLicAndPermit;
            parameters[104].Value = Common.SqlNull(t_Organization.FGSortMem);
            parameters[105].Value = Common.SqlNull(t_Organization.FGEng);
            parameters[106].Value = Common.SqlNull(t_Organization.FEmail);
            parameters[107].Value = Common.SqlNull(t_Organization.FGAbove);
            parameters[108].Value = Common.SqlNull(t_Organization.FGProp);
            parameters[109].Value = Common.SqlNull(t_Organization.FGManageMode);
            parameters[110].Value = Common.SqlNull(t_Organization.FGCharterVal);
            parameters[111].Value = Common.SqlNull(t_Organization.FGPermissVal);
            parameters[112].Value = Common.SqlNull(t_Organization.FGCertifiVal);
            parameters[113].Value = t_Organization.FGInitialApproveFlag;
            parameters[114].Value = Common.SqlNull(t_Organization.FSaleID);
            parameters[115].Value = t_Organization.FOtherARAcctID;
            parameters[116].Value = t_Organization.FOtherAPAcctID;

            int ret = SqlHelper.ExecuteNonQuery(connK3Desc, strSql.ToString(), parameters);
            return ret;
        }

        /// <summary>
        /// 记录是否存在
        /// </summary>
        /// <param name="ItemId"></param>
        /// <returns></returns>
        public static bool Exist(string fName,int fItemID)
        {
            bool retVal = false;
            string sql = string.Format("Select Count(*) From [t_Organization] Where fName = '{0}' OR fItemID ={1}",fName, fItemID);
            object obj = SqlHelper.ExecuteScalar(connK3Desc, sql);
            if(obj != null && int.Parse(obj.ToString()) > 0)
            {
                retVal = true;
            }
            return retVal;
        }
    }
}