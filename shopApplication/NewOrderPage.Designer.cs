namespace shopApplication
{
    partial class NewOrderPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            totalTextBox = new TextBox();
            label1 = new Label();
            orderListView = new ListView();
            acceptBtn = new Button();
            cancelBtn = new Button();
            label2 = new Label();
            customersComboBox = new ComboBox();
            SuspendLayout();
            // 
            // totalTextBox
            // 
            totalTextBox.Enabled = false;
            totalTextBox.Location = new Point(85, 672);
            totalTextBox.Name = "totalTextBox";
            totalTextBox.Size = new Size(627, 38);
            totalTextBox.TabIndex = 7;
            totalTextBox.TextAlign = HorizontalAlignment.Right;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(12, 680);
            label1.Name = "label1";
            label1.Size = new Size(67, 30);
            label1.TabIndex = 6;
            label1.Text = "總計:";
            // 
            // orderListView
            // 
            orderListView.Location = new Point(12, 12);
            orderListView.Name = "orderListView";
            orderListView.Size = new Size(700, 650);
            orderListView.TabIndex = 5;
            orderListView.UseCompatibleStateImageBehavior = false;
            // 
            // acceptBtn
            // 
            acceptBtn.Location = new Point(562, 879);
            acceptBtn.Name = "acceptBtn";
            acceptBtn.Size = new Size(150, 46);
            acceptBtn.TabIndex = 8;
            acceptBtn.Text = "確定";
            acceptBtn.UseVisualStyleBackColor = true;
            acceptBtn.Click += acceptBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(12, 879);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(150, 46);
            cancelBtn.TabIndex = 9;
            cancelBtn.Text = "取消";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 724);
            label2.Name = "label2";
            label2.Size = new Size(67, 30);
            label2.TabIndex = 10;
            label2.Text = "客戶:";
            // 
            // customersComboBox
            // 
            customersComboBox.FormattingEnabled = true;
            customersComboBox.Location = new Point(85, 721);
            customersComboBox.Name = "customersComboBox";
            customersComboBox.Size = new Size(627, 38);
            customersComboBox.TabIndex = 11;
            // 
            // NewOrderPage
            // 
            AcceptButton = acceptBtn;
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = cancelBtn;
            ClientSize = new Size(724, 937);
            Controls.Add(customersComboBox);
            Controls.Add(label2);
            Controls.Add(cancelBtn);
            Controls.Add(acceptBtn);
            Controls.Add(totalTextBox);
            Controls.Add(label1);
            Controls.Add(orderListView);
            Name = "NewOrderPage";
            Text = "新增訂單";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox totalTextBox;
        private Label label1;
        private ListView orderListView;
        private Button acceptBtn;
        private Button cancelBtn;
        private Label label2;
        private ComboBox customersComboBox;
    }
}