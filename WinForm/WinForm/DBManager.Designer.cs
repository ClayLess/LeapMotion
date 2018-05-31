namespace WinForm
{
    partial class DBManager
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
            this.ID_textBox = new System.Windows.Forms.TextBox();
            this.Name_textBox = new System.Windows.Forms.TextBox();
            this.Intro_textBox = new System.Windows.Forms.TextBox();
            this.search_button = new System.Windows.Forms.Button();
            this.clear_button = new System.Windows.Forms.Button();
            this.ID_Label = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.Hand_Info_View = new System.Windows.Forms.ListView();
            this.select_button = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ID_textBox
            // 
            this.ID_textBox.Location = new System.Drawing.Point(202, 46);
            this.ID_textBox.Name = "ID_textBox";
            this.ID_textBox.Size = new System.Drawing.Size(100, 21);
            this.ID_textBox.TabIndex = 0;
            // 
            // Name_textBox
            // 
            this.Name_textBox.Location = new System.Drawing.Point(202, 88);
            this.Name_textBox.Name = "Name_textBox";
            this.Name_textBox.Size = new System.Drawing.Size(100, 21);
            this.Name_textBox.TabIndex = 1;
            // 
            // Intro_textBox
            // 
            this.Intro_textBox.Location = new System.Drawing.Point(202, 127);
            this.Intro_textBox.Name = "Intro_textBox";
            this.Intro_textBox.Size = new System.Drawing.Size(268, 21);
            this.Intro_textBox.TabIndex = 2;
            // 
            // search_button
            // 
            this.search_button.Location = new System.Drawing.Point(111, 179);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(75, 23);
            this.search_button.TabIndex = 3;
            this.search_button.Text = "搜索";
            this.search_button.UseVisualStyleBackColor = true;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // clear_button
            // 
            this.clear_button.Location = new System.Drawing.Point(232, 178);
            this.clear_button.Name = "clear_button";
            this.clear_button.Size = new System.Drawing.Size(75, 23);
            this.clear_button.TabIndex = 4;
            this.clear_button.Text = "清空";
            this.clear_button.UseVisualStyleBackColor = true;
            this.clear_button.Click += new System.EventHandler(this.clear_button_Click);
            // 
            // ID_Label
            // 
            this.ID_Label.AutoSize = true;
            this.ID_Label.Location = new System.Drawing.Point(109, 55);
            this.ID_Label.Name = "ID_Label";
            this.ID_Label.Size = new System.Drawing.Size(17, 12);
            this.ID_Label.TabIndex = 5;
            this.ID_Label.Text = "ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(109, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(29, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(109, 136);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "Intro";
            // 
            // Hand_Info_View
            // 
            this.Hand_Info_View.FullRowSelect = true;
            this.Hand_Info_View.Location = new System.Drawing.Point(55, 216);
            this.Hand_Info_View.Name = "Hand_Info_View";
            this.Hand_Info_View.Size = new System.Drawing.Size(334, 97);
            this.Hand_Info_View.TabIndex = 8;
            this.Hand_Info_View.UseCompatibleStateImageBehavior = false;
            this.Hand_Info_View.View = System.Windows.Forms.View.Details;
            this.Hand_Info_View.SizeChanged += new System.EventHandler(this.Hand_Info_View_SizeChanged);
            // 
            // select_button
            // 
            this.select_button.Location = new System.Drawing.Point(395, 216);
            this.select_button.Name = "select_button";
            this.select_button.Size = new System.Drawing.Size(75, 23);
            this.select_button.TabIndex = 9;
            this.select_button.Text = "选中";
            this.select_button.UseVisualStyleBackColor = true;
            this.select_button.Click += new System.EventHandler(this.select_button_Click);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(396, 276);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 11;
            this.button5.Text = "删除";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // DBManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 368);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.select_button);
            this.Controls.Add(this.Hand_Info_View);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ID_Label);
            this.Controls.Add(this.clear_button);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.Intro_textBox);
            this.Controls.Add(this.Name_textBox);
            this.Controls.Add(this.ID_textBox);
            this.Name = "DBManager";
            this.Text = "DBManager";
            this.SizeChanged += new System.EventHandler(this.DBManager_SizeChanged);
            this.Resize += new System.EventHandler(this.DBManager_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ID_textBox;
        private System.Windows.Forms.TextBox Name_textBox;
        private System.Windows.Forms.TextBox Intro_textBox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.Button clear_button;
        private System.Windows.Forms.Label ID_Label;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListView Hand_Info_View;
        private System.Windows.Forms.Button select_button;
        private System.Windows.Forms.Button button5;
    }
}