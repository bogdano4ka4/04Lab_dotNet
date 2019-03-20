using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading;
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
        private Thread _workingThread;
        private CancellationToken _token;
        private CancellationTokenSource _tokenSource;
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
            set
            {
                _person = value; 
                OnPropertyChanged();
            }
        }
        internal UserListViewModel()
        {
            _users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
            _tokenSource = new CancellationTokenSource();
            _token = _tokenSource.Token;
            StartWorkingThread();
            StationManager.StopThreads += StopWorkingThread;
        }
        private void StartWorkingThread()
        {
            _workingThread = new Thread(WorkingThreadProcess);
            _workingThread.Start();
        }

        private void WorkingThreadProcess()
        {
            int i = 0;
            while (!_token.IsCancellationRequested)
            {
                var users = _users.ToList();
                Users = new ObservableCollection<Person>(StationManager.DataStorage.UsersList);
                for (int j = 0; j < 3; j++)
                {
                    Thread.Sleep(500);
                    if (_token.IsCancellationRequested)
                        break;
                }
                if (_token.IsCancellationRequested)
                    break;
                for (int j = 0; j < 10; j++)
                {
                    Thread.Sleep(500);
                    if (_token.IsCancellationRequested)
                        break;
                }
                if (_token.IsCancellationRequested)
                    break;
                i++;
            }
        }
        internal void StopWorkingThread()
        {
            _tokenSource.Cancel();
            _workingThread.Join(2000);
            _workingThread.Abort();
            _workingThread = null;
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
            UpdateData();
        }

        private void UpdateData()
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
