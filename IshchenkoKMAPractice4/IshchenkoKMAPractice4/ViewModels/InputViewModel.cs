using System;
using System.Threading.Tasks;
using System.Windows;
using IshchenkoKMAPractice4.Exceptions;
using IshchenkoKMAPractice4.Models;
using IshchenkoKMAPractice4.Tools;
using IshchenkoKMAPractice4.Tools.Managers;
using IshchenkoKMAPractice4.Tools.Navigation;

namespace IshchenkoKMAPractice4.ViewModels
{
    public class InputViewModel : BaseViewModel
    {
        private RelayCommand<object> _closeCommand;
        private Person _person;
        private RelayCommand<object> _proceed;
        private String _buttonName;
        private Person _currPerson;

        public InputViewModel()
        {
            _person = new Person();
        }

        private Person CurrentPerson
        {
            get => _currPerson;
            set => _currPerson = value;
        }

        public string ButtonName
        {
            get => _buttonName;
            set
            {
                _buttonName = value;
                OnPropertyChanged();
            }
        }

        public Person Person
        {
            get => _person;
            set
            {
                _person = value;
                CurrentPerson = new Person(_person.FirstName, _person.LastName, _person.Email, _person.BirthDate);
                OnPropertyChanged("Person");
            }
        }

        public RelayCommand<object> ProceedCommand
        {
            get => _proceed = new RelayCommand<object>(p => ProceedImplementation());
        }

        private async void ProceedImplementation()
        {
            LoaderManager.Instance.ShowLoader();
            Person person = new Person();
            try
            {
                await Task.Run(() =>
                {
                    if (ButtonName == "Create")
                    {
                        person = new Person(_person.FirstName, _person.LastName, _person.Email, _person.BirthDate);
                        if (StationManager.DataStorage.PersonExists(person.Email))
                            throw new ExistingUserException();


                        if (person.IsBirthday)
                        {
                            MessageBox.Show("Congratulations!!!");
                        }

                        StationManager.DataStorage.AddPerson(person);
                        MessageBox.Show("Creation was Successful");

                    }
                    else if (ButtonName == "Change")
                    {
                        person = new Person(_person.FirstName, _person.LastName, _person.Email, _person.BirthDate);
                        if (StationManager.DataStorage.PersonExists(person.Email) &&
                            !person.FirstName.Equals(CurrentPerson.Email))
                        {
                            throw new ExistingUserException();
                        }

                        if (person.IsBirthday)
                        {
                            MessageBox.Show("Congratulations!!!");
                        }

                        StationManager.DataStorage.RemovePerson(
                            StationManager.DataStorage.GetPersonByEmail(CurrentPerson.Email));
                        StationManager.DataStorage.AddPerson(person);
                        MessageBox.Show("Editing was successful");
                    }
                });
                NavigationManager.Instance.Navigate(ViewType.Main, true);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            LoaderManager.Instance.HideLoader();
        }

        public RelayCommand<object> CloseCommand => _closeCommand = new RelayCommand<object>(p => NavigationManager.Instance.Navigate(ViewType.Main));
    }
}