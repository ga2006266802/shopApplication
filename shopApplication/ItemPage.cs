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

namespace shopApplication
{
    public partial class ItemPage : Form
    {
        Item Item = new Item();
        List<Item> itemList = new List<Item>();

        public ItemPage(Item itemTemp, List<Item> listTemp)
        {
            InitializeComponent();
            this.Text = "新增商品";
            this.Item = itemTemp;
            this.itemList = listTemp;
            numLabel.Visible = false;
        }

        public ItemPage(Item itemTemp)
        {
            InitializeComponent();
            this.Text = "編輯商品";
            numLabel.Visible = false;
            itemName.Text = itemTemp.name;
            itemAmount.Value = itemTemp.amount;
            itemPrice.Value = itemTemp.price;
            this.Item = itemTemp;
            itemAmount.Select(0, 1);
        }

        public ItemPage(Item itemTemp, Item orderTemp)
        {
            InitializeComponent();
            this.Text = "編輯訂單商品";
            this.Item = orderTemp;
            itemName.Text = itemTemp.name;
            itemName.Enabled = false;
            itemPrice.Value = itemTemp.price;
            itemPrice.Enabled = false;
            itemAmount.Value = orderTemp.amount;
            itemAmount.Maximum = itemTemp.amount;
            numLabel.Text = $"最大:{itemTemp.amount}";
            itemAmount.Minimum = 1;
            UpDownBase upDownBase = (UpDownBase)itemAmount;
            upDownBase.TextChanged += new System.EventHandler(upDown_ValueChanged);
        }

        private void upDown_ValueChanged(object sender, EventArgs e)
        {
            if (itemAmount.Value < itemAmount.Minimum) itemAmount.Value = itemAmount.Minimum;
            if (this.Text == "編輯訂單商品")
            {
                if (itemAmount.Value > itemAmount.Maximum) itemAmount.Value = itemAmount.Maximum;
            }
        }

        private void CaneclButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(itemName.Text.Replace(" ", "")) ||
                string.IsNullOrEmpty(itemPrice.Text.Replace(" ", "")) ||
                string.IsNullOrEmpty(itemAmount.Text.Replace(" ", "")))
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
