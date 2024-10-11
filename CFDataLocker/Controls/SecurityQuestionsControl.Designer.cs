namespace CFDataLocker.Controls
{
    partial class SecurityQuestionsControl
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
            this.cbQuestion = new System.Windows.Forms.ComboBox();
            this.btnDeleteQuestion = new System.Windows.Forms.Button();
            this.btnNewQuestion = new System.Windows.Forms.Button();
            this.grpEdit = new System.Windows.Forms.GroupBox();
            this.btnCancelUpdateQuestion = new System.Windows.Forms.Button();
            this.btnUpdateQuestion = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txtAnswer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtQuestion = new System.Windows.Forms.TextBox();
            this.grpEdit.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Question:";
            // 
            // cbQuestion
            // 
            this.cbQuestion.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbQuestion.FormattingEnabled = true;
            this.cbQuestion.Location = new System.Drawing.Point(61, 13);
            this.cbQuestion.Name = "cbQuestion";
            this.cbQuestion.Size = new System.Drawing.Size(191, 21);
            this.cbQuestion.TabIndex = 2;
            this.cbQuestion.SelectedIndexChanged += new System.EventHandler(this.cbQuestion_SelectedIndexChanged);
            // 
            // btnDeleteQuestion
            // 
            this.btnDeleteQuestion.Location = new System.Drawing.Point(258, 13);
            this.btnDeleteQuestion.Name = "btnDeleteQuestion";
            this.btnDeleteQuestion.Size = new System.Drawing.Size(62, 23);
            this.btnDeleteQuestion.TabIndex = 3;
            this.btnDeleteQuestion.Text = "Delete";
            this.btnDeleteQuestion.UseVisualStyleBackColor = true;
            this.btnDeleteQuestion.Click += new System.EventHandler(this.btnDeleteQuestion_Click);
            // 
            // btnNewQuestion
            // 
            this.btnNewQuestion.Location = new System.Drawing.Point(326, 13);
            this.btnNewQuestion.Name = "btnNewQuestion";
            this.btnNewQuestion.Size = new System.Drawing.Size(62, 23);
            this.btnNewQuestion.TabIndex = 4;
            this.btnNewQuestion.Text = "Add";
            this.btnNewQuestion.UseVisualStyleBackColor = true;
            this.btnNewQuestion.Click += new System.EventHandler(this.btnNewQuestion_Click);
            // 
            // grpEdit
            // 
            this.grpEdit.Controls.Add(this.btnCancelUpdateQuestion);
            this.grpEdit.Controls.Add(this.btnUpdateQuestion);
            this.grpEdit.Controls.Add(this.label4);
            this.grpEdit.Controls.Add(this.txtAnswer);
            this.grpEdit.Controls.Add(this.label5);
            this.grpEdit.Controls.Add(this.txtQuestion);
            this.grpEdit.Location = new System.Drawing.Point(6, 53);
            this.grpEdit.Name = "grpEdit";
            this.grpEdit.Size = new System.Drawing.Size(396, 110);
            this.grpEdit.TabIndex = 10;
            this.grpEdit.TabStop = false;
            this.grpEdit.Text = "Edit";
            // 
            // btnCancelUpdateQuestion
            // 
            this.btnCancelUpdateQuestion.Location = new System.Drawing.Point(324, 76);
            this.btnCancelUpdateQuestion.Name = "btnCancelUpdateQuestion";
            this.btnCancelUpdateQuestion.Size = new System.Drawing.Size(62, 23);
            this.btnCancelUpdateQuestion.TabIndex = 15;
            this.btnCancelUpdateQuestion.Text = "Cancel";
            this.btnCancelUpdateQuestion.UseVisualStyleBackColor = true;
            this.btnCancelUpdateQuestion.Click += new System.EventHandler(this.btnCancelUpdateQuestion_Click);
            // 
            // btnUpdateQuestion
            // 
            this.btnUpdateQuestion.Location = new System.Drawing.Point(256, 76);
            this.btnUpdateQuestion.Name = "btnUpdateQuestion";
            this.btnUpdateQuestion.Size = new System.Drawing.Size(62, 23);
            this.btnUpdateQuestion.TabIndex = 14;
            this.btnUpdateQuestion.Text = "Update";
            this.btnUpdateQuestion.UseVisualStyleBackColor = true;
            this.btnUpdateQuestion.Click += new System.EventHandler(this.btnUpdateQuestion_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 13;
            this.label4.Text = "Answer:";
            // 
            // txtAnswer
            // 
            this.txtAnswer.Location = new System.Drawing.Point(57, 50);
            this.txtAnswer.Name = "txtAnswer";
            this.txtAnswer.Size = new System.Drawing.Size(329, 20);
            this.txtAnswer.TabIndex = 12;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 27);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "Question:";
            // 
            // txtQuestion
            // 
            this.txtQuestion.Location = new System.Drawing.Point(58, 24);
            this.txtQuestion.Name = "txtQuestion";
            this.txtQuestion.Size = new System.Drawing.Size(328, 20);
            this.txtQuestion.TabIndex = 10;
            // 
            // SecurityQuestionsControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpEdit);
            this.Controls.Add(this.btnNewQuestion);
            this.Controls.Add(this.btnDeleteQuestion);
            this.Controls.Add(this.cbQuestion);
            this.Controls.Add(this.label1);
            this.Name = "SecurityQuestionsControl";
            this.Size = new System.Drawing.Size(407, 168);
            this.grpEdit.ResumeLayout(false);
            this.grpEdit.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbQuestion;
        private System.Windows.Forms.Button btnDeleteQuestion;
        private System.Windows.Forms.Button btnNewQuestion;
        private System.Windows.Forms.GroupBox grpEdit;
        private System.Windows.Forms.Button btnCancelUpdateQuestion;
        private System.Windows.Forms.Button btnUpdateQuestion;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtAnswer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtQuestion;
    }
}
