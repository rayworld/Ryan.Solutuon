using Aohua.DAL;
using Aohua.K3.Models;
using DevComponents.DotNetBar;
using DevComponents.DotNetBar.Controls;
using Ryan.Framework.DotNetFx40.Converter;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace Aohua.VoucherApp
{
    public partial class FormVoucherImport : Office2007Form
    {
        CheckBox HeaderCheckBox = null;

        public FormVoucherImport()
        {
            InitializeComponent();

            if (!this.DesignMode)
            {
                HeaderCheckBox = new CheckBox
                {
                    Size = new Size(15, 15)
                };
                DataGridViewXDetail.Controls.Add(HeaderCheckBox);

                HeaderCheckBox.KeyUp += new KeyEventHandler(HeaderCheckBox_KeyUp);
                HeaderCheckBox.MouseClick += new MouseEventHandler(HeaderCheckBox_MouseClick);
                DataGridViewXDetail.CurrentCellDirtyStateChanged += new EventHandler(DgvSelectAll_CurrentCellDirtyStateChanged);
                DataGridViewXDetail.CellPainting += new DataGridViewCellPaintingEventHandler(DgvSelectAll_CellPainting);
            }

        }


        //导入的Excel文件名称
        private static string ExcelFileName = "";

        //导入的Excel文件工作簿名称
        private static string SheetName = "Sheet1";

        private static DataTable dtFilter = new DataTable(), 
            dtVoucherEntries = new DataTable(), 
            dtVoucher = new DataTable(), 
            dtInvoiceDetail = new DataTable();

        //凭证ID
        private static int VoucherID = 0;
        
        //借方、贷方汇总
        private static decimal CreditTotal, 
            DebitTotal;
        
        //记录数据过滤结果
        private static string AreaFilter, 
            TaxRateFilter;

        private static string CustArea;

        #region 窗体事件


        private void HeaderCheckBox_MouseClick(object sender, MouseEventArgs e)
        {
            HeaderCheckBoxClick((CheckBox)sender);
        }

        private void DgvSelectAll_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DataGridViewXDetail.CurrentCell is DataGridViewCheckBoxCell)
                DataGridViewXDetail.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        private void DgvSelectAll_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1 && e.ColumnIndex == 0)
                ResetHeaderCheckBoxLocation(e.ColumnIndex, e.RowIndex);
        }

        private void ResetHeaderCheckBoxLocation(int ColumnIndex, int RowIndex)
        {
            Rectangle oRectangle = this.DataGridViewXDetail.GetCellDisplayRectangle(ColumnIndex, RowIndex, true);
            Point oPoint = new Point
            {
                X = oRectangle.Location.X + (oRectangle.Width - HeaderCheckBox.Width) / 2 + 1,
                Y = oRectangle.Location.Y + (oRectangle.Height - HeaderCheckBox.Height) / 2 + 1
            };
            HeaderCheckBox.Location = oPoint;
        }


        private void HeaderCheckBoxClick(CheckBox HCheckBox)
        {
            foreach (DataGridViewRow Row in DataGridViewXDetail.Rows)
            {
                Row.Cells["chkSelect"].Value = HCheckBox.Checked;
            }
            DataGridViewXDetail.RefreshEdit();
        }

        private void HeaderCheckBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
                HeaderCheckBoxClick((CheckBox)sender);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormVoucheImport_Load(object sender, EventArgs e)
        {
            DateTime ServerTime = Vouchers.GetServerTime();
            if(ServerTime > DateTime.Parse("2024-10-01"))
            {
                this.ButtonXImportExcelNew.Enabled = false;
                this.ButtonXStatistics.Enabled = false;
                this.ButtonXCreateVoucher.Enabled = false;

            }
            else
            {
                BindComboBox(ComboBoxVoucherGroup);
                BindComboBox(ComboBoxExPreparerID);
            }

        }

        private void DataGridViewXStatic_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                               dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font,
                rect, e.InheritedRowStyle.ForeColor,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter
                );
            }
        }

        private void DataGridViewXDetail_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dgv = (DataGridView)sender;
            if (dgv.RowHeadersVisible)
            {
                Rectangle rect = new Rectangle(e.RowBounds.Left, e.RowBounds.Top,
                               dgv.RowHeadersWidth, e.RowBounds.Height);
                rect.Inflate(-2, -2);
                TextRenderer.DrawText(e.Graphics,
                (e.RowIndex + 1).ToString(),
                e.InheritedRowStyle.Font,
                rect, e.InheritedRowStyle.ForeColor,
                TextFormatFlags.Right | TextFormatFlags.VerticalCenter
                );
            }
        }

        private void DataGridViewXStatic_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //CustomDesktopAlert.H2(DataGridViewXStatic.Rows[e.RowIndex].Cells["购方企业名称"].Value.ToString());
            if (e.RowIndex >= 0)
            {
                string CustName = DataGridViewXStatic.Rows[e.RowIndex].Cells["购方企业名称"].Value.ToString();
                string CustAddress = DataGridViewXStatic.Rows[e.RowIndex].Cells["地址电话"].Value.ToString();
                string CustArea = DataGridViewXStatic.Rows[e.RowIndex].Cells["分公司"].Value.ToString();

                FormCustomNumberSelecterV2 form = new FormCustomNumberSelecterV2(CustName, CustAddress, CustArea)
                {
                    StartPosition = FormStartPosition.CenterParent
                };
                if (form.ShowDialog() == DialogResult.OK)
                {
                    DataGridViewXStatic.Rows[e.RowIndex].Cells["AccountID"].Value = form.AccountID;
                    DataGridViewXStatic.Rows[e.RowIndex].Cells["ItemClassID"].Value = form.ItemClassID;
                    DataGridViewXStatic.Rows[e.RowIndex].Cells["CustomID"].Value = form.CustomID;
                }

            }
            else
            {
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonXCreateVoucher_Click(object sender, System.EventArgs e)
        {
            //重新分组汇总
            DataTable dttemp = GetDgvToTable(DataGridViewXStatic);

            //处理十进制列类型转换
            dttemp.Columns.Add(new DataColumn("开票金额1", System.Type.GetType("System.Decimal")));
            foreach (DataRow dr in dttemp.Rows)
            {
                dr["开票金额1"] = Decimal.Parse(dr["开票金额"].ToString()); 
            }

            dttemp = FilterData(dttemp, "AccountID <> ''");

            //dtInvoiceDetail = dtInvoiceDetail.DefaultView.ToTable(false, new string[] { "发票号码", "购方企业名称", "地址电话", "商品名称", "金额1", "税额1", "开票金额", "税率", "分公司" });


            //处理发票汇总表
            var query = from t in dttemp.AsEnumerable()
                        group t by new
                        {
                            t1 = t.Field<string>("ReceiptID"),
                            t2 = t.Field<string>("AccountID"),
                            t3 = t.Field<string>("ItemClassID"),
                            t4 = t.Field<string>("CustomID"),
                            t5 = t.Field<string>("购方企业名称"),
                            t6 = t.Field<string>("地址电话"),
                            t7 = t.Field<string>("分公司")
                        } into m
                        select new
                        {
                            发票号= m.Key.t1,
                            科目号 = m.Key.t2,
                            客户类型号 = m.Key.t3,
                            客户号 = m.Key.t4,
                            购方企业名称 = m.Key.t5,
                            地址电话 = m.Key.t6,
                            分公司 = m.Key.t7,
                            开票金额 = m.Sum(n => n.Field<decimal>("开票金额1"))
                        };
            query = query.OrderBy(x => x.科目号).ThenBy(x => x.客户类型号).ThenBy(x => x.客户号);
            DataTable dt1 = IEnumerable2DataTable(query);
            DataGridViewXStatic.DataSource = dt1;
            for(int i = 0; i< DataGridViewXStatic.Columns.Count;i++)
            {
                //CustomDesktopAlert.H2(dc.Name);
                if (DataGridViewXStatic.Columns[i].Name == "AccountID")
                {
                    DataGridViewXStatic.Columns.RemoveAt(i);
                }

                if (DataGridViewXStatic.Columns[i].Name == "CustomID")
                {
                    DataGridViewXStatic.Columns.RemoveAt(i);
                }

                if (DataGridViewXStatic.Columns[i].Name == "ItemClassID")
                {
                    DataGridViewXStatic.Columns.RemoveAt(i);
                }

                if (DataGridViewXStatic.Columns[i].Name == "ReceiptID")
                {
                    DataGridViewXStatic.Columns.RemoveAt(i);
                }
            }
            InsertVoucher(dtVoucher);
            //Insert VoucherEntries
            InsertVoucherEntries(dt1);

            InsertVoucherEntriesV2(dtFilter);

        }

        private void ButtonXImportExcelNew_Click(object sender, EventArgs e)
        {
            //打开Excel
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "c:\\",//注意这里写路径时要用c:\\而不是c:\
                Filter = "Excel97-2003文本文件|*.xls|Excel 2007文件|*.xlsx|所有文件|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                ExcelFileName = dialog.FileName;
            }
            else
            {
                return;
            }

            if (!string.IsNullOrEmpty(ExcelFileName))
            {
                ShowInvoiceDetail();
            }
        }

        #endregion

        #region 私有过程



        /// <summary>
        /// 匹配数据记录
        /// </summary>
        private void CheckData()
        {
            foreach (DataGridViewRow dr in DataGridViewXStatic.Rows)
            {

                //dr.Cells["AccountID"].Value = dr.Cells["购方企业名称"].Value.ToString();
                string custName = dr.Cells["购方企业名称"].Value.ToString();
                string custAddress = dr.Cells["地址电话"].Value.ToString().Trim();
                custAddress = GetNumPosition(custAddress) > 0 ? custAddress.Substring(0, GetNumPosition(custAddress)) : custAddress;
                string area = dr.Cells["分公司"].Value.ToString();
                string itemid = DAL.VoucherEntries.GetItemIDItemClassIDByCustomNameCustomAddressCustomArea(custName, custAddress, area);
                dr.Cells["CustomID"].Value = itemid != "-1" ? itemid.Split(',')[0] : "";
                dr.Cells["ItemClassID"].Value = itemid != "-1" ? itemid.Split(',')[1] : "";
                string accountid = itemid != "-1" ? DAL.VoucherEntries.GetAccountIDByItemClassID(dr.Cells["ItemClassID"].Value.ToString()) : "";
                dr.Cells["AccountID"].Value = accountid != "-1" ? accountid : "";
                //填入发票号
                dr.Cells["ReceiptID"].Value = GetReceiptNoByCustName(custName);
            }
        }

        private static string GetReceiptNoByCustName(string CustName)
        {
            string retVal = "";

            DataTable dt333 = FilterData(dtFilter, "购方企业名称 = '" + CustName + "'");
            if(dt333.Rows.Count>0)
            {
                for (int i = 0; i < dt333.Rows.Count; i++)
                {
                    retVal += "#" + dt333.Rows[i]["发票号码"].ToString() + ";";
                }
            }

            return retVal.Substring(0, retVal.Length - 1);
        }

        /// <summary>
        /// 绑定Combo控件
        /// </summary>
        /// <param name="combobox"></param>
        private static void BindComboBox(ComboBoxEx combobox)
        {
            switch(combobox.Name)
            {
                case "ComboBoxVoucherGroup":
                    combobox.DataSource = VoucherGroups.BindComboBoxVoucherGroupDataV2();
                    combobox.DisplayMember = "FName";
                    combobox.ValueMember = "FGroupID";
                    break;
                case "ComboBoxExPreparerID":
                    combobox.DataSource = VoucherGroups.BindComboBoxPreparerIDData();
                    combobox.DisplayMember = "FName";
                    combobox.ValueMember = "FUserID";
                    break;
                default:
                    break;
            }

            //设置默认值
            if (combobox.DataSource != null)
            {
                combobox.SelectedIndex = 0;
            }
            else
            {
                //DataSource为空
            }
        }


        /// <summary>
        /// 得到第一个数字在字符串中的位子
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static int GetNumPosition(string input)
        {
            if (string.IsNullOrEmpty(input))
                return -1;
            for (int i = 0; i < input.Length; i++)
                if (char.IsDigit(input[i]))
                    return i;
            return -1;
        }

        private void ShowInvoiceStatistics(DataTable dtstat)
        {
            //处理发票汇总表
            var query = from t in dtstat.AsEnumerable()
                        group t by new
                        {
                            t2 = t.Field<string>("购方企业名称"),
                            t3 = t.Field<string>("地址电话"),
                            t4 = t.Field<string>("分公司")
                        } into m
                        select new
                        {
                            购方企业名称 = m.Key.t2,
                            地址电话 = m.Key.t3,
                            分公司 = m.Key.t4,
                            金额 = m.Sum(n => n.Field<decimal>("金额1")),
                            税额 = m.Sum(n => n.Field<decimal>("税额1")),
                            开票金额 = m.Sum(n => n.Field<decimal>("开票金额"))
                        };
            query = query.OrderBy(x => x.分公司).ThenBy(x => x.购方企业名称).ThenBy(x => x.地址电话);

            DataGridViewXStatic.DataSource = query.ToList();
            DataGridViewXStatic.Columns["购方企业名称"].Width = 400;
            DataGridViewXStatic.Columns["地址电话"].Width = 600;
            DataGridViewXStatic.Columns["金额"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewXStatic.Columns["税额"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
            DataGridViewXStatic.Columns["开票金额"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

            DataGridViewXStatic.Columns.Add(new DataGridViewColumn()
            {
                Name = "AccountID",
                HeaderText = "科目ID",
                CellTemplate = new DataGridViewTextBoxCell()
            });
            DataGridViewXStatic.Columns.Add(new DataGridViewColumn()
            {
                Name = "CustomID",
                HeaderText = "客户ID",
                CellTemplate = new DataGridViewTextBoxCell()
            });
            DataGridViewXStatic.Columns.Add(new DataGridViewColumn()
            {
                Name = "ItemClassID",
                HeaderText="客户类型ID",
                CellTemplate = new DataGridViewTextBoxCell()
            });
            DataGridViewXStatic.Columns.Add(new DataGridViewColumn()
            {
                Name = "ReceiptID",
                HeaderText = "发票号",
                CellTemplate = new DataGridViewTextBoxCell()
            });
        }

        private void ShowInvoiceDetail()
        {
            //处理发票明细表
            //将明细表导入成DataTable
            dtInvoiceDetail = ToDataTable.Excel2DataTable(ExcelFileName, SheetName, "*", "");
            //如果DataTable不为空
            if (dtInvoiceDetail.Rows.Count > 0)
            {
                //删除“小计行”，可以只判断是不是“小计”
                for (int i = 0; i < dtInvoiceDetail.Rows.Count; i++)
                {
                    if (dtInvoiceDetail.Rows[i]["商品名称"].ToString() != "*建筑服务*装修" && dtInvoiceDetail.Rows[i]["商品名称"].ToString() != "*设计服务*设计费")
                    {
                        dtInvoiceDetail.Rows[i].Delete();
                    }
                }
                dtInvoiceDetail.AcceptChanges();
                
                //填充空行信息
                for (int j = 0; j < dtInvoiceDetail.Rows.Count; j++)
                {
                    if (dtInvoiceDetail.Rows[j]["发票代码"].ToString() == "")
                    {
                        dtInvoiceDetail.Rows[j]["发票号码"] = dtInvoiceDetail.Rows[j - 1]["发票号码"].ToString();
                        dtInvoiceDetail.Rows[j]["购方企业名称"] = dtInvoiceDetail.Rows[j - 1]["购方企业名称"].ToString();
                        dtInvoiceDetail.Rows[j]["地址电话"] = dtInvoiceDetail.Rows[j - 1]["地址电话"].ToString();
                        //dtInvoiceDetail.Rows[j]["商品名称"] = dtInvoiceDetail.Rows[j - 1]["商品名称"].ToString();
                        //dtInvoiceDetail.Rows[j]["税率"] = dtInvoiceDetail.Rows[j - 1]["税率"].ToString();
                    }
                }
            
                //数据列类型转换
                dtInvoiceDetail.Columns.Add(new DataColumn("金额1", System.Type.GetType("System.Decimal")));
                dtInvoiceDetail.Columns.Add(new DataColumn("税额1", System.Type.GetType("System.Decimal")));
                dtInvoiceDetail.Columns.Add(new DataColumn("开票金额", System.Type.GetType("System.Decimal")));
                dtInvoiceDetail.Columns.Add(new DataColumn("分公司", System.Type.GetType("System.String")));
                DataGridViewCheckBoxColumn checkBoxColumn = new DataGridViewCheckBoxColumn
                {
                    Name = "chkSelect",
                    HeaderText = "选择"
                };
                this.DataGridViewXDetail.Columns.Insert(0, checkBoxColumn);

                foreach (DataRow dr in dtInvoiceDetail.Rows)
                {
                    dr["金额1"] = Decimal.Parse(dr["金额"].ToString());
                    dr["税额1"] = Decimal.Parse(dr["税额"].ToString());
                    dr["开票金额"] = Decimal.Parse(dr["金额"].ToString()) + Decimal.Parse(dr["税额"].ToString());
                    dr["分公司"] = dr["地址电话"].ToString().EndsWith("H") ? "汉口" : dr["地址电话"].ToString().EndsWith("Y") ? "汉阳" : dr["地址电话"].ToString().EndsWith("W") ? "武昌" : "工装";
                    dr["地址电话"] = dr["地址电话"].ToString().Replace("******** H", "").Replace("****** H", "").Replace("******** W", "").Replace("****** W", "").Replace("******** Y", "").Replace("****** Y", "").Trim();
                }
                dtInvoiceDetail = dtInvoiceDetail.DefaultView.ToTable(false, new string[] { "发票号码", "购方企业名称", "地址电话", "商品名称", "金额1", "税额1", "开票金额", "税率", "分公司" });
                DataGridViewXDetail.DataSource = dtInvoiceDetail;

                DataGridViewXDetail.Columns["购方企业名称"].Width = 400;
                DataGridViewXDetail.Columns["商品名称"].Width = 200;
                DataGridViewXDetail.Columns["地址电话"].Width = 600;
                DataGridViewXDetail.Columns["金额1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DataGridViewXDetail.Columns["税额1"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;
                DataGridViewXDetail.Columns["开票金额"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight;

                for (int i = 0; i < dtInvoiceDetail.Rows.Count; i++)
                {
                    DebitTotal += decimal.Parse(dtInvoiceDetail.Rows[i]["开票金额"].ToString());
                    CreditTotal += decimal.Parse(dtInvoiceDetail.Rows[i]["金额1"].ToString()) + decimal.Parse(dtInvoiceDetail.Rows[i]["税额1"].ToString());
                }

                dtFilter = BindDetailData();
            }
            else
            {
                Ryan.Framework.DotNetFx40.Common.CustomDesktopAlert.H2("加载Excel数据失败！");
            }

        }

        /// <summary>
        /// 过滤不同单据类型
        /// </summary>
        /// <param name="dt">Excel 数据表</param>
        /// <param name="where">条件</param>
        /// <returns></returns>
        private static DataTable FilterData(DataTable dt, string where)
        {
            DataRow[] rows = dt.Select(where);
            DataTable tmpdt = dt.Clone();
            foreach (DataRow row in rows)  // 将查询的结果添加到tempdt中； 
            {
                tmpdt.Rows.Add(row.ItemArray);
            }
            return tmpdt;
        }

        public static DataTable IEnumerable2DataTable<T>(IEnumerable<T> collection)
        {
            var props = typeof(T).GetProperties();
            var dt = new DataTable();
            dt.Columns.AddRange(props.Select(p => new DataColumn(p.Name, p.PropertyType)).ToArray());
            if (collection.Count() > 0)
            {
                for (int i = 0; i < collection.Count(); i++)
                {
                    ArrayList tempList = new ArrayList();
                    foreach (PropertyInfo pi in props)
                    {
                        object obj = pi.GetValue(collection.ElementAt(i), null);
                        tempList.Add(obj);
                    }
                    object[] array = tempList.ToArray();
                    dt.LoadDataRow(array, true);
                }
            }
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtVoucherties"></param>
        /// <returns></returns>
        private static int InsertVoucherEntries(DataTable dt1)
        {
            int retVal = 0;

            for (int i = 0; i < dt1.Rows.Count; i++)
            {
                int AccountID = int.Parse(dt1.Rows[i]["科目号"].ToString());
                string AccountName = VoucherEntries.GetAccountNameByAccountID(AccountID);
                int AccountID2 = AccountName.EndsWith("10%") ? 27352 : AccountName.EndsWith("11%") ? 27196 : AccountName.EndsWith("6%") ? 27197 : 27195;
                decimal Amount = decimal.Parse(dt1.Rows[i]["开票金额"].ToString());
                int ItemClassID = int.Parse(dt1.Rows[i]["客户类型号"].ToString());
                int CustomID = int.Parse(dt1.Rows[i]["客户号"].ToString());
                int DetailID = GetDetailID(ItemClassID, CustomID);
                CustArea = dt1.Rows[i]["分公司"].ToString();
                string Explanation = CustArea + "公司预收账转收入" + dt1.Rows[i]["发票号"].ToString();

                VoucherEntry voucherEntry = new VoucherEntry()
                {
                    FAccountID = AccountID,
                    FAccountID2 = AccountID2,
                    FAmount = Amount,
                    FAmountFor = Amount,
                    FBrNo = "",
                    FCashFlowItem = 0,
                    FCurrencyID = 1,
                    FDC = 1,
                    FDetailID = DetailID,
                    FEntryID = i,
                    FExchangeRate = 1,
                    FExplanation = Explanation,
                    FInternalInd = "AutoTrans",
                    FMeasureUnitID = 0,
                    FQuantity = 0,
                    FResourceID = 0,
                    FSettleNo = "",
                    FSettleTypeID = 0,
                    FTaskID = 0,
                    FTransNo = null,
                    FUnitPrice = 0,
                    FVoucherID = VoucherID
                };
                BaseDAL.Insert<VoucherEntry>(voucherEntry);
            }
            return retVal;
        }

        private void ComboBoxExTaxRate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboBoxExTaxRate.SelectedIndex >= 0)
            {
                TaxRateFilter = string.Format(" 税率 = '{0}'", ComboBoxExTaxRate.SelectedItem.ToString());
                dtFilter = BindDetailData();
                DataGridViewXDetail.DataSource = dtFilter;
            }
        }

        private void ComboBoxExArea_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ComboBoxExArea.SelectedIndex >= 0)
            {
                AreaFilter = string.Format(" 分公司 ='{0}'",ComboBoxExArea.SelectedItem.ToString());
                dtFilter = BindDetailData();
                DataGridViewXDetail.DataSource = dtFilter;
            }
        }

        private void ButtonXStatistics_Click(object sender, EventArgs e)
        {
            TabItemStatistics.Visible = true;
            tabControl1.SelectedTab = TabItemStatistics;
            //得到选中的行
            dtFilter = FilterSelectData(dtFilter);
            this.DataGridViewXDetail.DataSource = dtFilter;
            ShowInvoiceStatistics(dtFilter);
            //附加ItemID，AccountID，ItemClassID，发票号
            CheckData();
        }

        private DataTable FilterSelectData(DataTable dt222)
        {
            DataTable dtRetVal = dt222.Clone();
            dtRetVal.Rows.Clear();
            for (int i = 0; i < DataGridViewXDetail.Rows.Count; i++)
            {
                DataGridViewCheckBoxCell checkCell = (DataGridViewCheckBoxCell)DataGridViewXDetail.Rows[i].Cells["chkSelect"];
                Boolean flag = Convert.ToBoolean(checkCell.Value);
                if (flag == true)
                {
                    DataRow dr = dtRetVal.NewRow();
                    dr["发票号码"] = DataGridViewXDetail.Rows[i].Cells["发票号码"].Value.ToString();
                    dr["购方企业名称"] = DataGridViewXDetail.Rows[i].Cells["购方企业名称"].Value.ToString();
                    dr["地址电话"] = DataGridViewXDetail.Rows[i].Cells["地址电话"].Value.ToString();
                    dr["商品名称"] = DataGridViewXDetail.Rows[i].Cells["商品名称"].Value.ToString();
                    dr["金额1"] = decimal.Parse(DataGridViewXDetail.Rows[i].Cells["金额1"].Value.ToString());
                    dr["税率"] = DataGridViewXDetail.Rows[i].Cells["税率"].Value.ToString();
                    dr["税额1"] = decimal.Parse(DataGridViewXDetail.Rows[i].Cells["税额1"].Value.ToString());
                    dr["开票金额"] = decimal.Parse(DataGridViewXDetail.Rows[i].Cells["开票金额"].Value.ToString());
                    dr["分公司"] = DataGridViewXDetail.Rows[i].Cells["分公司"].Value.ToString();
                    dtRetVal.Rows.Add(dr);
                }
            }
            dtRetVal.DefaultView.Sort = "[购方企业名称]";//按Id倒序和Name倒序
            dtRetVal = dtRetVal.DefaultView.ToTable();//返回一个新的DataTable
            DataGridViewXDetail.DataSource = dtRetVal;
            return dtRetVal;
        }

        private static DataTable BindDetailData()
        {
            string DataFilter = "";
            if (! string.IsNullOrEmpty(AreaFilter) && !string.IsNullOrEmpty(TaxRateFilter))
            {
                DataFilter = AreaFilter + " And " + TaxRateFilter;
            }
            else if (string.IsNullOrEmpty(AreaFilter) && !string.IsNullOrEmpty(TaxRateFilter))
            {
                DataFilter = TaxRateFilter;
            }
            else if (!string.IsNullOrEmpty(AreaFilter) && string.IsNullOrEmpty(TaxRateFilter))
            {
                DataFilter = AreaFilter;
            }
            else
            {
                DataFilter = "";
            }
            return FilterData(dtInvoiceDetail, DataFilter);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="AccountID"></param>
        /// <param name="AccountID2"></param>
        /// <param name="Amount"></param>
        /// <param name="EntryID"></param>
        /// <param name="Explanation"></param>
        private static void InsertV2(int AccountID,int AccountID2, string SumColumn, DataTable dt000, string CustArea)
        {
            decimal Amount = decimal.Parse(dt000.Compute("sum(" + SumColumn + ")", "true").ToString());
            int EntryID = VoucherEntries.GetMaxEntryID(VoucherID);

            VoucherEntry voucherEntry = new VoucherEntry()
            {
                FAccountID = AccountID,
                FAccountID2 = AccountID2,
                FAmount = Amount,
                FAmountFor = Amount,
                FBrNo = "",
                FCashFlowItem = 0,
                FCurrencyID = 1,
                FDC = 0,
                FDetailID = 0,
                FEntryID = EntryID,
                FExchangeRate = 1,
                FExplanation = CustArea + "公司预收账转收入",
                FInternalInd = "",
                FMeasureUnitID = 0,
                FQuantity = 0,
                FResourceID = 0,
                FSettleNo = "",
                FSettleTypeID = 0,
                FTaskID = 0,
                FTransNo = null,
                FUnitPrice = 0,
                FVoucherID = VoucherID
            };
            BaseDAL.Insert<VoucherEntry>(voucherEntry);
        }

        /// <summary>
        /// 得到第一条记录的AccountID2
        /// </summary>
        /// <param name="custName">购方企业名称</param>
        /// <param name="custAdress">地址电话</param>
        /// <returns>AccountID</returns>
        private int GetAccountID2ByCustNameCustAddress(string custName,string custAdress)
        {
            int retVal = 0;
            foreach(DataGridViewRow dr in DataGridViewXStatic.Rows)
            {
                if (dr.Cells["购方企业名称"].Value.ToString() == custName && dr.Cells["地址电话"].Value.ToString() == custAdress)
                {
                    retVal = int.Parse(dr.Cells["科目号"].Value.ToString());
                }
            }
            return retVal;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtVoucherties"></param>
        /// <returns></returns>
        private void InsertVoucherEntriesV2(DataTable dtFilted)
        {
            //收入 "税率 = '3%'"
            DataTable dt0 = FilterData(dtFilted, "税率 = '3%'");
            if (dt0.Rows.Count > 0)
            {
                string custName = dt0.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt0.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName,custAddress);
                InsertV2(4396, accountID2, "金额1", dt0, CustArea);
            }

            //收入 "税率 = '6%'"
            DataTable dt1 = FilterData(dtFilted, "税率 = '6%'");
            if (dt1.Rows.Count > 0)
            {
                string custName = dt1.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt1.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27190, accountID2, "金额1",dt1, CustArea);
            }

            //收入 "税率 = '9%'"
            DataTable dt2 = FilterData(dtFilted, "税率 = '9%'");
            if (dt2.Rows.Count > 0)
            {
                string custName = dt2.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt2.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27412, accountID2, "金额1",dt2, CustArea);
            }

            //收入 "税率 = '10%'"
            DataTable dt3 = FilterData(dtFilted, "税率 = '10%'");
            if(dt3.Rows.Count > 0)
            {
                string custName = dt3.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt3.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27357, accountID2, "金额1",dt3, CustArea);
            }

            //收入 "税率 = '11%'"
            DataTable dt8 = FilterData(dtFilted, "税率 = '11%'");
            if (dt8.Rows.Count > 0)
            {
                string custName = dt8.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt8.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27206, accountID2, "金额1",dt8, CustArea);
            }

            //税额 "税率 = '3%'"
            DataTable dt4 = FilterData(dtFilted, "税率 = '3%'");
            if (dt4.Rows.Count > 0)
            {
                string custName = dt4.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt4.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27195, accountID2, "税额1", dt4, CustArea);
            }

            //税额 "税率 = '6%'"
            DataTable dt5 = FilterData(dtFilted, "税率 = '6%'");
            if (dt5.Rows.Count > 0)
            {
                string custName = dt5.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt5.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27197, accountID2, "税额1", dt5, CustArea);
            }

            //税额 "税率 = '9%'"
            DataTable dt6 = FilterData(dtFilted, "税率 = '9%'");
            if (dt6.Rows.Count > 0)
            {
                string custName = dt6.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt6.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27411, accountID2, "税额1", dt6, CustArea);
            }

            //税额 "税率 = '10%'
            DataTable dt7 = FilterData(dtFilted, "税率 = '10%'");
            if (dt7.Rows.Count > 0)
            {
                string custName = dt7.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt7.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27352, accountID2, "税额1", dt7, CustArea);
            }

            //税额 "税率 = '11%'
            DataTable dt9 = FilterData(dtFilted, "税率 = '11%'");
            if (dt9.Rows.Count > 0)
            {
                string custName = dt9.Rows[0]["购方企业名称"].ToString();
                string custAddress = dt9.Rows[0]["地址电话"].ToString();
                int accountID2 = GetAccountID2ByCustNameCustAddress(custName, custAddress);
                InsertV2(27196, accountID2, "税额1", dt9, CustArea);
            }

            //更新主表EntryCount
            Vouchers.UpdateEntryCount(VoucherEntries.GetMaxEntryID(VoucherID),VoucherID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="ItemClassID"></param>
        /// <param name="ItemID"></param>
        /// <returns></returns>
        private static int GetDetailID(int ItemClassID , int ItemID)
        {
            int retVal = -1;
            //查纵表，如果存在就返回detailID
            retVal = ItemDetails.GetDetailIDByItemClassIDItemID(ItemClassID, ItemID);
            if (retVal == -1)
            {
                retVal = ItemDetails.GetNewItemDetailID();
                //否则写纵表
                ItemDetailV itemDetailV = new ItemDetailV()
                {
                    FDetailID = retVal,
                    FItemClassID =ItemClassID,
                    FItemID = ItemID
                };
                BaseDAL.Insert<ItemDetailV>(itemDetailV);
                //写横表
                ItemDetails.InsertItemDetailV2(retVal, ItemClassID, ItemID);
            }
            
            return retVal;
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtVoucher"></param>
        /// <returns></returns>
        private  int InsertVoucher(DataTable dtVoucher)
        {
            int retValue = -1;
            int year = DateTime.Now.Year;
            int period = DateTime.Now.Month;
            int groupid = int.Parse(ComboBoxVoucherGroup.SelectedValue.ToString());
            int preparerid = int.Parse(ComboBoxExPreparerID.SelectedValue.ToString());
            VoucherID = Vouchers.GetNewVoucherID();
            Voucher voucher = new Voucher()
            {
                FVoucherID = VoucherID,
                FBrNo = "0",
                FApproveID = -1,
                FAttachments = 0,
                FCashierID = -1,
                FChecked = false,
                FCheckerID = -1,
                FCreditTotal = CreditTotal,
                FDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                FDebitTotal = DebitTotal,
                FEntryCount = 0,//等更新完了再更新
                FExplanation = "",
                FFootNote = "",
                FFrameWorkID = -1,
                FGroupID = groupid,
                FHandler = null,
                FInternalInd = null,
                FObjectName = null,
                FOwnerGroupID = Vouchers.GetOwnerGroupIDByPreparerID(preparerid),
                FParameter = null,
                FPeriod = period,//
                FPosted = false,//                
                FPosterID = -1,//
                FPreparerID = preparerid,
                FReference = null,
                FSerialNum = Vouchers.GetNewSerialNum(),
                FTransDate = DateTime.Parse(DateTime.Now.ToString("yyyy-MM-dd")),
                FTranType = 0,
                FYear = year,//
                FNumber = Vouchers.GetNewFNumber(year,period,groupid),
                UUID = Guid.NewGuid()
            };

            retValue = BaseDAL.Insert<Voucher>(voucher);

            return retValue;
        }
        #endregion

        #region 工具
        /// <summary>
        /// 绑定DataGridView数据到DataTable
        /// </summary>
        /// <param name="dgv">复制数据的DataGridView</param>
        /// <returns>返回的绑定数据后的DataTable</returns>
        public DataTable GetDgvToTable(DataGridView dgv)
        {
            DataTable dt = new DataTable();
            // 列强制转换
            for (int colCount = 0; colCount < dgv.Columns.Count; colCount++)
            {
                DataColumn dc = new DataColumn(dgv.Columns[colCount].Name.ToString());
                dt.Columns.Add(dc);
            }
            // 循环行
            for (int rowCount = 0; rowCount < dgv.Rows.Count; rowCount++)
            {
                DataRow dr = dt.NewRow();
                for (int countsub = 0; countsub < dgv.Columns.Count; countsub++)
                {
                    dr[countsub] = Convert.ToString(dgv.Rows[rowCount].Cells[countsub].Value);
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
        #endregion
    }
}