using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemCore")]
    [Serializable]
    public class ICItemCore
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
        /// 默认值:""
        /// </summary>
        public string FModel { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FName { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FHelpCode { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:"(0)"
        /// </summary>
        public Int16? FDeleted { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FShortNumber { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FNumber { get; set; }

        //[TimeSpan]
        //public byte?[] FModifyTime { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FParentID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:"('0')"
        /// </summary>
        public string FBrNo { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FTopID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16? FRP { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16? FOmortize { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16? FOmortizeScale { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FForSale { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Double"
        /// 默认值:""
        /// </summary>
        public Double? FStaCost { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Double"
        /// 默认值:""
        /// </summary>
        public Double? FOrderPrice { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FOrderMethod { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FPriceFixingType { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FSalePriceFixingType { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Double"
        /// 默认值:"(0)"
        /// </summary>
        public Double? FPerWastage { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32? FARAcctID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16? FPlanPriceMethod { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:""
        /// </summary>
        public Int16? FPlanClass { get; set; }
    }
}