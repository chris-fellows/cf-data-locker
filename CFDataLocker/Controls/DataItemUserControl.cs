using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CFDataLocker.Model;

namespace CFDataLocker
{
    public partial class DataItemUserControl : UserControl
    {
        private DataItem _dataItem;

        public DataItemUserControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            ViewToModel(_dataItem);
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
            dataItem.Contact.EmailAddress = txtContactEmail.Text;
            dataItem.Contact.Telephone = txtContactTelephone.Text;
            dataItem.Active = chkActive.Checked;
        }

        private void txtUserName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
