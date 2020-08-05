using Ryan.Framework.DotNetFx40.DBUtility;
using Ryan.Framework.DotNetFx40.Encrypt;
using Ryan.Framework.DotNetFx40.Config;
using System;
using System.Data;
using System.Text;
using System.Windows.Forms;
using static Ryan.Framework.DotNetFx40.Config.ConfigHelper;

namespace ToolsBuilder
{
    public partial class frmModelBuilder : Form
    {
        public frmModelBuilder()
        {
            InitializeComponent();
        }

        string conn = "";

        private void frmModelBuilder_Load(object sender, EventArgs e)
        {
            //string conn = "gGxSu0Ol3757HGgeJlaeli4Wdvb+gKm4Zymt0qk/o21QR2eKDqNg0KK5bqSqTx+CcpqNcakPZ8ETs1Ylse/vWrOwCg/V+ZZ9LZjWWDknCp0gmsYlGsh7Wnrctk6Y/6esPSE6MV09z46guDPe5FWImdc3fLs//7FH/3UEE+f04GP1tHtNRjTyipexZc2TaVPv";
            //textBox1.Text = EncryptHelper.Decrypt(conn);
            string ConnecitonNameList = "请选择," + ConfigHelper.GetConnectionNameList(ConfigurationFile.AppConfig);
            Console.WriteLine(ConnecitonNameList);
            comboBox1.DataSource = ConnecitonNameList.Split(',');
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine(comboBox1.SelectedItem.ToString());
            conn = SqlHelper.GetConnectionString(comboBox1.SelectedItem.ToString());
            BindTableNameList(conn, "");
        }

        private void BindTableNameList(string conn, string filter)
        {
            lvTableNames.Items.Clear();
            lvTableNames.Columns.Clear();
            string sql = string.Format("select name as 表名称 from  SysObjects where XType='U' and name like '%{0}%' order by Name",filter);
            DataTable dt = SqlHelper.ExecuteDataSet(conn, CommandType.Text, sql, null).Tables[0];
            Console.WriteLine(dt.Rows.Count);
            DataTableToListView(dt, lvTableNames);
            //listView1.View = View.Details;
            lvTableNames.Columns[0].Width = 200;
        }


        public static void DataTableToListView(DataTable dt, ListView lst)
        {
            for (int j = 0; j < dt.Columns.Count; j++)
            {
                lst.Columns.Add(dt.Columns[j].ColumnName);
            }

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                string[] rowdata = new string[dt.Columns.Count];
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    rowdata[j] = dr[j].ToString();
                }

                ListViewItem lvi = new ListViewItem(rowdata);
                lst.Items.Add(lvi);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = lvTableNames.HitTest(e.X, e.Y);
            if (info.Item != null)
            {
                //MessageBox.Show(info.Item.Text);
                DataTable dt = ShowColumnInfo(info.Item.Text);
                if (dt.Rows.Count > 0)
                {
                    lvColumnProperty.Items.Clear();
                    lvColumnProperty.Columns.Clear();
                    DataTableToListView(dt, lvColumnProperty);
                    lvColumnProperty.Columns[0].Width = 140;
                    lvColumnProperty.Columns[1].Width = 160;
                }
            }
        }

        private DataTable ShowColumnInfo(string tablename)
        {
            StringBuilder sb = new StringBuilder();
            //sb.Append(" SELECT ");
            ////sb.Append(" 表名 = case when a.colorder = 1 then d.name else '' end,");
            ////sb.Append(" 表说明 = case when a.colorder = 1 then isnull(f.value,'') else '' end,");
            ////sb.Append(" 字段序号 = a.colorder,");
            //sb.Append(" 字段名 = a.name,");
            //sb.Append(" 标识 = case when COLUMNPROPERTY(a.id, a.name,'IsIdentity')= 1 then '√'else '' end,");
            //sb.Append(" 主键 = case when exists(SELECT 1 FROM sysobjects where xtype = 'PK' and parent_obj = a.id and name in (");
            //sb.Append("     SELECT name FROM sysindexes WHERE indid in(SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid))) then '√' else '' end,");
            //sb.Append("         类型 = b.name,");
            //sb.Append("         占用字节数 = a.length,");
            //sb.Append("         长度 = COLUMNPROPERTY(a.id, a.name, 'PRECISION'),");
            //sb.Append("         小数位数 = isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0),");
            //sb.Append("         允许空 = case when a.isnullable = 1 then '√'else '' end,");
            //sb.Append("         默认值 = isnull(e.text, ''),");
            //sb.Append("         字段说明 = isnull(g.[value], '')");
            //sb.Append(" FROM");
            //sb.Append("     syscolumns a left join systypes b on a.xusertype = b.xusertype");
            //sb.Append("     inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'");
            //sb.Append("     left join syscomments e on a.cdefault = e.id");
            //sb.Append("     left join sys.extended_properties g on a.id = G.major_id and a.colid = g.minor_id");
            //sb.Append("     left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0");
            //sb.Append(" where");
            //sb.Append("     d.name = '" + tablename + "'--如果只查询指定表,加上此where条件，tablename是要查询的表名；去除where条件查询所有的表信息");
            //sb.Append(" order by");
            //sb.Append("     a.id,a.colorder");

            //K3表结构及字段说明
            sb.Append("select ");
            sb.Append("");
            sb.Append("    tt.字段名, j.FDescription as K3说明, tt.标识, tt.主键,");
            sb.Append("    tt.类型, tt.占用字节数, tt.长度, tt.小数位数, tt.允许空, tt.默认值");
            sb.Append(" from(");
            sb.Append("    select ");
            sb.Append("");
            sb.Append("        表名 = d.name,");
            sb.Append("        字段名 = a.name,");
            sb.Append("        标识 = case when COLUMNPROPERTY(a.id, a.name, 'IsIdentity') = 1 then '√'else '' end,");
            sb.Append("");
            sb.Append("        主键 = case when exists( ");
            sb.Append("            SELECT 1 FROM sysobjects where xtype = 'PK' and parent_obj = a.id and name in ( ");
            sb.Append("                SELECT name FROM sysindexes WHERE indid in(");
            sb.Append("                SELECT indid FROM sysindexkeys WHERE id = a.id AND colid = a.colid");
            sb.Append("                )");
            sb.Append("            )");
            sb.Append("        ) then '√' else '' end,");
            sb.Append("        类型 = b.name,");
            sb.Append("        占用字节数 = a.length,");
            sb.Append("        长度 = COLUMNPROPERTY(a.id, a.name, 'PRECISION'),");
            sb.Append("        小数位数 = isnull(COLUMNPROPERTY(a.id, a.name, 'Scale'), 0),");
            sb.Append("        允许空 = case when a.isnullable = 1 then '√'else '' end,");
            sb.Append("        默认值 = isnull(e.text, ''),");
            sb.Append("        字段说明 = isnull(g.[value], ''");
            sb.Append("    )");
            sb.Append("");
            sb.Append("    FROM    ");
            sb.Append("        syscolumns a left join systypes b on a.xusertype = b.xusertype");
            sb.Append("");
            sb.Append("        inner join sysobjects d on a.id = d.id and d.xtype = 'U' and d.name <> 'dtproperties'");
            sb.Append("");
            sb.Append("        left join syscomments e on a.cdefault = e.id");
            sb.Append("");
            sb.Append("        left join sys.extended_properties g on a.id = G.major_id and a.colid = g.minor_id");
            sb.Append("");
            sb.Append("        left join sys.extended_properties f on d.id = f.major_id and f.minor_id = 0");
            sb.Append("    ) as tt left join(    ");
            sb.Append("    SELECT");
            sb.Append("        t.FTableName, r.FFieldName, r.FDescription");
            sb.Append("    FROM");
            sb.Append("");
            sb.Append("        dbo.t_TableDescription t");
            sb.Append("");
            sb.Append("    INNER JOIN dbo.t_FieldDescription r ON t.FTableID = r.FTableID");
            sb.Append(" ) j on tt.表名 = j.FTableName and tt.字段名 = j.FFieldName");
            sb.Append(" where ");
            sb.Append("");
            sb.Append("    tt.表名 = '" + tablename + "'");

            return SqlHelper.ExecuteDataSet(conn, CommandType.Text, sb.ToString(),null).Tables[0];
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(lvColumnProperty.Items.Count > 0)
            {
                foreach (ListViewItem lvi in lvColumnProperty.Items)
                {
                    //列名字
                    string columnName = lvi.Text;
                    //数据类型
                    string dataType = Change2CSharpDataType(lvi.SubItems[4].Text);
                    //是否为空
                    string nullable = lvi.SubItems[8].Text == "" || (lvi.SubItems[8].Text != "" && dataType.ToLower() == "string") ? "" : "?";
                    //描述
                    string columndesc = lvi.SubItems[1].Text;
                    //默认值
                    string defaultValue = lvi.SubItems[9].Text;
                    //主键列
                    bool IsPrimaryKey = lvi.SubItems[3].Text == "" ? false : true;
                    //自增列
                    bool IsAutoIncrement = lvi.SubItems[2].Text == "" ? false : true;
                    //时间戳
                    bool IsTimeStamp = dataType.ToLower() == "timespan" ? true : false;

                    if (IsPrimaryKey) Console.WriteLine("[PrimaryKey]");
                    if (IsAutoIncrement) Console.WriteLine("[AutoIncrement]");
                    if (IsTimeStamp) Console.WriteLine("[TimeSpan]");
                    //Console.WriteLine(string.Format("[Column(ColumnName=\"{0}\", ColumnDesc=\"{1}\", DataType=\"{2}\", DefaultValue=\"{3}\", IsPrimaryKey={4}, IsAutoIncrement={5},IsTimeStamp={6})]", columnName,columndesc,dataType,defaultValue,IsPrimaryKey,IsAutoIncrement,IsTimeStamp));
                    Console.WriteLine("/// </summary>");
                    Console.WriteLine("/// " + string.Format("描述:\"{0}\"", columndesc));
                    Console.WriteLine("/// " + string.Format("数据类型:\"{0}\"", dataType));
                    Console.WriteLine("/// " + string.Format("默认值:\"{0}\"", defaultValue));
                    Console.WriteLine("/// </summary>");
                    //时间戳列不能为空
                    if (IsTimeStamp)
                    {
                        Console.WriteLine("public " + dataType + " " + columnName + " {get; set;}");
                    }
                    else
                    {
                        Console.WriteLine("public " + dataType + nullable + " " + columnName + " {get; set;}");
                    }
                    //KIS不用处理时间戳列
                    //if (lvi.SubItems[4].Text.ToLower() != "timestamp")
                    //{
                    //    Console.WriteLine("public " + dataType + nullable + " " + columnName + " {get; set;}");
                    //}
                    //else
                    //{
                    //    Console.WriteLine("///public " + dataType + nullable + " " + columnName + " {get; set;}");
                    //}
                    Console.WriteLine("");
                }
            }
        }

        /// <summary>
        /// 数据库中与c#中的数据类型对照
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        private string Change2CSharpDataType(string type)
        {
            string reval = string.Empty;
            switch (type.ToLower())
            {
                case "int":
                    reval = "Int32";
                    break;
                case "text":
                    reval = "string";
                    break;
                case "bigint":
                    reval = "Int64";
                    break;
                case "binary":
                    reval = "Byte[]";
                    break;
                case "bit":
                    reval = "bool";
                    break;
                case "char":
                    reval = "string";
                    break;
                case "datetime":
                    reval = "DateTime";
                    break;
                case "decimal":
                    reval = "decimal";
                    break;
                case "float":
                    reval = "Double";
                    break;
                case "image":
                    reval = "Byte[]";
                    break;
                case "money":
                    reval = "decimal";
                    break;
                case "nchar":
                    reval = "string";
                    break;
                case "ntext":
                    reval = "string";
                    break;
                case "numeric":
                    reval = "decimal";
                    break;
                case "nvarchar":
                    reval = "string";
                    break;
                case "real":
                    reval = "Single";
                    break;
                case "smalldatetime":
                    reval = "DateTime";
                    break;
                case "smallint":
                    reval = "Int16";
                    break;
                case "smallmoney":
                    reval = "decimal";
                    break;
                case "timestamp":
                    reval = "Byte[]";
                    break;
                case "tinyint":
                    reval = "Byte";
                    break;
                case "uniqueidentifier":
                    reval = "Guid";
                    break;
                case "varbinary":
                    reval = "Byte[]";
                    break;
                case "varchar":
                    reval = "string";
                    break;
                case "variant":
                    reval = "object";
                    break;
                default:
                    reval = "string";
                    break;
            }
            return reval;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            BindTableNameList(conn,textBox2.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            frmCreateConnection form = new frmCreateConnection();
            //form.ShowDialog.DialogResult;
            if (form.ShowDialog() == DialogResult.OK)
            {
                //保存连接信息
                string connectionName = form.connectionName;
                string connectionString = EncryptHelper.Encrypt(string.Format("Data Source={0};Initial Catalog={1};User ID={2};Password={3};", form.serverName, form.dbName, form.userName, form.password));
                string provide = "System.Data.SqlClient";
                Console.WriteLine(string.Format("ConnectionName\":\"{0}\", \"ConnectionString\":\"DataSource={1};Initial Catalog={2};User ID={3};Password={4};\"", form.connectionName, form.serverName, form.dbName, form.userName, form.password));
                ConfigHelper.UpdateOrCreateConnectionString(ConfigurationFile.AppConfig, connectionName, connectionString, provide);
                string ConnecitonNameList = "请选择," + ConfigHelper.GetConnectionNameList(ConfigurationFile.AppConfig);
                comboBox1.DataSource = ConnecitonNameList.Split(',');
                form.Close();
            }
            
        }
    }
}