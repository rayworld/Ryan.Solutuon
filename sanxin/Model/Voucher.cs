using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace SanXin.KIS.Model
{
    [Table(TableName = "t_Voucher")]
    public class Voucher
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
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FVoucherID { get; set; }

        /// </summary>
        /// 描述:"凭证日期"
        /// 数据类型:"DateTime"
        /// 默认值:""
        /// </summary>
        public DateTime FDate { get; set; }

        /// </summary>
        /// 描述:"会计年度"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FYear { get; set; }

        /// </summary>
        /// 描述:"会计期间"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FPeriod { get; set; }

        /// </summary>
        /// 描述:"凭证字内码"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FGroupID { get; set; }

        /// </summary>
        /// 描述:"凭证号"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FNumber { get; set; }

        /// </summary>
        /// 描述:"参考信息"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FReference { get; set; }

        /// </summary>
        /// 描述:"备注"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FExplanation { get; set; }

        /// </summary>
        /// 描述:"附件张数"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32? FAttachments { get; set; }

        /// </summary>
        /// 描述:"分录数"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FEntryCount { get; set; }

        /// </summary>
        /// 描述:"借方金额合计"
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal FDebitTotal { get; set; }

        /// </summary>
        /// 描述:"贷方金额合计"
        /// 数据类型:"decimal"
        /// 默认值:""
        /// </summary>
        public decimal FCreditTotal { get; set; }

        /// </summary>
        /// 描述:"机制凭证"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FInternalInd { get; set; }

        /// </summary>
        /// 描述:"是否审核"
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool FChecked { get; set; }

        /// </summary>
        /// 描述:"是否过账"
        /// 数据类型:"bool"
        /// 默认值:"(0)"
        /// </summary>
        public bool FPosted { get; set; }

        /// </summary>
        /// 描述:"制单人"
        /// 数据类型:"Int32"
        /// 默认值:""
        /// </summary>
        public Int32 FPreparerID { get; set; }

        /// </summary>
        /// 描述:"审核人"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FCheckerID { get; set; }

        /// </summary>
        /// 描述:"记账人"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FPosterID { get; set; }

        /// </summary>
        /// 描述:"出纳员"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FCashierID { get; set; }

        /// </summary>
        /// 描述:"会计主管"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FHandler { get; set; }

        /// </summary>
        /// 描述:"制单人所属工作组"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FOwnerGroupID { get; set; }

        /// </summary>
        /// 描述:"对象接口"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FObjectName { get; set; }

        /// </summary>
        /// 描述:"接口参数"
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string FParameter { get; set; }

        /// </summary>
        /// 描述:"凭证序号"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FSerialNum { get; set; }

        /// </summary>
        /// 描述:"单据类型"
        /// 数据类型:"Int32"
        /// 默认值:"(0)"
        /// </summary>
        public Int32 FTranType { get; set; }

        /// </summary>
        /// 描述:"业务日期"
        /// 数据类型:"DateTime"
        /// 默认值:""
        /// </summary>
        public DateTime? FTransDate { get; set; }

        /// </summary>
        /// 描述:"集团组织机构内码"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FFrameWorkID { get; set; }

        /// </summary>
        /// 描述:"审批"
        /// 数据类型:"Int32"
        /// 默认值:"((-1))"
        /// </summary>
        public Int32 FApproveID { get; set; }

        /// </summary>
        /// 描述:"批注"
        /// 数据类型:"string"
        /// 默认值:"('')"
        /// </summary>
        public string FFootNote { get; set; }

        /// </summary>
        /// 描述:"UUID"
        /// 数据类型:"Guid"
        /// 默认值:"(newid())"
        /// </summary>
        public Guid? UUID { get; set; }

        [TimeSpan]
        /// </summary>
        /// 描述:"修改时间"
        /// 数据类型:"byte[]"
        /// 默认值:""
        /// </summary>
        public byte? [] FModifyTime { get; set; }

    }
}
