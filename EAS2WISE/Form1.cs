using DevComponents.DotNetBar;
using Newtonsoft.Json;
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using Ryan.Framework.DotNetFx40.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace EAS2WISE
{
    public partial class Form1 : Office2007Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();

        /// <summary>
        /// 打开
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonXImportExcelNew_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Microsoft Excel 文件|*.xlsx;*.xls|所有文件|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
            {
                string[] SheetNames = ExcelHelper.GetExcelSheetNames(openFileDialog.FileName);
                if (SheetNames != null && SheetNames.Length > 1)//Excel有不只一个sheet，弹出选择窗口
                {
                    FrmSheetsSelecter frmSheetsSelecter = new FrmSheetsSelecter
                    {
                        SheetList = SheetNames
                    };
                    if (frmSheetsSelecter.ShowDialog() != DialogResult.Retry)
                    {
                        if (frmSheetsSelecter.SelectedSheetName != "")
                        {
                            dt = ExcelHelper.LoadDataFromExcel(openFileDialog.FileName, frmSheetsSelecter.SelectedSheetName);
                        }
                        else
                        {
                            dt = (DataTable)null;
                            DataGridViewXDetail.DataSource = dt;
                            MessageBox.Show("请先选择一个工作簿",
                                "系统错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                else if (SheetNames != null && SheetNames.Length == 1)//只有一个sheet
                {
                    string SelectedSheetName = SheetNames[0];
                    dt = ExcelHelper.LoadDataFromExcel(openFileDialog.FileName, SelectedSheetName);
                    DataGridViewXDetail.DataSource = dt;
                }
                else
                {
                    dt = (DataTable)null;
                    DataGridViewXDetail.DataSource = dt;
                    MessageBox.Show("打开Excel文件出错！",
                        "系统错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                dt = (DataTable)null;
                DataGridViewXDetail.DataSource = dt;
                MessageBox.Show("请先打开Excel文件或者文件出错！",
                    "系统错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

        }

        /// <summary>
        /// 转换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonXCreateVoucher_Click(object sender, System.EventArgs e)
        {
            if (dt.Rows.Count > 0)
            {
                string json = JsonConvert.SerializeObject(dt);
                List<EAS> list = JsonConvert.DeserializeObject<List<EAS>>(json);
                //Console.WriteLine(list.Count);
                List<WISE> wises = new List<WISE>();
                foreach(EAS eas in list)
                {
                    WISE wise = new WISE()
                    {
                        科目名称 = "",
                        币别名称 = "",
                        制单 = "",
                        审核 = "",
                        核准 = "",
                        出纳 = "",
                        经办 = "",
                        结算方式 = "",
                        结算号 = "",
                        数量 = "",
                        数量单位 = "",
                        单价 = "",
                        参考信息 = "",
                        往来业务编号 = "",
                        附件数 = "",
                        序号 = "",
                        系统模块 = "",
                        业务描述 = "",
                        汇率类型 = "公司汇率",
                        汇率 = "",
                        会计年度 = eas.业务日期.Substring(0, 4),
                        会计期间 = eas.会计期间.Replace(".0",""),
                        凭证字 = eas.凭证类型,
                        凭证号 = int.Parse(eas.凭证号.Replace("记--", "").ToString()).ToString(),
                        科目代码 = eas.科目,
                        币别代码 = eas.币种 == "BB01" ? "RMB" : "",
                        原币金额 = eas.原币金额.Replace(".0",""),
                        借方 = eas.方向 == "1" ? eas.原币金额 : "",
                        贷方 = eas.方向 == "0" ? eas.原币金额 : "",
                        凭证摘要 = eas.摘要,
                        业务日期 = DateTime.Parse(eas.业务日期),
                        分录序号 = (int.Parse(eas.分录号) - 1).ToString(),
                        核算项目 = GetProject(eas),
                        过账 = "",
                        机制凭证 = "",
                        现金流量 = "",
                        结余与盈余差异 = "",
                        结余与盈余差异方向 = "",
                        关联凭证ID = "",
                        凭证日期 = eas.记账日期,
                        凭证ID = eas.凭证序号
                    };
                    wises.Add(wise);
                    //wises.ForEach(param => Console.WriteLine(param.核算项目));
                }
                //写Excel文件
                this.DataGridViewXDetail.DataSource = null;
                this.DataGridViewXDetail.DataSource = wises;
                string BasePath = System.AppDomain.CurrentDomain.BaseDirectory;
                string FileDate = DateTime.Now.ToString("yyyyMMddhhmmss");
                string FileName =  BasePath + "Wise" + FileDate + ".xls";
                if (List2Excel(wises, FileName,"Page1"))
                {
                    CustomDesktopAlert.H2("Wise" + FileDate + ".xls 生成成功!");
                }
                else
                {
                    CustomDesktopAlert.H2("生成Excel文件失败");
                }

            }
            else
            {
                CustomDesktopAlert.H2("Excel文件无数据，请先打开EAS文件！");
            }

        }

        private bool List2Excel(List<WISE> wises, string FileName = "Wise.xls", string SheetName = "Sheet1")
        {
            bool retVal = false;
            try
            {
                //1、//创建工作簿对象
                IWorkbook workbook = new HSSFWorkbook();
                //2、//创建工作表
                ISheet sheet = workbook.CreateSheet(SheetName);
                IRow row0 = sheet.CreateRow(0);
                string[] ColumnHeaders = ("凭证日期,会计年度,会计期间,凭证字,凭证号," +
                    "科目代码,科目名称,币别代码,币别名称," +
                    "原币金额,借方,贷方,制单,审核,核准," +
                    "出纳,经办,结算方式,结算号,凭证摘要," +
                    "数量,数量单位,单价,参考信息,业务日期," +
                    "往来业务编号,附件数,序号,系统模块," +
                    "业务描述,汇率类型,汇率,分录序号," +
                    "核算项目,过账,机制凭证,现金流量," +
                    "结余与盈余差异,结余与盈余差异方向," +
                    "关联凭证ID,凭证ID").Split(',');
                for (int i = 0; i < ColumnHeaders.Length; i++)
                {
                    row0.CreateCell(i).SetCellValue(ColumnHeaders[i]);
                }

                for (int r = 1; r < wises.Count + 1; r++)
                {
                    //3、//创建行row
                    //r：行号，j：wises下标
                    IRow row = sheet.CreateRow(r);
                    int j = r - 1;
                    row.CreateCell(0).SetCellValue(wises[j].凭证日期.ToString("yyyy/M/d"));
                    row.CreateCell(1).SetCellValue(double.Parse(wises[j].会计年度));
                    row.CreateCell(2).SetCellValue(double.Parse(wises[j].会计期间));
                    row.CreateCell(3).SetCellValue(wises[j].凭证字);
                    row.CreateCell(4).SetCellValue(double.Parse(wises[j].凭证号));
                    row.CreateCell(5).SetCellValue(wises[j].科目代码);
                    row.CreateCell(6).SetCellValue(wises[j].科目名称);
                    row.CreateCell(7).SetCellValue(wises[j].币别代码);
                    row.CreateCell(8).SetCellValue(wises[j].币别名称);
                    row.CreateCell(9).SetCellValue(double.Parse(wises[j].原币金额));
                    if(wises[j].借方 == "")
                    {
                        row.CreateCell(10).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(10).SetCellValue(double.Parse(wises[j].借方));
                    }
                    if(wises[j].贷方 == "")
                    {
                        row.CreateCell(11).SetCellValue("");
                    }
                    else
                    {
                        row.CreateCell(11).SetCellValue(double.Parse(wises[j].贷方));
                    }
                    //row.CreateCell(10).SetCellValue(wises[j].借方);
                    //row.CreateCell(11).SetCellValue(wises[j].贷方);
                    row.CreateCell(12).SetCellValue(wises[j].制单);
                    row.CreateCell(13).SetCellValue(wises[j].审核);
                    row.CreateCell(14).SetCellValue(wises[j].核准);
                    row.CreateCell(15).SetCellValue(wises[j].出纳);
                    row.CreateCell(16).SetCellValue(wises[j].经办);
                    row.CreateCell(17).SetCellValue(wises[j].结算方式);
                    row.CreateCell(18).SetCellValue(wises[j].结算号);
                    row.CreateCell(19).SetCellValue(wises[j].凭证摘要);
                    row.CreateCell(20).SetCellValue(wises[j].数量);
                    row.CreateCell(21).SetCellValue(wises[j].数量单位);
                    row.CreateCell(22).SetCellValue(wises[j].单价);
                    row.CreateCell(23).SetCellValue(wises[j].参考信息);
                    row.CreateCell(24).SetCellValue(wises[j].业务日期.ToString("yyyy/M/d"));
                    row.CreateCell(25).SetCellValue(wises[j].往来业务编号);
                    row.CreateCell(26).SetCellValue(wises[j].附件数);
                    row.CreateCell(27).SetCellValue(wises[j].序号);
                    row.CreateCell(28).SetCellValue(wises[j].系统模块);
                    row.CreateCell(29).SetCellValue(wises[j].业务描述);
                    row.CreateCell(30).SetCellValue(wises[j].汇率类型);
                    row.CreateCell(31).SetCellValue(wises[j].汇率);
                    row.CreateCell(32).SetCellValue(double.Parse(wises[j].分录序号));
                    row.CreateCell(33).SetCellValue(wises[j].核算项目);
                    row.CreateCell(34).SetCellValue(wises[j].过账);
                    row.CreateCell(35).SetCellValue(wises[j].机制凭证);
                    row.CreateCell(36).SetCellValue(wises[j].现金流量);
                    row.CreateCell(37).SetCellValue(wises[j].结余与盈余差异);
                    row.CreateCell(38).SetCellValue(wises[j].结余与盈余差异方向);
                    row.CreateCell(39).SetCellValue(wises[j].关联凭证ID);
                    row.CreateCell(40).SetCellValue(wises[j].凭证ID);
                }

                List<Schema> schemas = new List<Schema>()
                {
                    new Schema(){FType = "ClassInfo" , FKey = "ClassType" , FFieldName = "" , FCaption = "VoucherData" , FValueType = "" , FNeedSave = "" , FColIndex = "" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "" , FImpFieldName = "" , FDefaultVal = "" , FSearch = "" , FItemPageName = "" , FTrueType = "" , FPrecision = "" , FSearchName = "" , FIsShownList = "" , FViewMask = "" , FPage = "" },
                    new Schema(){FType = "ClassInfo" , FKey = "ClassTypeID" , FFieldName = "" , FCaption = " 123" , FValueType = "" , FNeedSave = "" , FColIndex = "" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "" , FImpFieldName = "" , FDefaultVal = "" , FSearch = "" , FItemPageName = "" , FTrueType = "" , FPrecision = "" , FSearchName = "" , FIsShownList = "" , FViewMask = "" , FPage = "" },
                    new Schema(){FType = "PageInfo" , FKey = "Page1" , FFieldName = "" , FCaption = "Page1" , FValueType = "" , FNeedSave = "" , FColIndex = "" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "" , FImpFieldName = "" , FDefaultVal = "" , FSearch = "" , FItemPageName = "" , FTrueType = "" , FPrecision = "" , FSearchName = "" , FIsShownList = "" , FViewMask = "" , FPage = "" },
                    new Schema(){FType = "FieldInfo" , FKey = "FDate" , FFieldName = "FDate" , FCaption = "凭证日期" , FValueType = " DateTime" , FNeedSave = "" , FColIndex = "1" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FDate" , FImpFieldName = "FDate" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FYear" , FFieldName = "FYear" , FCaption = "会计年度" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "2" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FYear" , FImpFieldName = "FYear" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FPeriod" , FFieldName = "FPeriod" , FCaption = "会计期间" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "3" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FPeriod" , FImpFieldName = "FPeriod" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FGroupID" , FFieldName = "FGroupID" , FCaption = "凭证字" , FValueType = " Varchar(80)" , FNeedSave = "" , FColIndex = "4" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FGroupID" , FImpFieldName = "FGroupID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FNumber" , FFieldName = "FNumber" , FCaption = "凭证号" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "5" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FNumber" , FImpFieldName = "FNumber" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FAccountNum" , FFieldName = "FAccountNum" , FCaption = "科目代码" , FValueType = " Varchar(40)" , FNeedSave = "" , FColIndex = "7" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FAccountNum" , FImpFieldName = "FAccountNum" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FAccountName" , FFieldName = "FAccountName" , FCaption = "科目名称" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "8" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FAccountName" , FImpFieldName = "FAccountName" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCurrencyNum" , FFieldName = "FCurrencyNum" , FCaption = "币别代码" , FValueType = " Varchar(10)" , FNeedSave = "" , FColIndex = "9" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCurrencyNum" , FImpFieldName = "FCurrencyNum" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCurrencyName" , FFieldName = "FCurrencyName" , FCaption = "币别名称" , FValueType = " Varchar(40)" , FNeedSave = "" , FColIndex = "10" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCurrencyName" , FImpFieldName = "FCurrencyName" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FAmountFor" , FFieldName = "FAmountFor" , FCaption = "原币金额" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "11" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FAmountFor" , FImpFieldName = "FAmountFor" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FDebit" , FFieldName = "FDebit" , FCaption = "借方" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "12" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FDebit" , FImpFieldName = "FDebit" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCredit" , FFieldName = "FCredit" , FCaption = "贷方" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "13" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCredit" , FImpFieldName = "FCredit" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FPreparerID" , FFieldName = "FPreparerID" , FCaption = "制单" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "14" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FPreparerID" , FImpFieldName = "FPreparerID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCheckerID" , FFieldName = "FCheckerID" , FCaption = "审核" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "15" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCheckerID" , FImpFieldName = "FCheckerID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FApproveID" , FFieldName = "FApproveID" , FCaption = "核准" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "17" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FApproveID" , FImpFieldName = "FApproveID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCashierID" , FFieldName = "FCashierID" , FCaption = "出纳" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "18" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCashierID" , FImpFieldName = "FCashierID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FHandler" , FFieldName = "FHandler" , FCaption = "经办" , FValueType = " Varchar(50)" , FNeedSave = "" , FColIndex = "19" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FHandler" , FImpFieldName = "FHandler" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FSettleTypeID" , FFieldName = "FSettleTypeID" , FCaption = "结算方式" , FValueType = " Varchar(80)" , FNeedSave = "" , FColIndex = "20" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FSettleTypeID" , FImpFieldName = "FSettleTypeID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FSettleNo" , FFieldName = "FSettleNo" , FCaption = "结算号" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "21" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FSettleNo" , FImpFieldName = "FSettleNo" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FExplanation" , FFieldName = "FExplanation" , FCaption = "凭证摘要" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "22" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FExplanation" , FImpFieldName = "FExplanation" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FQuantity" , FFieldName = "FQuantity" , FCaption = "数量" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "23" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FQuantity" , FImpFieldName = "FQuantity" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FMeasureUnitID" , FFieldName = "FMeasureUnitID" , FCaption = "数量单位" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "24" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FMeasureUnitID" , FImpFieldName = "FMeasureUnitID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FUnitPrice" , FFieldName = "FUnitPrice" , FCaption = "单价" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "25" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FUnitPrice" , FImpFieldName = "FUnitPrice" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FReference" , FFieldName = "FReference" , FCaption = "参考信息" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "26" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FReference" , FImpFieldName = "FReference" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FTransDate" , FFieldName = "FTransDate" , FCaption = "业务日期" , FValueType = " DateTime" , FNeedSave = "" , FColIndex = "27" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FTransDate" , FImpFieldName = "FTransDate" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FTransNo" , FFieldName = "FTransNo" , FCaption = "往来业务编号" , FValueType = " Varchar(255)" , FNeedSave = "" , FColIndex = "28" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FTransNo" , FImpFieldName = "FTransNo" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FAttachments" , FFieldName = "FAttachments" , FCaption = "附件数" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "29" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FAttachments" , FImpFieldName = "FAttachments" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FSerialNum" , FFieldName = "FSerialNum" , FCaption = "序号" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "30" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FSerialNum" , FImpFieldName = "FSerialNum" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FObjectName" , FFieldName = "FObjectName" , FCaption = "系统模块" , FValueType = " Varchar(100)" , FNeedSave = "" , FColIndex = "31" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FObjectName" , FImpFieldName = "FObjectName" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FParameter" , FFieldName = "FParameter" , FCaption = "业务描述" , FValueType = " Varchar(100)" , FNeedSave = "" , FColIndex = "32" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FParameter" , FImpFieldName = "FParameter" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FExchangeRateType" , FFieldName = "FExchangeRateType" , FCaption = "汇率类型" , FValueType = " Varchar(80)" , FNeedSave = "" , FColIndex = "33" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FExchangeRateType" , FImpFieldName = "FExchangeRateType" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FExchangeRate" , FFieldName = "FExchangeRate" , FCaption = "汇率" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "34" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FExchangeRate" , FImpFieldName = "FExchangeRate" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FEntryID" , FFieldName = "FEntryID" , FCaption = "分录序号" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "35" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FEntryID" , FImpFieldName = "FEntryID" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FItem" , FFieldName = "FItem" , FCaption = "核算项目" , FValueType = "Text" , FNeedSave = "" , FColIndex = "36" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FItem" , FImpFieldName = "FItem" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FPosted" , FFieldName = "FPosted" , FCaption = "过账" , FValueType = " Decimal(28,10)" , FNeedSave = "" , FColIndex = "37" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FPosted" , FImpFieldName = "FPosted" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FInternalInd" , FFieldName = "FInternalInd" , FCaption = "机制凭证" , FValueType = " Varchar(10)" , FNeedSave = "" , FColIndex = "38" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FInternalInd" , FImpFieldName = "FInternalInd" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FCashFlow" , FFieldName = "FCashFlow" , FCaption = "现金流量" , FValueType = "Text" , FNeedSave = "" , FColIndex = "39" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FCashFlow" , FImpFieldName = "FCashFlow" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FDiffItemNumber" , FFieldName = "FDiffItemNumber" , FCaption = "结余与盈余差异" , FValueType = " Varchar(20)" , FNeedSave = "" , FColIndex = "40" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FDiffItemNumber" , FImpFieldName = "FDiffItemNumber" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FDiffItemSign" , FFieldName = "FDiffItemSign" , FCaption = "结余与盈余差异方向" , FValueType = " Varchar(20)" , FNeedSave = "" , FColIndex = "41" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FDiffItemSign" , FImpFieldName = "FDiffItemSign" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1"  },
                    new Schema(){FType = "FieldInfo" , FKey = "FLinkVchId" , FFieldName = "FLinkVchId" , FCaption = "关联凭证ID" , FValueType = " Varchar(20)" , FNeedSave = "" , FColIndex = "42" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FLinkVchId" , FImpFieldName = "FLinkVchId" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" },
                    new Schema(){FType = "FieldInfo" , FKey = "FVoucherId" , FFieldName = "FVoucherId" , FCaption = "凭证ID" , FValueType = " Varchar(20)" , FNeedSave = "" , FColIndex = "43" , FSrcTableName = "" , FSrcFieldName = "" , FExpFieldName = "FVoucherId" , FImpFieldName = "FVoucherId" , FDefaultVal = "" , FSearch = "0" , FItemPageName = "" , FTrueType = "" , FPrecision = "0" , FSearchName = "0" , FIsShownList = "0" , FViewMask = "0" , FPage = "1" }
                };

                //4、//创建工作表
                ISheet SheetSchema = workbook.CreateSheet("t_Schema");
                IRow HeaderRow = SheetSchema.CreateRow(0);
                string[] SchemaHeaders = ("FType,FKey,FFieldName,FCaption," +
                    "FValueType,FNeedSave,FColIndex,FSrcTableName," +
                    "FSrcFieldName,FExpFieldName,FImpFieldName," +
                    "FDefaultVal,FSearch,FItemPageName,FTrueType," +
                    "FPrecision,FSearchName,FIsShownList," +
                    "FViewMask,FPage").Split(',');
                for (int ii = 0; ii < SchemaHeaders.Length; ii++)
                {
                    HeaderRow.CreateCell(ii).SetCellValue(SchemaHeaders[ii]);
                }

                for (int rr = 1; rr < schemas.Count + 1; rr++)
                {
                    //5、//创建行row
                    //r：行号，j：wises下标
                    IRow rowSchema = SheetSchema.CreateRow(rr);
                    int jj = rr - 1;

                    rowSchema.CreateCell(0).SetCellValue(schemas[jj].FType);
                    rowSchema.CreateCell(1).SetCellValue(schemas[jj].FKey);
                    rowSchema.CreateCell(2).SetCellValue(schemas[jj].FFieldName);
                    rowSchema.CreateCell(3).SetCellValue(schemas[jj].FCaption);
                    rowSchema.CreateCell(4).SetCellValue(schemas[jj].FValueType);
                    rowSchema.CreateCell(5).SetCellValue(schemas[jj].FNeedSave);
                    rowSchema.CreateCell(6).SetCellValue(schemas[jj].FColIndex);
                    rowSchema.CreateCell(7).SetCellValue(schemas[jj].FSrcTableName);
                    rowSchema.CreateCell(8).SetCellValue(schemas[jj].FSrcFieldName);
                    rowSchema.CreateCell(9).SetCellValue(schemas[jj].FExpFieldName);
                    rowSchema.CreateCell(10).SetCellValue(schemas[jj].FImpFieldName);
                    rowSchema.CreateCell(11).SetCellValue(schemas[jj].FDefaultVal);
                    rowSchema.CreateCell(12).SetCellValue(schemas[jj].FSearch);
                    rowSchema.CreateCell(13).SetCellValue(schemas[jj].FItemPageName);
                    rowSchema.CreateCell(14).SetCellValue(schemas[jj].FTrueType);
                    rowSchema.CreateCell(15).SetCellValue(schemas[jj].FPrecision);
                    rowSchema.CreateCell(16).SetCellValue(schemas[jj].FSearchName);
                    rowSchema.CreateCell(17).SetCellValue(schemas[jj].FIsShownList);
                    rowSchema.CreateCell(18).SetCellValue(schemas[jj].FViewMask);
                    rowSchema.CreateCell(19).SetCellValue(schemas[jj].FPage);
                }

                //创建流对象并设置存储Excel文件的路径
                FileStream file = new FileStream(FileName, FileMode.Create);
                workbook.Write(file);
                file.Close();
                retVal = true;
            }
            catch (Exception ex)
            {
                retVal = false;
                CustomDesktopAlert.H4(ex.Message);
            }
            return retVal;
        }

        private string GetProject(EAS eas)
        {
            string retVal = !string.IsNullOrEmpty(eas.核算项目1) ? string.Format("{0}---{1}---{2}", eas.核算项目1, eas.编码1, eas.名称1) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目2) ? string.Format("||{0}---{1}---{2}", eas.核算项目2, eas.编码2, eas.名称2) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目3) ? string.Format("||{0}---{1}---{2}", eas.核算项目3, eas.编码3, eas.名称3) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目4) ? string.Format("||{0}---{1}---{2}", eas.核算项目4, eas.编码4, eas.名称4) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目5) ? string.Format("||{0}---{1}---{2}", eas.核算项目5, eas.编码5, eas.名称5) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目6) ? string.Format("||{0}---{1}---{2}", eas.核算项目6, eas.编码6, eas.名称6) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目7) ? string.Format("||{0}---{1}---{2}", eas.核算项目7, eas.编码7, eas.名称7) : "";
            retVal += !string.IsNullOrEmpty(eas.核算项目8) ? string.Format("||{0}---{1}---{2}", eas.核算项目8, eas.编码8, eas.名称8) : "";
            return retVal;
        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "Microsoft Excel 文件|*.xlsx;*.xls|所有文件|*.*"
            };

            if (openFileDialog.ShowDialog() == DialogResult.OK && !string.IsNullOrEmpty(openFileDialog.FileName))
            {
                string[] SheetNames = ExcelHelper.GetExcelSheetNames(openFileDialog.FileName);
                if (SheetNames != null && SheetNames.Length > 1)//Excel有不只一个sheet，弹出选择窗口
                {
                    FrmSheetsSelecter frmSheetsSelecter = new FrmSheetsSelecter
                    {
                        SheetList = SheetNames
                    };
                    if (frmSheetsSelecter.ShowDialog() != DialogResult.Retry)
                    {
                        if (frmSheetsSelecter.SelectedSheetName != "")
                        {
                            dt = ExcelHelper.LoadDataFromExcel(openFileDialog.FileName, frmSheetsSelecter.SelectedSheetName);
                            DataGridViewXDetail.DataSource = dt;
                            string json = JsonConvert.SerializeObject(dt);
                            List<Schema> schemas = JsonConvert.DeserializeObject<List<Schema>>(json);

                            schemas.ForEach(s => Console.WriteLine("new Schema() { " +
                                "FType = \"" + s.FType + "\" , " +
                                "FKey = \"" + s.FKey + "\" , " +
                                "FFieldName = \"" + s.FFieldName + "\" , " +
                                "FCaption = \"" + s.FCaption + "\" , " +
                                "FValueType = \"" + s.FValueType + "\" , " +
                                "FNeedSave = \"" + s.FNeedSave + "\" , " +
                                "FColIndex = \"" + s.FColIndex + "\" , " +
                                "FSrcTableName = \"" + s.FSrcTableName + "\" , " +
                                "FSrcFieldName = \"" + s.FSrcFieldName + "\" , " +
                                "FExpFieldName = \"" + s.FExpFieldName + "\" , " +
                                "FImpFieldName = \"" + s.FImpFieldName + "\" , " +
                                "FDefaultVal = \"" + s.FDefaultVal + "\" , " +
                                "FSearch = \"" + s.FSearch + "\" , " +
                                "FItemPageName = \"" + s.FItemPageName + "\" , " +
                                "FTrueType = \"" + s.FTrueType + "\" , " +
                                "FPrecision = \"" + s.FPrecision + "\" , " +
                                "FSearchName = \"" + s.FSearchName + "\" , " +
                                "FIsShownList = \"" + s.FIsShownList + "\" , " +
                                "FViewMask = \"" + s.FViewMask + "\" , " +
                                "FPage = \"" + s.FPage + "\" , " +
                                "},"));
                        }
                        else
                        {
                            dt = (DataTable)null;
                            DataGridViewXDetail.DataSource = dt;
                            MessageBox.Show("请先选择一个工作簿",
                                "系统错误",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Stop);
                            return;
                        }
                    }
                }
                else if (SheetNames != null && SheetNames.Length == 1)//只有一个sheet
                {
                    string SelectedSheetName = SheetNames[0];
                    dt = ExcelHelper.LoadDataFromExcel(openFileDialog.FileName, SelectedSheetName);
                    DataGridViewXDetail.DataSource = dt;
                }
                else
                {
                    dt = (DataTable)null;
                    DataGridViewXDetail.DataSource = dt;
                    MessageBox.Show("打开Excel文件出错！",
                        "系统错误",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
            }
            else
            {
                dt = (DataTable)null;
                DataGridViewXDetail.DataSource = dt;
                MessageBox.Show("请先打开Excel文件或者文件出错！",
                    "系统错误",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
        }
    }
    #region Model
    public class EAS
    {
        public string 公司 { get; set; }
        public DateTime 记账日期 { get; set; }
        public string 业务日期 { get; set; }
        public string 会计期间 { get; set; }
        public string 凭证类型 { get; set; }
        public string 凭证号 { get; set; }
        public string 分录号 { get; set; }
        public string 摘要 { get; set; }
        public string 科目 { get; set; }
        public string 币种 { get; set; }
        public string 汇率 { get; set; }
        public string 方向 { get; set; }
        public string 原币金额 { get; set; }
        public string 数量 { get; set; }
        public string 单价 { get; set; }
        public string 借方金额 { get; set; }
        public string 贷方金额 { get; set; }
        public string 制单人 { get; set; }
        public string 过账人 { get; set; }
        public string 审核人 { get; set; }
        public string 附件数量 { get; set; }
        public string 过账标记 { get; set; }
        public string 机制凭证模块 { get; set; }
        public string 删除标记 { get; set; }
        public string 凭证序号 { get; set; }
        public string 单位 { get; set; }
        public string 参考信息 { get; set; }
        public string 是否有现金流量 { get; set; }
        public string 现金流量标记 { get; set; }
        public string 业务编号 { get; set; }
        public string 结算方式 { get; set; }
        public string 结算号 { get; set; }
        public string 辅助账摘要 { get; set; }
        public string 核算项目1 { get; set; }
        public string 编码1 { get; set; }
        public string 名称1 { get; set; }
        public string 核算项目2 { get; set; }
        public string 编码2 { get; set; }
        public string 名称2 { get; set; }
        public string 核算项目3 { get; set; }
        public string 编码3 { get; set; }
        public string 名称3 { get; set; }
        public string 核算项目4 { get; set; }
        public string 编码4 { get; set; }
        public string 名称4 { get; set; }
        public string 核算项目5 { get; set; }
        public string 编码5 { get; set; }
        public string 名称5 { get; set; }
        public string 核算项目6 { get; set; }
        public string 编码6 { get; set; }
        public string 名称6 { get; set; }
        public string 核算项目7 { get; set; }
        public string 编码7 { get; set; }
        public string 名称7 { get; set; }
        public string 核算项目8 { get; set; }
        public string 编码8 { get; set; }
        public string 名称8 { get; set; }
        public string 发票号 { get; set; }
        public string 换票证号 { get; set; }
        public string 客户 { get; set; }
        public string 费用类别 { get; set; }
        public string 收款人 { get; set; }
        public string 物料 { get; set; }
        public string 财务组织 { get; set; }
        public string 供应商 { get; set; }
        public string 辅助账业务日期 { get; set; }
        public string 到期日 { get; set; }

    }

    public class WISE
    {
        public DateTime 凭证日期 { get; set; }
        public string 会计年度 { get; set; }
        public string 会计期间 { get; set; }
        public string 凭证字 { get; set; }
        public string 凭证号 { get; set; }
        public string 科目代码 { get; set; }
        public string 科目名称 { get; set; }
        public string 币别代码 { get; set; }
        public string 币别名称 { get; set; }
        public string 原币金额 { get; set; }
        public string 借方 { get; set; }
        public string 贷方 { get; set; }
        public string 制单 { get; set; }
        public string 审核 { get; set; }
        public string 核准 { get; set; }
        public string 出纳 { get; set; }
        public string 经办 { get; set; }
        public string 结算方式 { get; set; }
        public string 结算号 { get; set; }
        public string 凭证摘要 { get; set; }
        public string 数量 { get; set; }
        public string 数量单位 { get; set; }
        public string 单价 { get; set; }
        public string 参考信息 { get; set; }
        public DateTime 业务日期 { get; set; }
        public string 往来业务编号 { get; set; }
        public string 附件数 { get; set; }
        public string 序号 { get; set; }
        public string 系统模块 { get; set; }
        public string 业务描述 { get; set; }
        public string 汇率类型 { get; set; }
        public string 汇率 { get; set; }
        public string 分录序号 { get; set; }
        public string 核算项目 { get; set; }
        public string 过账 { get; set; }
        public string 机制凭证 { get; set; }
        public string 现金流量 { get; set; }
        public string 结余与盈余差异 { get; set; }
        public string 结余与盈余差异方向 { get; set; }
        public string 关联凭证ID { get; set; }
        public string 凭证ID { get; set; }
    }

    public class Schema
    {
        public string FType { get; set; }
        public string FKey { get; set; }
        public string FFieldName { get; set; }
        public string FCaption { get; set; }
        public string FValueType { get; set; }
        public string FNeedSave { get; set; }
        public string FColIndex { get; set; }
        public string FSrcTableName { get; set; }
        public string FSrcFieldName { get; set; }
        public string FExpFieldName { get; set; }
        public string FImpFieldName { get; set; }
        public string FDefaultVal { get; set; }
        public string FSearch { get; set; }
        public string FItemPageName { get; set; }
        public string FTrueType { get; set; }
        public string FPrecision { get; set; }
        public string FSearchName { get; set; }
        public string FIsShownList { get; set; }
        public string FViewMask { get; set; }
        public string FPage { get; set; }

    }
    #endregion
}