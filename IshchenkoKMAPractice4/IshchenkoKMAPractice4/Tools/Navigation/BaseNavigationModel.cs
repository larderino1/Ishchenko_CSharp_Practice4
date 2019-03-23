using System;
using System.Collections.Generic;
using IshchenkoKMAPractice4.Models;
using IshchenkoKMAPractice4.ViewModels;
using IshchenkoKMAPractice4.Views;
using IshchenkoKMAPractice4.Tools.Navigation;

namespace IshchenkoKMAPractice4.Tools.Navigation
{
    internal abstract class BaseNavigationModel : INavigationModel
    {
        private readonly IContentOwner _contentOwner;
        private readonly Dictionary<ViewType, INavigatable> _viewsDictionary;

        protected BaseNavigationModel(IContentOwner contentOwner)
        {
            _contentOwner = contentOwner;
            _viewsDictionary = new Dictionary<ViewType, INavigatable>();
        }

        protected IContentOwner ContentOwner
        {
            get { return _contentOwner; }
        }

        protected Dictionary<ViewType, INavigatable> ViewsDictionary
        {
            get { return _viewsDictionary; }
        }

        public void Navigate(ViewType viewType)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
        }


        public void Navigate(ViewType viewType, bool update)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];
            ListView tempView = (ListView) ViewsDictionary[viewType];
            ListViewModel tempModel = (ListViewModel) tempView.DataContext;
            tempModel.Update = update;
        }

        public void Navigate(ViewType viewType, String buttonName)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];

            if (viewType == ViewType.Input)
            {
                InputView tempView = (InputView) ViewsDictionary[viewType];
                InputViewModel tempModel = (InputViewModel) tempView.DataContext;
                tempModel.ButtonName = buttonName;
            }
            else if (viewType == ViewType.Edit)
            {
                EditView tempView = (EditView) ViewsDictionary[viewType];
                EditViewModel tempModel = (EditViewModel) tempView.DataContext;
                tempModel.ButtonName = buttonName;
            }
        }

        public void Navigate(ViewType viewType, Person person)
        {
            if (!ViewsDictionary.ContainsKey(viewType))
                InitializeView(viewType);
            ContentOwner.ContentControl.Content = ViewsDictionary[viewType];

            InputView tempView = (InputView) ViewsDictionary[viewType];
            InputViewModel tempModel = (InputViewModel) tempView.DataContext;
            tempModel.ButtonName = "Change";
            tempModel.Person = new Person(person.FirstName, person.LastName, person.Email, person.BirthDate);
            ;
        }

        protected abstract void InitializeView(ViewType viewType);

    }
}
