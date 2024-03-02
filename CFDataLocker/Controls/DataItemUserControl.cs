using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using CFDataLocker.Model;

namespace CFDataLocker
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

            var dataItem = new DataItem() { Contact = new Contact(), Credentials = new Credentials() };
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
            txtUserName.Text = dataItem.Credentials.UserName;
            txtPassword.Text = dataItem.Credentials.Password;
            txtDescription.Text = dataItem.Description;
            txtNotes.Text = dataItem.Notes;
            txtURL.Text = dataItem.URL;
            txtAccountNumber.Text = dataItem.AccountNumber;
            txtContactName.Text = dataItem.Contact.Name;
            txtContactAddress.Text = dataItem.Contact.Address;
            txtContactEmail.Text = dataItem.Contact.EmailAddress;
            txtContactTelephone.Text = dataItem.Contact.Telephone;
            chkActive.Checked = dataItem.Active;
        }

        private void ViewToModel(DataItem dataItem)
        {
            dataItem.Credentials.UserName = txtUserName.Text;
            dataItem.Credentials.Password = txtPassword.Text;
            dataItem.Description = txtDescription.Text;
            dataItem.Notes = txtNotes.Text;
            dataItem.URL = txtURL.Text;
            dataItem.AccountNumber = txtAccountNumber.Text;
            dataItem.Contact.Name = txtContactName.Text;
            dataItem.Contact.Address = txtContactAddress.Text;
            dataItem.Contact.EmailAddress = txtContactEmail.Text;
            dataItem.Contact.Telephone = txtContactTelephone.Text;
            dataItem.Active = chkActive.Checked;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
