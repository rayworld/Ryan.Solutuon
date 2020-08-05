using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemStandard")]
    [Serializable]
    public class ICItemStandard
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
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FStandardCost { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FStandardManHour { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FStdPayRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FChgFeeRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FStdFixFeeRate { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FOutMachFee { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FPieceRate { get; set; }
    }
}
