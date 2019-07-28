using System;

namespace Aohua.K3.Models
{
    /// <summary>
    /// t_VoucherEntry:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
    public partial class VoucherEntry
    {
        public VoucherEntry()
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

        [PrimaryKey]
        /// <summary>
        /// 分录号
        /// </summary>
        public int FEntryID { get; set; }

        /// <summary>
        /// 摘要
        /// </summary>
        public string FExplanation { get; set; }

        /// <summary>
        /// 科目内码
        /// t_Account
        /// </summary>
        public int FAccountID { get; set; }

        /// <summary>
        /// 核算项目
        /// </summary>
        public int FDetailID { get; set; }

        /// <summary>
        /// 币别 
        /// t_Currency
        /// </summary>
        public int FCurrencyID { get; set; }

        /// <summary>
        /// 汇率
        /// </summary>
        public Double FExchangeRate { get; set; }

        /// <summary>
        /// 余额方向
        /// </summary>
        public int FDC { get; set; }

        /// <summary>
        /// 原币金额
        /// </summary>
        public decimal FAmountFor { get; set; }

        /// <summary>
        /// 本位币金额
        /// </summary>
        public decimal FAmount { get; set; }

        /// <summary>
        /// 数量
        /// </summary>
        public double FQuantity { get; set; }

        /// <summary>
        /// 单位内码 
        /// t_Measureunit
        /// </summary>
        public int FMeasureUnitID { get; set; }

        /// <summary>
        /// 单价
        /// </summary>
        public double FUnitPrice { get; set; }

        /// <summary>
        /// 机制凭证
        /// </summary>
        public string FInternalInd { get; set; }

        /// <summary>
        /// 对方科目 
        /// t_Account
        /// </summary>
        public int FAccountID2 { get; set; }

        /// <summary>
        /// 结算方式 
        /// t_Settle
        /// </summary>
        public int FSettleTypeID { get; set; }

        /// <summary>
        /// 结算号
        /// </summary>
        public string FSettleNo { get; set; }

        /// <summary>
        /// 业务号
        /// </summary>
        public string FTransNo { get; set; }

        /// <summary>
        /// 现金流量
        /// </summary>
        public int FCashFlowItem { get; set; }

        /// <summary>
        /// 项目任务内码
        /// </summary>
        public int FTaskID { get; set; }

        /// <summary>
        /// 项目资源内码
        /// </summary>
        public int FResourceID { get; set; }

        #endregion Model

    }
}

