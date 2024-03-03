using CFDataLocker.Models;

namespace CFDataLocker.Interfaces
{
    /// <summary>
    /// Imports data items in to data locker
    /// </summary>
    public interface IDataLockerImporter
    {
        void Import(DataLocker document);
    }
}
