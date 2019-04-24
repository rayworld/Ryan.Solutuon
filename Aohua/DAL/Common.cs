using System;

namespace Aohua.DAL
{
    public partial class Common
    {
        public static object SqlNull(object obj)
        {
            if (obj == null || obj.ToString() == "")
            {
                return DBNull.Value;
            }
            else
            {
                return obj;
            }
        }
    }
}
