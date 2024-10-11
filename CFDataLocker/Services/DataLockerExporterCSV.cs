using CFDataLocker.Interfaces;
using CFDataLocker.Models;
using CFUtilities.CSV;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CFDataLocker.Services
{
    /// <summary>
    /// Exports data locker to CSV
    /// </summary>
    public class DataLockerExporterCSV : IDataLockerExporter
    {
        private readonly CSVSettings _csvSettings;
        
        public DataLockerExporterCSV(Char delimiter, string file, Encoding encoding)
        {
            _csvSettings = new CSVSettings()
            {
                Delimiter = delimiter,
                Encoding = encoding,
                Filename = file,
                Columns= new List<CSVColumn>()
                {
                    new CSVColumn() { DataType = typeof(string), Name = "Group", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "Description", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "AccountNumber", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "CredentialsUserName", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "CredentialsPassword", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "CredentialsPin", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactName", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressLine1", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressLine2", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressTown", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressCounty", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressPostcode", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddressCountry", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactEmail", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactTelephone", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "BankCardName", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "BankCardNumber" , ValueQuoted = true },
                    new CSVColumn() { DataType = typeof(string), Name = "BankCardExpiryDate", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "BankCardSecurity", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion1Question", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion1Answer" , ValueQuoted = true },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion2Question", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion2Answer", ValueQuoted = true  },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion3Question" , ValueQuoted = true },
                    new CSVColumn() { DataType = typeof(string), Name = "SecurityQuestion3Answer" , ValueQuoted = true },
                    new CSVColumn() { DataType = typeof(string), Name = "Notes", ValueQuoted = true },
                    new CSVColumn() { DataType = typeof(string), Name = "URL" , ValueQuoted = true },
                }
            };
        }

        public void Export(DataLocker document)
        {            
            var csvWriter = new CSVWriter();
            csvWriter.Write<DataItem>(document.DataItems.OrderBy(di => di.GroupID).ToList(),
                _csvSettings,
                (dataItem) =>
                {
                    var group = document.Groups.First(g => g.ID == dataItem.GroupID);

                    var values = new List<object>();
                    values.Add(group.Description);
                    values.Add(dataItem.Description);
                    values.Add(dataItem.AccountNumber);
                    values.Add(dataItem.Credentials?.UserName);
                    values.Add(dataItem.Credentials?.Password);
                    values.Add(dataItem.Credentials?.Pin);
                    values.Add(dataItem.Contact?.Name);
                    values.Add(dataItem.Contact?.Address?.Line1);
                    values.Add(dataItem.Contact?.Address?.Line2);
                    values.Add(dataItem.Contact?.Address?.Town);
                    values.Add(dataItem.Contact?.Address?.County);
                    values.Add(dataItem.Contact?.Address?.Postcode);
                    values.Add(dataItem.Contact?.Address?.Country);
                    values.Add(dataItem.Contact?.Email);
                    values.Add(dataItem.Contact?.Telephone);
                    values.Add(dataItem.BankCard?.Name);
                    values.Add(dataItem.BankCard?.Number);
                    values.Add(dataItem.BankCard?.ExpiryDate);
                    values.Add(dataItem.BankCard?.Security);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 1 ?
                                            dataItem.SecurityQuestions.Questions[0].Question : null);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 1 ?
                                            dataItem.SecurityQuestions.Questions[0].Answer : null);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 2 ?
                                            dataItem.SecurityQuestions.Questions[1].Question : null);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 2 ?
                                            dataItem.SecurityQuestions.Questions[1].Answer : null);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 3 ?
                                            dataItem.SecurityQuestions.Questions[2].Question : null);
                    values.Add(dataItem.SecurityQuestions != null && dataItem.SecurityQuestions.Questions != null && dataItem.SecurityQuestions.Questions.Count >= 3 ?
                                            dataItem.SecurityQuestions.Questions[2].Answer : null);
                    values.Add(dataItem.Notes);
                    values.Add(dataItem.URL);
                    return values;
                });
        }
    }
}
