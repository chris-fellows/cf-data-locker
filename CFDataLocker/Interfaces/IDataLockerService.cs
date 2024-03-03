using CFDataLocker.Models;

namespace CFDataLocker.Interfaces
{
    /// <summary>
    /// Service for accessing data locker
    /// </summary>
    public interface IDataLockerService
    {
        /// <summary>
        /// Creates random key
        /// </summary>
        /// <returns></returns>
        string CreateRandomKey();

        /// <summary>
        /// Unlocks data locker with key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        DataLocker Unlock(string key);

        /// <summary>
        /// Locks data locker with key
        /// </summary>
        /// <param name="dataLocker"></param>
        /// <param name="key"></param>
        void Lock(DataLocker dataLocker, string key);
    }
}
