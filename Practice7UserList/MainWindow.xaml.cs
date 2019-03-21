using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using Practice7UserList.Tools.DataStorage;
using Practice7UserList.Tools.Managers;
using Practice7UserList.Tools.Navigation;
using Practice7UserList.ViewModels;

namespace Practice7UserList
{
    
    public partial class MainWindow : Window, IContentOwner
    {
        public ContentControl ContentControl
        {
            get { return _contentControl; }
        }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
            InitializeApplication();
        }

        private void InitializeApplication()
        {
            StationManager.Initialize(new SerializedDataStorage());
            NavigationManager.Instance.Initialize(new InitializationNavigationModel(this));
            NavigationManager.Instance.Navigate(ViewType.Main);
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            ((SerializedDataStorage)StationManager.DataStorage).SaveChanges();
            StationManager.CloseApp();
        }
    }
}
