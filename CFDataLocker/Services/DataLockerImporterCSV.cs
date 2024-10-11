using System;
using System.Collections.Generic;
using System.Linq;
using CFDataLocker.Interfaces;
using CFDataLocker.Models;

namespace CFDataLocker.Services
{
    /// <summary>
    /// Imports data locker from CSV
    /// </summary>
    public class DataLockerImporterCSV : IDataLockerImporter
    {
        private readonly string _file;

        public DataLockerImporterCSV(string file)
        {
            _file = file;
        }

        public void Import(DataLocker document)
        {
            // Read CSV file
            var csvFileObject = new CFUtilities.CSV.CSVFile();
            var csvSettings = new CFUtilities.CSV.CSVSettings(_file, '\t', false, false);
            var dataTable = csvFileObject.Read(csvSettings, null);
            
            int rowCount = 0;
            for (int rowIndex = 0; rowIndex < dataTable.Rows.Count; rowIndex++)
            {
                // Read line
                rowCount++;
                
                if (rowCount > 1)   // Ignore header
                {
                    // Get group
                    var currentGroup = document.Groups.FirstOrDefault(g => g.Description == dataTable.Rows[rowIndex]["Group"].ToString());
                    if (currentGroup == null)   // New group
                    {
                        currentGroup = new Group()
                        {
                            ID = Guid.NewGuid().ToString(),
                            Description = dataTable.Rows[rowIndex]["Group"].ToString()
                        };
                        document.Groups.Add(currentGroup);
                    }

                    // Remove existing data item if exists
                    var dataItem = document.DataItems.FirstOrDefault(di => di.Description == dataTable.Rows[rowIndex]["Description"].ToString());
                    if (dataItem != null)
                    {
                        document.DataItems.Remove(dataItem);
                    }

                    // Add data item
                    dataItem = new DataItem()
                    {
                        ID = Guid.NewGuid().ToString(),
                        GroupID = currentGroup.ID,
                        AccountNumber = dataTable.Rows[rowIndex]["AccountNumber"].ToString(),
                        Credentials = new Credentials()
                        {
                            UserName = dataTable.Rows[rowIndex]["CredentialsUserName"].ToString(),
                            Password = dataTable.Rows[rowIndex]["CredentialsPassword"].ToString(),
                            Pin = dataTable.Rows[rowIndex]["CredentialsPin"].ToString()
                        },
                        Contact = new Contact()
                        {
                            Email = dataTable.Rows[rowIndex]["ContactEmail"].ToString(),
                            Name = dataTable.Rows[rowIndex]["ContactName"].ToString(),
                            Telephone = dataTable.Rows[rowIndex]["ContactTelephone"].ToString(),
                            Address = new Address()
                            {
                                Line1 = dataTable.Rows[rowIndex]["ContactAddressLine1"].ToString(),
                                Line2 = dataTable.Rows[rowIndex]["ContactAddressLine2"].ToString(),
                                Town = dataTable.Rows[rowIndex]["ContactAddressTown"].ToString(),
                                County = dataTable.Rows[rowIndex]["ContactAddressCounty"].ToString(),
                                Postcode = dataTable.Rows[rowIndex]["ContactAddressPostcode"].ToString(),
                                Country = dataTable.Rows[rowIndex]["ContactAddressCountry"].ToString(),
                            }
                        },
                        Description = dataTable.Rows[rowIndex]["Description"].ToString(),
                        URL = dataTable.Rows[rowIndex]["URL"].ToString(),
                        Notes = dataTable.Rows[rowIndex]["Notes"].ToString(),
                        Active = true,
                        BankCard = new BankCard()
                        {
                            Name = dataTable.Rows[rowIndex]["BankCardName"].ToString(),
                            Number = dataTable.Rows[rowIndex]["BankCardNumber"].ToString(),
                            ExpiryDate = dataTable.Rows[rowIndex]["BankCardExpiryDate"].ToString(),
                            Security = dataTable.Rows[rowIndex]["BankCardSecurity"].ToString()
                        },
                        SecurityQuestions = new SecurityQuestions()
                        {
                            Questions = new List<SecurityQuestion>()
                            {
                                new SecurityQuestion()
                                {
                                    Question =  dataTable.Rows[rowIndex]["SecurityQuestion1Question"].ToString(),
                                    Answer =  dataTable.Rows[rowIndex]["SecurityQuestion1Answer"].ToString(),
                                },
                                new SecurityQuestion()
                                {
                                    Question =  dataTable.Rows[rowIndex]["SecurityQuestion2Question"].ToString(),
                                    Answer =  dataTable.Rows[rowIndex]["SecurityQuestion2Answer"].ToString(),
                                },
                                new SecurityQuestion()
                                {
                                    Question =  dataTable.Rows[rowIndex]["SecurityQuestion3Question"].ToString(),
                                    Answer =  dataTable.Rows[rowIndex]["SecurityQuestion3Answer"].ToString(),
                                }
                            }
                        }
                    };
                    dataItem.SecurityQuestions.Questions.RemoveAll(q => String.IsNullOrEmpty(q.Question));

                    document.DataItems.Add(dataItem);
                }
            }            
        }
    }
}