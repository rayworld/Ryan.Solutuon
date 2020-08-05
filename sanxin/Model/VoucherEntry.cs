using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace SanXin.KIS.Model
{
    [Table(TableName = "t_VoucherEntry")]
    public class VoucherEntry
    {
        /// </summary>
        /// 描述:"公司代码"
        /// 数据类型:"string"
        /// 默认值:"('0')"
        /// </summary>
        public string FBrNo { get; set; }

        [PrimaryKey]
        /// </summary>
        /// 描述:"凭证内码"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FVoucherID { get; set; }

        [PrimaryKey]
        /// </summary>
        /// 描述:"分录号"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FEntryID { get; set; }

        /// </summary>
        /// 描述:"摘要"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FExplanation { get; set; }

        /// </summary>
        /// 描述:"科目内码"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FAccountID { get; set; }

        /// </summary>
        /// 描述:"核算项目"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FDetailID { get; set; }

        /// </summary>
        /// 描述:"币别"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FCurrencyID { get; set; }

        /// </summary>
        /// 描述:"汇率"
        /// 数据类型:"Double"
        /// 默认值:""
        /// </summary>
        public Double FExchangeRate { get; set; }

        /// </summary>
        /// 描述:"余额方向"
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16 FDC { get; set; }

        /// </summary>
        /// 描述:"原币金额"
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal FAmountFor { get; set; }

        /// </summary>
        /// 描述:"本位币金额"
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal FAmount { get; set; }

        /// </summary>
        /// 描述:"数量"
        /// 数据类型:"Double"
        /// 默认值:"(0)"
        /// </summary>
        public Double FQuantity { get; set; }

        /// </summary>
        /// 描述:"单位内码"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FMeasureUnitID { get; set; }

        /// </summary>
        /// 描述:"单价"
        /// 数据类型:"Double"
        /// 默认值:"(0)"
        /// </summary>
        public Double FUnitPrice { get; set; }

        /// </summary>
        /// 描述:"机制凭证"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FInternalInd { get; set; }

        /// </summary>
        /// 描述:"对方科目"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FAccountID2 { get; set; }

        /// </summary>
        /// 描述:"结算方式"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FSettleTypeID { get; set; }

        /// </summary>
        /// 描述:"结算号"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FSettleNo { get; set; }

        /// </summary>
        /// 描述:"业务号"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FTransNo { get; set; }

        /// </summary>
        /// 描述:"现金流量"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FCashFlowItem { get; set; }

        /// </summary>
        /// 描述:"项目任务内码"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FTaskID { get; set; }

        /// </summary>
        /// 描述:"项目资源内码"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FResourceID { get; set; }
    }
}
