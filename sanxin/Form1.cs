using KIS.Model;
using Newtonsoft.Json;
using Ryan.Framework.DotNetFx40.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using static Ryan.Framework.DotNetFx40.Config.ConfigHelper;

namespace KIS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        //private readonly string conn = SqlHelper.GetConnectionString("Auhua.Test.AIS20110212144120");

        private void Form1_Load(object sender, EventArgs e)
        {
            //数据源类型
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "DataSourceType", "WebAPI");
            //数据源显示名称
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "DataSourceDispName", "三新图书ERP系统API");
            //数据源地址
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "DataSourceValue", "https://www.beidu.com/asdf");
            //单据类型
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "BillType", 
                "[" +
                    "{\"Id\": 1,\"Name\": \"采购订单\",\"PerentID\":0,\"Number\":1}," +
                    "{\"Id\": 2,\"Name\": \"销售出库单\",\"PerentID\":0,\"Number\":2}" +
                "]");
            //得到不同单据类型的过滤条件
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "DataFilter", "{['BillTypeId':'10001','Filter':''],['BillTypeId':'10002','Filter':'']}");
            //数据列对应关系
            ConfigHelper.UpdateOrCreateAppSetting(ConfigurationFile.AppConfig, "ColumnMaping", "{['BillTypeId':'10001','Maping':''],['BillTypeId':'10002':'Maping':'']}");

            string BillTypeSetting = ConfigHelper.ReadValueByKey(ConfigurationFile.AppConfig, "BillType");
            //Jsono
            List<Ryan_BillType> list = JsonConvert.DeserializeObject<List<Ryan_BillType>>(BillTypeSetting);

            var topNode = new TreeNode
            {
                Name = "0",
                Text = "三新凭证数据管理平台",
                Tag = 0
            };
            treeView1.Nodes.Add(topNode);
            Bind(topNode, list, 0);

            treeView1.ExpandAll();

            //dataGridView1.DataSource = list;
            //List<Ryan_BillType> ryan_BillTypes = 
            //delete 新
            //string ids = "30,20";
            //int i = BaseDAL.Delete<ICStockBill>(p=> ids.Split(',').Contains(p.FBillNo.ToString()),conn);
            //Console.WriteLine(i);
            //GetModel 新
            //List<ICStockBill> list = BaseDAL.GetModel<ICStockBill>(x => x.FInterID >= 2 && x.FSupplyID == 0, "FCheckDate DESC",conn);
            //Console.WriteLine(list.Count);
            //dataGridView1.DataSource = list.OrderBy(x=>x.FInterID).ThenBy(x=>x.FCheckerID).ToList();
            ///删除一条数据
            ///Dictionary<string, object> WhereOptions = new Dictionary<string, object>()
            ///{
            ///   {"FInterID", 2}
            ///};
            ///Console.WriteLine(BaseDAL.Delete<ICStockBill>(conn, WhereOptions));

            ///查询一组数据，并加入List
            ///WhereOptions 为空则相当于GetAll()
            //Dictionary<string, object> WhereOptions = new Dictionary<string, object>()
            //{
            //    { "FInterID", 2},
            //};
            //List<ICStockBill> list = BaseDAL.GetModel<ICStockBill>(conn, WhereOptions);
            //Console.WriteLine(list.Count);

            ///新增一条或多条记录，可以插入空值
            //ICStockBill iCStockBill = new ICStockBill()
            //{
            //    FInterID = 4,
            //    FBillNo = "100001",
            //    FBrNo = "0",
            //    FAcctID = null,
            //    FActPriceVchTplID = 0,
            //    FActualVchTplID = 0,
            //    FBillerID = 0,
            //    FBrID = 0,
            //    FBackFlushed = false,
            //    FBillTypeID = 0,
            //    FCancellation = false,
            //    FCheckDate = DateTime.Parse("2020-05-23"),
            //    FAutoCreType = byte.Parse("12,000", NumberStyles.Float, CultureInfo.CreateSpecificCulture("fr-FR")),
            //    FCheckerID = 0,
            //    FCheckSelect = 0,
            //    FChildren = 0,
            //    FConsignee = "",
            //    FCostObjNumber = "",
            //    FCurCheckLevel = 0,
            //    FCurrencyID = 0,
            //    FCussentAcctID = 0,
            //    FDate = DateTime.Parse("2020-05-23"),
            //    FDeptID = 0,
            //    FDrpRelateTranType = 0,
            //    FEmpID = 0,
            //    FExplanation = "",
            //    FFetchAdd = "",
            //    FFetchDate = DateTime.Parse("2020-05-23"),
            //    FFManagerID = 0,
            //    FHolisticDiscountRate = 0,
            //    FHookInterID = 0,
            //    FHookStatus = 0,
            //    FImport = 0,
            //    FLSSrcInterID = 0,
            //    FManagerID = 0,
            //    FManageType = 0,
            //    FMarketingStyle = 0,
            //    FMultiCheckDate1 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate2 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate3 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate4 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate5 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate6 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckLevel1 = 0,
            //    FMultiCheckLevel2 = 0,
            //    FMultiCheckLevel3 = 0,
            //    FMultiCheckLevel4 = 0,
            //    FMultiCheckLevel5 = 0,
            //    FMultiCheckLevel6 = 0,
            //    FNote = "",
            //    FOrderAffirm = 0,
            //    FOrgBillInterID = 0,
            //    FPayBillID = 0,
            //    FPlanPriceVchTplID = 0,
            //    FPlanVchTplID = 0,
            //    FPOOrdBillNo = "",
            //    FPOSName = "",
            //    FPosted = 0,
            //    FPosterID = 0,
            //    FPOStyle = 0,
            //    FPrintCount = 0,
            //    FProcID = 0,
            //    FPurposeID = 0,
            //    FRefType = 0,
            //    FRelateBrID = 0,
            //    FRelateInvoiceID = 0,
            //    FReturnBillInterID = 0,
            //    FROB = 0,
            //    FRSCBillNo = "",
            //    FSaleStyle = 0,
            //    FSCBillNo = "",
            //    FSCStockID = 0,
            //    FSelTranType = 0,
            //    FSettleDate = DateTime.Parse("2020-05-23"),
            //    FSManagerID = 0,
            //    FStatus = 0,
            //    FSupplyID = 0,
            //    FSystemType = 0,
            //    FTranStatus = 0,
            //    FTranType = 0,
            //    FUpStockWhenSave = false,
            //    FUse = "",
            //    FUUID = Guid.NewGuid(),
            //    FVchInterID = 0,
            //    FVIPCardID = 0,
            //    FVIPScore = 0,
            //    FWBInterID = 0,
            //    FWorkShiftId = 0,
            //    FZanGuCount = false,
            //    FZPBillInterID = 0,
            //    FDCStockID = 0
            //};
            //List<ICStockBill> list = new List<ICStockBill>()
            //{
            //    iCStockBill
            //};
            ////list.Add(iCStockBill);
            //int SuccCount = BaseDAL.Insert<ICStockBill>(conns, list);
            //Console.WriteLine(SuccCount);

            //更新一条或多条记录，可以插入空值
            //Dictionary<string, object> updatecolumn = new Dictionary<string, object>()
            //{
            //    {"FCheckerID",null },
            //    {"FBillerID",9999 }
            //};

            //Dictionary<string, object> whereoptions = new Dictionary<string, object>()
            //{
            //    {"FInterID",4 }
            //};

            //Console.WriteLine(BaseDAL.Update<ICStockBill>(conn, updatecolumn,null));

            ///更新实体，可以插入空值
            //ICStockBill iCStockBill = new ICStockBill()
            //{
            //    FInterID = 4,
            //    FBillNo = "100000",
            //    FBrNo = "0",
            //    FAcctID = null,
            //    FActPriceVchTplID = 0,
            //    FActualVchTplID = 0,
            //    FBillerID = null,
            //    FBrID = 0,
            //    FBackFlushed = false,
            //    FBillTypeID = 0,
            //    FCancellation = false,
            //    FCheckDate = DateTime.Parse("2020-05-25"),
            //    FAutoCreType = byte.Parse("10,000", NumberStyles.Float, CultureInfo.CreateSpecificCulture("fr-FR")),
            //    FCheckerID = null,
            //    FCheckSelect = 0,
            //    FChildren = 0,
            //    FConsignee = "",
            //    FCostObjNumber = "",
            //    FCurCheckLevel = 0,
            //    FCurrencyID = 0,
            //    FCussentAcctID = 0,
            //    FDate = DateTime.Parse("2020-05-23"),
            //    FDeptID = 0,
            //    FDrpRelateTranType = 0,
            //    FEmpID = 0,
            //    FExplanation = "",
            //    FFetchAdd = "",
            //    FFetchDate = DateTime.Parse("2020-05-23"),
            //    FFManagerID = 0,
            //    FHolisticDiscountRate = 0,
            //    FHookInterID = 0,
            //    FHookStatus = 0,
            //    FImport = 0,
            //    FLSSrcInterID = 0,
            //    FManagerID = 0,
            //    FManageType = 0,
            //    FMarketingStyle = 0,
            //    FMultiCheckDate1 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate2 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate3 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate4 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate5 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckDate6 = DateTime.Parse("2020-05-23"),
            //    FMultiCheckLevel1 = 0,
            //    FMultiCheckLevel2 = 0,
            //    FMultiCheckLevel3 = 0,
            //    FMultiCheckLevel4 = 0,
            //    FMultiCheckLevel5 = 0,
            //    FMultiCheckLevel6 = 0,
            //    FNote = "",
            //    FOrderAffirm = 0,
            //    FOrgBillInterID = 0,
            //    FPayBillID = 0,
            //    FPlanPriceVchTplID = 0,
            //    FPlanVchTplID = 0,
            //    FPOOrdBillNo = "",
            //    FPOSName = "",
            //    FPosted = 0,
            //    FPosterID = 0,
            //    FPOStyle = 0,
            //    FPrintCount = 0,
            //    FProcID = 0,
            //    FPurposeID = 0,
            //    FRefType = 0,
            //    FRelateBrID = 0,
            //    FRelateInvoiceID = 0,
            //    FReturnBillInterID = 0,
            //    FROB = 0,
            //    FRSCBillNo = "",
            //    FSaleStyle = 0,
            //    FSCBillNo = "",
            //    FSCStockID = 0,
            //    FSelTranType = 0,
            //    FSettleDate = DateTime.Parse("2020-05-23"),
            //    FSManagerID = 0,
            //    FStatus = 0,
            //    FSupplyID = 0,
            //    FSystemType = 0,
            //    FTranStatus = 0,
            //    FTranType = 0,
            //    FUpStockWhenSave = false,
            //    FUse = "",
            //    FUUID = Guid.NewGuid(),
            //    FVchInterID = 0,
            //    FVIPCardID = 0,
            //    FVIPScore = 0,
            //    FWBInterID = 0,
            //    FWorkShiftId = 0,
            //    FZanGuCount = false,
            //    FZPBillInterID = 0,
            //    FDCStockID = 0
            //};

            //Dictionary<string, object> whereoptions = new Dictionary<string, object>()
            //{
            //    {"FInterID",4 }
            //};

            //Console.WriteLine(BaseDAL.Update<ICStockBill>(conn, iCStockBill, whereoptions));

        }

        //绑定树控件
        private void Bind(TreeNode parNode, List<Ryan_BillType> list, int nodeId)
        {
            var childList = list.FindAll(t => t.ParentId == nodeId).OrderBy(t => t.Id);
            foreach (var ryan_BillType in childList)
            {
                var node = new TreeNode
                {
                    Name = ryan_BillType.Id.ToString(),
                    Text = ryan_BillType.Name,
                    Tag = ryan_BillType.Number
                };
                parNode.Nodes.Add(node);
                Bind(node, list, ryan_BillType.Id);
            }
        }
    }
}
