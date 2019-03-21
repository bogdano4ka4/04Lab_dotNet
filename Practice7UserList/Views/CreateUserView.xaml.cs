using System.Windows.Controls;
using Practice7UserList.Tools.Navigation;
using Practice7UserList.ViewModels;

namespace Practice7UserList.Views.Authentication
{
    public partial class AddPersonView : UserControl, INavigatable
    {
        internal AddPersonView()
        {
            InitializeComponent();
            DataContext = new CreateUserViewModel();
        }

    }
}
