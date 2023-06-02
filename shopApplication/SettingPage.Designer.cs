namespace shopApplication
{
    partial class SettingPage
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
            AcceptButton = new Button();
            label1 = new Label();
            ShopNameTextBox = new TextBox();
            CaneclButton = new Button();
            AddressTextBox = new TextBox();
            label2 = new Label();
            PhoneTextBox = new TextBox();
            label3 = new Label();
            FaxTextBox = new TextBox();
            label4 = new Label();
            ProvisionalPriceCheckBox = new CheckBox();
            ProvisionalPriceScrollBar = new HScrollBar();
            ProvisionalPriceLabel = new Label();
            SuspendLayout();
            // 
            // AcceptButton
            // 
            AcceptButton.Location = new Point(522, 363);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(150, 46);
            AcceptButton.TabIndex = 0;
            AcceptButton.Text = "確定";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(107, 59);
            label1.Name = "label1";
            label1.Size = new Size(115, 30);
            label1.TabIndex = 1;
            label1.Text = "商店名稱:";
            // 
            // ShopNameTextBox
            // 
            ShopNameTextBox.Location = new Point(228, 56);
            ShopNameTextBox.Name = "ShopNameTextBox";
            ShopNameTextBox.Size = new Size(409, 38);
            ShopNameTextBox.TabIndex = 2;
            // 
            // CaneclButton
            // 
            CaneclButton.Location = new Point(107, 363);
            CaneclButton.Name = "CaneclButton";
            CaneclButton.Size = new Size(150, 46);
            CaneclButton.TabIndex = 3;
            CaneclButton.Text = "取消";
            CaneclButton.UseVisualStyleBackColor = true;
            CaneclButton.Click += CaneclButton_Click;
            // 
            // AddressTextBox
            // 
            AddressTextBox.Location = new Point(228, 100);
            AddressTextBox.Name = "AddressTextBox";
            AddressTextBox.Size = new Size(409, 38);
            AddressTextBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(107, 103);
            label2.Name = "label2";
            label2.Size = new Size(115, 30);
            label2.TabIndex = 4;
            label2.Text = "商店地址:";
            // 
            // PhoneTextBox
            // 
            PhoneTextBox.Location = new Point(228, 144);
            PhoneTextBox.Name = "PhoneTextBox";
            PhoneTextBox.Size = new Size(409, 38);
            PhoneTextBox.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(155, 144);
            label3.Name = "label3";
            label3.Size = new Size(67, 30);
            label3.TabIndex = 6;
            label3.Text = "電話:";
            // 
            // FaxTextBox
            // 
            FaxTextBox.Location = new Point(228, 188);
            FaxTextBox.Name = "FaxTextBox";
            FaxTextBox.Size = new Size(409, 38);
            FaxTextBox.TabIndex = 9;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(155, 188);
            label4.Name = "label4";
            label4.Size = new Size(67, 30);
            label4.TabIndex = 8;
            label4.Text = "傳真:";
            // 
            // ProvisionalPriceCheckBox
            // 
            ProvisionalPriceCheckBox.AutoSize = true;
            ProvisionalPriceCheckBox.Location = new Point(68, 257);
            ProvisionalPriceCheckBox.Name = "ProvisionalPriceCheckBox";
            ProvisionalPriceCheckBox.Size = new Size(189, 34);
            ProvisionalPriceCheckBox.TabIndex = 11;
            ProvisionalPriceCheckBox.Text = "開啟臨時售價";
            ProvisionalPriceCheckBox.UseVisualStyleBackColor = true;
            // 
            // ProvisionalPriceScrollBar
            // 
            ProvisionalPriceScrollBar.LargeChange = 1;
            ProvisionalPriceScrollBar.Location = new Point(260, 257);
            ProvisionalPriceScrollBar.Name = "ProvisionalPriceScrollBar";
            ProvisionalPriceScrollBar.Size = new Size(307, 34);
            ProvisionalPriceScrollBar.TabIndex = 12;
            ProvisionalPriceScrollBar.ValueChanged += ProvisionalPriceScrollBar_ValueChanged;
            // 
            // ProvisionalPriceLabel
            // 
            ProvisionalPriceLabel.AutoSize = true;
            ProvisionalPriceLabel.Location = new Point(570, 257);
            ProvisionalPriceLabel.Name = "ProvisionalPriceLabel";
            ProvisionalPriceLabel.Size = new Size(76, 30);
            ProvisionalPriceLabel.TabIndex = 13;
            ProvisionalPriceLabel.Text = "100%";
            // 
            // SettingPage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CaneclButton;
            ClientSize = new Size(800, 450);
            Controls.Add(ProvisionalPriceLabel);
            Controls.Add(ProvisionalPriceScrollBar);
            Controls.Add(ProvisionalPriceCheckBox);
            Controls.Add(FaxTextBox);
            Controls.Add(label4);
            Controls.Add(PhoneTextBox);
            Controls.Add(label3);
            Controls.Add(AddressTextBox);
            Controls.Add(label2);
            Controls.Add(CaneclButton);
            Controls.Add(ShopNameTextBox);
            Controls.Add(label1);
            Controls.Add(AcceptButton);
            Name = "SettingPage";
            Text = "軟體設定";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AcceptButton;
        private Label label1;
        private TextBox ShopNameTextBox;
        private Button CaneclButton;
        private TextBox AddressTextBox;
        private Label label2;
        private TextBox PhoneTextBox;
        private Label label3;
        private TextBox FaxTextBox;
        private Label label4;
        private CheckBox ProvisionalPriceCheckBox;
        private HScrollBar ProvisionalPriceScrollBar;
        private Label ProvisionalPriceLabel;
    }
}