using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;
using Practice7UserList.Annotations;
using Practice7UserList.Models;
using Practice7UserList.Tools;
using Practice7UserList.Tools.DataStorage;
using Practice7UserList.Tools.Managers;
using Practice7UserList.Tools.Navigation;

namespace Practice7UserList.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {
        #region Fields  
        private ObservableCollection<Person> _users;
        private Person _person;
        private string _filtering;
        private int _filterIndex;
        private int _sortIndex;
        private ObservableCollection<Person> _filterUsers;
        private ObservableCollection<Person> _sortedUsers;
        private bool _filterOrNot = false;
        private bool _sortOrNot = false;
        private ICommand _deletePersonCommand;
        private ICommand _addUserCommand;
        private ICommand _saveDataCommand;
        private ICommand _filterCommand;
        private ICommand _sortCommand;
        private ICommand _showAllCommand;
        #endregion

        #region Properties
        public ObservableCollection<Person> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public int FilterIndex
        {
            get => _filterIndex;
            set
            {
                _filterIndex = value;
                OnPropertyChanged();
            }
        }
        public int SortIndex
        {
            get => _sortIndex;
            set
            {
                _sortIndex = value;
                OnPropertyChanged();
            }
        }

        public Person SelectedUser
        {
            get => _person;
            set
            {
                _person = value;
                OnPropertyChanged();
            }
        }
        public string Filtering
        {
            get => _filtering;
            set
            {
                _filtering = value;
                OnPropertyChanged();
            }
        }
        #endregion

        internal UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }
        #region Fields
        public ICommand DeletePersonCommand => _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand<object>(DeletePersonImplementation, CanExecuteCommand));
        public ICommand AddUserCommand => _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(AddUserImplementation));
        public ICommand SaveCommand => _saveDataCommand ?? (_saveDataCommand = new RelayCommand<object>(SaveImplementation));
        public ICommand FilterCommand => _filterCommand ?? (_filterCommand = new RelayCommand<object>(FilterImplementation));
        public ICommand SortCommand => _sortCommand ?? (_sortCommand = new RelayCommand<object>(SortImplementation));
        public ICommand ShowAllCommand => _showAllCommand ?? (_showAllCommand = new RelayCommand<object>(ShowAllImplementation));
        #endregion

        #region Implementations
        private void ShowAllImplementation(object obj)
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            UpdateData();
        }
        private void FilterImplementation(object obj)
        {
             _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _filterUsers = new ObservableCollection<Person>();
            switch (FilterIndex)
            {
                case 0:
                    foreach (var per in _users)
                    if (String.Equals(per.Name, Filtering, StringComparison.CurrentCultureIgnoreCase))
                         _filterUsers.Add(per);
                    break;

                case 1:
                    foreach (var per in _users)
                        if (String.Equals(per.Surname, Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 2:
                    foreach (var per in _users)
                        if (String.Equals(per.Email, Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 3:
                    foreach (var per in _users)
                        if (String.Equals(per.BirthdayShort, Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 4:
                    foreach (var per in _users)
                        if (String.Equals(per.IsAdult.ToString(), Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 5:
                    foreach (var per in _users)
                        if (String.Equals(per.SunSign, Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 6:
                    foreach (var per in _users)
                        if (String.Equals(per.ChineseSign, Filtering, StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
                case 7:
                    foreach (var per in _users)
                        if (String.Equals(per.IsBirthday.ToString(), Filtering,
                            StringComparison.CurrentCultureIgnoreCase))
                            _filterUsers.Add(per);
                    break;
            }
           _users=new ObservableCollection<Person>(_filterUsers);
           _filterOrNot = true;
           UpdateData();
        }
        
        private void SortImplementation(object obj)
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _sortedUsers = new ObservableCollection<Person>();
            switch (SortIndex)
            {
                case 0:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.Name));
                    break;
                case 1:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.Surname));
                    break;
                case 2:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.Email));
                    break;
                case 3:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.Birth));
                    break;
                case 4:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.IsAdult));
                    break;
                case 5:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.SunSign));
                    break;
                case 6:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.ChineseSign));
                    break;
                case 7:
                    _sortedUsers = new ObservableCollection<Person>(_users.OrderBy(i => i.IsBirthday));
                    break;
            }
            _users = new ObservableCollection<Person>(_sortedUsers);
            _sortOrNot = true;
            UpdateData();
        }

        public void UpdateData()
        {
            if (_filterOrNot)
                _users = _filterUsers;
            else
                _users = _sortOrNot ? _sortedUsers : new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            
            _filterOrNot = false;
            _sortOrNot = false;
            OnPropertyChanged("Users");
        }

        private void SaveImplementation(object obj)
        {
            ((SerializedDataStorage)StationManager.DataStorage).SaveChanges();
        }
        
        private void AddUserImplementation(object obj)
        {
            NavigationManager.Instance.Navigate(ViewType.AddUser);
        }
        private void DeletePersonImplementation(object obj)
        {
            MessageBox.Show($"Person {SelectedUser.Name} was successfully deleted");
            StationManager.DataStorage.DeleteUser(_person);
            StationManager.UpdateModel.UpdateData();
        }
        #endregion
        private bool CanExecuteCommand(object obj)
        {
            return _person != null;
        }

       
      
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
