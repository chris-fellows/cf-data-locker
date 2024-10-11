using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CFDataLocker.Models;

namespace CFDataLocker.Controls
{
    /// <summary>
    /// Control for viewing or changing DataItem
    /// </summary>
    public partial class DataItemUserControl : UserControl
    {
        private DataItem _dataItem;

        public DataItemUserControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_dataItem);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var dataItem = new DataItem() 
            { 
                Contact = new Contact() {  Address = new Address() },
                Credentials = new Credentials(), 
                BankCard= new BankCard(),
                SecurityQuestions = new SecurityQuestions() {  Questions = new List<SecurityQuestion>() }
            };
            ViewToModel(dataItem);

            if (String.IsNullOrEmpty(dataItem.Description))
            {
                messages.Add(new PropertyMessage(nameof(DataItem.Description), "Description is invalid or not set"));
            }
            if (!String.IsNullOrEmpty(dataItem.URL) &&
                !dataItem.URL.ToLower().StartsWith("www.") &&
                !dataItem.URL.ToLower().StartsWith("http://") &&
                !dataItem.URL.ToLower().StartsWith("https://"))
            {
                messages.Add(new PropertyMessage(nameof(DataItem.URL), "URL is invalid or not set"));
            }

            // Add validation messages for child components
            messages.AddRange(contactControl1.ValidateBeforeApplyChanges());
            messages.AddRange(credentialsControl1.ValidateBeforeApplyChanges());
            messages.AddRange(bankCardControl1.ValidateBeforeApplyChanges());
            messages.AddRange(securityQuestionsControl1.ValidateBeforeApplyChanges());

            return messages;                
        }

        public DataItem DataItem
        {
            get { return _dataItem; }
            set
            {
                _dataItem = value;
                if (_dataItem != null)
                {
                    ModelToView(_dataItem);
                }
            }
        }
        
        private void ModelToView(DataItem dataItem)
        {           
            txtDescription.Text = dataItem.Description;
            txtNotes.Text = dataItem.Notes;
            txtURL.Text = dataItem.URL;
            txtAccountNumber.Text = dataItem.AccountNumber;          
            chkActive.Checked = dataItem.Active;

            contactControl1.Contact = _dataItem.Contact;

            credentialsControl1.Credentials = _dataItem.Credentials;

            bankCardControl1.BankCard = _dataItem.BankCard;

            securityQuestionsControl1.SecurityQuestions = _dataItem.SecurityQuestions;
        }

        private void ViewToModel(DataItem dataItem)
        {          
            dataItem.Description = txtDescription.Text;
            dataItem.Notes = txtNotes.Text;
            dataItem.URL = txtURL.Text;
            dataItem.AccountNumber = txtAccountNumber.Text;          
            dataItem.Active = chkActive.Checked;

            contactControl1.ViewToModel(dataItem.Contact);

            credentialsControl1.ViewToModel(dataItem.Credentials);

            bankCardControl1.ViewToModel(dataItem.BankCard);

            securityQuestionsControl1.ViewToModel(dataItem.SecurityQuestions);
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNotes_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
