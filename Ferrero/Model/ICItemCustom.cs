using Ryan.Framework.DotNetFx40.ORM.Attributes;
using System;

namespace EAS2WISE.Model
{
    [Table(TableName = "t_ICItemCustom")]
    [Serializable]
    public class ICItemCustom
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
        public string F_101 { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string F_102 { get; set; }

        /// </summary>
        /// 描述:""
        /// 数据类型:"string"
        /// 默认值:""
        /// </summary>
        public string F_103 { get; set; }
    }
}
