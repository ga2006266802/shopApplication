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
        public NewOrderPage(ListView listView,String tot,SetData setData)
        {
            InitializeComponent();
            this.setData = setData;
            ListView_func.listView_init(orderListView);
            for(int index = 0; index < listView.Items.Count; index++)
            {
                orderListView.Items.Add((ListViewItem)listView.Items[index].Clone()) ;
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


            
            

            for (int i = 0; i < customers.Count; i++)
            {
                customersComboBox.Items.Add(customers[i]);
            }
        }

        private void acceptBtn_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(customersComboBox.Text.Replace(" ","")))
            {
                MessageBox.Show("有欄位空白", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            Excel.Application appl = new Excel.Application();
            Excel.Workbook wb = appl.Workbooks.Add();
            Excel.Worksheet ws;
            ws = wb.ActiveSheet;
            ws.Name = "測試";

            int col = 1;

            appl.Cells[col, 1] = setData.shopName;

            col++;

            appl.Cells[col, 1] = "客戶";
            appl.Cells[col, 2] = customersComboBox.Text;

            col++;
            appl.Cells[col, 1] = "時間";
            appl.Cells[col, 2] = DateTime.Now.ToString();

            col++;

            appl.Cells[col, 1] = "名稱";
            appl.Cells[col, 2] = "價錢";
            appl.Cells[col, 3] = "數量";
            appl.Cells[col, 4] = "合計";

            col++;

            int amount = 0;
            int itemNum = 0;

            for (; itemNum < orderListView.Items.Count; itemNum++)
            {
                for (int subItemNum = 0; subItemNum < orderListView.Items[0].SubItems.Count; subItemNum++) {
                    appl.Cells[col + itemNum, subItemNum + 1] = orderListView.Items[itemNum].SubItems[subItemNum].Text;
                    if (subItemNum == 3)
                    {
                        amount += int.Parse(orderListView.Items[itemNum].SubItems[subItemNum].Text);
                    }
                }
            }

            appl.Cells[col + itemNum, 1] = "總價";
            appl.Cells[col + itemNum, 2] = amount;

            Excel.Range range;
            range = ws.Range["A1","D1"]; //店面名稱
            range.Cells.MergeCells = true; //合併儲存格
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //文字置中
            range = ws.Range["B2", "D2"]; //客戶名稱
            range.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter; //文字置中
            range.Cells.MergeCells = true; //合併儲存格
            range = ws.Range["B3", "D3"]; //時間
            range.Cells.MergeCells = true; //合併儲存格
            range = ws.Range["A4", "D4"];
            //range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlContinuous; //設定下邊框樣式
            //range.Interior.Color = Color.Red; //設定底色
            range.Borders[Excel.XlBordersIndex.xlEdgeTop].Weight = Excel.XlBorderWeight.xlMedium; //設定上邊框粗細
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium; //設定下邊框粗細
            range = ws.Range["A"+ (4 + itemNum).ToString() , "D" + (4+itemNum).ToString()];
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium; //設定下邊框粗細
            range = ws.Range["B4", "B" + (4 + itemNum).ToString()];
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium; //設定左邊框粗細
            range.Borders[Excel.XlBordersIndex.xlEdgeRight].Weight = Excel.XlBorderWeight.xlMedium; //設定右邊框粗細
            range = ws.Range["D4", "D" + (4 + itemNum).ToString()];
            range.Borders[Excel.XlBordersIndex.xlEdgeLeft].Weight = Excel.XlBorderWeight.xlMedium; //設定左邊框粗細
            range = ws.Range["B" + (5 + itemNum).ToString(), "D" + (5 + itemNum).ToString()];
            range.Cells.MergeCells = true;
            range.Borders[Excel.XlBordersIndex.xlEdgeBottom].LineStyle = Excel.XlLineStyle.xlDouble; //設定下邊框樣式
            //range.Borders[Excel.XlBordersIndex.xlEdgeBottom].Weight = Excel.XlBorderWeight.xlMedium; //設定下邊框粗細


            path = FileName.customersDirectoryPath + '/' + customersComboBox.Text; 
            if (!Directory.Exists(path)) //生成客戶資料夾
            {
                Directory.CreateDirectory(path);
            }

            path += '/' + customersComboBox.Text + '-' + DateTime.Now.ToString("yyyyMMdd") + '-';

            for(int i = 1; ;i++)
            {
                if(!File.Exists(path + i.ToString() + ".xlsx"))
                {
                    path += i.ToString();
                    break;
                }
            }

            wb.SaveAs(Directory.GetCurrentDirectory() + '/' + path);
            ws = null;
            wb.Close();
            wb = null;
            appl.Visible = true;
            appl.Workbooks.Open(Directory.GetCurrentDirectory() + '/' + path + ".xlsx"); //開啟excel
            //appl.Quit();
            //appl = null;



            for (int i = 0; i <= customers.Count; i++) //將新客戶記錄起來
            {
                if (i == customers.Count)
                {
                    customers.Add(customersComboBox.Text);
                    break;
                }
                else if(customers[i].Equals(customersComboBox.Text))
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
    }
}
