
namespace Practice7UserList.Tools.Navigation
{
    internal enum ViewType
    {
        AddUser,
        Main
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
