using System.Diagnostics;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;
using System.Reflection;

namespace shopSystem
{
    public partial class Form1 : Form
    {
        private Button clearButton;
        List<Item> itemList = new List<Item>(); //存放所有商品
        public Form1()
        {
            InitializeComponent();

            listView_init(itemListView, 3);
            listView_init(orderListView, 4);
            this.Text = "shopSystem";

            //Excel.Application appl = new Excel.Application();
            //Excel.Workbook wb = appl.Workbooks.Add();
            //Excel.Worksheet ws;
            //ws = wb.ActiveSheet;
            //ws.Name = "測試";

            //appl.Cells[1, 1] = "名稱";
            //appl.Cells[1, 2] = "數量";
            //appl.Cells[1, 3] = "數量";
            //appl.Cells[2, 1] = "1";
            //appl.Cells[2, 2] = "2";

            //wb.SaveAs(@"excelTest1");
            //ws = null;
            //wb.Close();
            //wb = null;
            //appl.Quit();
            //appl = null;

            if (Directory.Exists(FileName.mainDirectoryPath)) //檢查存檔資料夾是否存在
            {
                string path = FileName.mainDirectoryPath + '/' + FileName.productsTxtPath;
                if (File.Exists(path)) //檢查商品目錄是否存在
                {
                    string json;
                    json = File.ReadAllText(path);
                    itemList = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
                    foreach (Item item in itemList)
                    {
                        listView_add_item(item, itemListView);
                    }
                }
            }
            else
            {
                Directory.CreateDirectory(FileName.mainDirectoryPath);
            }
        }

        private void listView_init(ListView listView, int Columns)
        {
            listView.View = View.Details;

            int width = itemListView.Size.Width / 5;
            listView.Columns.Add("產品名稱", width * 2);
            listView.Columns.Add("價錢", width);

            if (Columns == 3)
            {
                listView.Columns.Add(/*"num",*/"數量", -2);
                listView.MultiSelect = false;
            }
            else
            {
                listView.Columns.Add(/*"num",*/"數量", width);
                listView.Columns.Add(/*"num",*/"價格", -2);
            }

            //listView.Columns["num"].Width = -2;
            listView.FullRowSelect = true;
        }

        private void listView_add_item(Item item, ListView listView)
        {
            var newItem = new ListViewItem(item.name);
            newItem.SubItems.Add(item.price.ToString());
            newItem.SubItems.Add(item.amount.ToString());
            if (listView.Name.Equals("orderListView"))
            {
                newItem.SubItems.Add(item.price.ToString());
            }
            listView.Items.Add(newItem);

            if (listView.Name.Equals("orderListView"))
            {
                cal_total();
            }
        }

        private void addNewItemBtn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            Item itemTemp = new Item();
            AddItemPage addItemPage = new AddItemPage(itemTemp, itemList);
            result = addItemPage.ShowDialog();

            if (result == DialogResult.OK)
            {
                listView_add_item(itemTemp, itemListView);
                itemList.Add(itemTemp);

                var option = new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,
                };


                string json = System.Text.Json.JsonSerializer.Serialize(itemList, option);
                File.WriteAllText(FileName.mainDirectoryPath + '/' + FileName.productsTxtPath, json);
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) //搜尋
        {
            itemListView.Items.Clear();
            if (searchTextBox.Text.Replace(" ", "").Length == 0)
            {
                foreach (Item item in itemList)
                {
                    listView_add_item(item, itemListView);
                }
            }
            else
            {
                foreach (Item item in itemList)
                {
                    if (item.name.Contains(searchTextBox.Text))
                    {
                        listView_add_item(item, itemListView);
                    }
                }
            }
        }

        private void itemListView_DoubleClick(object sender, EventArgs e) //選中項目放入新建訂單欄目
        {
            foreach (Item item in itemList)
            {

                for (int i = 0; i < orderListView.Items.Count; i++)
                {
                    if (itemListView.SelectedItems[0].Text.Equals(orderListView.Items[i].Text))
                    {
                        return;
                    }
                }

                if (itemListView.SelectedItems[0].Text.Equals(item.name))
                {
                    item.amount = 1;
                    listView_add_item(item, orderListView);
                    return;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            orderListView.Items.Clear();
        }

        private void cal_total() //計算總價
        {
            int tot = 0;
            for (int i = 0; i < orderListView.Items.Count; i++)
            {
                tot += int.Parse(orderListView.Items[i].SubItems[3].Text);
            }
            totalTextBox.Text = tot.ToString();
        }
    }
}

public class Item
{
    public string name { get; set; }
    public int price { get; set; }
    public int amount { get; set; }
}

static class FileName
{
    public const string mainDirectoryPath = @"saved";
    public const string productsTxtPath = @"product.txt";
}