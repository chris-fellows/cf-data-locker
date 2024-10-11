using CFDataLocker.Models;
using CFDataLocker.Utilities;
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
    public partial class CredentialsControl : UserControl
    {
        private Credentials _credentials;

        public CredentialsControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_credentials);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var credentials = new Credentials();
            ViewToModel(credentials);

            if (!String.IsNullOrEmpty(credentials.UserName) ||
                !String.IsNullOrEmpty(credentials.Password) ||
                !String.IsNullOrEmpty(credentials.Pin))
            {
                messages.AddRange(DataAnnotationUtilities.GetValidationErrorsPropertyMessages(credentials));
            }

            return messages;
        }

        public Credentials Credentials
        {
            get { return _credentials; }
            set
            {
                _credentials = value;
                if (_credentials != null)
                {
                    ModelToView(_credentials);
                }
            }
        }

        private void ModelToView(Credentials credentials)
        {
            txtUserName.Text = credentials.UserName;
            txtPassword.Text = credentials.Password;
            txtPin.Text = credentials.Pin;
        }

        public void ViewToModel(Credentials credentials)
        {
            credentials.UserName = txtUserName.Text;
            credentials.Password = txtPassword.Text;
            credentials.Pin = txtPin.Text;
        }
    }
}
