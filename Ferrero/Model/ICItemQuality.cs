using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemQuality")]
    [Serializable]
    public class ICItemQuality
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
        /// 默认值:"(352)"
        /// </summary>
        public Int32? FInspectionLevel { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FInspectionProject { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(' ')"
        /// </summary>
        public Int32? FIsListControl { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FProChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FWWChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FSOChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FWthDrwChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FStkChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FOtherChkMde { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(9999)"
        /// </summary>
        public Int32? FStkChkPrd { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FStkChkAlrm { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(' ')"
        /// </summary>
        public Int32? FIdentifier { get; set; }
    }
}
