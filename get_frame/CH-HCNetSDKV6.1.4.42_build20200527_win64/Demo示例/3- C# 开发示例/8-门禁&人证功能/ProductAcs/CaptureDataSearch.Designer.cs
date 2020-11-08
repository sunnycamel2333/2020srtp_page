namespace AcsDemo.ProductAcs
{
    partial class CaptureDataSearch
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
            this.listViewDataDisplay = new System.Windows.Forms.ListView();
            this.columnHeaderIndex = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCaptureNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderLastNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderEmployeeNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderIDCard = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderCardNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderFPID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripTools = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClear = new System.Windows.Forms.ToolStripMenuItem();
            this.pictureBoxPic = new System.Windows.Forms.PictureBox();
            this.pictureBoxInfrared = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxCaptureNo = new System.Windows.Forms.TextBox();
            this.textBoxMaxResults = new System.Windows.Forms.TextBox();
            this.textBoxSearchPos = new System.Windows.Forms.TextBox();
            this.textBoxSearchID = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.richTextBoxOutputJson = new System.Windows.Forms.RichTextBox();
            this.buttonSearch = new System.Windows.Forms.Button();
            this.buttonBefore = new System.Windows.Forms.Button();
            this.buttonNext = new System.Windows.Forms.Button();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonStop = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.columnHeaderDataType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.comboBoxSearchType = new System.Windows.Forms.ComboBox();
            this.columnHeaderRisk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStripTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPic)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfrared)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewDataDisplay
            // 
            this.listViewDataDisplay.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIndex,
            this.columnHeaderCaptureNo,
            this.columnHeaderLastNo,
            this.columnHeaderName,
            this.columnHeaderEmployeeNo,
            this.columnHeaderIDCard,
            this.columnHeaderCardNo,
            this.columnHeaderFPID,
            this.columnHeaderDataType,
            this.columnHeaderRisk});
            this.listViewDataDisplay.ContextMenuStrip = this.contextMenuStripTools;
            this.listViewDataDisplay.FullRowSelect = true;
            this.listViewDataDisplay.GridLines = true;
            this.listViewDataDisplay.Location = new System.Drawing.Point(14, 10);
            this.listViewDataDisplay.MultiSelect = false;
            this.listViewDataDisplay.Name = "listViewDataDisplay";
            this.listViewDataDisplay.Size = new System.Drawing.Size(893, 257);
            this.listViewDataDisplay.TabIndex = 0;
            this.listViewDataDisplay.UseCompatibleStateImageBehavior = false;
            this.listViewDataDisplay.View = System.Windows.Forms.View.Details;
            this.listViewDataDisplay.SelectedIndexChanged += new System.EventHandler(this.listViewDataDisplay_SelectedIndexChanged);
            // 
            // columnHeaderIndex
            // 
            this.columnHeaderIndex.Text = "Index";
            // 
            // columnHeaderCaptureNo
            // 
            this.columnHeaderCaptureNo.Text = "CaptureNo";
            this.columnHeaderCaptureNo.Width = 102;
            // 
            // columnHeaderLastNo
            // 
            this.columnHeaderLastNo.Text = "LastCaptureNo";
            this.columnHeaderLastNo.Width = 108;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 97;
            // 
            // columnHeaderEmployeeNo
            // 
            this.columnHeaderEmployeeNo.Text = "EmployeeNo";
            this.columnHeaderEmployeeNo.Width = 107;
            // 
            // columnHeaderIDCard
            // 
            this.columnHeaderIDCard.Text = "IDCardNo";
            this.columnHeaderIDCard.Width = 122;
            // 
            // columnHeaderCardNo
            // 
            this.columnHeaderCardNo.Text = "CardNos";
            this.columnHeaderCardNo.Width = 143;
            // 
            // columnHeaderFPID
            // 
            this.columnHeaderFPID.Text = "FingprintIDs";
            this.columnHeaderFPID.Width = 89;
            // 
            // contextMenuStripTools
            // 
            this.contextMenuStripTools.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClear});
            this.contextMenuStripTools.Name = "contextMenuStripTools";
            this.contextMenuStripTools.Size = new System.Drawing.Size(107, 26);
            this.contextMenuStripTools.Opening += new System.ComponentModel.CancelEventHandler(this.contextMenuStripTools_Opening);
            this.contextMenuStripTools.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.contextMenuStripTools_ItemClicked);
            // 
            // toolStripMenuItemClear
            // 
            this.toolStripMenuItemClear.Name = "toolStripMenuItemClear";
            this.toolStripMenuItemClear.Size = new System.Drawing.Size(106, 22);
            this.toolStripMenuItemClear.Text = "Clear";
            // 
            // pictureBoxPic
            // 
            this.pictureBoxPic.Location = new System.Drawing.Point(28, 17);
            this.pictureBoxPic.Name = "pictureBoxPic";
            this.pictureBoxPic.Size = new System.Drawing.Size(110, 151);
            this.pictureBoxPic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxPic.TabIndex = 1;
            this.pictureBoxPic.TabStop = false;
            // 
            // pictureBoxInfrared
            // 
            this.pictureBoxInfrared.Location = new System.Drawing.Point(156, 17);
            this.pictureBoxInfrared.Name = "pictureBoxInfrared";
            this.pictureBoxInfrared.Size = new System.Drawing.Size(110, 151);
            this.pictureBoxInfrared.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxInfrared.TabIndex = 1;
            this.pictureBoxInfrared.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboBoxSearchType);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBoxCaptureNo);
            this.groupBox1.Controls.Add(this.textBoxMaxResults);
            this.groupBox1.Controls.Add(this.textBoxSearchPos);
            this.groupBox1.Controls.Add(this.textBoxSearchID);
            this.groupBox1.Location = new System.Drawing.Point(14, 273);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(291, 203);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Condition";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 141);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(65, 12);
            this.label5.TabIndex = 2;
            this.label5.Text = "CaptureNos";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 107);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 2;
            this.label4.Text = "MaxResults";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "SearchPosition";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "SearchID";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(0, 12);
            this.label1.TabIndex = 1;
            // 
            // textBoxCaptureNo
            // 
            this.textBoxCaptureNo.Location = new System.Drawing.Point(107, 138);
            this.textBoxCaptureNo.Name = "textBoxCaptureNo";
            this.textBoxCaptureNo.Size = new System.Drawing.Size(160, 21);
            this.textBoxCaptureNo.TabIndex = 0;
            this.textBoxCaptureNo.Text = "1";
            this.toolTip1.SetToolTip(this.textBoxCaptureNo, "Tips: input 1,2,3 or 1 2 3 or null");
            // 
            // textBoxMaxResults
            // 
            this.textBoxMaxResults.Location = new System.Drawing.Point(107, 102);
            this.textBoxMaxResults.Name = "textBoxMaxResults";
            this.textBoxMaxResults.ReadOnly = true;
            this.textBoxMaxResults.Size = new System.Drawing.Size(160, 21);
            this.textBoxMaxResults.TabIndex = 0;
            this.textBoxMaxResults.Text = "1";
            this.textBoxMaxResults.Visible = false;
            // 
            // textBoxSearchPos
            // 
            this.textBoxSearchPos.Location = new System.Drawing.Point(107, 60);
            this.textBoxSearchPos.Name = "textBoxSearchPos";
            this.textBoxSearchPos.Size = new System.Drawing.Size(160, 21);
            this.textBoxSearchPos.TabIndex = 0;
            this.textBoxSearchPos.Text = "0";
            // 
            // textBoxSearchID
            // 
            this.textBoxSearchID.Location = new System.Drawing.Point(107, 20);
            this.textBoxSearchID.Name = "textBoxSearchID";
            this.textBoxSearchID.Size = new System.Drawing.Size(160, 21);
            this.textBoxSearchID.TabIndex = 0;
            this.textBoxSearchID.Text = "123abc";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.richTextBoxOutputJson);
            this.groupBox2.Controls.Add(this.pictureBoxPic);
            this.groupBox2.Controls.Add(this.pictureBoxInfrared);
            this.groupBox2.Location = new System.Drawing.Point(328, 273);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(579, 174);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Details";
            // 
            // richTextBoxOutputJson
            // 
            this.richTextBoxOutputJson.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxOutputJson.Location = new System.Drawing.Point(289, 17);
            this.richTextBoxOutputJson.Name = "richTextBoxOutputJson";
            this.richTextBoxOutputJson.Size = new System.Drawing.Size(284, 151);
            this.richTextBoxOutputJson.TabIndex = 6;
            this.richTextBoxOutputJson.Text = "";
            // 
            // buttonSearch
            // 
            this.buttonSearch.Location = new System.Drawing.Point(455, 453);
            this.buttonSearch.Name = "buttonSearch";
            this.buttonSearch.Size = new System.Drawing.Size(75, 23);
            this.buttonSearch.TabIndex = 4;
            this.buttonSearch.Text = "Search";
            this.buttonSearch.UseVisualStyleBackColor = true;
            this.buttonSearch.Click += new System.EventHandler(this.buttonSearch_Click);
            // 
            // buttonBefore
            // 
            this.buttonBefore.Location = new System.Drawing.Point(552, 453);
            this.buttonBefore.Name = "buttonBefore";
            this.buttonBefore.Size = new System.Drawing.Size(75, 23);
            this.buttonBefore.TabIndex = 4;
            this.buttonBefore.Text = "Before";
            this.buttonBefore.UseVisualStyleBackColor = true;
            this.buttonBefore.Visible = false;
            // 
            // buttonNext
            // 
            this.buttonNext.Location = new System.Drawing.Point(649, 453);
            this.buttonNext.Name = "buttonNext";
            this.buttonNext.Size = new System.Drawing.Size(75, 23);
            this.buttonNext.TabIndex = 4;
            this.buttonNext.Text = "Next";
            this.buttonNext.UseVisualStyleBackColor = true;
            this.buttonNext.Visible = false;
            // 
            // listViewMessage
            // 
            this.listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader21,
            this.columnHeader22});
            this.listViewMessage.ContextMenuStrip = this.contextMenuStripTools;
            this.listViewMessage.FullRowSelect = true;
            this.listViewMessage.GridLines = true;
            this.listViewMessage.Location = new System.Drawing.Point(20, 486);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(887, 117);
            this.listViewMessage.TabIndex = 60;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Time";
            this.columnHeader1.Width = 177;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "State";
            this.columnHeader21.Width = 112;
            // 
            // columnHeader22
            // 
            this.columnHeader22.Text = "Operation\r\n";
            this.columnHeader22.Width = 593;
            // 
            // buttonStop
            // 
            this.buttonStop.Location = new System.Drawing.Point(766, 453);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(75, 23);
            this.buttonStop.TabIndex = 4;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 180);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(65, 12);
            this.label6.TabIndex = 2;
            this.label6.Text = "SearchType";
            // 
            // columnHeaderDataType
            // 
            this.columnHeaderDataType.Text = "DataType";
            // 
            // comboBoxSearchType
            // 
            this.comboBoxSearchType.FormattingEnabled = true;
            this.comboBoxSearchType.Items.AddRange(new object[] {
            "",
            "new",
            "modified"});
            this.comboBoxSearchType.Location = new System.Drawing.Point(107, 171);
            this.comboBoxSearchType.Name = "comboBoxSearchType";
            this.comboBoxSearchType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxSearchType.TabIndex = 3;
            // 
            // columnHeaderRisk
            // 
            this.columnHeaderRisk.Text = "RiskData";
            // 
            // CaptureDataSearch
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 615);
            this.Controls.Add(this.listViewMessage);
            this.Controls.Add(this.buttonNext);
            this.Controls.Add(this.buttonBefore);
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.buttonSearch);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewDataDisplay);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "CaptureDataSearch";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "CaptureDataSearch";
            this.contextMenuStripTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxPic)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxInfrared)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewDataDisplay;
        private System.Windows.Forms.ColumnHeader columnHeaderCaptureNo;
        private System.Windows.Forms.ColumnHeader columnHeaderLastNo;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderEmployeeNo;
        private System.Windows.Forms.ColumnHeader columnHeaderIDCard;
        private System.Windows.Forms.ColumnHeader columnHeaderCardNo;
        private System.Windows.Forms.ColumnHeader columnHeaderFPID;
        private System.Windows.Forms.PictureBox pictureBoxPic;
        private System.Windows.Forms.PictureBox pictureBoxInfrared;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxSearchID;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxCaptureNo;
        private System.Windows.Forms.TextBox textBoxMaxResults;
        private System.Windows.Forms.TextBox textBoxSearchPos;
        private System.Windows.Forms.ColumnHeader columnHeaderIndex;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSearch;
        private System.Windows.Forms.Button buttonBefore;
        private System.Windows.Forms.Button buttonNext;
        private System.Windows.Forms.ListView listViewMessage;
        private System.Windows.Forms.ColumnHeader columnHeader21;
        private System.Windows.Forms.ColumnHeader columnHeader22;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripTools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClear;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.RichTextBox richTextBoxOutputJson;
        private System.Windows.Forms.Button buttonStop;
        private System.Windows.Forms.ColumnHeader columnHeaderDataType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxSearchType;
        private System.Windows.Forms.ColumnHeader columnHeaderRisk;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}