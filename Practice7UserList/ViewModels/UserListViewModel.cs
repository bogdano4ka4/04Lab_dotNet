using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using Practice7UserList.Annotations;
using Practice7UserList.Tools;
using Practice7UserList.Tools.Managers;
using Practice7UserList.Tools.Navigation;

namespace Practice7UserList.ViewModels
{
    class UserListViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<Person> _users;
        private Person _person;
        private ICommand _deletePersonCommand;
        private ICommand _addUserCommand;

        public ObservableCollection<Person> Users
        {
            get => _users;
            private set
            {
                _users = value;
                OnPropertyChanged();
            }
        }
        public Person SelectedUser
        {
            get => _person;
            set => _person = value;
        }
        internal UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
        }

        public ICommand DeletePersonCommand
        {
            get { return _deletePersonCommand ?? (_deletePersonCommand = new RelayCommand<object>(DeletePersonImplementation, CanExecuteCommand)); }
        }

        public ICommand AddUserCommand
        {
            get { return _addUserCommand ?? (_addUserCommand = new RelayCommand<object>(AddUserImplementation)); }
        }
        private void AddUserImplementation(object obj)
        {

            LoaderManager.Instance.ShowLoader();
            NavigationManager.Instance.Navigate(ViewType.AddUser);
            Thread.Sleep(500);
            LoaderManager.Instance.HideLoader();
            UpdateData(obj);
        }

        private bool CanExecuteCommand(object obj)
        {
            return _person != null;
        }


        private void DeletePersonImplementation(object obj)
        {
            MessageBox.Show($"Person {SelectedUser.Name} was successfully deleted");
            StationManager.DataStorage.DeleteUser(_person);
            UpdateData(obj);
        }

        private void UpdateData(object obj)
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            OnPropertyChanged("Users");
        }



        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
