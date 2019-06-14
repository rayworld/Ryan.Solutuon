using Aohua.Models;
using Ryan.Framework.DotNetFx40.DBUtility;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Aohua.DAL
{
    public partial class MeasureUnits
    {
        private static string connK3Desc = SqlHelper.GetConnectionString("K3Desc");

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public static int Insert(MeasureUnit model)
        {
            StringBuilder strSql = new StringBuilder();
            strSql.Append("insert into t_MeasureUnit(");
            strSql.Append("FMeasureUnitID,FUnitGroupID,FNumber,FAuxClass,FName,FCoefficient,FBrNo,FItemID,FParentID,FDeleted,FShortNumber,FOperDate,FScale,FStandard,FControl,FSystemType,FConversation,FPrecision,FNameEN,FNameEnPlu)");
            strSql.Append(" values (");
            strSql.Append("@FMeasureUnitID,@FUnitGroupID,@FNumber,@FAuxClass,@FName,@FCoefficient,@FBrNo,@FItemID,@FParentID,@FDeleted,@FShortNumber,@FOperDate,@FScale,@FStandard,@FControl,@FSystemType,@FConversation,@FPrecision,@FNameEN,@FNameEnPlu)");
            SqlParameter[] parameters = {
                    new SqlParameter("@FMeasureUnitID", SqlDbType.Int,4),
                    new SqlParameter("@FUnitGroupID", SqlDbType.Int,4),
                    new SqlParameter("@FNumber", SqlDbType.VarChar,30),
                    new SqlParameter("@FAuxClass", SqlDbType.VarChar,80),
                    new SqlParameter("@FName", SqlDbType.VarChar,80),
                    new SqlParameter("@FCoefficient", SqlDbType.Decimal,13),
                    new SqlParameter("@FBrNo", SqlDbType.Char,10),
                    new SqlParameter("@FItemID", SqlDbType.Int,4),
                    new SqlParameter("@FParentID", SqlDbType.Int,4),
                    new SqlParameter("@FDeleted", SqlDbType.SmallInt,2),
                    new SqlParameter("@FShortNumber", SqlDbType.VarChar,30),
                    new SqlParameter("@FOperDate", SqlDbType.Char,10),
                    new SqlParameter("@FScale", SqlDbType.Decimal,13),
                    new SqlParameter("@FStandard", SqlDbType.SmallInt,2),
                    new SqlParameter("@FControl", SqlDbType.SmallInt,2),
                    new SqlParameter("@FSystemType", SqlDbType.Int,4),
                    //new SqlParameter("@UUID", SqlDbType.UniqueIdentifier,16),
                    new SqlParameter("@FConversation", SqlDbType.Int,4),
                    new SqlParameter("@FPrecision", SqlDbType.Int,4),
                    new SqlParameter("@FNameEN", SqlDbType.NVarChar,255),
                    new SqlParameter("@FNameEnPlu", SqlDbType.NVarChar,255)};
            parameters[0].Value = model.FMeasureUnitID;
            parameters[1].Value = model.FUnitGroupID;
            parameters[2].Value = Common.SqlNull(model.FNumber);
            parameters[3].Value = model.FAuxClass;//不能为空限制
            parameters[4].Value = Common.SqlNull(model.FName);
            parameters[5].Value = model.FCoefficient;
            parameters[6].Value = model.FBrNo;
            parameters[7].Value = model.FItemID;
            parameters[8].Value = Common.SqlNull(model.FParentID);
            parameters[9].Value = model.FDeleted;
            parameters[10].Value = Common.SqlNull(model.FShortNumber);
            parameters[11].Value = Common.SqlNull(model.FOperDate);
            parameters[12].Value = model.FScale;
            parameters[13].Value = model.FStandard;
            parameters[14].Value = model.FControl;
            parameters[15].Value = model.FSystemType;
            //parameters[16].Value = Guid.NewGuid();
            parameters[16].Value = model.FConversation;
            parameters[17].Value = model.FPrecision;
            parameters[18].Value = Common.SqlNull(model.FNameEN);
            parameters[19].Value = Common.SqlNull(model.FNameEnPlu);

            int rows = SqlHelper.ExecuteNonQuery(connK3Desc,strSql.ToString(), parameters);
            return rows;
        }

        public static MeasureUnit GetModel(DataRow dr)
        {
            MeasureUnit measureUnit = new MeasureUnit();
            if (dr["FMeasureUnitID"] != null && dr["FMeasureUnitID"].ToString() != "")
            {
                measureUnit.FMeasureUnitID = int.Parse(dr["FMeasureUnitID"].ToString());
            }
            if (dr["FUnitGroupID"] != null && dr["FUnitGroupID"].ToString() != "")
            {
                measureUnit.FUnitGroupID = int.Parse(dr["FUnitGroupID"].ToString());
            }
            if (dr["FNumber"] != null)
            {
                measureUnit.FNumber = dr["FNumber"].ToString();
            }
            if (dr["FAuxClass"] != null)
            {
                measureUnit.FAuxClass = dr["FAuxClass"].ToString();
            }
            if (dr["FName"] != null)
            {
                measureUnit.FName = dr["FName"].ToString();
            }
            if (dr["FCoefficient"] != null && dr["FCoefficient"].ToString() != "")
            {
                measureUnit.FCoefficient = decimal.Parse(dr["FCoefficient"].ToString());
            }
            if (dr["FBrNo"] != null)
            {
                measureUnit.FBrNo = dr["FBrNo"].ToString();
            }
            if (dr["FItemID"] != null && dr["FItemID"].ToString() != "")
            {
                measureUnit.FItemID = int.Parse(dr["FItemID"].ToString());
            }
            if (dr["FParentID"] != null && dr["FParentID"].ToString() != "")
            {
                measureUnit.FParentID = int.Parse(dr["FParentID"].ToString());
            }
            if (dr["FDeleted"] != null && dr["FDeleted"].ToString() != "")
            {
                measureUnit.FDeleted = int.Parse(dr["FDeleted"].ToString());
            }
            if (dr["FShortNumber"] != null)
            {
                measureUnit.FShortNumber = dr["FShortNumber"].ToString();
            }
            if (dr["FOperDate"] != null)
            {
                measureUnit.FOperDate = dr["FOperDate"].ToString();
            }
            if (dr["FScale"] != null && dr["FScale"].ToString() != "")
            {
                measureUnit.FScale = decimal.Parse(dr["FScale"].ToString());
            }
            if (dr["FStandard"] != null && dr["FStandard"].ToString() != "")
            {
                measureUnit.FStandard = int.Parse(dr["FStandard"].ToString());
            }
            if (dr["FControl"] != null && dr["FControl"].ToString() != "")
            {
                measureUnit.FControl = int.Parse(dr["FControl"].ToString());
            }
            //if (dr["FModifyTime"] != null && dr["FModifyTime"].ToString() != "")
            //{
            //    measureUnit.FModifyTime = DateTime.Parse(dr["FModifyTime"].ToString());
            //}
            if (dr["FSystemType"] != null && dr["FSystemType"].ToString() != "")
            {
                measureUnit.FSystemType = int.Parse(dr["FSystemType"].ToString());
            }
            //if (dr["UUID"] != null && dr["UUID"].ToString() != "")
            //{
            //    model.UUID = new Guid(dr["UUID"].ToString());
            //}
            if (dr["FConversation"] != null && dr["FConversation"].ToString() != "")
            {
                measureUnit.FConversation = int.Parse(dr["FConversation"].ToString());
            }
            if (dr["FPrecision"] != null && dr["FPrecision"].ToString() != "")
            {
                measureUnit.FPrecision = int.Parse(dr["FPrecision"].ToString());
            }
            if (dr["FNameEN"] != null)
            {
                measureUnit.FNameEN = dr["FNameEN"].ToString();
            }
            if (dr["FNameEnPlu"] != null)
            {
                measureUnit.FNameEnPlu = dr["FNameEnPlu"].ToString();
            }

            return measureUnit;
        }


    }
}
