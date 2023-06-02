using System.Diagnostics;
using System.IO;
using System.Reflection;
using System.Collections;

namespace shopApplication
{
    public partial class Form1 : Form
    {


        List<Item> itemList = new List<Item>(); //�s��Ҧ��ӫ~
        List<Item> orderList = new List<Item>(); //�s����ʰӫ~
        SetData setData = new SetData();

        public Form1()
        {
            InitializeComponent();
            searchTextBox.TextChanged += new System.EventHandler(TextBox_func.textChange);
            ListView_func.listView_init(itemListView);
            ListView_func.listView_init(orderListView);
            this.Text = "shopApplication";
            newOrderBtn.Enabled = false;

            if (Directory.Exists(FileName.mainDirectoryPath)) //�ˬd�s�ɸ�Ƨ��O�_�s�b
            {
                string path = FileName.mainDirectoryPath + '/' + FileName.productsTxtPath;
                string json;

                if ((json = File_func.read_json_file(path)) != "")
                {
                    itemList = System.Text.Json.JsonSerializer.Deserialize<List<Item>>(json);
                    item_func.add_all_item_to_ListViwe(itemListView, itemList, null);
                }

                path = FileName.mainDirectoryPath + '/' + FileName.setTxtPath;
                if ((json = File_func.read_json_file(path)) != "")
                {
                    setData = System.Text.Json.JsonSerializer.Deserialize<SetData>(json);
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

            if (sender.GetType().Name == "Button")
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
                        MessageBox.Show("�п�ܶ���", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }

                    itemTemp = itemList[item_func.find_item_index(itemList, itemListView.SelectedItems[0].Text)];
                    itemPage = new ItemPage(itemTemp);
                    break;
                default: //�s��orderListView����
                    itemTemp = itemList[item_func.find_item_index(itemList, orderListView.SelectedItems[0].Text)];
                    Item orderTemp = new Item();
                    orderTemp = orderList[item_func.find_item_index(orderList, orderListView.SelectedItems[0].Text)];
                    itemPage = new ItemPage(itemTemp, orderTemp);
                    itemTemp = orderTemp;
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
                        itemListView.SelectedItems[0].SubItems[0].Text = itemTemp.name;
                        itemListView.SelectedItems[0].SubItems[1].Text = itemTemp.price.ToString();
                        itemListView.SelectedItems[0].SubItems[2].Text = itemTemp.amount.ToString();
                        break;
                    default: //�s��orderListView����
                        orderListView.SelectedItems[0].SubItems[2].Text = itemTemp.amount.ToString();
                        orderListView.SelectedItems[0].SubItems[3].Text = (itemTemp.amount * itemTemp.price).ToString();
                        ListView_func.cal_total(orderListView, totalTextBox);
                        break;
                }

                string json = System.Text.Json.JsonSerializer.Serialize(itemList, File_func.option);
                string path = FileName.mainDirectoryPath + '/' + FileName.productsTxtPath;
                File_func.save_text_file(path, json);
            }

        }

        private void newOrderBtn_Click(object sender, EventArgs e)
        {
            DialogResult result;
            NewOrderPage newOrderPage = new NewOrderPage(orderListView, totalTextBox.Text, setData);
            result = newOrderPage.ShowDialog();

            if (result == DialogResult.OK)
            {
                for (int i = 0; i < orderListView.Items.Count; i++)
                {
                    int index = item_func.find_item_index(itemList, orderListView.Items[i].SubItems[0].Text); //���blist������m
                    itemList[index].amount = itemList[index].amount - int.Parse(orderListView.Items[i].SubItems[orderListView.Columns["itemNum"].Index].Text); //������X�ƶq
                }
                string json = System.Text.Json.JsonSerializer.Serialize(itemList, File_func.option);
                string path = FileName.mainDirectoryPath + '/' + FileName.productsTxtPath;
                File_func.save_text_file(path, json); //�s��

                searchTextBox.Text = String.Empty;
                itemListView.Items.Clear();
                item_func.add_all_item_to_ListViwe(itemListView, itemList, null); //��s��ܼƾ�
                clearOrderList();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            clearOrderList();
        }

        private void orderItemDelBtn_Click(object sender, EventArgs e)
        {
            orderList.RemoveAt(orderListView.SelectedItems[0].Index);
            orderListView.SelectedItems[0].Remove();

            if (orderListView.Items.Count == 0)
            {
                clearOrderList();
            }
            else
            {
                ListView_func.cal_total(orderListView, totalTextBox);
            }
        }

        private void clearOrderList()
        {
            orderItemDelBtn.Enabled = false;
            newOrderBtn.Enabled = false;
            totalTextBox.Text = string.Empty;
            orderListView.Items.Clear();
            orderList.Clear();
        }

        private void orderListView_MouseUp(object sender, MouseEventArgs e)
        {
            if (((ListView)sender).SelectedItems.Count == 0)
            {
                orderItemDelBtn.Enabled = false;
            }
            else
            {
                orderItemDelBtn.Enabled = true;
            }
        }

        private void searchTextBox_TextChanged(object sender, EventArgs e) //�j�M
        {
            itemListView.Items.Clear();
            if (string.IsNullOrEmpty(searchTextBox.Text))
            {
                item_func.add_all_item_to_ListViwe(itemListView, itemList, null);
            }
            else
            {
                foreach (Item item in itemList)
                {
                    if (item.name.Contains(searchTextBox.Text))
                    {
                        ListView_func.listView_add_item(item, itemListView, null);
                    }
                }
            }
        }

        private void itemListView_DoubleClick(object sender, EventArgs e) //�襤���ة�J�s�حq�����
        {
            if ((int.Parse(itemListView.SelectedItems[0].SubItems[2].Text)) == 0)
            {
                MessageBox.Show("�S���w�s", "���~", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            foreach (Item item in itemList)
            {

                for (int i = 0; i < orderListView.Items.Count; i++)
                {
                    if (itemListView.SelectedItems[0].Text.Equals(orderListView.Items[i].Text)) //�Y�w�g�����ܴN���A�s�W
                    {
                        itemListView.SelectedItems.Clear();
                        orderListView.SelectedItems.Clear();
                        orderListView.Focus();
                        orderListView.Items[i].Selected = true;
                        orderListView.SelectedItems[0].EnsureVisible();
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

        private void settingBtn_Click(object sender, EventArgs e)
        {
            SettingPage settingPage = new SettingPage(setData);
            settingPage.ShowDialog();
        }

        private void clearSearchBoxBtn_Click(object sender, EventArgs e)
        {
            searchTextBox.Text = string.Empty;
            searchTextBox.Focus();
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

public static class FileName
{
    public const string mainDirectoryPath = @"saved";
    public const string productsTxtPath = @"product.txt";
    public const string customersDirectoryPath = @"customers";
    public const string customersTxtPath = @"customers.txt";
    public const string setTxtPath = @"set.txt";
}

public class File_func
{
    public static string read_json_file(string path)
    {
        string json = "";

        if (File.Exists(path)) //�ˬd�ӫ~�ؿ��O�_�s�b
        {
            json = File.ReadAllText(path);
        }

        return json;
    }

    public static void save_text_file(string path, string json)
    {
        File.WriteAllText(path, json);
    }

    public static System.Text.Json.JsonSerializerOptions option = new System.Text.Json.JsonSerializerOptions
    {
        WriteIndented = true,//���n���b�@��
        Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping,//���n�s����ǲŸ�
    };
}

public class TextBox_func
{
    public static void textChange(object sender, EventArgs e)
    {
        removeBlank(sender);
    }
    public static void removeBlank(object sender)
    {
        if (sender.GetType().Name == "TextBox")
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
        listView.Columns.Add("item", "���~�W��", width * 2);
        listView.Columns.Add("itemPrice", "����", width);

        if (listView.Name.Equals("itemListView"))
        {
            listView.Columns.Add("itemNum", "�ƶq", -2);
            listView.MultiSelect = false;
        }
        else
        {
            listView.Columns.Add("itemNum", "�ƶq", width);
            listView.Columns.Add("itemTotelPrice", "����", -2);
        }

        //listView.Columns["itemNum"].Width = -2;
        listView.FullRowSelect = true;
        listView.Font = new Font(listView.Font.FontFamily, 12);
    }

    public static void listView_add_item(Item item, ListView listView, TextBox textBox)
    {
        var newItem = new ListViewItem(item.name);
        newItem.SubItems.Add(item.price.ToString());
        newItem.SubItems.Add(item.amount.ToString());
        if (listView.Name.Equals("orderListView"))
        {
            newItem.SubItems.Add((item.price * item.amount).ToString());
        }
        listView.Items.Add(newItem);

        if (listView.Name.Equals("orderListView"))
        {
            cal_total(listView, textBox);
        }
    }

    public static void cal_total(ListView listView, TextBox textBox) //�p���`��
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
    public static void add_all_item_to_ListViwe(ListView listView, List<Item> itemList, TextBox textBox)
    {
        foreach (Item item in itemList)
        {
            ListView_func.listView_add_item(item, listView, textBox);
        }
    }

    public static int find_item_index(List<Item> itemList, String text) // -1 = �S���
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