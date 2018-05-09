namespace WinForm
{
    partial class DB_Connecter
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
            this.components = new System.ComponentModel.Container();
            this.ip_text = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.port_text = new System.Windows.Forms.TextBox();
            this.DB_name_text = new System.Windows.Forms.TextBox();
            this.username_text = new System.Windows.Forms.TextBox();
            this.password_text = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Comfirm_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ip_text
            // 
            this.ip_text.Location = new System.Drawing.Point(145, 20);
            this.ip_text.Name = "ip_text";
            this.ip_text.Size = new System.Drawing.Size(100, 21);
            this.ip_text.TabIndex = 0;
            this.ip_text.Text = "127.0.0.1";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // port_text
            // 
            this.port_text.Location = new System.Drawing.Point(145, 60);
            this.port_text.Name = "port_text";
            this.port_text.Size = new System.Drawing.Size(100, 21);
            this.port_text.TabIndex = 2;
            this.port_text.Text = "3306";
            // 
            // DB_name_text
            // 
            this.DB_name_text.Location = new System.Drawing.Point(145, 100);
            this.DB_name_text.Name = "DB_name_text";
            this.DB_name_text.Size = new System.Drawing.Size(100, 21);
            this.DB_name_text.TabIndex = 3;
            this.DB_name_text.Text = "test1";
            // 
            // username_text
            // 
            this.username_text.Location = new System.Drawing.Point(145, 140);
            this.username_text.Name = "username_text";
            this.username_text.Size = new System.Drawing.Size(100, 21);
            this.username_text.TabIndex = 4;
            this.username_text.Text = "root";
            // 
            // password_text
            // 
            this.password_text.Location = new System.Drawing.Point(145, 180);
            this.password_text.Name = "password_text";
            this.password_text.PasswordChar = '*';
            this.password_text.Size = new System.Drawing.Size(100, 21);
            this.password_text.TabIndex = 5;
            this.password_text.Text = "123456";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F);
            this.label1.Location = new System.Drawing.Point(46, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 6;
            this.label1.Text = "IP address";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F);
            this.label2.Location = new System.Drawing.Point(46, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Port";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F);
            this.label3.Location = new System.Drawing.Point(46, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "DB name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F);
            this.label4.Location = new System.Drawing.Point(46, 143);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 9;
            this.label4.Text = "username";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F);
            this.label5.Location = new System.Drawing.Point(46, 183);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "password";
            // 
            // Comfirm_button
            // 
            this.Comfirm_button.Location = new System.Drawing.Point(95, 217);
            this.Comfirm_button.Name = "Comfirm_button";
            this.Comfirm_button.Size = new System.Drawing.Size(75, 23);
            this.Comfirm_button.TabIndex = 11;
            this.Comfirm_button.Text = "Comfirm";
            this.Comfirm_button.UseVisualStyleBackColor = true;
            this.Comfirm_button.Click += new System.EventHandler(this.Comfirm_button_Click);
            // 
            // DB_Connecter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Controls.Add(this.Comfirm_button);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.password_text);
            this.Controls.Add(this.username_text);
            this.Controls.Add(this.DB_name_text);
            this.Controls.Add(this.port_text);
            this.Controls.Add(this.ip_text);
            this.Name = "DB_Connecter";
            this.Text = "DB_Connecter";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ip_text;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox port_text;
        private System.Windows.Forms.TextBox DB_name_text;
        private System.Windows.Forms.TextBox username_text;
        private System.Windows.Forms.TextBox password_text;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Comfirm_button;
    }
}