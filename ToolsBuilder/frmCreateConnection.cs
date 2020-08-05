using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToolsBuilder
{
    public partial class frmCreateConnection : Form
    {
        public frmCreateConnection()
        {
            InitializeComponent();
        }

        public string connectionName { get; set; }
        public string serverName { get; set; }
        public string dbName { get; set; }
        public string userName { get; set; }
        public string password { get; set; }
        public DBType dbType { get; set; }

        private void button1_Click(object sender, EventArgs e)
        {
            connectionName = textBox1.Text;
            serverName = textBox2.Text;
            dbName = textBox3.Text;
            userName = textBox4.Text;
            password = textBox5.Text;
            dbType = (DBType)Enum.Parse(typeof(DBType), comboBox1.SelectedItem.ToString());
        }

        public enum DBType
        {
            Oracle_MySQL_56 = 10,
            Oracle_MySQL_57 = 11,
            Oracle_MySQL_80 = 12,
            Microsoft_SQL_Server_2000 = 0,
            Microsoft_SQL_Server_2005 = 1,
            Microsoft_SQL_Server_2008 = 2,
            Microsoft_SQL_Server_2012 = 3,
            Microsoft_SQL_Server_2016 = 4,
            Microsoft_SQL_Server_2019 = 5,
        }

        private void frmCreateConnection_Load(object sender, EventArgs e)
        {
            comboBox1.Items.AddRange(Enum.GetNames(typeof(DBType)));
        }
    }
}
