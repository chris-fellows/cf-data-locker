using CFDataLocker.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CFDataLocker.Controls
{
    public partial class SecurityQuestionsControl : UserControl
    {
        private SecurityQuestions _securityQuestions;
        private SecurityQuestions _securityQuestionsNew;

        public SecurityQuestionsControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_securityQuestions);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var securityQuestions = new SecurityQuestions() { Questions = new List<SecurityQuestion>() };
            ViewToModel(securityQuestions);
            //if (String.IsNullOrEmpty(dataItem.Description))
            //{
            //    messages.Add(new PropertyMessage(nameof(DataItem.Description), "Description is invalid or not set"));
            //}           

            return messages;
        }

        public SecurityQuestions SecurityQuestions
        {
            get { return _securityQuestions; }
            set
            {
                _securityQuestions = value;
                if (_securityQuestions != null)
                {
                    ModelToView(_securityQuestions);
                }
            }
        }

        private void ModelToView(SecurityQuestions securityQuestions)
        {
            _securityQuestionsNew = (SecurityQuestions)securityQuestions.Clone();

            cbQuestion.DataSource = _securityQuestionsNew.Questions;
            cbQuestion.DisplayMember = nameof(SecurityQuestion.Question);
            cbQuestion.ValueMember = nameof(SecurityQuestion.Question);

            if (_securityQuestionsNew.Questions.Any()) cbQuestion.SelectedIndex = 0;   // Select first question

            // Enable Delete button if question selected
            btnDeleteQuestion.Enabled = _securityQuestionsNew.Questions.Count > 0;

            // Prevent user editing question/answer if no question selected
            txtAnswer.Enabled = _securityQuestionsNew.Questions.Count > 0;
            txtQuestion.Enabled = _securityQuestionsNew.Questions.Count > 0;            
            btnUpdateQuestion.Enabled = _securityQuestionsNew.Questions.Count > 0;
            btnCancelUpdateQuestion.Enabled = _securityQuestionsNew.Questions.Count > 0;
        }

        public void ViewToModel(SecurityQuestions securityQuestions)
        {
            // Add questions
            securityQuestions.Questions.Clear();
            securityQuestions.Questions.AddRange(_securityQuestionsNew.Questions.Select(q => (SecurityQuestion)q.Clone()));
        }

        private void cbQuestion_SelectedIndexChanged(object sender, EventArgs e)
        {
            SecurityQuestion securityQuestion = (SecurityQuestion)cbQuestion.SelectedItem;

            txtQuestion.Enabled = true;
            txtAnswer.Enabled = true;

            txtQuestion.Text = securityQuestion.Question;
            txtAnswer.Text = securityQuestion.Answer;

            // Prevent user changing
            cbQuestion.Enabled = false;

            btnCancelUpdateQuestion.Enabled = true;
            btnDeleteQuestion.Enabled = true;
        }

        private void btnUpdateQuestion_Click(object sender, EventArgs e)
        {
            SecurityQuestion securityQuestion = (SecurityQuestion)cbQuestion.SelectedItem;

            securityQuestion.Question = txtQuestion.Text;
            securityQuestion.Answer = txtAnswer.Text;

            // Get index of question so that we can select it in UI below
            var index = _securityQuestionsNew.Questions.IndexOf(securityQuestion);

            // Update UI
            ModelToView(_securityQuestionsNew);

            // Select question
            cbQuestion.SelectedIndex = index;
        }

        private void btnCancelUpdateQuestion_Click(object sender, EventArgs e)
        {
            SecurityQuestion securityQuestion = (SecurityQuestion)cbQuestion.SelectedItem;         
            
            txtQuestion.Text = securityQuestion.Question;
            txtAnswer.Text = securityQuestion.Answer;

            cbQuestion.Enabled = true;            
        }

        private void btnNewQuestion_Click(object sender, EventArgs e)
        {
            SecurityQuestion securityQuestion = new SecurityQuestion()
            {
                Question = "[Question]",
                Answer = "[Answer]"
            };
            _securityQuestionsNew.Questions.Add(securityQuestion);

            // Update UI
            ModelToView(_securityQuestionsNew);

            // Select new question
            cbQuestion.SelectedIndex = _securityQuestionsNew.Questions.Count - 1;
        }

        private void btnDeleteQuestion_Click(object sender, EventArgs e)
        {
            SecurityQuestion securityQuestion = (SecurityQuestion)cbQuestion.SelectedItem;

            if (MessageBox.Show($"Delete question '{securityQuestion.Question}?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                _securityQuestionsNew.Questions.Remove(securityQuestion);
                
                // Update UI
                ModelToView(_securityQuestionsNew);
            }
        }
    }
}
