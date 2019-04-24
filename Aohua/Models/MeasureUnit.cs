using System;
namespace Aohua.Models
{
    /// <summary>
    /// t_MeasureUnit:实体类(属性说明自动提取数据库字段的描述信息)
    /// 1、从单表生成器生成带为空判断的字段属性
    /// 2、去掉FModifyTime 时间戳列
    /// 3、调整GET,SET格式
    /// </summary>
    [Serializable]
    public partial class MeasureUnit
    {
        /// <summary>
        /// 
        /// </summary>
        public int FMeasureUnitID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FUnitGroupID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FAuxClass { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FCoefficient { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FBrNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FItemID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int? FParentID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FDeleted { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FShortNumber { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FOperDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public decimal FScale { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FStandard { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FControl { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DateTime FModifyTime { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FSystemType { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public Guid UUID { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FConversation { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public int FPrecision { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNameEN { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string FNameEnPlu { get; set; }

    }
}

