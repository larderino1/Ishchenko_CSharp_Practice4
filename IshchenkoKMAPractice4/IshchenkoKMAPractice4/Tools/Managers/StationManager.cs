using System;
using System.Windows;
using IshchenkoKMAPractice4.Tools.Storage;

namespace IshchenkoKMAPractice4.Tools.Managers
{
    internal static class StationManager
    {

        private static IDataStorage _dataStorage;

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
            Environment.Exit(1);
        }
    }
}