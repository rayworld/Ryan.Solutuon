using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemPlan")]
    [Serializable]
    public class ICItemPlan
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
        /// 默认值:"(321)"
        /// </summary>
        public Int32? FPlanTrategy { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(331)"
        /// </summary>
        public Int32? FOrderTrategy { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Single"
        /// 默认值:"(0)"
        /// </summary>
        public Single? FLeadTime { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Single"
        /// 默认值:"(0)"
        /// </summary>
        public Single? FFixLeadTime { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FTotalTQQ { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(1)"
        /// </summary>
        public decimal? FQtyMin { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(10000)"
        /// </summary>
        public decimal? FQtyMax { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FCUUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FOrderInterVal { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FBatchAppendQty { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(1)"
        /// </summary>
        public decimal? FOrderPoint { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(1)"
        /// </summary>
        public decimal? FBatFixEconomy { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(1)"
        /// </summary>
        public decimal? FBatChangeEconomy { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FRequirePoint { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(1)"
        /// </summary>
        public Int32? FPlanPoint { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FDefaultRoutingID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FDefaultWorkTypeID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(' ')"
        /// </summary>
        public Int32? FProductPrincipal { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FDailyConsume { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(1)"
        /// </summary>
        public bool? FMRPCon { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FPlanner { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool FPutInteger { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FInHighLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FInLowLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FLowestBomCode { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool FMRPOrder { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FIsCharSourceItem { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FCharSourceItemID { get; set; }
    }
}
