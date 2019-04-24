using System;

namespace Aohua.Models
{
    /// <summary>
    /// ICStockBill:实体类(属性说明自动提取数据库字段的描述信息)
    /// 1、从单表生成器生成带为空判断的字段属性
    /// 2、调整GET,SET格式
    /// 3、类名前加[Serializable]描述
    /// </summary>
    [Serializable]
    public class ICStockBill
    {
        /// <summary>
        /// 
        /// </summary>
        public string FBrNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FUse { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FDCStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSCStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FDeptID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FEmpID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSupplyID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FPosterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCheckerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FFManagerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSManagerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FBillerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FReturnBillInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FSCBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FHookInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FVchInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPosted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCheckSelect { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCurrencyID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSaleStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FAcctID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FROB { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FRSCBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FUpStockWhenSave { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FCancellation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FOrgBillInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FBillTypeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FPOStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FMultiCheckLevel6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCurCheckLevel { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FTaskID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FResourceID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FBackFlushed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FWBInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FTranStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FZPBillInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FRelateBrID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPurposeID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid FUUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FRelateInvoiceID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FOperDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FImport { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSystemType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FMarketingStyle { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPayBillID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCheckDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FExplanation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FFetchAdd { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FFetchDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FManagerID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FRefType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSelTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FChildren { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FHookStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FActPriceVchTplID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPlanPriceVchTplID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FProcID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FActualVchTplID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPlanVchTplID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FBrID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FVIPCardID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FVIPScore { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FHolisticDiscountRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FPOSName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FWorkShiftId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCussentAcctID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public bool FZanGuCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCOMHFreeItem2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FCOMHFreeItem3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCOMHFreeItem4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem6 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem7 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem8 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FCOMHFreeItem9 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FCOMHFreeItem11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FCOMHFreeItem12 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem13 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem15 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FCOMHFreeItem18 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem19 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem20 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FPOOrdBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FLSSrcInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FSettleDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FManageType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FOrderAffirm { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FAutoCreType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FConsignee { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FDrpRelateTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPrintCount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FCOMHFreeItem17 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FHeadSelfB0154 { get; set; }

    }
}