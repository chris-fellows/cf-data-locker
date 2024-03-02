﻿using CFDataLocker.Model;

namespace CFDataLocker.Interfaces
{
    /// <summary>
    /// Exports data items from data locker
    /// </summary>
    public interface IDataLockerExporter
    {
        void Export(DataLocker document);
    }
}
