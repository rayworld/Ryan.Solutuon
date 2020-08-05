using Ryan.Framework.DotNetFx40.DBUtility;
using SanXin.KIS.Model;
using System;
using System.Collections.Generic;
using System.Linq;


namespace sanxin
{
    public partial class BaseBill
    {
        public static int InsertBill(List<Bill> DataSource) 
        {
            int retVal = 0;

            if (DataSource.Count > 0)
            {
                //假设用billNo区分不同的单据
                //得到唯一单号列表
                string[] BillNos = DataSource.Select(p => p.BILLNO).Distinct().ToArray();

                foreach(string BillNo in BillNos)
                {
                    //得到一条单据的全部数据
                    List<Bill> Bills = DataSource.FindAll(p => p.BILLNO == BillNo).ToList();
                    //得到表头
                    Bill bill = Bills[0];
                    List<Voucher> vouchers = new List<Voucher>();
                    //填充表头
                    Voucher voucher = new Voucher
                    {
                        FDate = bill.FDATE,
                        FBrNo = bill.BILLNO
                    };
                    vouchers.Add(voucher);

                    //得到表体
                    List<Bill> BillEntry = Bills;
                    List<VoucherEntry> voucherEntries = new List<VoucherEntry>();
                    //填充表体
                    foreach(Bill Entry in BillEntry)
                    {
                        VoucherEntry voucherEntry = new VoucherEntry()
                        {
                            FEntryID = Entry.FENTRYID,
                            FDetailID = Entry.FITEMID,
                            FQuantity = double.Parse(Entry.FQTY.ToString())
                        };
                        voucherEntries.Add(voucherEntry);
                    }

                    //写主表
                    if(BaseDAL.Insert<Voucher>(vouchers) == 1)
                    {
                        //写明细表
                        if(BaseDAL.Insert<VoucherEntry>(voucherEntries) == Bills.Count())
                        {
                            retVal++;
                            string s = new string('|',retVal*100/Bills.Count);
                            Console.WriteLine(string.Format("BillNo:{0} is Complated.{1}",Bills[0].BILLNO,s));
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("请检查数据源是否有效！");
            }
            return retVal;
        }
    }
}