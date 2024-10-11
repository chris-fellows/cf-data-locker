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
    public partial class ContactControl : UserControl
    {
        private Contact _contact;

        public ContactControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_contact);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var contact = new Contact() { Address = new Address() };
            ViewToModel(contact);

            if (!String.IsNullOrEmpty(contact.Name) ||                
                !String.IsNullOrEmpty(contact.Email) ||
                !String.IsNullOrEmpty(contact.Telephone))
            {
                messages.AddRange(DataAnnotationUtilities.GetValidationErrorsPropertyMessages(contact));
            }

            return messages;
        }

        public Contact Contact
        {
            get { return _contact; }
            set
            {
                _contact = value;
                if (_contact != null)
                {
                    ModelToView(_contact);
                }
            }
        }

        private void ModelToView(Contact contact)
        {            
            txtContactName.Text = contact.Name;
            //txtContactAddress.Text = contact.Address;
            txtContactEmail.Text = contact.Email;
            txtContactTelephone.Text = contact.Telephone;

            addressControl1.Address = contact.Address;
        }

        public void ViewToModel(Contact contact)
        {            
            contact.Name = txtContactName.Text;            
            contact.Email = txtContactEmail.Text;
            contact.Telephone = txtContactTelephone.Text;

            addressControl1.ViewToModel(contact.Address);
        }
    }
}
