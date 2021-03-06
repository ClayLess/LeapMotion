﻿using System;

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
            this.Compare_Label = new System.Windows.Forms.Label();
            this.Eculid_Label = new System.Windows.Forms.Label();
            this.DotMult_Lable = new System.Windows.Forms.Label();
            this.Compare_Text = new System.Windows.Forms.TextBox();
            this.Eculid_Text = new System.Windows.Forms.TextBox();
            this.DotMult_Text = new System.Windows.Forms.TextBox();
            this.LeapStatus = new System.Windows.Forms.Label();
            this.Exe_Panel = new System.Windows.Forms.Panel();
            this.FingerList = new System.Windows.Forms.ListView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.比较模式ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.单手比较ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.双手比较ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新建条目ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.数据库连接信息ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StartSene = new System.Windows.Forms.ToolStripMenuItem();
            this.调试启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.VHand_name_Label = new System.Windows.Forms.Label();
            this.VHand_Name_TextBox = new System.Windows.Forms.TextBox();
            this.UpLoad_Button = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // Compare_Label
            // 
            this.Compare_Label.AutoSize = true;
            this.Compare_Label.Location = new System.Drawing.Point(111, 504);
            this.Compare_Label.Name = "Compare_Label";
            this.Compare_Label.Size = new System.Drawing.Size(47, 12);
            this.Compare_Label.TabIndex = 1;
            this.Compare_Label.Text = "Compare";
            // 
            // Eculid_Label
            // 
            this.Eculid_Label.AutoSize = true;
            this.Eculid_Label.Location = new System.Drawing.Point(111, 531);
            this.Eculid_Label.Name = "Eculid_Label";
            this.Eculid_Label.Size = new System.Drawing.Size(41, 12);
            this.Eculid_Label.TabIndex = 2;
            this.Eculid_Label.Text = "Eculid";
            // 
            // DotMult_Lable
            // 
            this.DotMult_Lable.AutoSize = true;
            this.DotMult_Lable.Location = new System.Drawing.Point(111, 558);
            this.DotMult_Lable.Name = "DotMult_Lable";
            this.DotMult_Lable.Size = new System.Drawing.Size(47, 12);
            this.DotMult_Lable.TabIndex = 3;
            this.DotMult_Lable.Text = "DotMult";
            // 
            // Compare_Text
            // 
            this.Compare_Text.Location = new System.Drawing.Point(183, 501);
            this.Compare_Text.Name = "Compare_Text";
            this.Compare_Text.Size = new System.Drawing.Size(100, 21);
            this.Compare_Text.TabIndex = 4;
            // 
            // Eculid_Text
            // 
            this.Eculid_Text.Location = new System.Drawing.Point(183, 528);
            this.Eculid_Text.Name = "Eculid_Text";
            this.Eculid_Text.Size = new System.Drawing.Size(100, 21);
            this.Eculid_Text.TabIndex = 5;
            // 
            // DotMult_Text
            // 
            this.DotMult_Text.Location = new System.Drawing.Point(183, 555);
            this.DotMult_Text.Name = "DotMult_Text";
            this.DotMult_Text.Size = new System.Drawing.Size(100, 21);
            this.DotMult_Text.TabIndex = 6;
            // 
            // LeapStatus
            // 
            this.LeapStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LeapStatus.AutoSize = true;
            this.LeapStatus.Location = new System.Drawing.Point(111, 614);
            this.LeapStatus.Name = "LeapStatus";
            this.LeapStatus.Size = new System.Drawing.Size(0, 12);
            this.LeapStatus.TabIndex = 7;
            // 
            // Exe_Panel
            // 
            this.Exe_Panel.AutoSize = true;
            this.Exe_Panel.Location = new System.Drawing.Point(12, 36);
            this.Exe_Panel.Name = "Exe_Panel";
            this.Exe_Panel.Size = new System.Drawing.Size(640, 433);
            this.Exe_Panel.TabIndex = 8;
            // 
            // FingerList
            // 
            this.FingerList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.FingerList.Location = new System.Drawing.Point(426, 488);
            this.FingerList.Name = "FingerList";
            this.FingerList.Size = new System.Drawing.Size(226, 144);
            this.FingerList.TabIndex = 9;
            this.FingerList.UseCompatibleStateImageBehavior = false;
            this.FingerList.View = System.Windows.Forms.View.Tile;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.比较模式ToolStripMenuItem,
            this.数据库ToolStripMenuItem,
            this.StartSene,
            this.调试启动ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(666, 25);
            this.menuStrip1.TabIndex = 11;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 比较模式ToolStripMenuItem
            // 
            this.比较模式ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.单手比较ToolStripMenuItem,
            this.双手比较ToolStripMenuItem});
            this.比较模式ToolStripMenuItem.Name = "比较模式ToolStripMenuItem";
            this.比较模式ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.比较模式ToolStripMenuItem.Text = "比较模式";
            // 
            // 单手比较ToolStripMenuItem
            // 
            this.单手比较ToolStripMenuItem.Name = "单手比较ToolStripMenuItem";
            this.单手比较ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.单手比较ToolStripMenuItem.Text = "单手比较";
            this.单手比较ToolStripMenuItem.Click += new System.EventHandler(this.单手比较ToolStripMenuItem_Click);
            // 
            // 双手比较ToolStripMenuItem
            // 
            this.双手比较ToolStripMenuItem.Name = "双手比较ToolStripMenuItem";
            this.双手比较ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.双手比较ToolStripMenuItem.Text = "双手比较";
            this.双手比较ToolStripMenuItem.Click += new System.EventHandler(this.双手比较ToolStripMenuItem_Click);
            // 
            // 数据库ToolStripMenuItem
            // 
            this.数据库ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新建条目ToolStripMenuItem,
            this.数据库管理ToolStripMenuItem,
            this.数据库连接信息ToolStripMenuItem});
            this.数据库ToolStripMenuItem.Name = "数据库ToolStripMenuItem";
            this.数据库ToolStripMenuItem.Size = new System.Drawing.Size(56, 21);
            this.数据库ToolStripMenuItem.Text = "数据库";
            // 
            // 新建条目ToolStripMenuItem
            // 
            this.新建条目ToolStripMenuItem.Name = "新建条目ToolStripMenuItem";
            this.新建条目ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.新建条目ToolStripMenuItem.Text = "新建条目";
            this.新建条目ToolStripMenuItem.Click += new System.EventHandler(this.新建条目ToolStripMenuItem_Click);
            // 
            // 数据库管理ToolStripMenuItem
            // 
            this.数据库管理ToolStripMenuItem.Name = "数据库管理ToolStripMenuItem";
            this.数据库管理ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.数据库管理ToolStripMenuItem.Text = "管理数据库";
            this.数据库管理ToolStripMenuItem.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            this.数据库管理ToolStripMenuItem.Click += new System.EventHandler(this.数据库管理ToolStripMenuItem_Click);
            // 
            // 数据库连接信息ToolStripMenuItem
            // 
            this.数据库连接信息ToolStripMenuItem.Name = "数据库连接信息ToolStripMenuItem";
            this.数据库连接信息ToolStripMenuItem.Size = new System.Drawing.Size(160, 22);
            this.数据库连接信息ToolStripMenuItem.Text = "数据库连接信息";
            this.数据库连接信息ToolStripMenuItem.Click += new System.EventHandler(this.数据库连接信息ToolStripMenuItem_Click);
            // 
            // StartSene
            // 
            this.StartSene.Name = "StartSene";
            this.StartSene.Size = new System.Drawing.Size(68, 21);
            this.StartSene.Text = "启动场景";
            this.StartSene.Click += new System.EventHandler(this.启动场景ToolStripMenuItem_Click);
            // 
            // 调试启动ToolStripMenuItem
            // 
            this.调试启动ToolStripMenuItem.Name = "调试启动ToolStripMenuItem";
            this.调试启动ToolStripMenuItem.Size = new System.Drawing.Size(68, 21);
            this.调试启动ToolStripMenuItem.Text = "调试启动";
            this.调试启动ToolStripMenuItem.Visible = false;
            this.调试启动ToolStripMenuItem.Click += new System.EventHandler(this.调试qidongToolStripMenuItem_Click);
            // 
            // VHand_name_Label
            // 
            this.VHand_name_Label.AutoSize = true;
            this.VHand_name_Label.Location = new System.Drawing.Point(51, 590);
            this.VHand_name_Label.Name = "VHand_name_Label";
            this.VHand_name_Label.Size = new System.Drawing.Size(107, 12);
            this.VHand_name_Label.TabIndex = 13;
            this.VHand_name_Label.Text = "Virtual Hand Name";
            // 
            // VHand_Name_TextBox
            // 
            this.VHand_Name_TextBox.Location = new System.Drawing.Point(183, 587);
            this.VHand_Name_TextBox.Name = "VHand_Name_TextBox";
            this.VHand_Name_TextBox.Size = new System.Drawing.Size(100, 21);
            this.VHand_Name_TextBox.TabIndex = 14;
            this.VHand_Name_TextBox.Text = "TestHand3";
            this.VHand_Name_TextBox.TextChanged += new System.EventHandler(this.VHand_Name_TextBox_TextChanged);
            // 
            // UpLoad_Button
            // 
            this.UpLoad_Button.Location = new System.Drawing.Point(290, 609);
            this.UpLoad_Button.Name = "UpLoad_Button";
            this.UpLoad_Button.Size = new System.Drawing.Size(75, 23);
            this.UpLoad_Button.TabIndex = 15;
            this.UpLoad_Button.Text = "Upload";
            this.UpLoad_Button.UseVisualStyleBackColor = true;
            this.UpLoad_Button.Click += new System.EventHandler(this.UpLoad_Button_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(666, 661);
            this.Controls.Add(this.UpLoad_Button);
            this.Controls.Add(this.VHand_Name_TextBox);
            this.Controls.Add(this.VHand_name_Label);
            this.Controls.Add(this.FingerList);
            this.Controls.Add(this.Exe_Panel);
            this.Controls.Add(this.LeapStatus);
            this.Controls.Add(this.DotMult_Text);
            this.Controls.Add(this.Eculid_Text);
            this.Controls.Add(this.Compare_Text);
            this.Controls.Add(this.DotMult_Lable);
            this.Controls.Add(this.Eculid_Label);
            this.Controls.Add(this.Compare_Label);
            this.Controls.Add(this.menuStrip1);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "MainForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label Compare_Label;
        private System.Windows.Forms.Label Eculid_Label;
        private System.Windows.Forms.Label DotMult_Lable;
        private System.Windows.Forms.TextBox Compare_Text;
        private System.Windows.Forms.TextBox Eculid_Text;
        private System.Windows.Forms.TextBox DotMult_Text;
        private System.Windows.Forms.Label LeapStatus;
        private System.Windows.Forms.Panel Exe_Panel;
        private System.Windows.Forms.ListView FingerList;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 比较模式ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 单手比较ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 双手比较ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新建条目ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 数据库管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem StartSene;
        private System.Windows.Forms.ToolStripMenuItem 数据库连接信息ToolStripMenuItem;
        private System.Windows.Forms.Label VHand_name_Label;
        private System.Windows.Forms.TextBox VHand_Name_TextBox;
        private System.Windows.Forms.Button UpLoad_Button;
        private System.Windows.Forms.ToolStripMenuItem 调试启动ToolStripMenuItem;
    }
}

