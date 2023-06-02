using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace shopApplication
{
    public partial class SettingPage : Form
    {
        SetData setItem = new SetData();
        public SettingPage(SetData setItem)
        {
            InitializeComponent();
            this.setItem = setItem;
            ShopNameTextBox.Text = setItem.shopName;
            AddressTextBox.Text = setItem.address;
            PhoneTextBox.Text = setItem.phoneNumber;
            FaxTextBox.Text = setItem.faxNumber;
            ProvisionalPriceCheckBox.Checked = setItem.provisionalPriceLabelOption.isOpen;
            ProvisionalPriceScrollBar.Value = setItem.provisionalPriceLabelOption.percent;
            ProvisionalPriceLabel.Text = setItem.provisionalPriceLabelOption.percent.ToString() + '%';
        }

        private void CaneclButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            setItem.shopName = ShopNameTextBox.Text;
            setItem.address = AddressTextBox.Text;
            setItem.phoneNumber = PhoneTextBox.Text;
            setItem.faxNumber = FaxTextBox.Text;
            setItem.provisionalPriceLabelOption.isOpen = ProvisionalPriceCheckBox.Checked;
            setItem.provisionalPriceLabelOption.percent = ProvisionalPriceScrollBar.Value;
            string json = System.Text.Json.JsonSerializer.Serialize(setItem, File_func.option);
            string path = FileName.mainDirectoryPath + '/' + FileName.setTxtPath;
            File.WriteAllText(path, json);
            this.Close();
        }

        private void ProvisionalPriceScrollBar_ValueChanged(object sender, EventArgs e)
        {
            if (ProvisionalPriceScrollBar.Value >= 99) ProvisionalPriceScrollBar.Value = 100;
            if (ProvisionalPriceScrollBar.Value <= 1) ProvisionalPriceScrollBar.Value = 0;
            ProvisionalPriceLabel.Text = ProvisionalPriceScrollBar.Value.ToString() + '%';
        }
    }

    public class SetData
    {
        public SetData()
        {
            shopName = new string("");
            address = new string("");
            phoneNumber = new string("");
            faxNumber = new string("");
            provisionalPriceLabelOption = new ProvisionalPriceLabelOption();
        }
        public string shopName { get; set; }
        public string address { get; set; }
        public string phoneNumber { get; set; }
        public string faxNumber { get; set; }

        public ProvisionalPriceLabelOption provisionalPriceLabelOption { get; set; }
    }

    public class ProvisionalPriceLabelOption
    {
        public ProvisionalPriceLabelOption()
        {
            
        }
        public bool isOpen { get; set; }

        public int percent { get; set; }
    }
}
