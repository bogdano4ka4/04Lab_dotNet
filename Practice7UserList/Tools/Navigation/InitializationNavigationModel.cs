using System;
using Practice7UserList.Views;
using Practice7UserList.Views.Authentication;

namespace Practice7UserList.Tools.Navigation
{
    internal class InitializationNavigationModel : BaseNavigationModel
    {
        public InitializationNavigationModel(IContentOwner contentOwner) : base(contentOwner)
        {

        }

        protected override void InitializeView(ViewType viewType)
        {
            switch (viewType)
            {
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainView());
                    break;
                case ViewType.AddUser:
                    ViewsDictionary.Add(viewType, new AddPersonView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
