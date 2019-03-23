using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using IshchenkoKMAPcractice4.Exceptions;
using IshchenkoKMAPractice4.Exceptions;

namespace IshchenkoKMAPractice4.Models
{
    [Serializable]
    public class Person
    {
        private string _firstName;
        private string _lastName;
        private string _email;
        private DateTime _birthDate = DateTime.Today;
        private readonly bool _isAdult;
        private readonly string _sunSign;
        private readonly string _chinaSign;
        private readonly bool _isBirthday;
        private readonly string[] _zodiak = new string[]
        {
            "Rat", "Ox", "Tiger", "Rabbit", "Dragon", "Snake", "Horse", "Goat", "Monkey", "Rooster", "Dog", "Pig"
        };
        private readonly string[] _horoscope = new string[]
        {
            "Козерог", "Водолей", "Рыбы", "Овен", "Телец", "Близнецы", "Рак", "Лев", "Дева", "Весы", "Скорпион", "Стрелец"
        };

        public string FirstName
        {
            get => _firstName;
            set
            {
                _firstName = value;
                OnPropertyChanged("FirstName");
            }
        }

        public string LastName
        {
            get => _lastName;
            set
            {
                _lastName = value;
                OnPropertyChanged("LastName");
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                _email = value;
                OnPropertyChanged("Email");
            }
        }

        public DateTime BirthDate
        {
            get => _birthDate;
            set
            {
                _birthDate = value;
                OnPropertyChanged("BirthDate");
            }
        }

        public bool IsAdult => _isAdult;

        public string SunSign => _sunSign;

        public string ChinaSign => _chinaSign;

        public bool IsBirthday => _isBirthday;

        public Person(string firstName, string lastName, string email, DateTime birthDate)
        {
            BirthCheck(birthDate);
            EmailCheck(email);
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            BirthDate = birthDate;
            _isAdult = CheckAdult();
            _sunSign = CheckSunSign();
            _chinaSign = CheckChinaSign();
            _isBirthday = CheckBirthdaySelebrate();
        }

        public Person(string firstName, string lastName, string email) : this(firstName, lastName, email,
            DateTime.Today){}
        public Person(string firstName, string lastName, DateTime birthDate) : this(firstName, lastName, "", DateTime.Today){}
        public Person(){}
        private bool CheckBirthdaySelebrate()
        {
            if (DateTime.Today.Month == BirthDate.Month && DateTime.Today.Day == BirthDate.Day)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //need testing
        private string CheckChinaSign()
        {
            int zodiacCount = BirthDate.Year - 4;
            string zodiacSign = _zodiak[zodiacCount % 12];
            return zodiacSign;
        }

        private string CheckSunSign()
        {
            int month = BirthDate.Month;
            int day = BirthDate.Day;
            switch (month)
            {
                case 1:
                    return day < 20 ? _horoscope[0] : _horoscope[1];
                case 2:
                    return day < 19 ? _horoscope[1] : _horoscope[2];
                case 3:
                    return day < 21 ? _horoscope[2] : _horoscope[3];
                case 4:
                    return day < 21 ? _horoscope[3] : _horoscope[4];
                case 5 :
                    return day < 21 ? _horoscope[4] : _horoscope[5];
                case 6 :
                    return day < 21 ? _horoscope[5] : _horoscope[6];
                case 7 :
                    return day < 23 ? _horoscope[6] : _horoscope[7];
                case 8 :
                    return day < 23 ? _horoscope[7] : _horoscope[8];
                case 9 :
                    return day < 24 ? _horoscope[8] : _horoscope[9];
                case 10 :
                    return day < 24 ? _horoscope[9] : _horoscope[10];
                case 11 :
                    return day < 22 ? _horoscope[10] : _horoscope[11];
                case 12 :
                    return day < 22 ? _horoscope[11] : _horoscope[0];
                default :
                    return _horoscope[0];
                    
            }
        }

        private bool CheckAdult()
        {
            int age = DateTime.Today.Year - BirthDate.Year;
            if (age < 18) return false;

            return true;
        }

        private void EmailCheck(string email)
        {
            if (!new EmailAddressAttribute().IsValid(email))
            {
                throw new IllegalEmailFormatException();
            }
        }

        private void BirthCheck(DateTime birthDate)
        {
            int age = DateTime.Today.Year - birthDate.Year;
            if (birthDate > DateTime.Today)
            {
               throw new WrongDateTimeException();
            }
            else if (age > 135)
            {
                throw new WrongDateTimeException();
            }
        }
        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
    }
}