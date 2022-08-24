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

namespace shopApplication
{
    public partial class NewOrderPage : Form
    {
        public NewOrderPage(ListView listView,String tot)
        {
            InitializeComponent();
            ListView_func.listView_init(orderListView);
            for(int index = 0; index < listView.Items.Count; index++)
            {
                orderListView.Items.Add((ListViewItem)listView.Items[index].Clone()) ;
            }
            totalTextBox.Text = tot;
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

            appl.Cells[1, 1] = "名稱";
            appl.Cells[1, 2] = "價錢";
            appl.Cells[1, 3] = "數量";
            appl.Cells[1, 4] = "總價";

            int amount = 0;
            int itemNum = 0;

            for (; itemNum < orderListView.Items.Count; itemNum++)
            {
                for (int subItemNum = 0; subItemNum < orderListView.Items[0].SubItems.Count; subItemNum++) {
                    appl.Cells[2 + itemNum, subItemNum + 1] = orderListView.Items[itemNum].SubItems[subItemNum].Text;
                    if (subItemNum == 3)
                    {
                        amount += int.Parse(orderListView.Items[itemNum].SubItems[subItemNum].Text);
                    }
                }
            }

            appl.Cells[2 + itemNum, 3] = "總價";
            appl.Cells[2 + itemNum, 4] = amount;

            wb.SaveAs(Directory.GetCurrentDirectory() +  @"\excelTest1");
            ws = null;
            wb.Close();
            wb = null;
            appl.Quit();
            appl = null;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
