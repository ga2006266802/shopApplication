namespace shopApplication
{
    partial class ItemPage
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
            CaneclButton = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            itemName = new TextBox();
            itemAmount = new NumericUpDown();
            itemPrice = new NumericUpDown();
            numLabel = new Label();
            ((System.ComponentModel.ISupportInitialize)itemAmount).BeginInit();
            ((System.ComponentModel.ISupportInitialize)itemPrice).BeginInit();
            SuspendLayout();
            // 
            // AcceptButton
            // 
            AcceptButton.Location = new Point(502, 392);
            AcceptButton.Name = "AcceptButton";
            AcceptButton.Size = new Size(150, 46);
            AcceptButton.TabIndex = 0;
            AcceptButton.Text = "確認";
            AcceptButton.UseVisualStyleBackColor = true;
            AcceptButton.Click += AcceptButton_Click;
            // 
            // CaneclButton
            // 
            CaneclButton.Location = new Point(141, 392);
            CaneclButton.Name = "CaneclButton";
            CaneclButton.Size = new Size(150, 46);
            CaneclButton.TabIndex = 1;
            CaneclButton.Text = "取消";
            CaneclButton.UseVisualStyleBackColor = true;
            CaneclButton.Click += CaneclButton_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Microsoft JhengHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label1.Location = new Point(103, 45);
            label1.Name = "label1";
            label1.Size = new Size(168, 47);
            label1.TabIndex = 2;
            label1.Text = "產品名稱";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Microsoft JhengHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label2.Location = new Point(171, 134);
            label2.Name = "label2";
            label2.Size = new Size(94, 47);
            label2.TabIndex = 3;
            label2.Text = "價錢";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Microsoft JhengHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            label3.Location = new Point(171, 234);
            label3.Name = "label3";
            label3.Size = new Size(94, 47);
            label3.TabIndex = 4;
            label3.Text = "數量";
            // 
            // itemName
            // 
            itemName.Font = new Font("Microsoft JhengHei UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            itemName.Location = new Point(277, 36);
            itemName.Name = "itemName";
            itemName.Size = new Size(443, 62);
            itemName.TabIndex = 5;
            // 
            // itemAmount
            // 
            itemAmount.Font = new Font("Microsoft JhengHei UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            itemAmount.Location = new Point(277, 226);
            itemAmount.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            itemAmount.Name = "itemAmount";
            itemAmount.Size = new Size(443, 62);
            itemAmount.TabIndex = 9;
            itemAmount.TextChanged += upDown_ValueChanged;
            // 
            // itemPrice
            // 
            itemPrice.Font = new Font("Microsoft JhengHei UI", 16.125F, FontStyle.Regular, GraphicsUnit.Point);
            itemPrice.Location = new Point(277, 126);
            itemPrice.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            itemPrice.Name = "itemPrice";
            itemPrice.Size = new Size(443, 62);
            itemPrice.TabIndex = 8;
            // 
            // numLabel
            // 
            numLabel.AutoSize = true;
            numLabel.Font = new Font("Microsoft JhengHei UI", 13.875F, FontStyle.Regular, GraphicsUnit.Point);
            numLabel.Location = new Point(277, 291);
            numLabel.Name = "numLabel";
            numLabel.Size = new Size(125, 47);
            numLabel.TabIndex = 10;
            numLabel.Text = "label4";
            // 
            // ItemPage
            // 
            AutoScaleDimensions = new SizeF(14F, 30F);
            AutoScaleMode = AutoScaleMode.Font;
            CancelButton = CaneclButton;
            ClientSize = new Size(800, 450);
            Controls.Add(numLabel);
            Controls.Add(itemAmount);
            Controls.Add(itemPrice);
            Controls.Add(itemName);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(CaneclButton);
            Controls.Add(AcceptButton);
            Name = "ItemPage";
            Text = "AddNewPage";
            ((System.ComponentModel.ISupportInitialize)itemAmount).EndInit();
            ((System.ComponentModel.ISupportInitialize)itemPrice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button AcceptButton;
        private Button CaneclButton;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox itemName;
        private NumericUpDown itemAmount;
        private NumericUpDown itemPrice;
        private Label numLabel;
    }
}