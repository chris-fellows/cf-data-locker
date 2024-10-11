namespace CFDataLocker.Controls
{
    partial class DataItemUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.credentialsControl1 = new CFDataLocker.Controls.CredentialsControl();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.contactControl1 = new CFDataLocker.Controls.ContactControl();
            this.tabPage5 = new System.Windows.Forms.TabPage();
            this.bankCardControl1 = new CFDataLocker.Controls.BankCardControl();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.securityQuestionsControl1 = new CFDataLocker.Controls.SecurityQuestionsControl();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage5.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage5);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(3, 3);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(421, 450);
            this.tabControl1.TabIndex = 14;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.chkActive);
            this.tabPage1.Controls.Add(this.txtAccountNumber);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.txtURL);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.txtNotes);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.txtDescription);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(413, 424);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "General";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(9, 401);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 26;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(75, 43);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(328, 20);
            this.txtAccountNumber.TabIndex = 25;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 24;
            this.label9.Text = "Account No:";
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(75, 74);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(328, 20);
            this.txtURL.TabIndex = 23;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(7, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 22;
            this.label5.Text = "URL:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(10, 119);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(393, 276);
            this.txtNotes.TabIndex = 21;
            this.txtNotes.TextChanged += new System.EventHandler(this.txtNotes_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 103);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Notes:";
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(75, 11);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(328, 20);
            this.txtDescription.TabIndex = 19;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 16;
            this.label3.Text = "Description:";
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.credentialsControl1);
            this.tabPage4.Location = new System.Drawing.Point(4, 22);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(413, 424);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Credentials";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // credentialsControl1
            // 
            this.credentialsControl1.Credentials = null;
            this.credentialsControl1.Location = new System.Drawing.Point(16, 4);
            this.credentialsControl1.Name = "credentialsControl1";
            this.credentialsControl1.Size = new System.Drawing.Size(375, 112);
            this.credentialsControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.contactControl1);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(413, 424);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Contact Details";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // contactControl1
            // 
            this.contactControl1.Contact = null;
            this.contactControl1.Location = new System.Drawing.Point(3, 3);
            this.contactControl1.Name = "contactControl1";
            this.contactControl1.Size = new System.Drawing.Size(336, 333);
            this.contactControl1.TabIndex = 16;
            // 
            // tabPage5
            // 
            this.tabPage5.Controls.Add(this.bankCardControl1);
            this.tabPage5.Location = new System.Drawing.Point(4, 22);
            this.tabPage5.Name = "tabPage5";
            this.tabPage5.Size = new System.Drawing.Size(413, 424);
            this.tabPage5.TabIndex = 4;
            this.tabPage5.Text = "Credit Card";
            this.tabPage5.UseVisualStyleBackColor = true;
            // 
            // bankCardControl1
            // 
            this.bankCardControl1.BankCard = null;
            this.bankCardControl1.Location = new System.Drawing.Point(3, 13);
            this.bankCardControl1.Name = "bankCardControl1";
            this.bankCardControl1.Size = new System.Drawing.Size(423, 150);
            this.bankCardControl1.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.securityQuestionsControl1);
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(413, 424);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Security Questions";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // securityQuestionsControl1
            // 
            this.securityQuestionsControl1.Location = new System.Drawing.Point(3, 3);
            this.securityQuestionsControl1.Name = "securityQuestionsControl1";
            this.securityQuestionsControl1.SecurityQuestions = null;
            this.securityQuestionsControl1.Size = new System.Drawing.Size(407, 173);
            this.securityQuestionsControl1.TabIndex = 0;
            // 
            // DataItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl1);
            this.Name = "DataItemUserControl";
            this.Size = new System.Drawing.Size(428, 455);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage4.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage5.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label3;
        private ContactControl contactControl1;
        private System.Windows.Forms.TabPage tabPage3;
        private SecurityQuestionsControl securityQuestionsControl1;
        private System.Windows.Forms.TabPage tabPage4;
        private CredentialsControl credentialsControl1;
        private System.Windows.Forms.TabPage tabPage5;
        private BankCardControl bankCardControl1;
    }
}
