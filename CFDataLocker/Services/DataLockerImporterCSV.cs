using System;
using System.Linq;
using CFDataLocker.Interfaces;
using CFDataLocker.Model;

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
                            UserName = dataTable.Rows[rowIndex]["UserName"].ToString(),
                            Password = dataTable.Rows[rowIndex]["Password"].ToString()
                        },
                        Contact = new Contact()
                        {
                            EmailAddress = dataTable.Rows[rowIndex]["ContactEmail"].ToString(),
                            Name = dataTable.Rows[rowIndex]["ContactName"].ToString(),
                            Telephone = dataTable.Rows[rowIndex]["ContactTelephone"].ToString()
                        },
                        Description = dataTable.Rows[rowIndex]["Description"].ToString(),
                        URL = dataTable.Rows[rowIndex]["URL"].ToString(),
                        Notes = dataTable.Rows[rowIndex]["Notes"].ToString(),
                        Active = true
                    };
                    document.DataItems.Add(dataItem);
                }
            }            
        }
    }
}
