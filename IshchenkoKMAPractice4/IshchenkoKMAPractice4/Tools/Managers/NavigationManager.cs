using System;
using IshchenkoKMAPractice4.Models;
using IshchenkoKMAPractice4.Tools.Navigation;

namespace IshchenkoKMAPractice4.Tools.Managers
{
    internal class NavigationManager
    {
        private static readonly object Locker = new object();
        private static NavigationManager _instance;

        internal static NavigationManager Instance
        {
            get
            {
                if (_instance != null)
                    return _instance;
                lock (Locker)
                {
                    return _instance ?? (_instance = new NavigationManager());
                }
            }
        }

        private INavigationModel _navigationModel;

        private NavigationManager()
        {

        }

        internal void Initialize(INavigationModel navigationModel)
        {
            _navigationModel = navigationModel;
        }

        internal void Navigate(ViewType viewType)
        {
            _navigationModel.Navigate(viewType);
        }

        internal void Navigate(ViewType viewType, bool refresh)
        {
            _navigationModel.Navigate(viewType, refresh);
        }

        internal void Navigate(ViewType viewType, String buttonName)
        {
            _navigationModel.Navigate(viewType, buttonName);
        }

        internal void Navigate(ViewType viewType, Person person)
        {
            _navigationModel.Navigate(viewType, person);
        }

    }
}