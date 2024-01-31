using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CFUtilities.Encryption;
using CFUtilities.XML;
using CFDataLocker.Model;

namespace CFDataLocker
{
    /// <summary>
    /// Maintains a locker of a document containing data items. The document is persisted as an
    /// encrypted file that must be locked/unlocking using a key.
    /// </summary>
    public class Locker
    {
        private string _filename;

        public Locker(string filename)
        {
            _filename = filename;
        }

        /// <summary>
        /// Unlocks the document using the specified key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public Document Unlock(string key)
        {
            Document document = null;
            string tempFile = Path.GetTempFileName();
            try
            {               
                string xml = TripleDESEncryption.DecryptString(File.ReadAllText(_filename), key);
                File.WriteAllText(tempFile, xml);
                document = XmlSerialization.DeserializeFromFile<Document>(tempFile);
            }
            catch(System.Exception exception)
            {
                // Ignore erorr, return no document
            }
            finally
            {
                if (File.Exists(tempFile))
                {
                    File.Delete(tempFile);
                }
            }
            return document;
        }

        /// <summary>
        /// Locks the document using the specified key
        /// </summary>
        /// <param name="document"></param>
        /// <param name="key"></param>
        public void Lock(Document document, string key)
        {        
            string tempFile = Path.GetTempFileName();     

            try
            {             
                XmlSerialization.SerializeToFile<Document>(document, tempFile);              
                string data = TripleDESEncryption.EncryptString(File.ReadAllText(tempFile), key);

                // Create backup if data changes
                string oldData = "";              
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
            string backupFile = "";
            do
            {
                count++;
                backupFile = string.Format("{0}.{1}{2}", Path.GetFileNameWithoutExtension(lockFile), count, Path.GetExtension(lockFile));
            } while (File.Exists(backupFile));

            File.Copy(lockFile, backupFile);
        }
    }
}
