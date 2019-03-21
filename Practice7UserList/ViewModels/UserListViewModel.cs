using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
        private ObservableCollection<Person> _users;
        private Person _person;
        private string _filtering;
        private int _index;
        private ObservableCollection<Person> _filterUsers;
        private bool _filterOrNot = false;

        private ICommand _deletePersonCommand;
        private ICommand _addUserCommand;
        private ICommand _saveDataCommand;
        private ICommand _filterCommand;
        private ICommand _showAllCommand;
        
        public ObservableCollection<Person> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }

        public int Index
        {
            get => _index;
            set
            {
                _index = value;
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

        internal UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }
        
        public ICommand DeletePersonCommand => _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand<object>(DeletePersonImplementation, CanExecuteCommand));
        public ICommand AddUserCommand => _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(AddUserImplementation));
        public ICommand SaveCommand => _saveDataCommand ?? (_saveDataCommand = new RelayCommand<object>(SaveImplementation));
        public ICommand FilterCommand => _filterCommand ?? (_filterCommand = new RelayCommand<object>(FilterImplementation));
        public ICommand ShowAllCommand => _showAllCommand ?? (_showAllCommand = new RelayCommand<object>(ShowAllImplementation));

        private void ShowAllImplementation(object obj)
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            UpdateData();
        }
        private void FilterImplementation(object obj)
        {
            FilterSwitch();
            StationManager.UpdateModel.UpdateData();
        }
        private void FilterSwitch()
        {
             _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _filterUsers = new ObservableCollection<Person>();
            switch (Index)
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
        }
        public void UpdateData()
        {
            _users = _filterOrNot
                ? _filterUsers
                : new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _filterOrNot = false;
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
      
        private bool CanExecuteCommand(object obj)
        {
            return _person != null;
        }

        private void DeletePersonImplementation(object obj)
        {
            MessageBox.Show($"Person {SelectedUser.Name} was successfully deleted");
            StationManager.DataStorage.DeleteUser(_person);
            StationManager.UpdateModel.UpdateData();
        }
      
        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
