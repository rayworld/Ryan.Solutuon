using Ryan.Framework.DotNetFx40.ORM.Attributes;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_Identity")]
    public class TIdentity
    {
        [PrimaryKey]
        /// <summary>
        /// 表名称
        /// </summary>
        public string FName { get; set; }

        /// <summary>
        /// 种子列的值
        /// </summary>
        public int FNext { get; set; }

        /// <summary>
        /// 下一跳步长
        /// </summary>
        public int FStep { get; set; }
    }
}
