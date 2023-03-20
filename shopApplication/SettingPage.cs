using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        }

        private void CaneclButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void AcceptButton_Click(object sender, EventArgs e)
        {
            setItem.shopName = ShopNameTextBox.Text;
            string json = System.Text.Json.JsonSerializer.Serialize(setItem, File_func.option);
            string path = FileName.mainDirectoryPath + '/' + FileName.setTxtPath;
            File.WriteAllText(path, json);
            this.Close();
        }
    }

    public class SetData
    {
        public SetData()
        {
            shopName = new string("");
        }
        public string shopName { get; set; }
    }
}
