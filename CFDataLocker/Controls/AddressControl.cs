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
using System.Xml.Linq;

namespace CFDataLocker.Controls
{
    public partial class AddressControl : UserControl
    {
        private Address _address;

        public AddressControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_address);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var address = new Address();
            ViewToModel(address);

            // Validate
            if (!String.IsNullOrEmpty(address.Line1) ||
                !String.IsNullOrEmpty(address.Line2) ||
                !String.IsNullOrEmpty(address.Town) ||
                !String.IsNullOrEmpty(address.Postcode) ||
                !String.IsNullOrEmpty(address.Country))
            {
                messages.AddRange(DataAnnotationUtilities.GetValidationErrorsPropertyMessages(address));

                if (String.IsNullOrEmpty(address.Line1))
                {
                    messages.Add(new PropertyMessage(nameof(Address.Line1), "Line1 is invalid or not set"));
                }
                //if (String.IsNullOrEmpty(address.Line2))
                //{
                //    messages.Add(new PropertyMessage(nameof(Address.Line2), "Line2 is invalid or not set"));
                //}
                if (String.IsNullOrEmpty(address.Town))
                {
                    messages.Add(new PropertyMessage(nameof(Address.Town), "Town is invalid or not set"));
                }
                if (String.IsNullOrEmpty(address.Town))
                {
                    messages.Add(new PropertyMessage(nameof(Address.Town), "Town is invalid or not set"));
                }
            }

            return messages;
        }

        public Address Address
        {
            get { return _address; }
            set
            {
                _address = value;
                if (_address != null)
                {
                    ModelToView(_address);
                }
            }
        }

        private void ModelToView(Address address)
        {
            txtLine1.Text = address.Line1;
            txtLine2.Text = address.Line2;
            txtTown.Text = address.Town;
            txtPostcode.Text = address.Postcode;
            txtCounty.Text = address.County;
            txtCountry.Text = address.Country;
        }

        public void ViewToModel(Address address)
        {
            address.Line1 = txtLine1.Text;
            address.Line2 = txtLine2.Text;
            address.Town = txtTown.Text;
            address.Postcode = txtPostcode.Text;
            address.County = txtCounty.Text;
            address.Country = txtCountry.Text;
        }
    }
}
