using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace shopApplication
{
    public partial class Form1 : Form
    {
        private Button clearButton;
        List<Item> itemList = new List<Item>(); //存放所有商品
        List<Item> orderList = new List<Item>(); //存放選購商品
        public Form1()
        {
            InitializeComponent();
            searchTextBox.TextChanged += new System.EventHandler(TextBox_func.textChange);
            ListView_func.listView_init(itemListView);
            ListView_func.listView_init(orderListView);
            this.Text = "shopApplication";
            newOrderBtn.Enabled = false;

            if (Directory.Exists(FileName.mainDirectoryPath)) //檢查存檔資料夾是否存在
            {
                string path = FileName.mainDirectoryPath + '/' + FileName.productsTxtPath;
                if (File.Exists(path)) //檢查商品目錄是否存在
                {
                    string json;
                    json = File.ReadAllText(path);
                    itemList = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
                    item_func.add_all_item_to_ListViwe(itemListView,itemList,null);
                }
            }
            else
            {
                Directory.CreateDirectory(FileName.mainDirectoryPath);
            }
        }

        private void useItemPage(object sender, EventArgs e)
        {
            DialogResult result;
            Item itemTemp = new Item();
            ItemPage itemPage;

            String name;

            if(sender.GetType().Name == "Button" )
            {
                name = ((Button)sender).Name;
            }
            else
            {
                name = ((ListView)sender).Name;
            }

            switch (name)
            {
                case "addNewItemBtn":
                    itemPage = new ItemPage(itemTemp, itemList);
                    break;
                case "editBtn":
                    if (itemListView.SelectedItems.Count == 0)
                    {
                        MessageBox.Show("請選擇項目", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    itemTemp = itemList[item_func.find_item_index(itemList, itemListView.SelectedItems[0].Text)];
                    itemPage = new ItemPage(itemTemp);
                    break;
                default: //編輯orderListView項目
                    itemTemp = itemList[item_func.find_item_index(itemList, orderListView.SelectedItems[0].Text)];
                    Item orderTemp = new Item();
                    orderTemp = orderList[item_func.find_item_index(orderList, orderListView.SelectedItems[0].Text)];
                    itemPage = new ItemPage(itemTemp, orderTemp);
                    break;
            }
            result = itemPage.ShowDialog();

            if (result == DialogResult.OK)
            {
                switch (name)
                {
                    case "addNewItemBtn":
                        ListView_func.listView_add_item(itemTemp, itemListView, null);
                        itemList.Add(itemTemp);
                        break;
                    case "editBtn":
                        itemListView.Items.Clear();
                        item_func.add_all_item_to_ListViwe(itemListView, itemList,null);
                        break;
                    default: //編輯orderListView項目
                        orderListView.Items.Clear();
                        item_func.add_all_item_to_ListViwe(orderListView, orderList, totalTextBox);
                        break;
                }

                var option = new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true,//不要擠在一團
                    Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,//不要存成科學符號
                };

                string json = System.Text.Json.JsonSerializer.Serialize(itemList, option);
                File.WriteAllText(FileName.mainDirectoryPath + '/' + FileName.productsTxtPath, json);
            }

        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            NewOrderPage newOrderPage = new NewOrderPage(orderListView,totalTextBox.Text);
            result = newOrderPage.ShowDialog();

            if (result == DialogResult.OK)
            {

            }

        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) //搜尋
        {
            itemListView.Items.Clear();
            if ( string.IsNullOrEmpty(searchTextBox.Text) )
            {
                item_func.add_all_item_to_ListViwe(itemListView, itemList,null);
            }
            else
            {
                foreach (Item item in itemList)
                {
                    if (item.name.Contains(searchTextBox.Text))
                    {
                        ListView_func.listView_add_item(item, itemListView,null);
                    }
                }
            }
        }

        private void itemListView_DoubleClick(object sender, EventArgs e) //選中項目放入新建訂單欄目
        {
            if ((int.Parse(itemListView.SelectedItems[0].SubItems[2].Text)) == 0)
            {
                MessageBox.Show("沒有庫存", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Item item in itemList)
            {

                for (int i = 0; i < orderListView.Items.Count; i++)
                {
                    if (itemListView.SelectedItems[0].Text.Equals(orderListView.Items[i].Text)) //若已經有的話就不再新增
                    {
                        itemListView.SelectedItems.Clear();
                        orderListView.Focus();
                        orderListView.Items[i].Selected = true;
                        return;
                    }
                }

                if (itemListView.SelectedItems[0].Text.Equals(item.name))
                {
                    Item itemTemp = new Item(item);
                    itemTemp.amount = 1;
                    orderList.Add(itemTemp);
                    ListView_func.listView_add_item(itemTemp, orderListView, totalTextBox);
                    newOrderBtn.Enabled = true;
                    return;
                }
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            newOrderBtn.Enabled = false;
            totalTextBox.Text = "";
            orderListView.Items.Clear();
            orderList.Clear();
        }

        private void orderListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            Debug.WriteLine(itemListView.SelectedItems.Count);
        }
    }
}

public class Item
{
    public Item()
    {

    }
    public Item(Item item)
    {
        this.name = item.name;
        this.amount = item.amount;
        this.price = item.price;
    }
    public string name { get; set; }
    public int price { get; set; }
    public int amount { get; set; }
}

static class FileName
{
    public const string mainDirectoryPath = @"saved";
    public const string productsTxtPath = @"product.txt";
}

public class TextBox_func
{
    public static void textChange(object sender, EventArgs e)
    {
        removeBlank(sender);
    }
    public static void removeBlank(object sender)
    {
        if ( sender.GetType().Name == "TextBox" )
        {
            ((TextBox)sender).Text = ((TextBox)sender).Text.Replace(" ", "");
        }
        else
        {
            ((ComboBox)sender).Text = ((ComboBox)sender).Text.Replace(" ", "");
        }
        
    }
}

public class ListView_func
{

    public static void listView_init(ListView listView)
    {
        listView.View = View.Details;

        int width = listView.Size.Width / 5;
        listView.Columns.Add("產品名稱", width * 2);
        listView.Columns.Add("價錢", width);

        if (listView.Name.Equals("itemListView"))
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

    public static void listView_add_item(Item item, ListView listView, TextBox textBox)
    {
        var newItem = new ListViewItem(item.name);
        newItem.SubItems.Add(item.price.ToString());
        newItem.SubItems.Add(item.amount.ToString());
        if (listView.Name.Equals("orderListView"))
        {
            newItem.SubItems.Add( (item.price * item.amount).ToString() );
        }
        listView.Items.Add(newItem);

        if (listView.Name.Equals("orderListView"))
        {
            cal_total(listView, textBox);
        }
    }

    private static void cal_total(ListView listView,TextBox textBox) //計算總價
    {
        int tot = 0;
        for (int i = 0; i < listView.Items.Count; i++)
        {
            tot += int.Parse(listView.Items[i].SubItems[3].Text);
        }
        textBox.Text = tot.ToString();
    }
}

public class item_func
{
    public static void add_all_item_to_ListViwe(ListView listView, List<Item> itemList,TextBox textBox)
    {
        foreach (Item item in itemList)
        {
            ListView_func.listView_add_item(item, listView, textBox);            
        }
    }

    public static int find_item_index(List<Item> itemList,String text) // -1 = 沒找到
    {
        int index = 0;

        foreach (Item item in itemList)
        {
            if (item.name.Equals(text))
            {
                return index;
            }
            index++;
        }
        return -1;
    }
}