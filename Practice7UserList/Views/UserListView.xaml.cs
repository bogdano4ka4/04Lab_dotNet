
using System.Windows.Controls;
using Practice7UserList.Tools.Navigation;
using Practice7UserList.ViewModels;

namespace Practice7UserList.Views
{
    public partial class UserListView : UserControl, INavigatable
    {
        public UserListView()
        {
            InitializeComponent();
            DataContext = new UserListViewModel();
        }
    }
}
