namespace WinForm
{
    partial class SendIdForm
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
            this.HandId_textBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ComfirmButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // HandId_textBox
            // 
            this.HandId_textBox.Location = new System.Drawing.Point(138, 82);
            this.HandId_textBox.Name = "HandId_textBox";
            this.HandId_textBox.Size = new System.Drawing.Size(100, 21);
            this.HandId_textBox.TabIndex = 0;
            this.HandId_textBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.HandId_textBox_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 16F);
            this.label1.Location = new System.Drawing.Point(36, 82);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 22);
            this.label1.TabIndex = 1;
            this.label1.Text = "Hand ID";
            // 
            // ComfirmButton
            // 
            this.ComfirmButton.Font = new System.Drawing.Font("宋体", 12F);
            this.ComfirmButton.Location = new System.Drawing.Point(96, 159);
            this.ComfirmButton.Name = "ComfirmButton";
            this.ComfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ComfirmButton.TabIndex = 2;
            this.ComfirmButton.Text = "Comfirm";
            this.ComfirmButton.UseVisualStyleBackColor = true;
            this.ComfirmButton.Click += new System.EventHandler(this.ComfirmButton_Click);
            // 
            // SendIdForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.ComfirmButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.HandId_textBox);
            this.Name = "SendIdForm";
            this.Text = "SendIdForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox HandId_textBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button ComfirmButton;
    }
}