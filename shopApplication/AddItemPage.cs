using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace shopSystem
{
    public partial class AddItemPage : Form
    {
        Item Item = new Item();
        List<Item> itemList = new List<Item>();
        public AddItemPage(Item itemTemp, List<Item> listTemp)
        {
            InitializeComponent();
            this.Text = "新增商品";
            this.Item = itemTemp;
            this.itemList = listTemp;
        }

        private void CaneclButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (itemName.Text.Replace(" ", "").Length == 0 ||
                itemPrice.Text.Replace(" ", "").Length == 0 ||
                itemAmount.Text.Replace(" ", "").Length == 0)
            {
                MessageBox.Show("有欄位空白", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                foreach (Item item in itemList)
                {
                    if (item.name.Equals(itemName.Text))
                    {
                        MessageBox.Show("商品名稱重複", "錯誤", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }


                Item.name = itemName.Text;
                Item.price = int.Parse(itemPrice.Text);
                Item.amount = int.Parse(itemAmount.Text);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
