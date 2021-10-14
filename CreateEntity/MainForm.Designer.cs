
namespace CreateEntity
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ConStr = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.testConBtn = new System.Windows.Forms.Button();
            this.lable4 = new System.Windows.Forms.Label();
            this.NameSpace = new System.Windows.Forms.TextBox();
            this.checkReplace = new System.Windows.Forms.CheckBox();
            this.checkDbContext = new System.Windows.Forms.CheckBox();
            this.textDbContext = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(180, 322);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(89, 46);
            this.button1.TabIndex = 0;
            this.button1.Text = "开 始";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 60);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "连接字符串:";
            // 
            // ConStr
            // 
            this.ConStr.Location = new System.Drawing.Point(17, 83);
            this.ConStr.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.ConStr.Multiline = true;
            this.ConStr.Name = "ConStr";
            this.ConStr.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.ConStr.Size = new System.Drawing.Size(409, 96);
            this.ConStr.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 20);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 3;
            this.label2.Text = "数据库:";
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.Location = new System.Drawing.Point(67, 18);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(88, 25);
            this.comboBox1.TabIndex = 4;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(102, 186);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(73, 25);
            this.button2.TabIndex = 6;
            this.button2.Text = "选择路径";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 190);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(83, 17);
            this.label3.TabIndex = 8;
            this.label3.Text = "生成文件路径:";
            // 
            // txtPath
            // 
            this.txtPath.BackColor = System.Drawing.SystemColors.Control;
            this.txtPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPath.Location = new System.Drawing.Point(17, 216);
            this.txtPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.txtPath.Multiline = true;
            this.txtPath.Name = "txtPath";
            this.txtPath.ReadOnly = true;
            this.txtPath.Size = new System.Drawing.Size(408, 71);
            this.txtPath.TabIndex = 9;
            // 
            // testConBtn
            // 
            this.testConBtn.Location = new System.Drawing.Point(90, 56);
            this.testConBtn.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.testConBtn.Name = "testConBtn";
            this.testConBtn.Size = new System.Drawing.Size(73, 25);
            this.testConBtn.TabIndex = 10;
            this.testConBtn.Text = "测试连接";
            this.testConBtn.UseVisualStyleBackColor = true;
            this.testConBtn.Click += new System.EventHandler(this.testConBtn_Click);
            // 
            // lable4
            // 
            this.lable4.AutoSize = true;
            this.lable4.Location = new System.Drawing.Point(180, 20);
            this.lable4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lable4.Name = "lable4";
            this.lable4.Size = new System.Drawing.Size(59, 17);
            this.lable4.TabIndex = 11;
            this.lable4.Text = "命名空间:";
            // 
            // NameSpace
            // 
            this.NameSpace.Location = new System.Drawing.Point(242, 19);
            this.NameSpace.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.NameSpace.Name = "NameSpace";
            this.NameSpace.Size = new System.Drawing.Size(175, 23);
            this.NameSpace.TabIndex = 12;
            // 
            // checkReplace
            // 
            this.checkReplace.AutoSize = true;
            this.checkReplace.Location = new System.Drawing.Point(17, 293);
            this.checkReplace.Name = "checkReplace";
            this.checkReplace.Size = new System.Drawing.Size(99, 21);
            this.checkReplace.TabIndex = 13;
            this.checkReplace.Text = "替换现有文件";
            this.checkReplace.UseVisualStyleBackColor = true;
            this.checkReplace.CheckedChanged += new System.EventHandler(this.checkReplace_CheckedChanged);
            // 
            // checkDbContext
            // 
            this.checkDbContext.AutoSize = true;
            this.checkDbContext.Location = new System.Drawing.Point(122, 293);
            this.checkDbContext.Name = "checkDbContext";
            this.checkDbContext.Size = new System.Drawing.Size(92, 21);
            this.checkDbContext.TabIndex = 14;
            this.checkDbContext.Text = "生成上下文-";
            this.checkDbContext.UseVisualStyleBackColor = true;
            this.checkDbContext.CheckedChanged += new System.EventHandler(this.checkDbContext_CheckedChanged);
            // 
            // textDbContext
            // 
            this.textDbContext.Enabled = false;
            this.textDbContext.Location = new System.Drawing.Point(211, 293);
            this.textDbContext.Name = "textDbContext";
            this.textDbContext.Size = new System.Drawing.Size(100, 23);
            this.textDbContext.TabIndex = 15;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(436, 380);
            this.Controls.Add(this.textDbContext);
            this.Controls.Add(this.checkDbContext);
            this.Controls.Add(this.checkReplace);
            this.Controls.Add(this.NameSpace);
            this.Controls.Add(this.lable4);
            this.Controls.Add(this.testConBtn);
            this.Controls.Add(this.txtPath);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ConStr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "实体生成器";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox ConStr;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.Button testConBtn;
        private System.Windows.Forms.Label lable4;
        private System.Windows.Forms.TextBox NameSpace;
        private System.Windows.Forms.CheckBox checkReplace;
        private System.Windows.Forms.CheckBox checkDbContext;
        private System.Windows.Forms.TextBox textDbContext;
    }
}

