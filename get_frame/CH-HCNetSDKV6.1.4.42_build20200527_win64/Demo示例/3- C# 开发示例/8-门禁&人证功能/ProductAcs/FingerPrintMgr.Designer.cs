namespace AcsDemo.ProductAcs
{
    partial class FingerPrintMgr
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
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.checkedListBoxFingerPrint = new System.Windows.Forms.CheckedListBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.comboBoxDeleteType = new System.Windows.Forms.ComboBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.checkedListBoxReaderValid = new System.Windows.Forms.CheckedListBox();
            this.buttonGet = new System.Windows.Forms.Button();
            this.buttonSet = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.checkBoxDeleteAll = new System.Windows.Forms.CheckBox();
            this.textBoxReaderNo = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.checkBoxNonBlock = new System.Windows.Forms.CheckBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBoxFingerprintType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.listViewMessage = new System.Windows.Forms.ListView();
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.buttonDelete = new System.Windows.Forms.Button();
            this.textBoxDataLength = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxFingerprintDataPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.testBoxCard = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.checkedListBoxLeaderFP = new System.Windows.Forms.CheckedListBox();
            this.label12 = new System.Windows.Forms.Label();
            this.textBoxEmployeeNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBoxFingerPrintNumber = new System.Windows.Forms.TextBox();
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.listViewFingerPrint = new System.Windows.Forms.ListView();
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnCatpure = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnOpen = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.textBoxSavePath = new System.Windows.Forms.TextBox();
            this.textBoxFingerNo = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.comboBoxFpPicType = new System.Windows.Forms.ComboBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.checkedListBoxFingerPrint);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Location = new System.Drawing.Point(565, 54);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(213, 161);
            this.groupBox2.TabIndex = 12;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Delete by the card number";
            // 
            // checkedListBoxFingerPrint
            // 
            this.checkedListBoxFingerPrint.FormattingEnabled = true;
            this.checkedListBoxFingerPrint.Location = new System.Drawing.Point(8, 38);
            this.checkedListBoxFingerPrint.Name = "checkedListBoxFingerPrint";
            this.checkedListBoxFingerPrint.Size = new System.Drawing.Size(183, 116);
            this.checkedListBoxFingerPrint.TabIndex = 1;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 22);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(185, 12);
            this.label10.TabIndex = 0;
            this.label10.Text = "Need to delete the fingerprint";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(563, 12);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(71, 12);
            this.label9.TabIndex = 10;
            this.label9.Text = "Delete Mode";
            // 
            // comboBoxDeleteType
            // 
            this.comboBoxDeleteType.FormattingEnabled = true;
            this.comboBoxDeleteType.Items.AddRange(new object[] {
            "Delete by number",
            "Delete by reader"});
            this.comboBoxDeleteType.Location = new System.Drawing.Point(649, 12);
            this.comboBoxDeleteType.Name = "comboBoxDeleteType";
            this.comboBoxDeleteType.Size = new System.Drawing.Size(121, 20);
            this.comboBoxDeleteType.TabIndex = 11;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(110, 109);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowse.TabIndex = 22;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // checkedListBoxReaderValid
            // 
            this.checkedListBoxReaderValid.FormattingEnabled = true;
            this.checkedListBoxReaderValid.Location = new System.Drawing.Point(265, 50);
            this.checkedListBoxReaderValid.Name = "checkedListBoxReaderValid";
            this.checkedListBoxReaderValid.Size = new System.Drawing.Size(123, 212);
            this.checkedListBoxReaderValid.TabIndex = 21;
            // 
            // buttonGet
            // 
            this.buttonGet.Location = new System.Drawing.Point(235, 286);
            this.buttonGet.Name = "buttonGet";
            this.buttonGet.Size = new System.Drawing.Size(75, 23);
            this.buttonGet.TabIndex = 20;
            this.buttonGet.Text = "Get";
            this.buttonGet.UseVisualStyleBackColor = true;
            this.buttonGet.Click += new System.EventHandler(this.buttonGet_Click);
            // 
            // buttonSet
            // 
            this.buttonSet.Location = new System.Drawing.Point(128, 286);
            this.buttonSet.Name = "buttonSet";
            this.buttonSet.Size = new System.Drawing.Size(75, 23);
            this.buttonSet.TabIndex = 19;
            this.buttonSet.Text = "Set";
            this.buttonSet.UseVisualStyleBackColor = true;
            this.buttonSet.Click += new System.EventHandler(this.buttonSet_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.checkBoxDeleteAll);
            this.groupBox3.Controls.Add(this.textBoxReaderNo);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(565, 239);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(213, 90);
            this.groupBox3.TabIndex = 13;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Delete by card reader";
            // 
            // checkBoxDeleteAll
            // 
            this.checkBoxDeleteAll.AutoSize = true;
            this.checkBoxDeleteAll.Location = new System.Drawing.Point(10, 52);
            this.checkBoxDeleteAll.Name = "checkBoxDeleteAll";
            this.checkBoxDeleteAll.Size = new System.Drawing.Size(84, 16);
            this.checkBoxDeleteAll.TabIndex = 2;
            this.checkBoxDeleteAll.Text = "Delete all";
            this.checkBoxDeleteAll.UseVisualStyleBackColor = true;
            // 
            // textBoxReaderNo
            // 
            this.textBoxReaderNo.Location = new System.Drawing.Point(140, 19);
            this.textBoxReaderNo.Name = "textBoxReaderNo";
            this.textBoxReaderNo.Size = new System.Drawing.Size(65, 21);
            this.textBoxReaderNo.TabIndex = 1;
            this.textBoxReaderNo.Text = "1";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 19);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(125, 12);
            this.label11.TabIndex = 0;
            this.label11.Text = "FingerprintReaderNo.";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Location = new System.Drawing.Point(21, 286);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 17;
            this.buttonAdd.Text = "Add";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // checkBoxNonBlock
            // 
            this.checkBoxNonBlock.AutoSize = true;
            this.checkBoxNonBlock.Location = new System.Drawing.Point(19, 251);
            this.checkBoxNonBlock.Name = "checkBoxNonBlock";
            this.checkBoxNonBlock.Size = new System.Drawing.Size(174, 16);
            this.checkBoxNonBlock.TabIndex = 16;
            this.checkBoxNonBlock.Text = "EquipmentCallbackNonBlock";
            this.checkBoxNonBlock.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(263, 25);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 12);
            this.label7.TabIndex = 12;
            this.label7.Text = "Card reader is valid";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(19, 251);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(0, 12);
            this.label6.TabIndex = 10;
            // 
            // comboBoxFingerprintType
            // 
            this.comboBoxFingerprintType.FormattingEnabled = true;
            this.comboBoxFingerprintType.Items.AddRange(new object[] {
            "Common fingerprint",
            "Stress fingerprint",
            "Patrol fingerprint",
            "Super fingerprint",
            "Dismissing fingerprint"});
            this.comboBoxFingerprintType.Location = new System.Drawing.Point(116, 146);
            this.comboBoxFingerprintType.Name = "comboBoxFingerprintType";
            this.comboBoxFingerprintType.Size = new System.Drawing.Size(129, 20);
            this.comboBoxFingerprintType.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(17, 150);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(101, 12);
            this.label5.TabIndex = 8;
            this.label5.Text = "Fingerprint Type";
            // 
            // listViewMessage
            // 
            this.listViewMessage.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.columnHeader8});
            this.listViewMessage.FullRowSelect = true;
            this.listViewMessage.GridLines = true;
            this.listViewMessage.Location = new System.Drawing.Point(6, 325);
            this.listViewMessage.Name = "listViewMessage";
            this.listViewMessage.Size = new System.Drawing.Size(505, 183);
            this.listViewMessage.TabIndex = 15;
            this.listViewMessage.UseCompatibleStateImageBehavior = false;
            this.listViewMessage.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "State";
            this.columnHeader7.Width = 78;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "Message";
            this.columnHeader8.Width = 500;
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(565, 342);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 14;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // textBoxDataLength
            // 
            this.textBoxDataLength.Location = new System.Drawing.Point(110, 176);
            this.textBoxDataLength.Name = "textBoxDataLength";
            this.textBoxDataLength.Size = new System.Drawing.Size(135, 21);
            this.textBoxDataLength.TabIndex = 7;
            this.textBoxDataLength.Text = "512";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(17, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 12);
            this.label4.TabIndex = 6;
            this.label4.Text = "Data Length";
            // 
            // textBoxFingerprintDataPath
            // 
            this.textBoxFingerprintDataPath.Location = new System.Drawing.Point(110, 82);
            this.textBoxFingerprintDataPath.Name = "textBoxFingerprintDataPath";
            this.textBoxFingerprintDataPath.Size = new System.Drawing.Size(135, 21);
            this.textBoxFingerprintDataPath.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(17, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(59, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "Data Path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(19, 216);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(89, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fingerprint ID";
            // 
            // testBoxCard
            // 
            this.testBoxCard.Location = new System.Drawing.Point(110, 23);
            this.testBoxCard.Name = "testBoxCard";
            this.testBoxCard.Size = new System.Drawing.Size(135, 21);
            this.testBoxCard.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Card NO";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.checkedListBoxLeaderFP);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.textBoxEmployeeNo);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.listViewMessage);
            this.groupBox1.Controls.Add(this.buttonBrowse);
            this.groupBox1.Controls.Add(this.checkedListBoxReaderValid);
            this.groupBox1.Controls.Add(this.buttonGet);
            this.groupBox1.Controls.Add(this.buttonSet);
            this.groupBox1.Controls.Add(this.buttonAdd);
            this.groupBox1.Controls.Add(this.checkBoxNonBlock);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.comboBoxFingerprintType);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.textBoxDataLength);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.textBoxFingerprintDataPath);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.textBoxFingerPrintNumber);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.testBoxCard);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 258);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(526, 521);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Fingerprint Information";
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(350, 286);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 27;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // checkedListBoxLeaderFP
            // 
            this.checkedListBoxLeaderFP.FormattingEnabled = true;
            this.checkedListBoxLeaderFP.Location = new System.Drawing.Point(400, 50);
            this.checkedListBoxLeaderFP.Name = "checkedListBoxLeaderFP";
            this.checkedListBoxLeaderFP.Size = new System.Drawing.Size(120, 212);
            this.checkedListBoxLeaderFP.TabIndex = 26;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(398, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(113, 12);
            this.label12.TabIndex = 25;
            this.label12.Text = "Leader FP is valid";
            // 
            // textBoxEmployeeNo
            // 
            this.textBoxEmployeeNo.Location = new System.Drawing.Point(110, 50);
            this.textBoxEmployeeNo.Name = "textBoxEmployeeNo";
            this.textBoxEmployeeNo.Size = new System.Drawing.Size(135, 21);
            this.textBoxEmployeeNo.TabIndex = 24;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(17, 53);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(71, 12);
            this.label8.TabIndex = 23;
            this.label8.Text = "Employee No";
            // 
            // textBoxFingerPrintNumber
            // 
            this.textBoxFingerPrintNumber.Location = new System.Drawing.Point(110, 211);
            this.textBoxFingerPrintNumber.Name = "textBoxFingerPrintNumber";
            this.textBoxFingerPrintNumber.Size = new System.Drawing.Size(135, 21);
            this.textBoxFingerPrintNumber.TabIndex = 3;
            this.textBoxFingerPrintNumber.Text = "1";
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Data Path";
            this.columnHeader6.Width = 180;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Length";
            this.columnHeader5.Width = 100;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Type";
            this.columnHeader4.Width = 120;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Number";
            this.columnHeader3.Width = 100;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Card No";
            this.columnHeader2.Width = 100;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "No.";
            this.columnHeader1.Width = 38;
            // 
            // listViewFingerPrint
            // 
            this.listViewFingerPrint.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader9});
            this.listViewFingerPrint.FullRowSelect = true;
            this.listViewFingerPrint.GridLines = true;
            this.listViewFingerPrint.Location = new System.Drawing.Point(12, 12);
            this.listViewFingerPrint.Name = "listViewFingerPrint";
            this.listViewFingerPrint.Size = new System.Drawing.Size(526, 227);
            this.listViewFingerPrint.TabIndex = 8;
            this.listViewFingerPrint.UseCompatibleStateImageBehavior = false;
            this.listViewFingerPrint.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "Employee No";
            this.columnHeader9.Width = 100;
            // 
            // btnCatpure
            // 
            this.btnCatpure.Location = new System.Drawing.Point(133, 93);
            this.btnCatpure.Name = "btnCatpure";
            this.btnCatpure.Size = new System.Drawing.Size(69, 23);
            this.btnCatpure.TabIndex = 28;
            this.btnCatpure.Text = "Catpure";
            this.btnCatpure.UseVisualStyleBackColor = true;
            this.btnCatpure.Click += new System.EventHandler(this.btnCatpure_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(11, 35);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(83, 12);
            this.label13.TabIndex = 29;
            this.label13.Text = "FpPictureType";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btnOpen);
            this.groupBox4.Controls.Add(this.label15);
            this.groupBox4.Controls.Add(this.textBoxSavePath);
            this.groupBox4.Controls.Add(this.textBoxFingerNo);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.comboBoxFpPicType);
            this.groupBox4.Controls.Add(this.btnCatpure);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(565, 434);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(213, 201);
            this.groupBox4.TabIndex = 30;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "CatpureFp";
            // 
            // btnOpen
            // 
            this.btnOpen.Location = new System.Drawing.Point(133, 158);
            this.btnOpen.Name = "btnOpen";
            this.btnOpen.Size = new System.Drawing.Size(72, 24);
            this.btnOpen.TabIndex = 35;
            this.btnOpen.Text = "open";
            this.btnOpen.UseVisualStyleBackColor = true;
            this.btnOpen.Click += new System.EventHandler(this.button1_Click);
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(22, 134);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(41, 12);
            this.label15.TabIndex = 34;
            this.label15.Text = "fpPath";
            // 
            // textBoxSavePath
            // 
            this.textBoxSavePath.Location = new System.Drawing.Point(81, 131);
            this.textBoxSavePath.Name = "textBoxSavePath";
            this.textBoxSavePath.Size = new System.Drawing.Size(124, 21);
            this.textBoxSavePath.TabIndex = 33;
            // 
            // textBoxFingerNo
            // 
            this.textBoxFingerNo.Location = new System.Drawing.Point(100, 66);
            this.textBoxFingerNo.Name = "textBoxFingerNo";
            this.textBoxFingerNo.Size = new System.Drawing.Size(100, 21);
            this.textBoxFingerNo.TabIndex = 32;
            this.textBoxFingerNo.Text = "1";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(16, 66);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(53, 12);
            this.label14.TabIndex = 31;
            this.label14.Text = "fingerNo";
            // 
            // comboBoxFpPicType
            // 
            this.comboBoxFpPicType.FormattingEnabled = true;
            this.comboBoxFpPicType.Items.AddRange(new object[] {
            "no picture",
            "full pixel picture",
            "1/4 pixel picture"});
            this.comboBoxFpPicType.Location = new System.Drawing.Point(100, 32);
            this.comboBoxFpPicType.Name = "comboBoxFpPicType";
            this.comboBoxFpPicType.Size = new System.Drawing.Size(102, 20);
            this.comboBoxFpPicType.TabIndex = 30;
            // 
            // FingerPrintMgr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(785, 784);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.comboBoxDeleteType);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.listViewFingerPrint);
            this.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "FingerPrintMgr";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FingerPrintMgr";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FingerprintManage_FormClosed);
            this.Load += new System.EventHandler(this.FingerPrintMgr_Load);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckedListBox checkedListBoxFingerPrint;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox comboBoxDeleteType;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.CheckedListBox checkedListBoxReaderValid;
        private System.Windows.Forms.Button buttonGet;
        private System.Windows.Forms.Button buttonSet;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.CheckBox checkBoxDeleteAll;
        private System.Windows.Forms.TextBox textBoxReaderNo;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.CheckBox checkBoxNonBlock;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox comboBoxFingerprintType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ListView listViewMessage;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.TextBox textBoxDataLength;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxFingerprintDataPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox testBoxCard;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxFingerPrintNumber;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ListView listViewFingerPrint;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.TextBox textBoxEmployeeNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckedListBox checkedListBoxLeaderFP;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnCatpure;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox comboBoxFpPicType;
        private System.Windows.Forms.TextBox textBoxFingerNo;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Button btnOpen;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox textBoxSavePath;
    }
}