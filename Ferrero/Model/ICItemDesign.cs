using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemDesign")]
    [Serializable]
    public class ICItemDesign
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
        /// 数据类型:"string"
        /// 默认值:"(' ')"
        /// </summary>
        public string FChartNumber { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsKeyItem { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FMaund { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FGrossWeight { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FNetWeight { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FCubicMeasure { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FLength { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FWidth { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FHeight { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FSize { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FVersion { get; set; }
    }
}
