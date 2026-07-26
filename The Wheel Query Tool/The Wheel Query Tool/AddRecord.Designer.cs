namespace The_Wheel_Query_Tool
{
    partial class frm_AddRecord
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
            txb_MovieNameInput = new TextBox();
            txb_MovieReleaseInput = new TextBox();
            txb_LetterboxdLinkInput = new TextBox();
            lbl_MovieName = new Label();
            lbl_MovieRelease = new Label();
            lbl_LetterboxdLink = new Label();
            lbl_WinDate = new Label();
            dtp_DateWonInput = new DateTimePicker();
            btn_AddRecord = new Button();
            SuspendLayout();
            // 
            // txb_MovieNameInput
            // 
            txb_MovieNameInput.Location = new Point(12, 26);
            txb_MovieNameInput.Name = "txb_MovieNameInput";
            txb_MovieNameInput.Size = new Size(594, 22);
            txb_MovieNameInput.TabIndex = 0;
            // 
            // txb_MovieReleaseInput
            // 
            txb_MovieReleaseInput.Location = new Point(12, 87);
            txb_MovieReleaseInput.Name = "txb_MovieReleaseInput";
            txb_MovieReleaseInput.Size = new Size(585, 22);
            txb_MovieReleaseInput.TabIndex = 1;
            // 
            // txb_LetterboxdLinkInput
            // 
            txb_LetterboxdLinkInput.Location = new Point(12, 145);
            txb_LetterboxdLinkInput.Name = "txb_LetterboxdLinkInput";
            txb_LetterboxdLinkInput.Size = new Size(537, 22);
            txb_LetterboxdLinkInput.TabIndex = 2;
            // 
            // lbl_MovieName
            // 
            lbl_MovieName.AutoSize = true;
            lbl_MovieName.Location = new Point(12, 9);
            lbl_MovieName.Name = "lbl_MovieName";
            lbl_MovieName.Size = new Size(84, 14);
            lbl_MovieName.TabIndex = 3;
            lbl_MovieName.Text = "Movie Name:";
            // 
            // lbl_MovieRelease
            // 
            lbl_MovieRelease.AutoSize = true;
            lbl_MovieRelease.Location = new Point(12, 70);
            lbl_MovieRelease.Name = "lbl_MovieRelease";
            lbl_MovieRelease.Size = new Size(98, 14);
            lbl_MovieRelease.TabIndex = 4;
            lbl_MovieRelease.Text = "Release Year:";
            // 
            // lbl_LetterboxdLink
            // 
            lbl_LetterboxdLink.AutoSize = true;
            lbl_LetterboxdLink.Location = new Point(12, 128);
            lbl_LetterboxdLink.Name = "lbl_LetterboxdLink";
            lbl_LetterboxdLink.Size = new Size(119, 14);
            lbl_LetterboxdLink.TabIndex = 5;
            lbl_LetterboxdLink.Text = "Letterboxd Link:";
            // 
            // lbl_WinDate
            // 
            lbl_WinDate.AutoSize = true;
            lbl_WinDate.Location = new Point(12, 189);
            lbl_WinDate.Name = "lbl_WinDate";
            lbl_WinDate.Size = new Size(70, 14);
            lbl_WinDate.TabIndex = 6;
            lbl_WinDate.Text = "Date Won:";
            // 
            // dtp_DateWonInput
            // 
            dtp_DateWonInput.Location = new Point(12, 206);
            dtp_DateWonInput.Name = "dtp_DateWonInput";
            dtp_DateWonInput.Size = new Size(200, 22);
            dtp_DateWonInput.TabIndex = 7;
            // 
            // btn_AddRecord
            // 
            btn_AddRecord.Location = new Point(12, 246);
            btn_AddRecord.Name = "btn_AddRecord";
            btn_AddRecord.Size = new Size(594, 78);
            btn_AddRecord.TabIndex = 8;
            btn_AddRecord.Text = "Add Record";
            btn_AddRecord.UseVisualStyleBackColor = true;
            btn_AddRecord.Click += btn_AddRecord_Click;
            // 
            // frm_AddRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 568);
            Controls.Add(btn_AddRecord);
            Controls.Add(dtp_DateWonInput);
            Controls.Add(lbl_WinDate);
            Controls.Add(lbl_LetterboxdLink);
            Controls.Add(lbl_MovieRelease);
            Controls.Add(lbl_MovieName);
            Controls.Add(txb_LetterboxdLinkInput);
            Controls.Add(txb_MovieReleaseInput);
            Controls.Add(txb_MovieNameInput);
            Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "frm_AddRecord";
            Text = "AddRecord";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txb_MovieNameInput;
        private TextBox txb_MovieReleaseInput;
        private TextBox txb_LetterboxdLinkInput;
        private Label lbl_MovieName;
        private Label lbl_MovieRelease;
        private Label lbl_LetterboxdLink;
        private Label lbl_WinDate;
        private DateTimePicker dtp_DateWonInput;
        private Button btn_AddRecord;
    }
}