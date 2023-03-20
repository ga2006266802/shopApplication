namespace shopApplication
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.itemListView = new System.Windows.Forms.ListView();
            this.orderListView = new System.Windows.Forms.ListView();
            this.searchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.totalTextBox = new System.Windows.Forms.TextBox();
            this.addNewItemBtn = new System.Windows.Forms.Button();
            this.clearBtn = new System.Windows.Forms.Button();
            this.newOrderBtn = new System.Windows.Forms.Button();
            this.editBtn = new System.Windows.Forms.Button();
            this.settingBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // itemListView
            // 
            this.itemListView.LabelWrap = false;
            this.itemListView.Location = new System.Drawing.Point(12, 60);
            this.itemListView.Name = "itemListView";
            this.itemListView.Size = new System.Drawing.Size(700, 650);
            this.itemListView.TabIndex = 0;
            this.itemListView.UseCompatibleStateImageBehavior = false;
            this.itemListView.DoubleClick += new System.EventHandler(this.itemListView_DoubleClick);
            // 
            // orderListView
            // 
            this.orderListView.Location = new System.Drawing.Point(862, 12);
            this.orderListView.Name = "orderListView";
            this.orderListView.Size = new System.Drawing.Size(700, 650);
            this.orderListView.TabIndex = 1;
            this.orderListView.UseCompatibleStateImageBehavior = false;
            this.orderListView.DoubleClick += new System.EventHandler(this.useItemPage);
            // 
            // searchTextBox
            // 
            this.searchTextBox.Location = new System.Drawing.Point(12, 12);
            this.searchTextBox.Name = "searchTextBox";
            this.searchTextBox.Size = new System.Drawing.Size(700, 38);
            this.searchTextBox.TabIndex = 2;
            this.searchTextBox.TextChanged += new System.EventHandler(this.searchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(862, 680);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 30);
            this.label1.TabIndex = 3;
            this.label1.Text = "總計:";
            // 
            // totalTextBox
            // 
            this.totalTextBox.Enabled = false;
            this.totalTextBox.Location = new System.Drawing.Point(935, 672);
            this.totalTextBox.Name = "totalTextBox";
            this.totalTextBox.Size = new System.Drawing.Size(627, 38);
            this.totalTextBox.TabIndex = 4;
            this.totalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // addNewItemBtn
            // 
            this.addNewItemBtn.Location = new System.Drawing.Point(12, 716);
            this.addNewItemBtn.Name = "addNewItemBtn";
            this.addNewItemBtn.Size = new System.Drawing.Size(150, 46);
            this.addNewItemBtn.TabIndex = 5;
            this.addNewItemBtn.Text = "新增項目";
            this.addNewItemBtn.UseVisualStyleBackColor = true;
            this.addNewItemBtn.Click += new System.EventHandler(this.useItemPage);
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(1412, 720);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(150, 46);
            this.clearBtn.TabIndex = 6;
            this.clearBtn.Text = "清除";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // newOrderBtn
            // 
            this.newOrderBtn.Location = new System.Drawing.Point(862, 720);
            this.newOrderBtn.Name = "newOrderBtn";
            this.newOrderBtn.Size = new System.Drawing.Size(150, 46);
            this.newOrderBtn.TabIndex = 7;
            this.newOrderBtn.Text = "新增訂單";
            this.newOrderBtn.UseVisualStyleBackColor = true;
            this.newOrderBtn.Click += new System.EventHandler(this.newOrderBtn_Click);
            // 
            // editBtn
            // 
            this.editBtn.Location = new System.Drawing.Point(168, 716);
            this.editBtn.Name = "editBtn";
            this.editBtn.Size = new System.Drawing.Size(150, 46);
            this.editBtn.TabIndex = 8;
            this.editBtn.Text = "編輯項目";
            this.editBtn.UseVisualStyleBackColor = true;
            this.editBtn.Click += new System.EventHandler(this.useItemPage);
            // 
            // settingBtn
            // 
            this.settingBtn.Location = new System.Drawing.Point(562, 716);
            this.settingBtn.Name = "settingBtn";
            this.settingBtn.Size = new System.Drawing.Size(150, 46);
            this.settingBtn.TabIndex = 9;
            this.settingBtn.Text = "軟體設定";
            this.settingBtn.UseVisualStyleBackColor = true;
            this.settingBtn.Click += new System.EventHandler(this.settingBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1574, 778);
            this.Controls.Add(this.settingBtn);
            this.Controls.Add(this.editBtn);
            this.Controls.Add(this.newOrderBtn);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.addNewItemBtn);
            this.Controls.Add(this.totalTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.searchTextBox);
            this.Controls.Add(this.orderListView);
            this.Controls.Add(this.itemListView);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ListView itemListView;
        private ListView orderListView;
        private TextBox searchTextBox;
        private Label label1;
        private TextBox totalTextBox;
        private Button addNewItemBtn;
        private Button newOrderBtn;
        private Button editBtn;
        private Button settingBtn;
        private Button clearBtn;
    }
}