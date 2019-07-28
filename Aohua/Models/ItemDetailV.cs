using System;

namespace Aohua.K3.Models
{
    /// <summary>
    /// t_ItemDetailV:实体类(属性说明自动提取数据库字段的描述信息)
    /// </summary>
    [Serializable]
     public partial class ItemDetailV
    {
        public ItemDetailV()
        { }

        [PrimaryKey]
        #region Models
        /// <summary>
        /// 
        /// </summary>
        public int FDetailID { get; set; }

        [PrimaryKey]
        /// <summary>
        /// 
        /// </summary>
        public int FItemClassID { get; set; }

        [PrimaryKey]
        /// <summary>
        /// 
        /// </summary>
        public int FItemID { get; set; }
        #endregion
    }
}