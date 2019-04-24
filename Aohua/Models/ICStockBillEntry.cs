using System;
namespace Aohua.Models
{
    /// <summary>
    /// ICStockBillEntry:实体类(属性说明自动提取数据库字段的描述信息)
    /// 1、从单表生成器生成带为空判断的字段属性
    /// 2、调整GET,SET格式
    /// </summary>
    [Serializable]
    public partial class ICStockBillEntry
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
        public int FEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FItemID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FQtyMust { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBatchNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNote { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSCBillInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FSCBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FUnitID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQtyMust { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FQtyActual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQtyActual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FPlanPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxPlanPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSourceEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FKFDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FKFPeriod { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FDCSPID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSCSPID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FConsignPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FConsignAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FProcessCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FMaterialCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FTaxAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FMapNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FMapName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FOrgBillEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FOperID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FPlanAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FProcessPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FTaxRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FSnListID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAmtRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FAuxPropID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FPriceRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxPriceRef { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FFetchDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FQtyInvoice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FQtyInvoiceBase { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FUnitCost { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCoefficient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSourceTranType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSourceInterId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FSourceBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FContractInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FContractEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FContractBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FICMOBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FICMOInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPPBomEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FOrderInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FOrderEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FOrderBillNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAllHookQTY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAllHookAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FCurrentHookQTY { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FCurrentHookAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FStdAllHookAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FStdCurrentHookAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSCStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FDCStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime? FPeriodDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCostObjGroupID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCostOBJID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FDetailID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FMaterialCostPrice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FReProduceType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FBomInterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FDiscountRate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FDiscountAmount { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSepcialSaleId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FOutCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FOutSecCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FDBCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FDBSecCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxQtyInvoice { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FOperSN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCheckStatus { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FSplitSecQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem1 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem2 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem3 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem4 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem5 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem7 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem10 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FCOMBFreeItem11 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSaleCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSaleSecCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSaleAuxCommitQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FInStockID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSelectedProcID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FVWInStockQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FAuxVWInStockQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecVWInStockQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecInvoiceQty { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FCostCenterID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPlanMode { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FMTONo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQtyActual { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FSecQtyMust { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FClientOrderNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FClientEntryID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FRowClosed { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCostPercentage { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FEntrySelfB0168 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FEntrySelfB0169 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FEntrySelfD0148 { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal? FCOMBFreeItem9 { get; set; }

    }
}

