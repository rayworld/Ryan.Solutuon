﻿using DevComponents.DotNetBar;
using Ryan.Framework.DotNetFx40.Config;
using System;
using System.Windows.Forms;

namespace EAS2WISE
{
    public partial class FormLogin : Office2007Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        #region 属性
        public string UserName { get; set; }
        public int UserId { get; set; }
        #endregion

        #region 事件
        /// <summary>
        /// 窗口启动事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FORM_Login_Load(object sender, EventArgs e)
        {
            this.EnableGlass = false;
            styleManager1.ManagerStyle = (eStyle)Enum.Parse(typeof(eStyle), ConfigHelper.ReadValueByKey(ConfigHelper.ConfigurationFile.AppConfig, "FormStyle"));
            txtUserName.Text = "Administrator";
            txtPassword.Text = "kingdee";
            txtPassword.PasswordChar = '*';
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }

        /// <summary>
        /// 用户登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOK_Click(object sender, EventArgs e)
        {
            //if (UserLogin(txtUserName.Text, txtPassword.Text) == true)
            //{
            //    this.DialogResult = System.Windows.Forms.DialogResult.OK;
            //    this.Close();
            //}
            //else
            //{
            //    this.DialogResult = System.Windows.Forms.DialogResult.None;
            //    CustomDesktopAlert.H4("账号或密码错误，请重新输入!");
            //}
        }

        /// <summary>
        /// 用户取消登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        /// <summary>
        /// 
        /// </summary>
        /// <param name="UserName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        private bool UserLogin(string UserName, string password)
        {
            //bool retVal = false;
            //T_User t_user = new T_User();
            //int fUserId = t_user.Login(UserName,password);
            //if(fUserId != 0  && !string.IsNullOrEmpty(UserName))
            //{
            //    this.UserName = UserName;
            //    this.UserId = fUserId;
            //    retVal = true;
            //}
            bool retVal = true;
            return retVal;
        }  
    }
}
