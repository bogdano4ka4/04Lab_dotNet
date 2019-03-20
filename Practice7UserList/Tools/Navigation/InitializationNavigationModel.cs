using System;
using Practice7UserList.Views;
using SignUpView = Practice7UserList.Views.Authentication.SignUpView;

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
                case ViewType.AddUser:
                    ViewsDictionary.Add(viewType, new SignUpView());
                    break;
                case ViewType.UpdatePerson:
                    ViewsDictionary.Add(viewType, new UpdateView());
                    break;
                case ViewType.Main:
                    ViewsDictionary.Add(viewType, new MainView());
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(viewType), viewType, null);
            }
        }
    }
}
