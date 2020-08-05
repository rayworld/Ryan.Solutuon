using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemMaterial")]
    [Serializable]
    public class ICItemMaterial
    {
        [PrimaryKey]
        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FItemID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FOrderRector { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FPOHghPrcMnyType { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FPOHighPrice { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FWWHghPrc { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FWWHghPrcMnyType { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FSOLowPrc { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FSOLowPrcMnyType { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(' ')"
        /// </summary>
        public bool? FIsSale { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FProfitRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FSalePrice { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FBatchManager { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FISKFPeriod { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FKFPeriod { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FTrack { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FPlanPrice { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:"(2)"
        /// </summary>
        public Int16? FPriceDecimal { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32? FSaleAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32? FCostAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FAPAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FGoodSpec { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FCostProject { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsSnManage { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FStockTime { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:""
        /// </summary>
        public bool? FBookPlan { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FBeforeExpire { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(17)"
        /// </summary>
        public Int32? FTaxRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FAdminAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FNote { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsSpecialTax { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FSOHighLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FSOLowLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FOIHighLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FOILowLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FDaysPer { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"DateTime"
        /// 默认值:""
        /// </summary>
        public DateTime? FLastCheckDate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FCheckCycle { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FCheckCycUnit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FStockPrice { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FABCCls { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Double"
        /// 默认值:""
        /// </summary>
        public Double? FBatchQty { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FClass { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Double"
        /// 默认值:""
        /// </summary>
        public Double? FCostDiffRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FDepartment { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32? FSaleTaxAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FCBBmStandardID { get; set; }
    }
}
