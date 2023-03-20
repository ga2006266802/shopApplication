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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.CaneclButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.itemName = new System.Windows.Forms.TextBox();
            this.itemAmount = new System.Windows.Forms.NumericUpDown();
            this.itemPrice = new System.Windows.Forms.NumericUpDown();
            this.numLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.itemAmount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPrice)).BeginInit();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(502, 392);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(150, 46);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "確認";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // CaneclButton
            // 
            this.CaneclButton.Location = new System.Drawing.Point(141, 392);
            this.CaneclButton.Name = "CaneclButton";
            this.CaneclButton.Size = new System.Drawing.Size(150, 46);
            this.CaneclButton.TabIndex = 1;
            this.CaneclButton.Text = "取消";
            this.CaneclButton.UseVisualStyleBackColor = true;
            this.CaneclButton.Click += new System.EventHandler(this.CaneclButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(127, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 30);
            this.label1.TabIndex = 2;
            this.label1.Text = "產品名稱";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(127, 134);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(61, 30);
            this.label2.TabIndex = 3;
            this.label2.Text = "價錢";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(127, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(61, 30);
            this.label3.TabIndex = 4;
            this.label3.Text = "數量";
            // 
            // itemName
            // 
            this.itemName.Location = new System.Drawing.Point(263, 35);
            this.itemName.Name = "itemName";
            this.itemName.Size = new System.Drawing.Size(403, 38);
            this.itemName.TabIndex = 5;
            // 
            // itemAmount
            // 
            this.itemAmount.Location = new System.Drawing.Point(263, 226);
            this.itemAmount.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.itemAmount.Name = "itemAmount";
            this.itemAmount.Size = new System.Drawing.Size(443, 38);
            this.itemAmount.TabIndex = 8;
            // 
            // itemPrice
            // 
            this.itemPrice.Location = new System.Drawing.Point(263, 132);
            this.itemPrice.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.itemPrice.Name = "itemPrice";
            this.itemPrice.Size = new System.Drawing.Size(443, 38);
            this.itemPrice.TabIndex = 9;
            // 
            // numLabel
            // 
            this.numLabel.AutoSize = true;
            this.numLabel.Location = new System.Drawing.Point(263, 267);
            this.numLabel.Name = "numLabel";
            this.numLabel.Size = new System.Drawing.Size(81, 30);
            this.numLabel.TabIndex = 10;
            this.numLabel.Text = "label4";
            // 
            // ItemPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CaneclButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numLabel);
            this.Controls.Add(this.itemPrice);
            this.Controls.Add(this.itemAmount);
            this.Controls.Add(this.itemName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CaneclButton);
            this.Controls.Add(this.AcceptButton);
            this.Name = "ItemPage";
            this.Text = "AddNewPage";
            ((System.ComponentModel.ISupportInitialize)(this.itemAmount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemPrice)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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