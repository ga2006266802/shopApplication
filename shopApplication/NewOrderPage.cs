using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Diagnostics;

namespace shopApplication
{
    public partial class NewOrderPage : Form
    {
        List<string> customers = new List<string>();
        string path;
        SetData setData;
        public NewOrderPage(ListView listView, String tot, SetData setData)
        {
            InitializeComponent();
            this.setData = setData;
            ListView_func.listView_init(orderListView);
            for (int index = 0; index < listView.Items.Count; index++)
            {
                orderListView.Items.Add((ListViewItem)listView.Items[index].Clone());
            }
            totalTextBox.Text = tot;

            path = FileName.customersDirectoryPath;
            if (Directory.Exists(path)) //檢查存檔資料夾是否存在
            {
                path = FileName.customersDirectoryPath + '/' + FileName.customersTxtPath;
                if (File.Exists(path))
                {
                    string json;
                    json = File.ReadAllText(path);
                    customers = System.Text.Json.JsonSerializer.Deserialize<List<string>>(json);
                }
            }
            else
            {
                Directory.CreateDirectory(FileName.customersDirectoryPath);
            }

            customersComBox_upData();

        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(customersComboBox.Text.Replace(" ", "")))
            {
                MessageBox.Show("有欄位空白", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Excel.Application appl = new Excel.Application();
            Excel.Workbook wb = appl.Workbooks.Add(Directory.GetCurrentDirectory() + "/orderExample.xlsx");
            Excel.Worksheet ws;
            ws = wb.Worksheets.Item[1];

            for (int RowIndex = 1; RowIndex <= ws.UsedRange.Rows.Count; RowIndex++) //更改範本excel內容為新訂單
            {
                for (int ColIndex = 1; ColIndex <= ws.UsedRange.Columns.Count; ColIndex++)
                {
                    if (ws.Cells[RowIndex, ColIndex].Value != null)
                    {
                        string cellValue = ws.Cells[RowIndex, ColIndex].Value.ToString();
                        if (cellValue.Contains('<') && cellValue.Contains('>') )
                        {
                            cellValue = cellValue.Substring(cellValue.IndexOf('<'), cellValue.IndexOf('>') - cellValue.IndexOf('<'));
                            cellValue = cellValue.Replace("<", String.Empty);
                            cellValue = cellValue.Replace(">", String.Empty);
                            string oriStr = cellValue;

                            switch (oriStr)
                            {
                                case "shopName":
                                    cellValue = setData.shopName;
                                    break;
                                case "customerName":
                                    cellValue = customersComboBox.Text;
                                    break;
                                case "address":
                                    cellValue = setData.address;
                                    break;
                                case "phoneNumber":
                                    cellValue = setData.phoneNumber;
                                    break;
                                case "faxNumber":
                                    cellValue = setData.faxNumber;
                                    break;
                                case "orderTime":
                                    cellValue = DateTime.Now.ToString("g");
                                    break;
                                case "customerPhone":
                                    cellValue = String.Empty;
                                    break;
                                case "amount":
                                    cellValue = totalTextBox.Text;
                                    break;
                                default: //名稱、價錢等動態欄位
                                    string[] temp = cellValue.Split(' ');
                                    if (int.Parse(temp.Last()) > orderListView.Items.Count)
                                    {
                                        cellValue = string.Empty;
                                    }
                                    else
                                    {
                                        cellValue = orderListView.Items[(int.Parse(temp.Last()) - 1)]. SubItems[orderListView.Columns[temp.First()]. DisplayIndex].Text;
                                    }
                                    break;
                            }

                            oriStr = '<' + oriStr + '>';
                            ws.Cells[RowIndex, ColIndex].Value = ws.Cells[RowIndex, ColIndex].Value.ToString().Replace(oriStr, cellValue);
                        }
                    }
                }
            }


            path = FileName.customersDirectoryPath + '/' + customersComboBox.Text;
            if (!Directory.Exists(path)) //生成客戶資料夾
            {
                Directory.CreateDirectory(path);
            }

            path += '/' + customersComboBox.Text + '-' + DateTime.Now.ToString("yyyyMMdd") + '-';

            for (int i = 1; ; i++)
            {
                if (!File.Exists(path + i.ToString() + ".xlsx"))
                {
                    path += i.ToString();
                    break;
                }
            }

            wb.SaveAs(Directory.GetCurrentDirectory() + '/' + path);

            if ((MessageBox.Show("需要列印訂單嗎?", "訂單已生成", MessageBoxButtons.YesNo) == DialogResult.Yes))
            {
                ws.PrintOutEx();
            }
            else
            {
                wb.Close();
                wb = null;
                if (MessageBox.Show("需要開啟訂單嗎?", "已取消列印訂單", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    appl.Workbooks.Open(Directory.GetCurrentDirectory() + '/' + path + ".xlsx"); //開啟excel
                    appl.Visible = true;
                }
                else
                {
                    appl.Quit();
                    appl = null;
                }
            }
            ws = null;

            for (int i = 0; i <= customers.Count; i++) //將新客戶記錄起來
            {
                if (i == customers.Count)
                {
                    customers.Add(customersComboBox.Text);
                    break;
                }
                else if (customers[i].Equals(customersComboBox.Text))
                {
                    break;
                }
            }

            string json = System.Text.Json.JsonSerializer.Serialize(customers, File_func.option);
            path = FileName.customersDirectoryPath + '/' + FileName.customersTxtPath;
            File.WriteAllText(path, json);

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void customersComBox_upData()
        {
            customersComboBox.Items.Clear();

            customersComboBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
            customersComboBox.AutoCompleteMode = AutoCompleteMode.Suggest;

            foreach (string customer in customers)
            {
                customersComboBox.Items.Add(customer);
                customersComboBox.AutoCompleteCustomSource.Add(customer);
            }
        }
    }
}
