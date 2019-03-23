using System;
using IshchenkoKMAPractice4.Models;

namespace IshchenkoKMAPractice4.Tools.Navigation
{
    internal enum ViewType
    {
        Input,
        Main,
        Edit
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
        void Navigate(ViewType viewType, bool refresh);
        void Navigate(ViewType viewType, String buttonName);
        void Navigate(ViewType viewType, Person person);
    }
}