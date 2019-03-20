using System.Windows;
using System.Windows.Input;
using Practice7UserList.Tools;
using Practice7UserList.Tools.Managers;
using Practice7UserList.Tools.Navigation;

namespace Practice7UserList.ViewModels
{
    internal class MainViewModel : BaseViewModel
    {
       
        private Visibility _menuVisibility = Visibility.Collapsed;
        private ICommand _showMenuCommand;
        private ICommand _closeCommand;

        public string CurrentUser => $"Current User: {StationManager.CurrentUser}";

       

        public Visibility MenuVisibility
        {
            get { return _menuVisibility; }
            private set
            {
                _menuVisibility = value;
                OnPropertyChanged();
            }
        }

        public ICommand ShowMenuCommand
        {
            get { return _showMenuCommand ?? (_showMenuCommand = new RelayCommand<object>(ShowMenuImplementation)); }
        }
       
        public ICommand CloseCommand
        {
            get { return _closeCommand ?? (_closeCommand = new RelayCommand<object>(CloseImplementation)); }
        }

        private void ShowMenuImplementation(object obj)
        {
            MenuVisibility = _menuVisibility == Visibility.Visible ? Visibility.Collapsed : Visibility.Visible;
        }
        

        private void CloseImplementation(object obj)
        {
            StationManager.CloseApp();
        }
    }
}
