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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtUserName = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtNotes = new System.Windows.Forms.TextBox();
            this.txtURL = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtContactAddress = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txtContactTelephone = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtContactName = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtContactEmail = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtAccountNumber = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-3, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "User name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(-3, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Password:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(-3, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Description:";
            // 
            // txtUserName
            // 
            this.txtUserName.Location = new System.Drawing.Point(76, 37);
            this.txtUserName.Name = "txtUserName";
            this.txtUserName.Size = new System.Drawing.Size(274, 20);
            this.txtUserName.TabIndex = 3;
            this.txtUserName.TextChanged += new System.EventHandler(this.txtUserName_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(76, 68);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(274, 20);
            this.txtPassword.TabIndex = 4;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(76, 7);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(274, 20);
            this.txtDescription.TabIndex = 5;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(-3, 299);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Notes:";
            // 
            // txtNotes
            // 
            this.txtNotes.Location = new System.Drawing.Point(0, 315);
            this.txtNotes.Multiline = true;
            this.txtNotes.Name = "txtNotes";
            this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtNotes.Size = new System.Drawing.Size(348, 110);
            this.txtNotes.TabIndex = 7;
            // 
            // txtURL
            // 
            this.txtURL.Location = new System.Drawing.Point(76, 97);
            this.txtURL.Name = "txtURL";
            this.txtURL.Size = new System.Drawing.Size(274, 20);
            this.txtURL.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(-3, 104);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "URL:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtContactAddress);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txtContactTelephone);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txtContactName);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txtContactEmail);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Location = new System.Drawing.Point(1, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(347, 130);
            this.groupBox1.TabIndex = 10;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Contact Details";
            // 
            // txtContactAddress
            // 
            this.txtContactAddress.Location = new System.Drawing.Point(79, 47);
            this.txtContactAddress.Name = "txtContactAddress";
            this.txtContactAddress.Size = new System.Drawing.Size(267, 20);
            this.txtContactAddress.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(2, 47);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Address:";
            // 
            // txtContactTelephone
            // 
            this.txtContactTelephone.Location = new System.Drawing.Point(77, 99);
            this.txtContactTelephone.Name = "txtContactTelephone";
            this.txtContactTelephone.Size = new System.Drawing.Size(268, 20);
            this.txtContactTelephone.TabIndex = 15;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(2, 102);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(61, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Telephone:";
            // 
            // txtContactName
            // 
            this.txtContactName.Location = new System.Drawing.Point(79, 19);
            this.txtContactName.Name = "txtContactName";
            this.txtContactName.Size = new System.Drawing.Size(268, 20);
            this.txtContactName.TabIndex = 13;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(2, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(38, 13);
            this.label7.TabIndex = 12;
            this.label7.Text = "Name:";
            // 
            // txtContactEmail
            // 
            this.txtContactEmail.Location = new System.Drawing.Point(78, 73);
            this.txtContactEmail.Name = "txtContactEmail";
            this.txtContactEmail.Size = new System.Drawing.Size(267, 20);
            this.txtContactEmail.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(2, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(35, 13);
            this.label6.TabIndex = 10;
            this.label6.Text = "Email:";
            // 
            // txtAccountNumber
            // 
            this.txtAccountNumber.Location = new System.Drawing.Point(76, 127);
            this.txtAccountNumber.Name = "txtAccountNumber";
            this.txtAccountNumber.Size = new System.Drawing.Size(274, 20);
            this.txtAccountNumber.TabIndex = 12;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(-2, 130);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(67, 13);
            this.label9.TabIndex = 11;
            this.label9.Text = "Account No:";
            // 
            // chkActive
            // 
            this.chkActive.AutoSize = true;
            this.chkActive.Checked = true;
            this.chkActive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkActive.Location = new System.Drawing.Point(3, 431);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(56, 17);
            this.chkActive.TabIndex = 13;
            this.chkActive.Text = "Active";
            this.chkActive.UseVisualStyleBackColor = true;
            // 
            // DataItemUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chkActive);
            this.Controls.Add(this.txtAccountNumber);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtURL);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtNotes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "DataItemUserControl";
            this.Size = new System.Drawing.Size(356, 451);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtUserName;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtNotes;
        private System.Windows.Forms.TextBox txtURL;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtContactTelephone;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtContactName;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtContactEmail;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtAccountNumber;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.TextBox txtContactAddress;
        private System.Windows.Forms.Label label10;
    }
}
