using System;
namespace Aohua.K3.Models
{
    /// <summary>
    /// t_Voucher:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class Voucher
    {
        public Voucher()
        { }
        #region Model

        /// <summary>
        /// 公司代码
        /// </summary>
        public string FBrNo { get; set; }

        [PrimaryKey]
        /// <summary>
        /// 凭证内码
        /// </summary>
        public int FVoucherID { get; set; }

        /// <summary>
        /// 凭证日期
        /// </summary>
        public DateTime FDate { get; set; }

        /// <summary>
        /// 会计年度
        /// </summary>
        public int FYear { get; set; }

        /// <summary>
        /// 会计期间
        /// </summary>
        public int FPeriod { get; set; }

        /// <summary>
        /// 凭证字内码
        /// t_VoucherGroup
        /// </summary>
        public int FGroupID { get; set; }

        /// <summary>
        /// 凭证号
        /// </summary>
        public int FNumber { get; set; }

        /// <summary>
        /// 参考信息
        /// </summary>
        public string FReference { get; set; }

        /// <summary>
        /// 备注
        /// </summary>
        public string FExplanation { get; set; }

        /// <summary>
        /// 附件张数
        /// </summary>
        public int? FAttachments { get; set; }

        /// <summary>
        /// 分录数
        /// </summary>
        public int FEntryCount { get; set; }

        /// <summary>
        /// 借方金额合计
        /// </summary>
        public decimal FDebitTotal { get; set; }

        /// <summary>
        /// 贷方金额合计
        /// </summary>
        public decimal FCreditTotal { get; set; }

        /// <summary>
        /// 机制凭证
        /// </summary>
        public string FInternalInd { get; set; }

        /// <summary>
        /// 是否审核
        /// </summary>
        public bool FChecked { get; set; }

        /// <summary>
        /// 是否过账
        /// 0-未过账,1-已过账
        /// </summary>
        public bool FPosted { get; set; }

        /// <summary>
        /// 制单人
        /// t_User
        /// </summary>
        public int FPreparerID { get; set; }

        /// <summary>
        /// 审核人
        /// t_User
        /// </summary>
        public int FCheckerID { get; set; }

        /// <summary>
        /// 记账人
        /// t_User
        /// </summary>
        public int FPosterID { get; set; }

        /// <summary>
        /// 出纳员
        /// t_User
        /// </summary>
        public int FCashierID { get; set; }

        /// <summary>
        /// 会计主管
        /// </summary>
        public string FHandler { get; set; }

        /// <summary>
        /// 制单人所属工作组
        /// </summary>
        public int FOwnerGroupID { get; set; }

        /// <summary>
        /// 对象接口
        /// </summary>
        public string FObjectName { get; set; }

        /// <summary>
        /// 接口参数
        /// </summary>
        public string FParameter { get; set; }

        /// <summary>
        /// 凭证序号
        /// </summary>
        public int FSerialNum { get; set; }

        /// <summary>
        /// 单据类型
        /// </summary>
        public int FTranType { get; set; }

        /// <summary>
        /// 业务日期
        /// </summary>
        public DateTime? FTransDate { get; set; }

        /// <summary>
        /// 集团组织机构内码
        /// </summary>
        public int FFrameWorkID { get; set; }

        /// <summary>
        /// 制单人
        /// </summary>
        public int FApproveID { get; set; }

        /// <summary>
        /// 批注
        /// </summary>
        public string FFootNote { get; set; }

        /// <summary>
        /// UUID
        /// </summary>
        public Guid UUID { get; set; }

        [TimeSpanColumn]
        /// <summary>
        /// 修改时间
        /// </summary>
        public TimeSpan FModifyTime { get; set; }

        #endregion Model

    }
}

