namespace The_Wheel_Query_Tool
{
    partial class frm_WheelQueryTool
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_WheelQueryTool));
            btn_CustomQuery = new Button();
            txb_QueryInput = new TextBox();
            ltb_QueryDisplay = new ListBox();
            gbx_Sorting = new GroupBox();
            btn_WinsOldtoNew = new Button();
            btn_WinsNewtoOld = new Button();
            btn_YearOldtoNew = new Button();
            btn_YearNewtoOld = new Button();
            btn_NameZtoA = new Button();
            btn_NameAtoZ = new Button();
            lbl_Wins = new Label();
            lbl_Year = new Label();
            lbl_Name = new Label();
            cmb_CustomQuerys = new ComboBox();
            btn_AddRecordFormDisplay = new Button();
            gbx_Sorting.SuspendLayout();
            SuspendLayout();
            // 
            // btn_CustomQuery
            // 
            btn_CustomQuery.Font = new Font("Consolas", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btn_CustomQuery.Location = new Point(712, 267);
            btn_CustomQuery.Name = "btn_CustomQuery";
            btn_CustomQuery.Size = new Size(322, 72);
            btn_CustomQuery.TabIndex = 0;
            btn_CustomQuery.Text = "Run Custom Query";
            btn_CustomQuery.UseVisualStyleBackColor = true;
            btn_CustomQuery.Click += btn_CustomQuery_Click;
            // 
            // txb_QueryInput
            // 
            txb_QueryInput.AcceptsReturn = true;
            txb_QueryInput.Location = new Point(712, 378);
            txb_QueryInput.Multiline = true;
            txb_QueryInput.Name = "txb_QueryInput";
            txb_QueryInput.ScrollBars = ScrollBars.Both;
            txb_QueryInput.Size = new Size(322, 226);
            txb_QueryInput.TabIndex = 1;
            txb_QueryInput.WordWrap = false;
            // 
            // ltb_QueryDisplay
            // 
            ltb_QueryDisplay.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ltb_QueryDisplay.FormattingEnabled = true;
            ltb_QueryDisplay.ItemHeight = 14;
            ltb_QueryDisplay.Location = new Point(12, 12);
            ltb_QueryDisplay.Name = "ltb_QueryDisplay";
            ltb_QueryDisplay.Size = new Size(694, 592);
            ltb_QueryDisplay.TabIndex = 2;
            ltb_QueryDisplay.DoubleClick += ltb_QueryDisplay_DoubleClick;
            // 
            // gbx_Sorting
            // 
            gbx_Sorting.Controls.Add(btn_WinsOldtoNew);
            gbx_Sorting.Controls.Add(btn_WinsNewtoOld);
            gbx_Sorting.Controls.Add(btn_YearOldtoNew);
            gbx_Sorting.Controls.Add(btn_YearNewtoOld);
            gbx_Sorting.Controls.Add(btn_NameZtoA);
            gbx_Sorting.Controls.Add(btn_NameAtoZ);
            gbx_Sorting.Controls.Add(lbl_Wins);
            gbx_Sorting.Controls.Add(lbl_Year);
            gbx_Sorting.Controls.Add(lbl_Name);
            gbx_Sorting.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            gbx_Sorting.Location = new Point(712, 90);
            gbx_Sorting.Name = "gbx_Sorting";
            gbx_Sorting.Size = new Size(322, 171);
            gbx_Sorting.TabIndex = 3;
            gbx_Sorting.TabStop = false;
            gbx_Sorting.Text = "Sorting:";
            // 
            // btn_WinsOldtoNew
            // 
            btn_WinsOldtoNew.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_WinsOldtoNew.Location = new Point(216, 104);
            btn_WinsOldtoNew.Name = "btn_WinsOldtoNew";
            btn_WinsOldtoNew.Size = new Size(100, 48);
            btn_WinsOldtoNew.TabIndex = 8;
            btn_WinsOldtoNew.Text = "Old → New";
            btn_WinsOldtoNew.UseVisualStyleBackColor = true;
            btn_WinsOldtoNew.Click += btn_WinsOldtoNew_Click;
            // 
            // btn_WinsNewtoOld
            // 
            btn_WinsNewtoOld.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_WinsNewtoOld.Location = new Point(216, 50);
            btn_WinsNewtoOld.Name = "btn_WinsNewtoOld";
            btn_WinsNewtoOld.Size = new Size(100, 48);
            btn_WinsNewtoOld.TabIndex = 7;
            btn_WinsNewtoOld.Text = "New → Old";
            btn_WinsNewtoOld.UseVisualStyleBackColor = true;
            btn_WinsNewtoOld.Click += btn_WinsNewtoOld_Click;
            // 
            // btn_YearOldtoNew
            // 
            btn_YearOldtoNew.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_YearOldtoNew.Location = new Point(110, 104);
            btn_YearOldtoNew.Name = "btn_YearOldtoNew";
            btn_YearOldtoNew.Size = new Size(100, 48);
            btn_YearOldtoNew.TabIndex = 6;
            btn_YearOldtoNew.Text = "Old → New";
            btn_YearOldtoNew.UseVisualStyleBackColor = true;
            btn_YearOldtoNew.Click += btn_YearOldtoNew_Click;
            // 
            // btn_YearNewtoOld
            // 
            btn_YearNewtoOld.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_YearNewtoOld.Location = new Point(110, 50);
            btn_YearNewtoOld.Name = "btn_YearNewtoOld";
            btn_YearNewtoOld.Size = new Size(100, 48);
            btn_YearNewtoOld.TabIndex = 5;
            btn_YearNewtoOld.Text = "New → Old";
            btn_YearNewtoOld.UseVisualStyleBackColor = true;
            btn_YearNewtoOld.Click += btn_YearNewtoOld_Click;
            // 
            // btn_NameZtoA
            // 
            btn_NameZtoA.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_NameZtoA.Location = new Point(4, 104);
            btn_NameZtoA.Name = "btn_NameZtoA";
            btn_NameZtoA.Size = new Size(100, 48);
            btn_NameZtoA.TabIndex = 4;
            btn_NameZtoA.Text = "Z → A";
            btn_NameZtoA.UseVisualStyleBackColor = true;
            btn_NameZtoA.Click += btn_NameZtoA_Click;
            // 
            // btn_NameAtoZ
            // 
            btn_NameAtoZ.Font = new Font("Consolas", 12F, FontStyle.Bold);
            btn_NameAtoZ.Location = new Point(6, 50);
            btn_NameAtoZ.Name = "btn_NameAtoZ";
            btn_NameAtoZ.Size = new Size(100, 48);
            btn_NameAtoZ.TabIndex = 3;
            btn_NameAtoZ.Text = "A → Z";
            btn_NameAtoZ.UseVisualStyleBackColor = true;
            btn_NameAtoZ.Click += btn_NameAtoZ_Click;
            // 
            // lbl_Wins
            // 
            lbl_Wins.AutoSize = true;
            lbl_Wins.Font = new Font("Consolas", 12F);
            lbl_Wins.Location = new Point(216, 28);
            lbl_Wins.Name = "lbl_Wins";
            lbl_Wins.Size = new Size(54, 19);
            lbl_Wins.TabIndex = 2;
            lbl_Wins.Text = "Wins:";
            // 
            // lbl_Year
            // 
            lbl_Year.AutoSize = true;
            lbl_Year.Font = new Font("Consolas", 12F);
            lbl_Year.Location = new Point(110, 28);
            lbl_Year.Name = "lbl_Year";
            lbl_Year.Size = new Size(54, 19);
            lbl_Year.TabIndex = 1;
            lbl_Year.Text = "Year:";
            // 
            // lbl_Name
            // 
            lbl_Name.AutoSize = true;
            lbl_Name.Font = new Font("Consolas", 12F);
            lbl_Name.Location = new Point(6, 28);
            lbl_Name.Name = "lbl_Name";
            lbl_Name.Size = new Size(54, 19);
            lbl_Name.TabIndex = 0;
            lbl_Name.Text = "Name:";
            // 
            // cmb_CustomQuerys
            // 
            cmb_CustomQuerys.DropDownStyle = ComboBoxStyle.DropDownList;
            cmb_CustomQuerys.FlatStyle = FlatStyle.System;
            cmb_CustomQuerys.Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cmb_CustomQuerys.FormattingEnabled = true;
            cmb_CustomQuerys.Location = new Point(712, 345);
            cmb_CustomQuerys.Name = "cmb_CustomQuerys";
            cmb_CustomQuerys.Size = new Size(322, 27);
            cmb_CustomQuerys.TabIndex = 4;
            cmb_CustomQuerys.SelectedIndexChanged += cmb_CustomQuerys_SelectedIndexChanged;
            // 
            // btn_AddRecordFormDisplay
            // 
            btn_AddRecordFormDisplay.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AddRecordFormDisplay.Location = new Point(712, 12);
            btn_AddRecordFormDisplay.Name = "btn_AddRecordFormDisplay";
            btn_AddRecordFormDisplay.Size = new Size(322, 72);
            btn_AddRecordFormDisplay.TabIndex = 5;
            btn_AddRecordFormDisplay.Text = "Add Record";
            btn_AddRecordFormDisplay.UseVisualStyleBackColor = true;
            btn_AddRecordFormDisplay.Click += btn_AddRecordFormDisplay_Click;
            // 
            // frm_WheelQueryTool
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1046, 616);
            Controls.Add(btn_AddRecordFormDisplay);
            Controls.Add(cmb_CustomQuerys);
            Controls.Add(gbx_Sorting);
            Controls.Add(ltb_QueryDisplay);
            Controls.Add(txb_QueryInput);
            Controls.Add(btn_CustomQuery);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            Name = "frm_WheelQueryTool";
            Text = "Wheel Query Tool";
            gbx_Sorting.ResumeLayout(false);
            gbx_Sorting.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btn_CustomQuery;
        private TextBox txb_QueryInput;
        private ListBox ltb_QueryDisplay;
        private GroupBox gbx_Sorting;
        private Button btn_WinsOldtoNew;
        private Button btn_WinsNewtoOld;
        private Button btn_YearOldtoNew;
        private Button btn_YearNewtoOld;
        private Button btn_NameZtoA;
        private Button btn_NameAtoZ;
        private Label lbl_Wins;
        private Label lbl_Year;
        private Label lbl_Name;
        private ComboBox cmb_CustomQuerys;
        private Button btn_AddRecordFormDisplay;
    }
}
