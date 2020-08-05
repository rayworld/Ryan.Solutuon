using Ryan.Framework.DotNetFx40.ORM;
using System;

namespace KIS.Model
{
    [Table(TableName ="ICStockBill")]
    public class ICStockBill
    {

        /// </summary>
        /// 
        /// </summary>
        public string FBrNo {get; set;}

        [PrimaryKey("FInterID", AutoIncrement=false)]
        /// </summary>
        /// 
        /// </summary>
        public Int32 FInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16? FTranType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FDate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FBillNo {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FUse {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FNote {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FDCStockID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FSCStockID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FDeptID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FEmpID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FSupplyID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FPosterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FCheckerID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FFManagerID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FSManagerID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FBillerID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FReturnBillInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FSCBillNo {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FHookInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FVchInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16 FPosted {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16? FCheckSelect {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FCurrencyID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FSaleStyle {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16 FROB {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FRSCBillNo {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16 FStatus {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public bool FUpStockWhenSave {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public bool FCancellation {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FAcctID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FOrgBillInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public bool FBackFlushed {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FZPBillInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel1 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel2 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel3 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel4 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel5 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FMultiCheckLevel6 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate1 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate2 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate3 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate4 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate5 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FMultiCheckDate6 {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FCurCheckLevel {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FBillTypeID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FPOStyle {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FRelateBrID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FPayBillID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FCostObjNumber {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FPurposeID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FWBInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Guid FUUID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FRelateInvoiceID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Byte? FTranStatus {get; set;}

        /// </summary>
        /// 
        /// </summary>
        ///public TimeStrap? FOperDate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FImport {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FSystemType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FMarketingStyle {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FCheckDate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FExplanation {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FFetchAdd {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FFetchDate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FManagerID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FRefType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FSelTranType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FChildren {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16 FHookStatus {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FActPriceVchTplID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FPlanPriceVchTplID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FProcID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FActualVchTplID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FPlanVchTplID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FBrID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FVIPCardID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public decimal FVIPScore {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public decimal FHolisticDiscountRate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FPOSName {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FWorkShiftId {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FCussentAcctID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public bool FZanGuCount {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FPOOrdBillNo {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FLSSrcInterID {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public DateTime? FSettleDate {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FManageType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32? FOrderAffirm {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Byte FAutoCreType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public string FConsignee {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int32 FDrpRelateTranType {get; set;}

        /// </summary>
        /// 
        /// </summary>
        public Int16 FPrintCount {get; set;}


    }
}
