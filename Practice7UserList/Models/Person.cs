using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.CompilerServices;
using System.Windows;
using Practice7UserList.Tools;
using Practice7UserList.Tools.Interfaces;

namespace Practice7UserList
{
    [Serializable]
    internal class Person:INotifyPropertyChanged
    {
        #region Fields
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _birth;
        #endregion

        #region Properties
        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged();
            }

        }
        public string Surname
        {
            get => _surname;
            set
            {
                _surname = value;
                OnPropertyChanged();
            }
        }
        public string Email
        {
            get => _email;
            set
            {
                if (!new EmailAddressAttribute().IsValid(value))
                {
                    MessageBox.Show("not valid email");
                    return;
                }
                _email = value;

                OnPropertyChanged();
            }
        }
        public DateTime? Birth
        {
            get => _birth;
            set
            {
                _birth = value;
                OnPropertyChanged();
                OnPropertyChanged("SunSign");
                OnPropertyChanged("ChineseSign");
                OnPropertyChanged("IsAdult");
                OnPropertyChanged("IsBirthday");
                OnPropertyChanged("BirthdayShort");
            }
        }
        public string BirthdayShort
        {
            get { return _birth?.ToShortDateString(); }
        }
        public bool IsBirthday
        {
            get => CheckBirthday();
        }

        public string SunSign
        {
            get => WestHor();
        }

        public string ChineseSign
        {
            get => GiveChinaHoroscope(Birth);
        }

        public bool IsAdult
        {
            get => CalculateAge() >= 18;
        }
        #endregion

        #region Constructor

        public Person(string name, string surname, string email, DateTime birth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _birth = birth;
        }
        public Person(string name, string surname, string email)
        {
           
            _name = name;
            _surname = surname;
            _email = email;
        }
        public Person(string name, string surname, DateTime birth)
        {
            
            _name = name;
            _surname = surname;
            _birth = birth;
            _email = null;
        }
        #endregion
        #region Methods
        private int? CalculateAge()
        {
            DateTime today = Convert.ToDateTime(DateTime.Today);
            int? year = 0;
            if (Birth?.Month > today.Month || (today.Month == Birth?.Month && today.Day < Birth?.Day))
                year = today.Year - Birth?.Year - 1;
            else year = today.Year - Birth?.Year;
            return year;
        }
        //method that return West Horoscope
        private string WestHor()
        {
            if ((Birth?.Month == 3 && Birth?.Day >= 21) || (Birth?.Month == 4 && Birth?.Day <= 20))
                return "Aries";
            if ((Birth?.Month == 4 && Birth?.Day >= 21) || (Birth?.Month == 5 && Birth?.Day <= 21))
                return "Taurus";
            if ((Birth?.Month == 5 && Birth?.Day >= 22) || (Birth?.Month == 6 && Birth?.Day <= 21))
                return "Gemini";
            if ((Birth?.Month == 6 && Birth?.Day >= 22) || (Birth?.Month == 7 && Birth?.Day <= 22))
                return "Cancer";
            if ((Birth?.Month == 7 && Birth?.Day >= 23) || (Birth?.Month == 8 && Birth?.Day <= 21))
                return "Leo";
            if ((Birth?.Month == 8 && Birth?.Day >= 22) || (Birth?.Month == 9 && Birth?.Day <= 23))
                return "Virgo";
            if ((Birth?.Month == 9 && Birth?.Day >= 24) || (Birth?.Month == 10 && Birth?.Day <= 23))
                return "Libra";
            if ((Birth?.Month == 10 && Birth?.Day >= 24) || (Birth?.Month == 11 && Birth?.Day <= 22))
                return "Scorpio";
            if ((Birth?.Month == 11 && Birth?.Day >= 23) || (Birth?.Month == 12 && Birth?.Day <= 22))
                return "Sagittarius";
            if ((Birth?.Month == 12 && Birth?.Day >= 24) || (Birth?.Month == 1 && Birth?.Day <= 23))
                return "Capricorn";
            if ((Birth?.Month == 1 && Birth?.Day >= 21) || (Birth?.Month == 2 && Birth?.Day <= 19))
                return "Aquarius";
            if ((Birth?.Month == 2 && Birth?.Day >= 20) || (Birth?.Month == 3 && Birth?.Day <= 20))
                return "Pisces";
            return "sign";
        }
        private bool CheckBirthday()
        {
            DateTime today = Convert.ToDateTime(DateTime.Today);
            if (today.Month == Birth?.Month && today.Day == Birth?.Day)
                return true;
            return false;
        }

        public string GiveChinaHoroscope(DateTime? date)
        {
            if (date != null)
            {
                int? year = date?.Year % 12;

                return Enum.GetName(typeof(ViewChinaHoroscope), year);
            }
            return Enum.GetName(typeof(ViewChinaHoroscope), 0);
        }
        #endregion
        [field: NonSerialized]
        public event PropertyChangedEventHandler PropertyChanged;

       
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
