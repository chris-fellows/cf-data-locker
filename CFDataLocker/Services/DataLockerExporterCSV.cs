using CFDataLocker.Interfaces;
using CFDataLocker.Model;
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
                    new CSVColumn() { DataType = typeof(string), Name = "Group" },
                    new CSVColumn() { DataType = typeof(string), Name = "Description" },
                    new CSVColumn() { DataType = typeof(string), Name = "AccountNumber" },
                    new CSVColumn() { DataType = typeof(string), Name = "UserName" },
                    new CSVColumn() { DataType = typeof(string), Name = "Password" },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactName" },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactAddress" },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactEmail" },
                    new CSVColumn() { DataType = typeof(string), Name = "ContactTelephone" },
                    new CSVColumn() { DataType = typeof(string), Name = "Notes" },
                    new CSVColumn() { DataType = typeof(string), Name = "URL" },
                }
            };
        }

        public void Export(DataLocker document)
        {
            var csvWriter = new CSVWriter();
            csvWriter.Write<DataItem>(document.DataItems,
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
                    values.Add(dataItem.Contact?.Name);
                    values.Add(dataItem.Contact?.Address);
                    values.Add(dataItem.Contact?.EmailAddress);
                    values.Add(dataItem.Contact?.Telephone);
                    values.Add(dataItem.Notes);
                    values.Add(dataItem.URL);
                    return values;
                });
        }
    }
}
