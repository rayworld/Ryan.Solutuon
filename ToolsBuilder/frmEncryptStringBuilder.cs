using Ryan.Framework.DotNetFx40.Encrypt;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Builder
{
    public partial class frmEncryptStringBuilder : Form
    {
        public frmEncryptStringBuilder()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox2.Text=="")
            {
                textBox2.Text = EncryptHelper.Encrypt(textBox1.Text);
            }
            else
            {
                textBox1.Text = EncryptHelper.Decrypt(textBox2.Text);
            }
        }
    }
}
