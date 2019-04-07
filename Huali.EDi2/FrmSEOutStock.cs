using DevComponents.DotNetBar;
using Ray.Framework.CustomDotNetBar;
using Huali.EDI2.Models;
using Ray.Framework.Converter;
using System;
using System.Data;
using System.Windows.Forms;

/// <summary>
/// ������־��
/// �汾��V8.0.0.0 
/// ���ڣ�2019-02-01 
/// ������Ӧ�������󣬽������Ǵ������еĵ���ȫ����0��5p���Ѿ���0
/// </summary>
namespace Huali.EDI2
{
    public partial class FrmSEOutStock : Office2007Form
    {
        public FrmSEOutStock()
        {
            InitializeComponent();
        }

        DataTable dt = new DataTable();
        private static TemplateType template = TemplateType.Unknow;
 
        #region �¼�
        /// <summary>
        /// ����
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX1_Click(object sender, EventArgs e)
        {
            //Check Data
            if (template == TemplateType.����)
            {
                if (CheckData_RL(dt))
                {
                    //ImportData
                    ImportData_RL(dt, "������");
                }
            }
            else if (template == TemplateType.�Ǵ�)
            {
                if (CheckData_XC(dt))
                {
                    //ImportData
                    ImportData_XC(dt, "������");
                }
            }
            else 
            {
                CustomDesktopAlert.H2("����ʶ���Excelģ���ļ���");
            }
        }

        /// <summary>
        /// ��
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ButtonX2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog
            {
                InitialDirectory = "C:\\Users\\Ray\\Desktop",//ע������д·��ʱҪ��c:\\������c:\
                Filter = "Excel2007�ļ�|*.xlsx|Excel2003�ļ�|*.xls|�����ļ�|*.*",
                RestoreDirectory = true,
                FilterIndex = 1
            };
            if (dialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                this.dataGridViewX1.DataSource = null;
                string fileName = dialog.FileName;
                template = SwichTemplateType(fileName);
                Convert2DataTable c2d = new Convert2DataTable();
                //string sheetName = template == TemplateType.���� ? "�ŵ���Ϣ" : "������ϸ";
                string sheetName = template == TemplateType.���� ? "�ŵ���Ϣ" : "Sheet1";
                dt = c2d.Excel2DataTable(fileName, sheetName, null, null);
                this.dataGridViewX1.DataSource = dt;
                CustomDesktopAlert.H2("�ɹ���Excel�ļ���");
            }
        }

        #endregion
        
        #region ˽�й���

        /// <summary>
        /// ѡ��ģ������
        /// </summary>
        /// <param name="filename">Excel�ļ���</param>
        /// <returns></returns>
        private TemplateType SwichTemplateType(string filename)
        {
            if (filename.Contains("��������") == true)
            {
                template = TemplateType.����;
            }
            else if (filename.Contains("���۶���") == true)
            {
                template = TemplateType.�Ǵ�;
            }
            else
            {
                template = TemplateType.Unknow;
            }
            return template;
        }

        /// <summary>
        /// ���˲�ͬ��������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="where">����</param>
        /// <returns></returns>
        private DataTable FilterData(DataTable dt, string where)
        {
            DataRow[] rows = dt.Select(where);
            DataTable tmpdt = dt.Clone();
            foreach (DataRow row in rows)  // ����ѯ�Ľ����ӵ�tempdt�У� 
            {
                tmpdt.Rows.Add(row.ItemArray);
            }
            return tmpdt;
        }

        /// <summary>
        /// �õ�Ψһ�ĵ����б�
        /// </summary>
        /// <param name="dt">���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private string GetDistinctBillNo(DataTable dt, string billNoFieldName)
        {
            string tempBillNo = "";
            string billNo = "";
            string retVal = "";

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                billNo = dt.Rows[i][billNoFieldName].ToString();
                if (billNo != tempBillNo)
                {
                    retVal += billNo + ";";
                    tempBillNo = billNo;
                }
            }

            //ȥ�����һ���ֺ�
            return retVal.Substring(0, retVal.Length - 1);
        }

        #region ����

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private bool ImportData_RL(DataTable dt, string billNoFieldName)
        {
            bool retVal = false;

            if (dt.Rows.Count > 0)
            {
                //�õ����ݺŵ��б�
                string distinctBillNo = GetDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //�õ�һ�ŵ�����
                    DataTable tmpdt = FilterData(dt, "������ = '" + billNo + "'");

                    //ImportSaleBill
                    InsertSaleBill_RL(tmpdt);
                }
            }
            else
            {
                CustomDesktopAlert.H2("û�п��õ����ݣ�");
            }

            return retVal;
        }

        /// <summary>
        /// �������ݺϷ���
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <returns></returns>
        private bool CheckData_RL(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //����Ʒ����
                Huali.EDI2.DAL.T_ICItem dICItem = new EDI2.DAL.T_ICItem();
                string rowNum = dr["���"].ToString();
                string productNumber = dr["������Ʒ���"].ToString();
                string productDegree = dr["���ӹ��"].ToString();
                int productId = dICItem.GetItemIDByFNameFnumber(productNumber, productDegree);
                if (productId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�в�Ʒ��Ų���ʶ��");
                    retVal = false;
                }
                else
                {
                    dr["������Ʒ���"] = productId.ToString();
                }

                //����ŵ�ID
                string storeNumber = dr["�ͻ����"].ToString();
                int storeId = dICItem.GetCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�пͻ���Ų���ʶ��");
                    //�ܵ��ż��
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.GetCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        CustomDesktopAlert.H2("��" + rowNum + "���ܵ��Ų���ʶ��");
                        return false;
                    }
                    else
                    {
                        dr["�ܵ����"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["�ܵ����"] = storeId.ToString();
                }

                //���ͻ�ID
                string customNumber = dr["�ŵ���"].ToString();
                int customId = dICItem.GetCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�пͻ���Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["�ͻ����"] = customId.ToString();
                    dr["�ŵ���"] = dr["�ܵ����"];
                }
            }
            return retVal;
        }

        /// <summary>
        /// ��һ�Ŷ���������д�����ݿ�
        /// </summary>
        /// <param name="dt">һ�Ŷ���������</param>
        private bool InsertSaleBill_RL(DataTable dt)
        {
            Huali.EDI2.DAL.SEOutStock dSale = new EDI2.DAL.SEOutStock();
            int interId = dSale.GetMaxFInterID();
            string billNo = dSale.GetMaxFBillNo();
            string sourceBillNo = dt.Rows[0]["������"].ToString();
            //�Ѿ����뵽��������
            int custId = int.Parse(dt.Rows[0]["�ͻ����"].ToString());
            int storeId = int.Parse(dt.Rows[0]["�ŵ���"].ToString());
            string productName = dt.Rows[0]["������Ʒ����"].ToString();
            string explanation = string.Format("���Ʒ {0} 2+1+1", productName);
            int empId = dSale.GetEmpIDByStoreID(storeId);
            Huali.EDI2.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15326,empId);
            try
            {
                if (dSale.InsertBill(mSale) == true)
                {
                    //CustomDesktopAlert.H2("д����ɹ���");

                    //д�ӱ�
                    int succ = 0;
                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        Huali.EDI2.DAL.SEOutStockEntry dSaleEnrty = new EDI2.DAL.SEOutStockEntry();
                        int itemId = int.Parse(dt.Rows[i]["������Ʒ���"].ToString());
                        int entryId = i + 1;                        
                        int stockId = 526;//CSW
                        int qty = int.Parse(dt.Rows[i]["��������"].ToString());
                        Huali.EDI2.DAL.T_ICItem dicitem = new EDI2.DAL.T_ICItem();
                        decimal price = dicitem.GetSalePriceByFItemID(itemId);

                        //Huali.EDI2.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, qty, qty, 0, 0,40311,40635, 255);
                        Huali.EDI2.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40311, 40635, 255);

                        if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                        {
                            succ += 1;
                        }
                    }
                    if (succ == dt.Rows.Count)
                    {
                        CustomDesktopAlert.H2("���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���");
                        return true;
                    }
                    else
                    {
                        CustomDesktopAlert.H2(billNo + "д�ӱ�ʧ�ܣ�");
                        return false;
                    }
                }
                else
                {
                    CustomDesktopAlert.H2("д�����ݱ�ʧ��");
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        #endregion

        #region �Ǵ�

        /// <summary>
        /// ��������������
        /// </summary>
        /// <param name="dt">Excel ���ݱ�</param>
        /// <param name="billNoFieldName">�����е�����</param>
        /// <returns></returns>
        private bool ImportData_XC(DataTable dt, string billNoFieldName)
        {
            bool retVal = true;

            if (dt.Rows.Count > 0)
            {
                //�õ����ݺŵ��б�
                string distinctBillNo = GetDistinctBillNo(dt, billNoFieldName);
                string[] billNos = distinctBillNo.Split(';');

                foreach (string billNo in billNos)
                {
                    //�õ�һ�ŵ�����
                    DataTable tmpdt = FilterData(dt, billNoFieldName + " = '" + billNo + "'");

                    //������������
                    InsertSaleBill_XC(tmpdt);

                    //������������
                    InsertFreeBill_XC(tmpdt);

                    //����5P����
                    Insert5PBill_XC(tmpdt);
                }
            }
            else
            {
                CustomDesktopAlert.H2("û�п��õ����ݣ�");
                return false;
            }
            return retVal;
        }

        /// <summary>
        /// �Ǵ���Ʒ��������
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool InsertFreeBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " ��Ʒ > 0 and ��� not like '%5P%'");

            if (tmpdt.Rows.Count > 0)
            {
                Huali.EDI2.DAL.SEOutStock dSale = new EDI2.DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                string explanation = string.Format("������� {0}", productName);
                int empId = dSale.GetEmpIDByStoreID(storeId);
                Huali.EDI2.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40394, 15322,empId);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //CustomDesktopAlert.H2("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            Huali.EDI2.DAL.SEOutStockEntry dSaleEnrty = new EDI2.DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["��Ʒ"].ToString());
                            Huali.EDI2.DAL.T_ICItem dicitem = new EDI2.DAL.T_ICItem();
                            //decimal price = dicitem.GetSalePriceByFItemID(itemId);
                            decimal price = 0;
                            int unitid = dicitem.GetUnitIDByitemID(itemId);

                            Huali.EDI2.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40526, unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            CustomDesktopAlert.H2("���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���");
                            return true;
                        }
                        else
                        {
                            CustomDesktopAlert.H2(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        CustomDesktopAlert.H2("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                CustomDesktopAlert.H2("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// �Ǵ�5Ƭװ��������
        /// </summary>
        /// <param name="dt">��������</param>
        private bool Insert5PBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, " ��Ʒ > 0 AND ��� LIKE '%5P%' ");

            if (tmpdt.Rows.Count > 0)
            {
                Huali.EDI2.DAL.SEOutStock dSale = new EDI2.DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                string explanation = string.Format("�������׿Ч {0}", productName);
                int empId = dSale.GetEmpIDByStoreID(storeId);
                Huali.EDI2.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20303, 40393, 15326,empId);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //CustomDesktopAlert.H2("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            Huali.EDI2.DAL.SEOutStockEntry dSaleEnrty = new EDI2.DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["��Ʒ"].ToString());
                            Huali.EDI2.DAL.T_ICItem dicitem = new EDI2.DAL.T_ICItem();
                            decimal price = dicitem.GetSalePriceByFItemID(itemId);
                            int unitid = dicitem.GetUnitIDByitemID(itemId);

                            Huali.EDI2.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, 0, 0, 0, 0, 0, 0, 0, 40311, 40569,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            CustomDesktopAlert.H2("���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���");
                            return true;
                        }
                        else
                        {
                            CustomDesktopAlert.H2(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        CustomDesktopAlert.H2("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                CustomDesktopAlert.H2("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// �Ǵ����۶�������
        /// </summary>
        /// <param name="dt"></param>
        private bool InsertSaleBill_XC(DataTable dt)
        {
            DataTable tmpdt = FilterData(dt, "���� > 0");

            //CustomDesktopAlert.H2(tmpdt.Rows.Count.ToString());

            if (tmpdt.Rows.Count > 0)
            {
                Huali.EDI2.DAL.SEOutStock dSale = new EDI2.DAL.SEOutStock();
                int interId = dSale.GetMaxFInterID();
                string billNo = dSale.GetMaxFBillNo();
                string sourceBillNo = tmpdt.Rows[0]["������"].ToString();
                //�Ѿ����뵽��������
                int custId = int.Parse(tmpdt.Rows[0]["������λ����"].ToString());
                int storeId = int.Parse(tmpdt.Rows[0]["�ŵ����"].ToString());
                string productName = tmpdt.Rows[0]["�ջ�������"].ToString();
                //string explanation = string.Format("���� {0}", productName);
                string explanation = string.Format("{0}", productName);
                int empId = dSale.GetEmpIDByStoreID(storeId);
                Huali.EDI2.Models.SEOutStock mSale = BuildSaleModel(interId, billNo, storeId, explanation, sourceBillNo, custId, 20302, null, 15322,empId);
                try
                {
                    if (dSale.InsertBill(mSale) == true)
                    {
                        //CustomDesktopAlert.H2("д����ɹ���");

                        //д�ӱ�
                        int succ = 0;
                        for (int i = 0; i < tmpdt.Rows.Count; i++)
                        {
                            Huali.EDI2.DAL.SEOutStockEntry dSaleEnrty = new EDI2.DAL.SEOutStockEntry();
                            int itemId = int.Parse(tmpdt.Rows[i]["SKU"].ToString());
                            int entryId = i + 1;
                            int stockId = int.Parse(tmpdt.Rows[i]["�ֿ�"].ToString());
                            int qty = int.Parse(tmpdt.Rows[i]["����"].ToString());
                            //int cxType = int.Parse(tmpdt.Rows[i]["�������"].ToString());
                            Huali.EDI2.DAL.T_ICItem dicitem = new EDI2.DAL.T_ICItem();
                            //decimal price = dicitem.GetSalePriceByFItemID(itemId);
                            decimal price = 0;
                            int unitid = dicitem.GetUnitIDByitemID(itemId);

                            Huali.EDI2.Models.SEOutStockEntry mSaleEntry = BuildSaleEntryModel(interId, entryId, itemId, stockId, qty, price, 0, 0, 0, 0, 0, 0, 40384, 40470,unitid);

                            if (dSaleEnrty.InsertBillEntry(mSaleEntry))
                            {
                                succ += 1;
                            }
                        }
                        if (succ == tmpdt.Rows.Count)
                        {
                            CustomDesktopAlert.H2("���ݺ� " + billNo + " ��" + succ + " ����¼����ɹ���</h2>");
                            return true;
                        }
                        else
                        {
                            CustomDesktopAlert.H2(billNo + "д�ӱ�ʧ�ܣ�");
                            return false;
                        }
                    }
                    else
                    {
                        CustomDesktopAlert.H2("д�����ݱ�ʧ��");
                        return false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    return false;
                }
            }
            else
            {
                CustomDesktopAlert.H2("û�п��õ����ݣ�");
                return false;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <returns></returns>
        private bool CheckData_XC(DataTable dt)
        {
            bool retVal = true;

            foreach (DataRow dr in dt.Rows)
            {
                //����Ʒ����
                Huali.EDI2.DAL.T_ICItem dICItem = new EDI2.DAL.T_ICItem();
                string rowNum = dr["���"].ToString();
                string sku = dr["SKU"].ToString();
                int productId = dICItem.GetItemIDBySKU(sku);
                if (productId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�в�Ʒ��Ų���ʶ��");
                    retVal = false;
                }
                else
                {
                    dr["SKU"] = productId.ToString();
                }

                //����ŵ�ID
                string storeNumber = dr["�ŵ����"].ToString();
                int storeId = dICItem.GetCustIDByFnumber(storeNumber);
                if (storeId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "���ŵ���벻��ʶ��");
                    //�ܵ��ż��
                    storeNumber = storeNumber.Substring(0, storeNumber.Length - 3) + "001";
                    storeId = dICItem.GetCustIDByFnumber(storeNumber);
                    if (storeId == 0)
                    {
                        CustomDesktopAlert.H2("��" + rowNum + "���ܵ��Ų���ʶ��");
                        return false;
                    }
                    else
                    {
                        dr["�ŵ����"] = storeId.ToString();
                    }
                }
                else
                {
                    dr["�ŵ����"] = storeId.ToString();
                }

                //���ͻ�ID
                string customNumber = dr["������λ����"].ToString();
                int customId = dICItem.GetCustIDByFnumber(customNumber);
                if (customId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�пͻ���Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["������λ����"] = customId.ToString();                    
                }

                //�ֿ���
                string stockName = dr["�ֿ�"].ToString();
                int stockId = dICItem.GetStockIDByFName(stockName);
                if (stockId == 0)
                {
                    CustomDesktopAlert.H2("��" + rowNum + "�вֿ��Ų���ʶ��");
                    return false;
                }
                else
                {
                    dr["�ֿ�"] = stockId.ToString();
                }

                //�������
                string cuxiaoType = dr["�������"].ToString();
                Huali.EDI2.DAL.SEOutStockEntry dEntry = new EDI2.DAL.SEOutStockEntry();
                int cxType = dEntry.GetInterIDByFName(cuxiaoType);
                dr["�������"] = cxType.ToString();
            }
            return retVal;
        }
        #endregion

        #region ���ɶ���

        /// <summary>
        /// �����������
        /// </summary>
        /// <param name="interId">�ڲ�ID</param>
        /// <param name="billNo">����</param>
        /// <param name="storeId">�ŵ�ID</param>
        /// <param name="explanation">˵��</param>
        /// <param name="sourceBillNo">EDIԭ����</param>
        /// <param name="customId">�ͻ����</param>
        /// <param name="areaPS">areaPS:20303</param>
        /// <param name="HeadSelfS0238">2048.2000</param>
        /// <param name="HeadSelfS0239">sp.so</param>
        /// <returns></returns>i
        private Huali.EDI2.Models.SEOutStock BuildSaleModel(int interId, string billNo, int storeId, string explanation, string sourceBillNo, int customId, int areaPS, int? HeadSelfS0238, int HeadSelfS0239, int EmpId)
        {
            //������ǰ����
            DateTime currDate = DateTime.Now.Date;

            Huali.EDI2.Models.SEOutStock mSale = new SEOutStock();
            Huali.EDI2.DAL.SEOutStock dSale = new Huali.EDI2.DAL.SEOutStock();
            mSale.FInterID = interId;
            mSale.FBillNo = billNo;
            mSale.FTranType = 83;
            mSale.FSalType = 101;
            mSale.FCustID = customId;//�������г���
            mSale.FExplanation = explanation;
            mSale.FBrNo = "0";
            mSale.FDate = currDate;
            mSale.FStockID = null;
            mSale.FAdd = null;
            mSale.FNote = null;
            mSale.FEmpID = EmpId;
            mSale.FCheckerID = null;
            mSale.FBillerID = 16454;
            mSale.FManagerID = 0;
            mSale.FClosed = 0;
            mSale.FInvoiceClosed = 0;
            mSale.FBClosed = 0;
            mSale.FDeptID = 271;
            mSale.FSettleID = 0;
            mSale.FTranStatus = 0;
            mSale.FExchangeRate = 1;
            mSale.FCurrencyID = 1;
            mSale.FStatus = 0;
            mSale.FCancellation = false;
            mSale.FMultiCheckLevel1 = null;
            mSale.FMultiCheckLevel2 = null;
            mSale.FMultiCheckLevel3 = null;
            mSale.FMultiCheckLevel4 = null;
            mSale.FMultiCheckLevel5 = null;
            mSale.FMultiCheckLevel6 = null;
            mSale.FMultiCheckDate1 = null;
            mSale.FMultiCheckDate2 = null;
            mSale.FMultiCheckDate3 = null;
            mSale.FMultiCheckDate4 = null;
            mSale.FMultiCheckDate5 = null;
            mSale.FMultiCheckDate6 = null;
            mSale.FCurCheckLevel = null;
            mSale.FRelateBrID = 0;
            mSale.FCheckDate = null;
            mSale.FFetchAdd = "";
            mSale.FSelTranType = 0;
            mSale.FChildren = 0;
            mSale.FBrID = null;
            ///mSale.FAreaPS = 20303;
            mSale.FAreaPS = areaPS;
            mSale.FPOOrdBillNo = null;
            mSale.FManageType = 0;
            mSale.FExchangeRateType = 1;
            mSale.FCustAddress = null;
            mSale.FPrintCount = 0;
            //2480
            ///mSale.FHeadSelfS0238 = 40394;
            mSale.FHeadSelfS0238 = HeadSelfS0238;
            //sp
            ///mSale.FHeadSelfS0239 = 15326;
            mSale.FHeadSelfS0239 = HeadSelfS0239;
            //?
            mSale.FHeadSelfS0240 = sourceBillNo;
            mSale.FHeadSelfS1241 = null;
            mSale.FHeadSelfS1242 = null;
            // �ŵ���
            mSale.FHeadSelfS0241 = storeId;
            mSale.FHeadSelfS0244 = "";
            mSale.FHeadSelfS1244 = null;
            mSale.FHeadSelfS1243 = null;
            mSale.FHeadSelfS0245 = currDate;
            mSale.FHeadSelfS1245 = null;
            mSale.FHeadSelfS0247 = "";
            mSale.FHeadSelfS1246 = null;

            return mSale;
        }

        /// <summary>
        /// ������ϸ�����
        /// </summary>
        /// <param name="finterid">�ڲ�ID</param>
        /// <param name="fentryid">���</param>
        /// <param name="fitemid">��ƷID</param>
        /// <param name="fstockid">�ֿ�ID</param>
        /// <param name="AuxCommitQty">AuxCommitQty</param>
        /// <param name="AuxStockBillQty">AuxStockBillQty</param>
        /// <param name="AuxStockQty">AuxStockQty</param>
        /// <param name="CommitQty">CommitQty</param>
        /// <param name="price">price</param>
        /// <param name="qty">qty</param>
        /// <param name="StockBillQty">StockBillQty</param>
        /// <param name="StockQty">StockQty</param>
        /// <param name="EntrySelfS0252">EntrySelfS0252</param>
        /// <param name="EntrySelfS0253">EntrySelfS0253</param>
        /// <returns></returns>
        private Huali.EDI2.Models.SEOutStockEntry BuildSaleEntryModel(int finterid, int fentryid, int fitemid, int fstockid, decimal qty, decimal price, decimal CommitQty, decimal AuxCommitQty, decimal StockQty, decimal AuxStockQty, decimal AuxStockBillQty, decimal StockBillQty, int EntrySelfS0252, int EntrySelfS0253,int UnitID)
        {
            /// ��������
            decimal currQty = qty;
            /// �����۸�
            decimal currPrice = price;
            /// ������ǰʱ��
            DateTime currDate = DateTime.Now.Date;

            Huali.EDI2.Models.SEOutStockEntry mSaleEntry = new SEOutStockEntry
            {
                FInterID = finterid,
                FEntryID = fentryid,
                FItemID = fitemid,
                FStockID = fstockid,
                FBrNo = "0",
                FQty = currQty,
                FCommitQty = CommitQty,
                FPrice = currPrice,
                FAmount = currQty * currPrice,
                FOrderInterID = "0",
                FDate = null,
                FNote = "",
                FInvoiceQty = 0,
                FBCommitQty = 0,
                FUnitID = UnitID,
                FAuxBCommitQty = 0,
                FAuxCommitQty = AuxCommitQty,
                FAuxInvoiceQty = 0,
                FAuxPrice = currPrice,
                FAuxQty = currQty,
                FSourceEntryID = 0,
                FMapNumber = "",
                FMapName = "",
                FAuxPropID = 0,
                FBatchNo = "",
                FCheckDate = null,
                FExplanation = "",
                FFetchAdd = "",
                FFetchDate = currDate,
                FMultiCheckDate1 = null,
                FMultiCheckDate2 = null,
                FMultiCheckDate3 = null,
                FMultiCheckDate4 = null,
                FMultiCheckDate5 = null,
                FMultiCheckDate6 = null,
                FSecCoefficient = 0,
                FSecQty = 0,
                FSecCommitQty = 0,
                FSourceTranType = 0,
                FSourceInterId = 0,
                FSourceBillNo = "",
                FContractInterID = 0,
                FContractEntryID = 0,
                FContractBillNo = "",
                FOrderEntryID = 0,
                FOrderBillNo = "",
                FBackQty = 0,
                FAuxBackQty = 0,
                FSecBackQty = 0,
                FStdAmount = currPrice * currQty,
                FPlanMode = 14036,
                FMTONo = "",
                FStockQty = StockQty,
                FAuxStockQty = AuxStockQty,
                FSecStockQty = 0,
                FSecInvoiceQty = 0,
                FDiffQtyClosed = 0,
                FAuxStockBillQty = AuxStockBillQty,
                FStockBillQty = StockBillQty,
                FEntrySelfS0251 = null,
                //mSaleEntry.FEntrySelfS0252 = 40311;
                FEntrySelfS0252 = EntrySelfS0252,
                //mSaleEntry.FEntrySelfS0253 = 40635;
                FEntrySelfS0253 = EntrySelfS0253,
                FEntrySelfS1234 = null,
                FEntrySelfS1235 = null,
                //mSaleEntry.FEntrySelfS0254 = "�ӿ���Ƭ";
                FEntrySelfS0254 = "",
                FEntrySelfS1236 = null
            };

            return mSaleEntry;
        }
        #endregion

        #endregion

        private void FrmSEOutStock_Load(object sender, EventArgs e)
        {

        }
    }

    public enum TemplateType 
    {
        ����,
        �Ǵ�,
        Unknow,
    }
}