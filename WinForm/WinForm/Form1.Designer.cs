namespace WinForm
{
    partial class MainForm
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.Compare_Label = new System.Windows.Forms.Label();
            this.Eculid_Label = new System.Windows.Forms.Label();
            this.DotMult_Lable = new System.Windows.Forms.Label();
            this.Compare_Text = new System.Windows.Forms.TextBox();
            this.Eculid_Text = new System.Windows.Forms.TextBox();
            this.DotMult_Text = new System.Windows.Forms.TextBox();
            this.LeapStatus = new System.Windows.Forms.Label();
            this.Exe_Panel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(298, 626);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Compare_Label
            // 
            this.Compare_Label.AutoSize = true;
            this.Compare_Label.Location = new System.Drawing.Point(226, 516);
            this.Compare_Label.Name = "Compare_Label";
            this.Compare_Label.Size = new System.Drawing.Size(47, 12);
            this.Compare_Label.TabIndex = 1;
            this.Compare_Label.Text = "Compare";
            // 
            // Eculid_Label
            // 
            this.Eculid_Label.AutoSize = true;
            this.Eculid_Label.Location = new System.Drawing.Point(226, 543);
            this.Eculid_Label.Name = "Eculid_Label";
            this.Eculid_Label.Size = new System.Drawing.Size(41, 12);
            this.Eculid_Label.TabIndex = 2;
            this.Eculid_Label.Text = "Eculid";
            // 
            // DotMult_Lable
            // 
            this.DotMult_Lable.AutoSize = true;
            this.DotMult_Lable.Location = new System.Drawing.Point(226, 570);
            this.DotMult_Lable.Name = "DotMult_Lable";
            this.DotMult_Lable.Size = new System.Drawing.Size(47, 12);
            this.DotMult_Lable.TabIndex = 3;
            this.DotMult_Lable.Text = "DotMult";
            // 
            // Compare_Text
            // 
            this.Compare_Text.Location = new System.Drawing.Point(298, 513);
            this.Compare_Text.Name = "Compare_Text";
            this.Compare_Text.Size = new System.Drawing.Size(100, 21);
            this.Compare_Text.TabIndex = 4;
            // 
            // Eculid_Text
            // 
            this.Eculid_Text.Location = new System.Drawing.Point(298, 540);
            this.Eculid_Text.Name = "Eculid_Text";
            this.Eculid_Text.Size = new System.Drawing.Size(100, 21);
            this.Eculid_Text.TabIndex = 5;
            // 
            // DotMult_Text
            // 
            this.DotMult_Text.Location = new System.Drawing.Point(298, 567);
            this.DotMult_Text.Name = "DotMult_Text";
            this.DotMult_Text.Size = new System.Drawing.Size(100, 21);
            this.DotMult_Text.TabIndex = 6;
            // 
            // LeapStatus
            // 
            this.LeapStatus.AutoSize = true;
            this.LeapStatus.Location = new System.Drawing.Point(226, 599);
            this.LeapStatus.Name = "LeapStatus";
            this.LeapStatus.Size = new System.Drawing.Size(0, 12);
            this.LeapStatus.TabIndex = 7;
            // 
            // Exe_Panel
            // 
            this.Exe_Panel.Location = new System.Drawing.Point(12, 12);
            this.Exe_Panel.Name = "Exe_Panel";
            this.Exe_Panel.Size = new System.Drawing.Size(640, 480);
            this.Exe_Panel.TabIndex = 8;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(668, 654);
            this.Controls.Add(this.Exe_Panel);
            this.Controls.Add(this.LeapStatus);
            this.Controls.Add(this.DotMult_Text);
            this.Controls.Add(this.Eculid_Text);
            this.Controls.Add(this.Compare_Text);
            this.Controls.Add(this.DotMult_Lable);
            this.Controls.Add(this.Eculid_Label);
            this.Controls.Add(this.Compare_Label);
            this.Controls.Add(this.button1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label Compare_Label;
        private System.Windows.Forms.Label Eculid_Label;
        private System.Windows.Forms.Label DotMult_Lable;
        private System.Windows.Forms.TextBox Compare_Text;
        private System.Windows.Forms.TextBox Eculid_Text;
        private System.Windows.Forms.TextBox DotMult_Text;
        private System.Windows.Forms.Label LeapStatus;
        private System.Windows.Forms.Panel Exe_Panel;
    }
}

