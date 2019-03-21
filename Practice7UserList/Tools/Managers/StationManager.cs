using System;
using Practice7UserList.Tools.DataStorage;
using Practice7UserList.ViewModels;

namespace Practice7UserList.Tools.Managers
{
    internal static class StationManager
    {
        private static IDataStorage _dataStorage;
        internal static UserListViewModel UpdateModel { get; set; }

        internal static IDataStorage DataStorage
        {
            get { return _dataStorage; }
        }

        internal static void Initialize(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
        
        internal static void CloseApp()
        {
            Environment.Exit(1);
        }
    }
}
