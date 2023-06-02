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
            itemListView = new ListView();
            orderListView = new ListView();
            searchTextBox = new TextBox();
            label1 = new Label();
            totalTextBox = new TextBox();
            addNewItemBtn = new Button();
            clearBtn = new Button();
            newOrderBtn = new Button();
            editBtn = new Button();
            settingBtn = new Button();
            clearSearchBoxBtn = new Button();
            orderItemDelBtn = new Button();
            SuspendLayout();
            // 
            // itemListView
            // 
            itemListView.LabelWrap = false;
            itemListView.Location = new Point(12, 80);
            itemListView.Name = "itemListView";
            itemListView.Size = new Size(700, 629);
            itemListView.TabIndex = 0;
            itemListView.UseCompatibleStateImageBehavior = false;
            itemListView.DoubleClick += itemListView_DoubleClick;
            // 
            // orderListView
            // 
            orderListView.Location = new Point(862, 12);
            orderListView.Name = "orderListView";
            orderListView.Size = new Size(700, 569);
            orderListView.TabIndex = 1;
            orderListView.UseCompatibleStateImageBehavior = false;
            orderListView.DoubleClick += useItemPage;
            orderListView.MouseUp += orderListView_MouseUp;
            // 
            // searchTextBox
            // 
            searchTextBox.Font = new Font("Microsoft JhengHei UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            searchTextBox.Location = new Point(12, 12);
            searchTextBox.Name = "searchTextBox";
            searchTextBox.Size = new Size(544, 62);
            searchTextBox.TabIndex = 2;
            searchTextBox.TextChanged += searchTextBox_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(862, 639);
            label1.Name = "label1";
            label1.Size = new Size(147, 67);
            label1.TabIndex = 3;
            label1.Text = "總計:";
            // 
            // totalTextBox
            // 
            totalTextBox.Enabled = false;
            totalTextBox.Font = new Font("Microsoft JhengHei UI", 19.875F, FontStyle.Regular, GraphicsUnit.Point);
            totalTextBox.Location = new Point(997, 639);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.Size = new Size(565, 75);
            totalTextBox.TabIndex = 4;
            totalTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // addNewItemBtn
            // 
            addNewItemBtn.Location = new Point(12, 716);
            addNewItemBtn.Name = "addNewItemBtn";
            addNewItemBtn.Size = new Size(150, 46);
            addNewItemBtn.TabIndex = 5;
            addNewItemBtn.Text = "新增項目";
            addNewItemBtn.UseVisualStyleBackColor = true;
            addNewItemBtn.Click += useItemPage;
            // 
            // clearBtn
            // 
            clearBtn.Location = new Point(1412, 720);
            clearBtn.Name = "clearBtn";
            clearBtn.Size = new Size(150, 46);
            clearBtn.TabIndex = 6;
            clearBtn.Text = "清除";
            clearBtn.UseVisualStyleBackColor = true;
            clearBtn.Click += clearButton_Click;
            // 
            // newOrderBtn
            // 
            newOrderBtn.Location = new Point(862, 720);
            newOrderBtn.Name = "newOrderBtn";
            newOrderBtn.Size = new Size(150, 46);
            newOrderBtn.TabIndex = 7;
            newOrderBtn.Text = "新增訂單";
            newOrderBtn.UseVisualStyleBackColor = true;
            newOrderBtn.Click += newOrderBtn_Click;
            // 
            // editBtn
            // 
            editBtn.Location = new Point(168, 716);
            editBtn.Name = "editBtn";
            editBtn.Size = new Size(150, 46);
            editBtn.TabIndex = 8;
            editBtn.Text = "編輯項目";
            editBtn.UseVisualStyleBackColor = true;
            editBtn.Click += useItemPage;
            // 
            // settingBtn
            // 
            settingBtn.Location = new Point(562, 716);
            settingBtn.Name = "settingBtn";
            settingBtn.Size = new Size(150, 46);
            settingBtn.TabIndex = 9;
            settingBtn.Text = "軟體設定";
            settingBtn.UseVisualStyleBackColor = true;
            settingBtn.Click += settingBtn_Click;
            // 
            // clearSearchBoxBtn
            // 
            clearSearchBoxBtn.Location = new Point(562, 12);
            clearSearchBoxBtn.Name = "clearSearchBoxBtn";
            clearSearchBoxBtn.Size = new Size(150, 62);
            clearSearchBoxBtn.TabIndex = 10;
            clearSearchBoxBtn.Text = "清空搜尋欄";
            clearSearchBoxBtn.UseVisualStyleBackColor = true;
            clearSearchBoxBtn.Click += clearSearchBoxBtn_Click;
            // 
            // orderItemDelBtn
            // 
            orderItemDelBtn.Enabled = false;
            orderItemDelBtn.Location = new Point(862, 587);
            orderItemDelBtn.Name = "orderItemDelBtn";
            orderItemDelBtn.Size = new Size(150, 46);
            orderItemDelBtn.TabIndex = 11;
            orderItemDelBtn.Text = "刪除";
            orderItemDelBtn.UseVisualStyleBackColor = true;
            orderItemDelBtn.Click += orderItemDelBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1574, 778);
            Controls.Add(orderItemDelBtn);
            Controls.Add(clearSearchBoxBtn);
            Controls.Add(settingBtn);
            Controls.Add(editBtn);
            Controls.Add(newOrderBtn);
            Controls.Add(clearBtn);
            Controls.Add(addNewItemBtn);
            Controls.Add(totalTextBox);
            Controls.Add(label1);
            Controls.Add(searchTextBox);
            Controls.Add(orderListView);
            Controls.Add(itemListView);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
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
        private Button clearSearchBoxBtn;
        private Button orderItemDelBtn;
    }
}