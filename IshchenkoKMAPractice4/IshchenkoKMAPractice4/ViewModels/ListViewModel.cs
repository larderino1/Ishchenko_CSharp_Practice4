using System;
using System.Collections.ObjectModel;
using IshchenkoKMAPractice4.Models;
using IshchenkoKMAPractice4.Tools;
using IshchenkoKMAPractice4.Tools.Managers;
using IshchenkoKMAPractice4.Tools.Navigation;
using System.Linq;

namespace IshchenkoKMAPractice4.ViewModels
{
    internal class ListViewModel : Tools.BaseViewModel
    {
        private RelayCommand<object> _creationCommand;
        private ObservableCollection<Person> _persons;
        private bool _update;
        private RelayCommand<object> _removeCommand;
        private RelayCommand<object> _changeCommand;
        private RelayCommand<object> _closeCommand;
        private String _firstName;

        internal ListViewModel()
        {
            _persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
        }

        public ObservableCollection<Person> Persons
        {
            get => _persons;
            private set
            {
                _persons = value;
                OnPropertyChanged();
            }
        }

        public bool Update
        {
            get => _update;
            set
            {
                _update = value;
                Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                OnPropertyChanged();
            }
        }

        public String FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                if (!value.Equals(""))
                {
                    var selected = from t in StationManager.DataStorage.PersonsList
                        where t.FirstName.StartsWith(value)
                        orderby t
                        select t;
                    Persons = new ObservableCollection<Person>(selected);
                }
                else
                {
                    Persons = new ObservableCollection<Person>(StationManager.DataStorage.PersonsList);
                }
                OnPropertyChanged();
            }
        }

        public RelayCommand<object> CreationCommand
        {
            get
            {
                return _creationCommand = new RelayCommand<object>(p =>
                    {
                        NavigationManager.Instance.Navigate(ViewType.Input, "Create");
                    });
            }
        }

        public RelayCommand<object> CloseCommand
        {
            get { return _closeCommand = new RelayCommand<object>(p => { StationManager.CloseApp(); }); }
        }

        public RelayCommand<object> ChangeCommand
        {
            get
            {
                return _changeCommand = new RelayCommand<object>(p =>
                    {
                        NavigationManager.Instance.Navigate(ViewType.Edit, "Change");
                    });
            }
        }

        public RelayCommand<object> DeleteCommand
        {
            get
            {
                return _removeCommand = new RelayCommand<object>(p =>
                    {
                        NavigationManager.Instance.Navigate(ViewType.Edit, "Remove");
                    });
            }
        }
    }
}