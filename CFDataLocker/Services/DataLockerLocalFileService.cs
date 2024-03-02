using System.IO;
using CFUtilities.Encryption;
using CFUtilities.XML;
using CFDataLocker.Model;
using CFDataLocker.Interfaces;

namespace CFDataLocker.Services
{
    /// <summary>
    /// Data locker service using local file.
    /// </summary>
    public class DataLockerLocalFileService : IDataLockerService
    {        
        private string _filename;

        public DataLockerLocalFileService(string filename)
        {
            _filename = filename;
        }

        /// <summary>
        /// Creates random key
        /// </summary>
        /// <param name="maxLength"></param>
        /// <returns></returns>
        public string CreateRandomKey()
        {
            return TripleDESEncryption.GenerateRandomKey(9);
        }

        public DataLocker Unlock(string key)
        {
            DataLocker dataLocker = null;
            var tempFile = Path.GetTempFileName();
            try
            {               
                var xml = TripleDESEncryption.DecryptString(File.ReadAllText(_filename), key);
                File.WriteAllText(tempFile, xml);
                dataLocker = XmlSerialization.DeserializeFromFile<DataLocker>(tempFile);

                // Decode to readable format
                dataLocker.Decode();
            }
            catch
            {
                // Ignore error, return no locker
                dataLocker = null;
            }
            finally
            {                
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
            return dataLocker;
        }
        
        public void Lock(DataLocker dataLocker, string key)
        {        
            var tempFile = Path.GetTempFileName();     

            try
            {
                // Clone document & encode to storable format
                var dataLockerCopy = (DataLocker)dataLocker.Clone();
                dataLockerCopy.Encode();

                XmlSerialization.SerializeToFile<DataLocker>(dataLockerCopy, tempFile);              
                string data = TripleDESEncryption.EncryptString(File.ReadAllText(tempFile), key);

                // Create backup if data changes
                var oldData = "";              
                if (File.Exists(_filename))
                {
                    oldData = File.ReadAllText(_filename);
                    if (data != oldData)
                    {
                        Backup(_filename);
                    }
                }

                // Save if different
                if (data != oldData)
                {
                    File.WriteAllText(_filename, data);                    
                }
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
        }


        /// <summary>
        /// Backs up the data file
        /// </summary>
        /// <param name="lockFile"></param>
        private void Backup(string lockFile)
        {
            int count = 0;
            var backupFile = "";
            do
            {
                count++;
                backupFile = string.Format("{0}.{1}{2}", Path.GetFileNameWithoutExtension(lockFile), count, Path.GetExtension(lockFile));
            } while (File.Exists(backupFile));

            File.Copy(lockFile, backupFile);
        }
    }
}
