namespace AcsDemo.ProductAcs
{
    partial class FingerPrintMgrByStaffCenter
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
            this.listViewFingerPrint = new System.Windows.Forms.ListView();
            this.No = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmployeeNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.enableCardReader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fingerPrintID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fingerType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.fingerDataPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leaderFP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.checkEmployeeNo = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.deleteFp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnPostFingerPrintCfg = new System.Windows.Forms.Button();
            this.SendFpCfg = new System.Windows.Forms.GroupBox();
            this.checkBoxDeleteFp = new System.Windows.Forms.CheckBox();
            this.btnSetUpFpCfg = new System.Windows.Forms.Button();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.btnClearList = new System.Windows.Forms.Button();
            this.btnUpdateList = new System.Windows.Forms.Button();
            this.labelLeaderFPEnableDoor = new System.Windows.Forms.Label();
            this.labelenableCardReader = new System.Windows.Forms.Label();
            this.checkedListBoxLeaderFP = new System.Windows.Forms.CheckedListBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.checkedListBoxReaderValid = new System.Windows.Forms.CheckedListBox();
            this.textBoxFingerDataPath = new System.Windows.Forms.TextBox();
            this.comboBoxFingerType = new System.Windows.Forms.ComboBox();
            this.comboBoxFingerPrintID = new System.Windows.Forms.ComboBox();
            this.checkBoxEmployeeNo = new System.Windows.Forms.CheckBox();
            this.labelFingerDataPath = new System.Windows.Forms.Label();
            this.labelFingerType = new System.Windows.Forms.Label();
            this.labelFingerPrintID = new System.Windows.Forms.Label();
            this.textBoxEmployeeNo = new System.Windows.Forms.TextBox();
            this.labelEmployeeNo = new System.Windows.Forms.Label();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnGetFpCfg = new System.Windows.Forms.Button();
            this.GetFpCfg = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnAddCond = new System.Windows.Forms.Button();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.textBoxFPID = new System.Windows.Forms.TextBox();
            this.textBoxCRNo = new System.Windows.Forms.TextBox();
            this.textBoxENo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listViewFpCond = new System.Windows.Forms.ListView();
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SendFpCfg.SuspendLayout();
            this.GetFpCfg.SuspendLayout();
            this.SuspendLayout();
            // 
            // listViewFingerPrint
            // 
            this.listViewFingerPrint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.No,
            this.EmployeeNo,
            this.enableCardReader,
            this.fingerPrintID,
            this.fingerType,
            this.fingerDataPath,
            this.leaderFP,
            this.checkEmployeeNo,
            this.deleteFp});
            this.listViewFingerPrint.FullRowSelect = true;
            this.listViewFingerPrint.GridLines = true;
            this.listViewFingerPrint.Location = new System.Drawing.Point(12, 10);
            this.listViewFingerPrint.Name = "listViewFingerPrint";
            this.listViewFingerPrint.Size = new System.Drawing.Size(1003, 223);
            this.listViewFingerPrint.TabIndex = 0;
            this.listViewFingerPrint.UseCompatibleStateImageBehavior = false;
            this.listViewFingerPrint.View = System.Windows.Forms.View.Details;
            this.listViewFingerPrint.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFingerPrint_ItemSelectionChanged);
            // 
            // No
            // 
            this.No.Text = "No.";
            // 
            // EmployeeNo
            // 
            this.EmployeeNo.Text = "EmployeeNo.";
            this.EmployeeNo.Width = 114;
            // 
            // enableCardReader
            // 
            this.enableCardReader.Text = "enableCardReader.";
            this.enableCardReader.Width = 145;
            // 
            // fingerPrintID
            // 
            this.fingerPrintID.Text = "fingerPrintID.";
            this.fingerPrintID.Width = 114;
            // 
            // fingerType
            // 
            this.fingerType.Text = "fingerType.";
            this.fingerType.Width = 100;
            // 
            // fingerDataPath
            // 
            this.fingerDataPath.Text = "fingerDataPath.";
            this.fingerDataPath.Width = 200;
            // 
            // leaderFP
            // 
            this.leaderFP.Text = "leaderFP.";
            this.leaderFP.Width = 100;
            // 
            // checkEmployeeNo
            // 
            this.checkEmployeeNo.Text = "checkEmployeeNo.";
            this.checkEmployeeNo.Width = 160;
            // 
            // deleteFp
            // 
            this.deleteFp.Text = "deleteFp.";
            this.deleteFp.Width = 80;
            // 
            // btnPostFingerPrintCfg
            // 
            this.btnPostFingerPrintCfg.Location = new System.Drawing.Point(781, 136);
            this.btnPostFingerPrintCfg.Name = "btnPostFingerPrintCfg";
            this.btnPostFingerPrintCfg.Size = new System.Drawing.Size(144, 23);
            this.btnPostFingerPrintCfg.TabIndex = 1;
            this.btnPostFingerPrintCfg.Text = "SendFpCfg";
            this.btnPostFingerPrintCfg.UseVisualStyleBackColor = true;
            this.btnPostFingerPrintCfg.Click += new System.EventHandler(this.POST_FingerPrintCfg_Click);
            // 
            // SendFpCfg
            // 
            this.SendFpCfg.Controls.Add(this.checkBoxDeleteFp);
            this.SendFpCfg.Controls.Add(this.btnSetUpFpCfg);
            this.SendFpCfg.Controls.Add(this.btnBrowse);
            this.SendFpCfg.Controls.Add(this.btnClearList);
            this.SendFpCfg.Controls.Add(this.btnUpdateList);
            this.SendFpCfg.Controls.Add(this.btnPostFingerPrintCfg);
            this.SendFpCfg.Controls.Add(this.labelLeaderFPEnableDoor);
            this.SendFpCfg.Controls.Add(this.labelenableCardReader);
            this.SendFpCfg.Controls.Add(this.checkedListBoxLeaderFP);
            this.SendFpCfg.Controls.Add(this.btnAdd);
            this.SendFpCfg.Controls.Add(this.checkedListBoxReaderValid);
            this.SendFpCfg.Controls.Add(this.textBoxFingerDataPath);
            this.SendFpCfg.Controls.Add(this.comboBoxFingerType);
            this.SendFpCfg.Controls.Add(this.comboBoxFingerPrintID);
            this.SendFpCfg.Controls.Add(this.checkBoxEmployeeNo);
            this.SendFpCfg.Controls.Add(this.labelFingerDataPath);
            this.SendFpCfg.Controls.Add(this.labelFingerType);
            this.SendFpCfg.Controls.Add(this.labelFingerPrintID);
            this.SendFpCfg.Controls.Add(this.textBoxEmployeeNo);
            this.SendFpCfg.Controls.Add(this.labelEmployeeNo);
            this.SendFpCfg.Location = new System.Drawing.Point(12, 239);
            this.SendFpCfg.Name = "SendFpCfg";
            this.SendFpCfg.Size = new System.Drawing.Size(1003, 204);
            this.SendFpCfg.TabIndex = 2;
            this.SendFpCfg.TabStop = false;
            this.SendFpCfg.Text = "SendFpCfg Or SetFpCfg";
            // 
            // checkBoxDeleteFp
            // 
            this.checkBoxDeleteFp.AutoSize = true;
            this.checkBoxDeleteFp.Location = new System.Drawing.Point(160, 166);
            this.checkBoxDeleteFp.Name = "checkBoxDeleteFp";
            this.checkBoxDeleteFp.Size = new System.Drawing.Size(82, 18);
            this.checkBoxDeleteFp.TabIndex = 15;
            this.checkBoxDeleteFp.Text = "DeleteFp";
            this.checkBoxDeleteFp.UseVisualStyleBackColor = true;
            // 
            // btnSetUpFpCfg
            // 
            this.btnSetUpFpCfg.Location = new System.Drawing.Point(781, 170);
            this.btnSetUpFpCfg.Name = "btnSetUpFpCfg";
            this.btnSetUpFpCfg.Size = new System.Drawing.Size(144, 23);
            this.btnSetUpFpCfg.TabIndex = 14;
            this.btnSetUpFpCfg.Text = "SetUpFpCfg";
            this.btnSetUpFpCfg.UseVisualStyleBackColor = true;
            this.btnSetUpFpCfg.Click += new System.EventHandler(this.btnSetUpFpCfg_Click);
            // 
            // btnBrowse
            // 
            this.btnBrowse.Location = new System.Drawing.Point(332, 128);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(62, 23);
            this.btnBrowse.TabIndex = 13;
            this.btnBrowse.Text = "Browse";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnClearList
            // 
            this.btnClearList.Location = new System.Drawing.Point(781, 103);
            this.btnClearList.Name = "btnClearList";
            this.btnClearList.Size = new System.Drawing.Size(144, 23);
            this.btnClearList.TabIndex = 5;
            this.btnClearList.Text = "ClearFpCfgList";
            this.btnClearList.UseVisualStyleBackColor = true;
            this.btnClearList.Click += new System.EventHandler(this.btnClearList_Click);
            // 
            // btnUpdateList
            // 
            this.btnUpdateList.Location = new System.Drawing.Point(781, 69);
            this.btnUpdateList.Name = "btnUpdateList";
            this.btnUpdateList.Size = new System.Drawing.Size(144, 23);
            this.btnUpdateList.TabIndex = 7;
            this.btnUpdateList.Text = "UpdateFpCfgList";
            this.btnUpdateList.UseVisualStyleBackColor = true;
            this.btnUpdateList.Click += new System.EventHandler(this.btnUpdateList_Click);
            // 
            // labelLeaderFPEnableDoor
            // 
            this.labelLeaderFPEnableDoor.AutoSize = true;
            this.labelLeaderFPEnableDoor.Location = new System.Drawing.Point(602, 17);
            this.labelLeaderFPEnableDoor.Name = "labelLeaderFPEnableDoor";
            this.labelLeaderFPEnableDoor.Size = new System.Drawing.Size(140, 14);
            this.labelLeaderFPEnableDoor.TabIndex = 12;
            this.labelLeaderFPEnableDoor.Text = "leaderFPEnableDoor.";
            // 
            // labelenableCardReader
            // 
            this.labelenableCardReader.AutoSize = true;
            this.labelenableCardReader.Location = new System.Drawing.Point(412, 16);
            this.labelenableCardReader.Name = "labelenableCardReader";
            this.labelenableCardReader.Size = new System.Drawing.Size(126, 14);
            this.labelenableCardReader.TabIndex = 11;
            this.labelenableCardReader.Text = "enableCardReader.";
            // 
            // checkedListBoxLeaderFP
            // 
            this.checkedListBoxLeaderFP.FormattingEnabled = true;
            this.checkedListBoxLeaderFP.Location = new System.Drawing.Point(591, 36);
            this.checkedListBoxLeaderFP.Name = "checkedListBoxLeaderFP";
            this.checkedListBoxLeaderFP.Size = new System.Drawing.Size(160, 157);
            this.checkedListBoxLeaderFP.TabIndex = 10;
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(781, 34);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(144, 23);
            this.btnAdd.TabIndex = 3;
            this.btnAdd.Text = "AddFpCfgToList";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // checkedListBoxReaderValid
            // 
            this.checkedListBoxReaderValid.FormattingEnabled = true;
            this.checkedListBoxReaderValid.Location = new System.Drawing.Point(400, 37);
            this.checkedListBoxReaderValid.Name = "checkedListBoxReaderValid";
            this.checkedListBoxReaderValid.Size = new System.Drawing.Size(160, 157);
            this.checkedListBoxReaderValid.TabIndex = 9;
            // 
            // textBoxFingerDataPath
            // 
            this.textBoxFingerDataPath.Location = new System.Drawing.Point(129, 129);
            this.textBoxFingerDataPath.Name = "textBoxFingerDataPath";
            this.textBoxFingerDataPath.Size = new System.Drawing.Size(197, 22);
            this.textBoxFingerDataPath.TabIndex = 8;
            // 
            // comboBoxFingerType
            // 
            this.comboBoxFingerType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFingerType.FormattingEnabled = true;
            this.comboBoxFingerType.Items.AddRange(new object[] {
            "normalFP",
            "hijackFP",
            "patrolFP",
            "superFP",
            "dismissingFP"});
            this.comboBoxFingerType.Location = new System.Drawing.Point(129, 94);
            this.comboBoxFingerType.Name = "comboBoxFingerType";
            this.comboBoxFingerType.Size = new System.Drawing.Size(121, 22);
            this.comboBoxFingerType.TabIndex = 7;
            // 
            // comboBoxFingerPrintID
            // 
            this.comboBoxFingerPrintID.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFingerPrintID.FormattingEnabled = true;
            this.comboBoxFingerPrintID.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9",
            "10",
            ""});
            this.comboBoxFingerPrintID.Location = new System.Drawing.Point(129, 61);
            this.comboBoxFingerPrintID.Name = "comboBoxFingerPrintID";
            this.comboBoxFingerPrintID.Size = new System.Drawing.Size(121, 22);
            this.comboBoxFingerPrintID.TabIndex = 6;
            // 
            // checkBoxEmployeeNo
            // 
            this.checkBoxEmployeeNo.AutoSize = true;
            this.checkBoxEmployeeNo.Location = new System.Drawing.Point(23, 166);
            this.checkBoxEmployeeNo.Name = "checkBoxEmployeeNo";
            this.checkBoxEmployeeNo.Size = new System.Drawing.Size(131, 18);
            this.checkBoxEmployeeNo.TabIndex = 5;
            this.checkBoxEmployeeNo.Text = "checkEmployeeNo";
            this.checkBoxEmployeeNo.UseVisualStyleBackColor = true;
            // 
            // labelFingerDataPath
            // 
            this.labelFingerDataPath.AutoSize = true;
            this.labelFingerDataPath.Location = new System.Drawing.Point(20, 132);
            this.labelFingerDataPath.Name = "labelFingerDataPath";
            this.labelFingerDataPath.Size = new System.Drawing.Size(112, 14);
            this.labelFingerDataPath.TabIndex = 4;
            this.labelFingerDataPath.Text = "FingerDataPath.";
            // 
            // labelFingerType
            // 
            this.labelFingerType.AutoSize = true;
            this.labelFingerType.Location = new System.Drawing.Point(20, 97);
            this.labelFingerType.Name = "labelFingerType";
            this.labelFingerType.Size = new System.Drawing.Size(84, 14);
            this.labelFingerType.TabIndex = 3;
            this.labelFingerType.Text = "FingerType.";
            // 
            // labelFingerPrintID
            // 
            this.labelFingerPrintID.AutoSize = true;
            this.labelFingerPrintID.Location = new System.Drawing.Point(20, 64);
            this.labelFingerPrintID.Name = "labelFingerPrintID";
            this.labelFingerPrintID.Size = new System.Drawing.Size(105, 14);
            this.labelFingerPrintID.TabIndex = 2;
            this.labelFingerPrintID.Text = "FingerPrintID.";
            // 
            // textBoxEmployeeNo
            // 
            this.textBoxEmployeeNo.Location = new System.Drawing.Point(129, 23);
            this.textBoxEmployeeNo.Name = "textBoxEmployeeNo";
            this.textBoxEmployeeNo.Size = new System.Drawing.Size(120, 22);
            this.textBoxEmployeeNo.TabIndex = 1;
            this.textBoxEmployeeNo.Text = "1";
            // 
            // labelEmployeeNo
            // 
            this.labelEmployeeNo.AutoSize = true;
            this.labelEmployeeNo.Location = new System.Drawing.Point(20, 26);
            this.labelEmployeeNo.Name = "labelEmployeeNo";
            this.labelEmployeeNo.Size = new System.Drawing.Size(84, 14);
            this.labelEmployeeNo.TabIndex = 0;
            this.labelEmployeeNo.Text = "EmployeeNo.";
            // 
            // listViewMessage
            // 
            this.listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listViewMessage.FullRowSelect = true;
            this.listViewMessage.GridLines = true;
            this.listViewMessage.Location = new System.Drawing.Point(653, 460);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(361, 243);
            this.listViewMessage.TabIndex = 4;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.View = System.Windows.Forms.View.Details;
            this.listViewMessage.DoubleClick += new System.EventHandler(this.listViewMessage_DoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "State.";
            this.columnHeader1.Width = 104;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Operation.";
            this.columnHeader2.Width = 242;
            // 
            // btnGetFpCfg
            // 
            this.btnGetFpCfg.Location = new System.Drawing.Point(532, 200);
            this.btnGetFpCfg.Name = "btnGetFpCfg";
            this.btnGetFpCfg.Size = new System.Drawing.Size(66, 23);
            this.btnGetFpCfg.TabIndex = 8;
            this.btnGetFpCfg.Text = "GetFpCfg";
            this.btnGetFpCfg.UseVisualStyleBackColor = true;
            this.btnGetFpCfg.Click += new System.EventHandler(this.btnGetFpCfg_Click);
            // 
            // GetFpCfg
            // 
            this.GetFpCfg.Controls.Add(this.btnClear);
            this.GetFpCfg.Controls.Add(this.btnAddCond);
            this.GetFpCfg.Controls.Add(this.btnUpdate);
            this.GetFpCfg.Controls.Add(this.textBoxFPID);
            this.GetFpCfg.Controls.Add(this.textBoxCRNo);
            this.GetFpCfg.Controls.Add(this.textBoxENo);
            this.GetFpCfg.Controls.Add(this.label3);
            this.GetFpCfg.Controls.Add(this.label2);
            this.GetFpCfg.Controls.Add(this.label1);
            this.GetFpCfg.Controls.Add(this.listViewFpCond);
            this.GetFpCfg.Controls.Add(this.btnGetFpCfg);
            this.GetFpCfg.Location = new System.Drawing.Point(20, 449);
            this.GetFpCfg.Name = "GetFpCfg";
            this.GetFpCfg.Size = new System.Drawing.Size(611, 256);
            this.GetFpCfg.TabIndex = 9;
            this.GetFpCfg.TabStop = false;
            this.GetFpCfg.Text = "GetFpCfg";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(449, 200);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(66, 23);
            this.btnClear.TabIndex = 17;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnAddCond
            // 
            this.btnAddCond.Location = new System.Drawing.Point(449, 167);
            this.btnAddCond.Name = "btnAddCond";
            this.btnAddCond.Size = new System.Drawing.Size(66, 23);
            this.btnAddCond.TabIndex = 16;
            this.btnAddCond.Text = "Add";
            this.btnAddCond.UseVisualStyleBackColor = true;
            this.btnAddCond.Click += new System.EventHandler(this.btnAddCond_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(532, 167);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(66, 23);
            this.btnUpdate.TabIndex = 14;
            this.btnUpdate.Text = "Update";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // textBoxFPID
            // 
            this.textBoxFPID.Location = new System.Drawing.Point(546, 120);
            this.textBoxFPID.Name = "textBoxFPID";
            this.textBoxFPID.Size = new System.Drawing.Size(52, 22);
            this.textBoxFPID.TabIndex = 15;
            // 
            // textBoxCRNo
            // 
            this.textBoxCRNo.Location = new System.Drawing.Point(546, 83);
            this.textBoxCRNo.Name = "textBoxCRNo";
            this.textBoxCRNo.Size = new System.Drawing.Size(52, 22);
            this.textBoxCRNo.TabIndex = 14;
            // 
            // textBoxENo
            // 
            this.textBoxENo.Location = new System.Drawing.Point(546, 42);
            this.textBoxENo.Name = "textBoxENo";
            this.textBoxENo.Size = new System.Drawing.Size(52, 22);
            this.textBoxENo.TabIndex = 13;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(446, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(105, 14);
            this.label3.TabIndex = 12;
            this.label3.Text = "FingerPrintID.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(446, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 14);
            this.label2.TabIndex = 11;
            this.label2.Text = "CardReaderNo.";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(446, 45);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(84, 14);
            this.label1.TabIndex = 10;
            this.label1.Text = "EmployeeNo.";
            // 
            // listViewFpCond
            // 
            this.listViewFpCond.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.listViewFpCond.FullRowSelect = true;
            this.listViewFpCond.GridLines = true;
            this.listViewFpCond.HideSelection = false;
            this.listViewFpCond.Location = new System.Drawing.Point(15, 21);
            this.listViewFpCond.Name = "listViewFpCond";
            this.listViewFpCond.Size = new System.Drawing.Size(418, 229);
            this.listViewFpCond.TabIndex = 9;
            this.listViewFpCond.TabStop = false;
            this.listViewFpCond.UseCompatibleStateImageBehavior = false;
            this.listViewFpCond.View = System.Windows.Forms.View.Details;
            this.listViewFpCond.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.listViewFpCond_ItemSelectionChanged);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "No.";
            this.columnHeader3.Width = 51;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "employeeNo.";
            this.columnHeader4.Width = 100;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "cardReaderNo.";
            this.columnHeader5.Width = 123;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "fingerPrintID.";
            this.columnHeader6.Width = 130;
            // 
            // FingerPrintMgrByStaffCenter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1026, 724);
            this.Controls.Add(this.GetFpCfg);
            this.Controls.Add(this.listViewMessage);
            this.Controls.Add(this.SendFpCfg);
            this.Controls.Add(this.listViewFingerPrint);
            this.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FingerPrintMgrByStaffCenter";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FingerPrintMgrByStaffCenter";
            this.Load += new System.EventHandler(this.FingerPrintMgrByStaffCenter_Load);
            this.SendFpCfg.ResumeLayout(false);
            this.SendFpCfg.PerformLayout();
            this.GetFpCfg.ResumeLayout(false);
            this.GetFpCfg.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listViewFingerPrint;
        private System.Windows.Forms.ColumnHeader No;
        private System.Windows.Forms.ColumnHeader fingerPrintID;
        private System.Windows.Forms.ColumnHeader fingerType;
        private System.Windows.Forms.ColumnHeader fingerDataPath;
        private System.Windows.Forms.Button btnPostFingerPrintCfg;
        private System.Windows.Forms.GroupBox SendFpCfg;
        private System.Windows.Forms.Label labelEmployeeNo;
        private System.Windows.Forms.TextBox textBoxEmployeeNo;
        private System.Windows.Forms.Label labelFingerPrintID;
        private System.Windows.Forms.CheckBox checkBoxEmployeeNo;
        private System.Windows.Forms.Label labelFingerDataPath;
        private System.Windows.Forms.Label labelFingerType;
        private System.Windows.Forms.ComboBox comboBoxFingerType;
        private System.Windows.Forms.ComboBox comboBoxFingerPrintID;
        private System.Windows.Forms.TextBox textBoxFingerDataPath;
        private System.Windows.Forms.CheckedListBox checkedListBoxLeaderFP;
        private System.Windows.Forms.CheckedListBox checkedListBoxReaderValid;
        private System.Windows.Forms.Label labelenableCardReader;
        private System.Windows.Forms.Label labelLeaderFPEnableDoor;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.ColumnHeader enableCardReader;
        private System.Windows.Forms.ColumnHeader leaderFP;
        private System.Windows.Forms.ColumnHeader checkEmployeeNo;
        private System.Windows.Forms.ColumnHeader EmployeeNo;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.ListView listViewMessage;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.Button btnClearList;
        private System.Windows.Forms.Button btnUpdateList;
        private System.Windows.Forms.Button btnGetFpCfg;
        private System.Windows.Forms.GroupBox GetFpCfg;
        private System.Windows.Forms.ListView listViewFpCond;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxENo;
        private System.Windows.Forms.TextBox textBoxCRNo;
        private System.Windows.Forms.TextBox textBoxFPID;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnAddCond;
        private System.Windows.Forms.Button btnSetUpFpCfg;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.CheckBox checkBoxDeleteFp;
        private System.Windows.Forms.ColumnHeader deleteFp;
    }
}