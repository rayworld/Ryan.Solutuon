using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "T_BASE_ICItemEntrance")]
    [Serializable]
    public class BASE_ICItemEntrance
    {
        [PrimaryKey]
        /// </summary>
        /// 描述:"                                                                                                                                                                                                                                                               "
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FItemID { get; set; }

        /// </summary>
        /// 描述:"英文名称                                                                                                                                                                                                                                                           "
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FNameEn { get; set; }

        /// </summary>
        /// 描述:"英文规格                                                                                                                                                                                                                                                           "
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FModelEn { get; set; }

        /// </summary>
        /// 描述:"HS编码                                                                                                                                                                                                                                                           "
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FHSNumber { get; set; }

        /// </summary>
        /// 描述:"HS第一法定单位                                                                                                                                                                                                                                                       "
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FFirstUnit { get; set; }

        /// </summary>
        /// 描述:"HS第二法定单位                                                                                                                                                                                                                                                       "
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FSecondUnit { get; set; }

        /// </summary>
        /// 描述:"HS第一法定单位换算率                                                                                                                                                                                                                                                    "
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FFirstUnitRate { get; set; }

        /// </summary>
        /// 描述:"HS第二法定单位换算率                                                                                                                                                                                                                                                    "
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal? FSecondUnitRate { get; set; }

        /// </summary>
        /// 描述:"是否保税监管                                                                                                                                                                                                                                                         "
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsManage { get; set; }

        /// </summary>
        /// 描述:"                                                                                                                                                                                                                                                               "
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FPackType { get; set; }

        /// </summary>
        /// 描述:"长度精度                                                                                                                                                                                                                                                           "
        /// 数据类型:"Int32"
        /// 默认值:"(2)"
        /// </summary>
        public Int32? FLenDecimal { get; set; }

        /// </summary>
        /// 描述:"体积精度                                                                                                                                                                                                                                                           "
        /// 数据类型:"Int32"
        /// 默认值:"(4)"
        /// </summary>
        public Int32? FCubageDecimal { get; set; }

        /// </summary>
        /// 描述:"重量精度                                                                                                                                                                                                                                                           "
        /// 数据类型:"Int32"
        /// 默认值:"(2)"
        /// </summary>
        public Int32? FWeightDecimal { get; set; }

        /// </summary>
        /// 描述:"进口关税率%                                                                                                                                                                                                                                                         "
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FImpostTaxRate { get; set; }

        /// </summary>
        /// 描述:"进口消费税率%                                                                                                                                                                                                                                                        "
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FConsumeTaxRate { get; set; }

        /// </summary>
        /// 描述:"保税监管类型                                                                                                                                                                                                                                                         "
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FManageType { get; set; }

    }
}
