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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_AddRecord));
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
            txb_MovieNameInput.Font = new Font("Consolas", 12F);
            txb_MovieNameInput.Location = new Point(13, 34);
            txb_MovieNameInput.Name = "txb_MovieNameInput";
            txb_MovieNameInput.PlaceholderText = "E.G. The Lego Movie";
            txb_MovieNameInput.Size = new Size(448, 26);
            txb_MovieNameInput.TabIndex = 0;
            // 
            // txb_MovieReleaseInput
            // 
            txb_MovieReleaseInput.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_MovieReleaseInput.Location = new Point(12, 142);
            txb_MovieReleaseInput.MaxLength = 4;
            txb_MovieReleaseInput.Name = "txb_MovieReleaseInput";
            txb_MovieReleaseInput.PlaceholderText = "####";
            txb_MovieReleaseInput.Size = new Size(57, 30);
            txb_MovieReleaseInput.TabIndex = 1;
            // 
            // txb_LetterboxdLinkInput
            // 
            txb_LetterboxdLinkInput.Font = new Font("Consolas", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txb_LetterboxdLinkInput.Location = new Point(12, 90);
            txb_LetterboxdLinkInput.Name = "txb_LetterboxdLinkInput";
            txb_LetterboxdLinkInput.PlaceholderText = "E.G. https://letterboxd.com/film/the-lego-movie/";
            txb_LetterboxdLinkInput.Size = new Size(448, 22);
            txb_LetterboxdLinkInput.TabIndex = 2;
            // 
            // lbl_MovieName
            // 
            lbl_MovieName.AutoSize = true;
            lbl_MovieName.Font = new Font("Consolas", 12F);
            lbl_MovieName.Location = new Point(12, 12);
            lbl_MovieName.Name = "lbl_MovieName";
            lbl_MovieName.Size = new Size(108, 19);
            lbl_MovieName.TabIndex = 3;
            lbl_MovieName.Text = "Movie Name:";
            // 
            // lbl_MovieRelease
            // 
            lbl_MovieRelease.AutoSize = true;
            lbl_MovieRelease.Font = new Font("Consolas", 12F);
            lbl_MovieRelease.Location = new Point(12, 120);
            lbl_MovieRelease.Name = "lbl_MovieRelease";
            lbl_MovieRelease.Size = new Size(126, 19);
            lbl_MovieRelease.TabIndex = 4;
            lbl_MovieRelease.Text = "Release Year:";
            // 
            // lbl_LetterboxdLink
            // 
            lbl_LetterboxdLink.AutoSize = true;
            lbl_LetterboxdLink.Font = new Font("Consolas", 12F);
            lbl_LetterboxdLink.Location = new Point(12, 68);
            lbl_LetterboxdLink.Name = "lbl_LetterboxdLink";
            lbl_LetterboxdLink.Size = new Size(153, 19);
            lbl_LetterboxdLink.TabIndex = 5;
            lbl_LetterboxdLink.Text = "Letterboxd Link:";
            // 
            // lbl_WinDate
            // 
            lbl_WinDate.AutoSize = true;
            lbl_WinDate.Font = new Font("Consolas", 12F);
            lbl_WinDate.Location = new Point(228, 120);
            lbl_WinDate.Name = "lbl_WinDate";
            lbl_WinDate.Size = new Size(90, 19);
            lbl_WinDate.TabIndex = 6;
            lbl_WinDate.Text = "Date Won:";
            // 
            // dtp_DateWonInput
            // 
            dtp_DateWonInput.Font = new Font("Consolas", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dtp_DateWonInput.Location = new Point(228, 142);
            dtp_DateWonInput.Name = "dtp_DateWonInput";
            dtp_DateWonInput.Size = new Size(233, 30);
            dtp_DateWonInput.TabIndex = 7;
            // 
            // btn_AddRecord
            // 
            btn_AddRecord.Font = new Font("Consolas", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btn_AddRecord.Location = new Point(12, 177);
            btn_AddRecord.Name = "btn_AddRecord";
            btn_AddRecord.Size = new Size(448, 78);
            btn_AddRecord.TabIndex = 8;
            btn_AddRecord.Text = "Add Record";
            btn_AddRecord.UseVisualStyleBackColor = true;
            btn_AddRecord.Click += btn_AddRecord_Click;
            // 
            // frm_AddRecord
            // 
            AutoScaleDimensions = new SizeF(7F, 14F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(473, 264);
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
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "frm_AddRecord";
            StartPosition = FormStartPosition.CenterParent;
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