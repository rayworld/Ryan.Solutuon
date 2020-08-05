using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemBase")]
    [Serializable]
    public class ICItemBase
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
        public Int32? FErpClsID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FUnitGroupID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FDefaultLoc { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FSPID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FSource { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int16"
        /// 默认值:"(2)"
        /// </summary>
        public Int16? FQtyDecimal { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FLowLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FHighLimit { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(1)"
        /// </summary>
        public decimal? FSecInv { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(341)"
        /// </summary>
        public Int32? FUseState { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsEquipment { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FEquipmentNum { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool? FIsSparePart { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FFullName { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FSecUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"decimal"
        /// 默认值:"(0)"
        /// </summary>
        public decimal? FSecCoefficient { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FSecUnitDecimal { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:"('')"
        /// </summary>
        public string FAlias { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FOrderUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FSaleUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FStoreUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FProductUnitID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:"('')"
        /// </summary>
        public string FApproveNo { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FAuxClassID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FTypeID { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FPreDeadLine { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32? FSerialClassID { get; set; }

    }
}
