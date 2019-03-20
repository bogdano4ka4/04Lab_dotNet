﻿using System;
using System.Windows;
using Practice7UserList.Tools.DataStorage;

namespace Practice7UserList.Tools.Managers
{
    internal static class StationManager
    {
        public static event Action StopThreads;
        private static IDataStorage _dataStorage;

        internal static Person CurrentUser { get; set; }

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
            MessageBox.Show("ShutDown");
            StopThreads?.Invoke();
            Environment.Exit(1);
        }
    }
}
