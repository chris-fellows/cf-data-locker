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
    public partial class BankCardControl : UserControl
    {
        private BankCard _bankCard;

        public BankCardControl()
        {
            InitializeComponent();
        }

        public void ApplyChanges()
        {
            if (ValidateBeforeApplyChanges().Any())
            {
                throw new ApplicationException("Cannot apply changes if there are validation errors");
            }

            ViewToModel(_bankCard);
        }

        public List<PropertyMessage> ValidateBeforeApplyChanges()
        {
            var messages = new List<PropertyMessage>();

            var creditCard = new BankCard();
            ViewToModel(creditCard);

            // Validate
            if (!String.IsNullOrEmpty(creditCard.Name) ||
                !String.IsNullOrEmpty(creditCard.Number) ||
                !String.IsNullOrEmpty(creditCard.ExpiryDate) ||
                !String.IsNullOrEmpty(creditCard.Security))
            {
                messages.AddRange(DataAnnotationUtilities.GetValidationErrorsPropertyMessages(creditCard));

                if (String.IsNullOrEmpty(creditCard.Name))
                {
                    messages.Add(new PropertyMessage(nameof(BankCard.Name), "Name is invalid or not set"));
                }
                if (String.IsNullOrEmpty(creditCard.Number))
                {
                    messages.Add(new PropertyMessage(nameof(BankCard.Number), "Number is invalid or not set"));
                }
                if (String.IsNullOrEmpty(creditCard.ExpiryDate))
                {
                    messages.Add(new PropertyMessage(nameof(BankCard.ExpiryDate), "ExpiryDate is invalid or not set"));
                }
                else
                {
                    // Format: MM/YYYY
                    bool isInvalidFormat = false;
                    int splitPos = creditCard.ExpiryDate.IndexOf("/");
                    if (splitPos == -1 || creditCard.ExpiryDate.Length != "MM/YYYY".Length)
                    {
                        isInvalidFormat = true;
                    }
                    else
                    {
                        var elements = creditCard.ExpiryDate.Split('/');
                        if (elements.Length != 2 ||
                            elements[0].Length != "MM".Length ||
                            elements[1].Length != "YYYY".Length)
                        {                         
                            isInvalidFormat = true;
                        }
                        else
                        {
                            if (Int32.TryParse(elements[0], out var month) &&
                                Int32.TryParse(elements[1], out var year))
                            {
                                if (month >=1  && month <= 12 &&
                                    year >= 2000 && year < 2999)
                                {
                                    isInvalidFormat = false;
                                }
                                else
                                {
                                    isInvalidFormat = true;
                                }
                            }
                            else
                            {
                                isInvalidFormat = true;
                            }                              
                        }
                    }
                    if (isInvalidFormat)
                    {
                        messages.Add(new PropertyMessage(nameof(BankCard.ExpiryDate), "ExpiryDate is invalid or not set"));
                    }
                }
                if (String.IsNullOrEmpty(creditCard.Security))
                {
                    messages.Add(new PropertyMessage(nameof(BankCard.Security), "Security is invalid or not set"));
                }
            }

            return messages;
        }

        public BankCard BankCard
        {
            get { return _bankCard; }
            set
            {
                _bankCard = value;
                if (_bankCard != null)
                {
                    ModelToView(_bankCard);
                }
            }
        }

        private void ModelToView(BankCard bankCard)
        {
            txtName.Text = bankCard.Name;
            txtNumber.Text = bankCard.Number;
            txtExpiryDate.Text = bankCard.ExpiryDate;
            txtSecurity.Text = bankCard.Security;
        }

        public void ViewToModel(BankCard bankCard)
        {
            bankCard.Name = txtName.Text;
            bankCard.Number = txtNumber.Text;
            bankCard.ExpiryDate = txtExpiryDate.Text;
            bankCard.Security = txtSecurity.Text;
        }
    }
}
