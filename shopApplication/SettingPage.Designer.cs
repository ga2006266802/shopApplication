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
            this.AcceptButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ShopNameTextBox = new System.Windows.Forms.TextBox();
            this.CaneclButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // AcceptButton
            // 
            this.AcceptButton.Location = new System.Drawing.Point(522, 363);
            this.AcceptButton.Name = "AcceptButton";
            this.AcceptButton.Size = new System.Drawing.Size(150, 46);
            this.AcceptButton.TabIndex = 0;
            this.AcceptButton.Text = "確定";
            this.AcceptButton.UseVisualStyleBackColor = true;
            this.AcceptButton.Click += new System.EventHandler(this.AcceptButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(107, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "商家名稱:";
            // 
            // ShopNameTextBox
            // 
            this.ShopNameTextBox.Location = new System.Drawing.Point(228, 56);
            this.ShopNameTextBox.Name = "ShopNameTextBox";
            this.ShopNameTextBox.Size = new System.Drawing.Size(409, 38);
            this.ShopNameTextBox.TabIndex = 2;
            // 
            // CaneclButton
            // 
            this.CaneclButton.Location = new System.Drawing.Point(107, 363);
            this.CaneclButton.Name = "CaneclButton";
            this.CaneclButton.Size = new System.Drawing.Size(150, 46);
            this.CaneclButton.TabIndex = 3;
            this.CaneclButton.Text = "取消";
            this.CaneclButton.UseVisualStyleBackColor = true;
            this.CaneclButton.Click += new System.EventHandler(this.CaneclButton_Click);
            // 
            // SettingPage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(14F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CaneclButton;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.CaneclButton);
            this.Controls.Add(this.ShopNameTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AcceptButton);
            this.Name = "SettingPage";
            this.Text = "設定";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button AcceptButton;
        private Label label1;
        private TextBox ShopNameTextBox;
        private Button CaneclButton;
    }
}