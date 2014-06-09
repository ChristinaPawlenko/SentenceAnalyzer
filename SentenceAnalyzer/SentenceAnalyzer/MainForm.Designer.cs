namespace SentenceAnalyzer
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.rtbSentenceContainer = new System.Windows.Forms.RichTextBox();
            this.btnAnalyze = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            this.helpProvider1 = new System.Windows.Forms.HelpProvider();
            this.pnlInfo = new System.Windows.Forms.Panel();
            this.lblPredicateText = new System.Windows.Forms.Label();
            this.lblSubjectText = new System.Windows.Forms.Label();
            this.lblSubject = new System.Windows.Forms.Label();
            this.lblPredicate = new System.Windows.Forms.Label();
            this.llblDirection = new System.Windows.Forms.LinkLabel();
            this.lblDirection = new System.Windows.Forms.Label();
            this.llblTense = new System.Windows.Forms.LinkLabel();
            this.lblTense = new System.Windows.Forms.Label();
            this.pnlInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // rtbSentenceContainer
            // 
            this.rtbSentenceContainer.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.helpProvider1.SetHelpString(this.rtbSentenceContainer, "");
            this.rtbSentenceContainer.Location = new System.Drawing.Point(12, 12);
            this.rtbSentenceContainer.Name = "rtbSentenceContainer";
            this.helpProvider1.SetShowHelp(this.rtbSentenceContainer, true);
            this.rtbSentenceContainer.Size = new System.Drawing.Size(450, 155);
            this.rtbSentenceContainer.TabIndex = 0;
            this.rtbSentenceContainer.Text = "";
            // 
            // btnAnalyze
            // 
            this.helpProvider1.SetHelpString(this.btnAnalyze, "");
            this.btnAnalyze.Location = new System.Drawing.Point(564, 144);
            this.btnAnalyze.Name = "btnAnalyze";
            this.helpProvider1.SetShowHelp(this.btnAnalyze, true);
            this.btnAnalyze.Size = new System.Drawing.Size(74, 23);
            this.btnAnalyze.TabIndex = 1;
            this.btnAnalyze.Text = "Analyze";
            this.btnAnalyze.UseVisualStyleBackColor = true;
            this.btnAnalyze.Click += new System.EventHandler(this.btnAnalyze_Click);
            // 
            // btnClear
            // 
            this.helpProvider1.SetHelpString(this.btnClear, "");
            this.btnClear.Location = new System.Drawing.Point(484, 144);
            this.btnClear.Name = "btnClear";
            this.helpProvider1.SetShowHelp(this.btnClear, true);
            this.btnClear.Size = new System.Drawing.Size(74, 23);
            this.btnClear.TabIndex = 2;
            this.btnClear.Text = "Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // helpProvider1
            // 
            this.helpProvider1.HelpNamespace = "..\\..\\..\\..\\Data\\About.pdf";
            // 
            // pnlInfo
            // 
            this.pnlInfo.Controls.Add(this.lblPredicateText);
            this.pnlInfo.Controls.Add(this.lblSubjectText);
            this.pnlInfo.Controls.Add(this.lblSubject);
            this.pnlInfo.Controls.Add(this.lblPredicate);
            this.pnlInfo.Controls.Add(this.llblDirection);
            this.pnlInfo.Controls.Add(this.lblDirection);
            this.pnlInfo.Controls.Add(this.llblTense);
            this.pnlInfo.Controls.Add(this.lblTense);
            this.pnlInfo.Location = new System.Drawing.Point(468, 12);
            this.pnlInfo.Name = "pnlInfo";
            this.pnlInfo.Size = new System.Drawing.Size(180, 113);
            this.pnlInfo.TabIndex = 12;
            this.pnlInfo.Visible = false;
            // 
            // lblPredicateText
            // 
            this.lblPredicateText.AutoEllipsis = true;
            this.lblPredicateText.Location = new System.Drawing.Point(64, 83);
            this.lblPredicateText.Name = "lblPredicateText";
            this.lblPredicateText.Size = new System.Drawing.Size(111, 13);
            this.lblPredicateText.TabIndex = 19;
            this.lblPredicateText.Text = "label2";
            // 
            // lblSubjectText
            // 
            this.lblSubjectText.AutoEllipsis = true;
            this.lblSubjectText.Location = new System.Drawing.Point(64, 61);
            this.lblSubjectText.Name = "lblSubjectText";
            this.lblSubjectText.Size = new System.Drawing.Size(111, 13);
            this.lblSubjectText.TabIndex = 18;
            this.lblSubjectText.Text = "label1";
            // 
            // lblSubject
            // 
            this.lblSubject.AutoSize = true;
            this.lblSubject.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblSubject.Location = new System.Drawing.Point(5, 61);
            this.lblSubject.Name = "lblSubject";
            this.lblSubject.Size = new System.Drawing.Size(46, 13);
            this.lblSubject.TabIndex = 17;
            this.lblSubject.Text = "Subject:";
            // 
            // lblPredicate
            // 
            this.lblPredicate.AutoSize = true;
            this.lblPredicate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblPredicate.Location = new System.Drawing.Point(5, 83);
            this.lblPredicate.Name = "lblPredicate";
            this.lblPredicate.Size = new System.Drawing.Size(55, 13);
            this.lblPredicate.TabIndex = 16;
            this.lblPredicate.Text = "Predicate:";
            // 
            // llblDirection
            // 
            this.llblDirection.AutoEllipsis = true;
            this.llblDirection.AutoSize = true;
            this.llblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llblDirection.Location = new System.Drawing.Point(63, 38);
            this.llblDirection.Name = "llblDirection";
            this.llblDirection.Size = new System.Drawing.Size(56, 13);
            this.llblDirection.TabIndex = 15;
            this.llblDirection.TabStop = true;
            this.llblDirection.Text = "Affirmative";
            this.llblDirection.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkedLink_LinkClicked);
            // 
            // lblDirection
            // 
            this.lblDirection.AutoSize = true;
            this.lblDirection.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblDirection.Location = new System.Drawing.Point(5, 38);
            this.lblDirection.Name = "lblDirection";
            this.lblDirection.Size = new System.Drawing.Size(52, 13);
            this.lblDirection.TabIndex = 14;
            this.lblDirection.Text = "Direction:";
            // 
            // llblTense
            // 
            this.llblTense.AutoEllipsis = true;
            this.llblTense.AutoSize = true;
            this.llblTense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.llblTense.Location = new System.Drawing.Point(45, 16);
            this.llblTense.Name = "llblTense";
            this.llblTense.Size = new System.Drawing.Size(130, 13);
            this.llblTense.TabIndex = 13;
            this.llblTense.TabStop = true;
            this.llblTense.Text = "Future Perfect Continuous";
            this.llblTense.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LinkedLink_LinkClicked);
            // 
            // lblTense
            // 
            this.lblTense.AutoSize = true;
            this.lblTense.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.lblTense.Location = new System.Drawing.Point(5, 16);
            this.lblTense.Name = "lblTense";
            this.lblTense.Size = new System.Drawing.Size(40, 13);
            this.lblTense.TabIndex = 12;
            this.lblTense.Text = "Tense:";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 179);
            this.Controls.Add(this.pnlInfo);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnAnalyze);
            this.Controls.Add(this.rtbSentenceContainer);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.HelpButton = true;
            this.helpProvider1.SetHelpString(this, "");
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.helpProvider1.SetShowHelp(this, false);
            this.Text = "Sentence Analyzer";
            this.pnlInfo.ResumeLayout(false);
            this.pnlInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbSentenceContainer;
        private System.Windows.Forms.Button btnAnalyze;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.HelpProvider helpProvider1;
        private System.Windows.Forms.Panel pnlInfo;
        private System.Windows.Forms.Label lblPredicateText;
        private System.Windows.Forms.Label lblSubjectText;
        private System.Windows.Forms.Label lblSubject;
        private System.Windows.Forms.Label lblPredicate;
        private System.Windows.Forms.LinkLabel llblDirection;
        private System.Windows.Forms.Label lblDirection;
        private System.Windows.Forms.LinkLabel llblTense;
        private System.Windows.Forms.Label lblTense;
    }
}

