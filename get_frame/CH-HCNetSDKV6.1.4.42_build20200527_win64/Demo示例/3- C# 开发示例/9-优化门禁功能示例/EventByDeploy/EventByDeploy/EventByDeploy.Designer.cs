namespace EventByDeploy
{
    partial class EventByDeploy
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
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(EventByDeploy));
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBoxCardNo = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.pictureBoxPic = new System.Windows.Forms.PictureBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxEmployeeNo = new System.Windows.Forms.TextBox();
            this.btnDeploy = new System.Windows.Forms.Button();
            this.cbDeployType = new System.Windows.Forms.ComboBox();
            this.listViewAlarmInfo = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxLanguage = new System.Windows.Forms.ComboBox();
            this.textBoxTime = new System.Windows.Forms.TextBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("panel1.BackgroundImage")));
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(877, 106);
            this.panel1.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Consolas", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(276, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(303, 41);
            this.label1.TabIndex = 1;
            this.label1.Text = "Event By Deploy";
            // 
            // btnLogin
            // 
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLogin.Location = new System.Drawing.Point(14, 124);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(82, 29);
            this.btnLogin.TabIndex = 4;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(299, 131);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(462, 14);
            this.label6.TabIndex = 56;
            this.label6.Text = "You should select one between Client Deploy and Real Time Deploy.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(299, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(497, 14);
            this.label2.TabIndex = 57;
            this.label2.Text = "Client Deploy means you can accept real time event and offline events.";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(299, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(427, 14);
            this.label3.TabIndex = 58;
            this.label3.Text = "Real Time Deploy means you can only accept real time events.";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.ForeColor = System.Drawing.Color.DimGray;
            this.label5.Location = new System.Drawing.Point(139, 278);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 14);
            this.label5.TabIndex = 62;
            this.label5.Text = "Card No";
            // 
            // textBoxCardNo
            // 
            this.textBoxCardNo.Location = new System.Drawing.Point(285, 277);
            this.textBoxCardNo.Name = "textBoxCardNo";
            this.textBoxCardNo.Size = new System.Drawing.Size(159, 22);
            this.textBoxCardNo.TabIndex = 61;
            this.textBoxCardNo.Text = "456";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.ForeColor = System.Drawing.Color.DimGray;
            this.label7.Location = new System.Drawing.Point(139, 325);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(39, 14);
            this.label7.TabIndex = 64;
            this.label7.Text = "Time";
            // 
            // pictureBoxPic
            // 
            this.pictureBoxPic.BackColor = System.Drawing.Color.White;
            this.pictureBoxPic.Location = new System.Drawing.Point(512, 218);
            this.pictureBoxPic.Name = "pictureBoxPic";
            this.pictureBoxPic.Size = new System.Drawing.Size(143, 176);
            this.pictureBoxPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPic.TabIndex = 65;
            this.pictureBoxPic.TabStop = false;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("宋体", 10.5F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label8.ForeColor = System.Drawing.Color.DimGray;
            this.label8.Location = new System.Drawing.Point(139, 236);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(95, 14);
            this.label8.TabIndex = 68;
            this.label8.Text = "Employee No";
            // 
            // textBoxEmployeeNo
            // 
            this.textBoxEmployeeNo.Location = new System.Drawing.Point(285, 235);
            this.textBoxEmployeeNo.Name = "textBoxEmployeeNo";
            this.textBoxEmployeeNo.Size = new System.Drawing.Size(159, 22);
            this.textBoxEmployeeNo.TabIndex = 67;
            this.textBoxEmployeeNo.Text = "123";
            // 
            // btnDeploy
            // 
            this.btnDeploy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDeploy.Location = new System.Drawing.Point(113, 173);
            this.btnDeploy.Name = "btnDeploy";
            this.btnDeploy.Size = new System.Drawing.Size(139, 29);
            this.btnDeploy.TabIndex = 6;
            this.btnDeploy.Text = "Deploy";
            this.btnDeploy.UseVisualStyleBackColor = true;
            this.btnDeploy.Click += new System.EventHandler(this.btnDeploy_Click);
            // 
            // cbDeployType
            // 
            this.cbDeployType.FormattingEnabled = true;
            this.cbDeployType.Items.AddRange(new object[] {
            "Client Deploy",
            "Real Time Deploy"});
            this.cbDeployType.Location = new System.Drawing.Point(113, 128);
            this.cbDeployType.Name = "cbDeployType";
            this.cbDeployType.Size = new System.Drawing.Size(139, 22);
            this.cbDeployType.TabIndex = 70;
            this.cbDeployType.Text = "Client Deploy";
            // 
            // listViewAlarmInfo
            // 
            this.listViewAlarmInfo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listViewAlarmInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.listViewAlarmInfo.FullRowSelect = true;
            this.listViewAlarmInfo.GridLines = true;
            this.listViewAlarmInfo.Location = new System.Drawing.Point(14, 422);
            this.listViewAlarmInfo.Name = "listViewAlarmInfo";
            this.listViewAlarmInfo.Size = new System.Drawing.Size(850, 198);
            this.listViewAlarmInfo.TabIndex = 71;
            this.listViewAlarmInfo.UseCompatibleStateImageBehavior = false;
            this.listViewAlarmInfo.View = System.Windows.Forms.View.Details;
            this.listViewAlarmInfo.SelectedIndexChanged += new System.EventHandler(this.listViewAlarmInfo_SelectedIndexChanged);
            this.listViewAlarmInfo.DoubleClick += new System.EventHandler(this.listViewAlarmInfo_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 64;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Time";
            this.columnHeader2.Width = 144;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "AlarmInfo";
            this.columnHeader3.Width = 627;
            // 
            // comboBoxLanguage
            // 
            this.comboBoxLanguage.FormattingEnabled = true;
            this.comboBoxLanguage.Items.AddRange(new object[] {
            "English",
            "Chinese"});
            this.comboBoxLanguage.Location = new System.Drawing.Point(743, 377);
            this.comboBoxLanguage.Name = "comboBoxLanguage";
            this.comboBoxLanguage.Size = new System.Drawing.Size(94, 22);
            this.comboBoxLanguage.TabIndex = 72;
            this.comboBoxLanguage.SelectedIndexChanged += new System.EventHandler(this.comboBoxLanguage_SelectedIndexChanged);
            // 
            // textBoxTime
            // 
            this.textBoxTime.Location = new System.Drawing.Point(283, 321);
            this.textBoxTime.Name = "textBoxTime";
            this.textBoxTime.Size = new System.Drawing.Size(161, 22);
            this.textBoxTime.TabIndex = 73;
            // 
            // EventByDeploy
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(876, 632);
            this.Controls.Add(this.textBoxTime);
            this.Controls.Add(this.comboBoxLanguage);
            this.Controls.Add(this.listViewAlarmInfo);
            this.Controls.Add(this.cbDeployType);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBoxEmployeeNo);
            this.Controls.Add(this.pictureBoxPic);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBoxCardNo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnDeploy);
            this.Controls.Add(this.btnLogin);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "EventByDeploy";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ACS Demo";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.EventByDeploy_FormClosing);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBoxCardNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.PictureBox pictureBoxPic;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBoxEmployeeNo;
        private System.Windows.Forms.Button btnDeploy;
        private System.Windows.Forms.ComboBox cbDeployType;
        private System.Windows.Forms.ListView listViewAlarmInfo;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ComboBox comboBoxLanguage;
        private System.Windows.Forms.TextBox textBoxTime;
    }
}

