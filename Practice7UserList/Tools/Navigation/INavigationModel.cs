using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7UserList.Tools.Navigation
{
    internal enum ViewType
    {
        AddUser,
        Main,
        UpdatePerson
    }

    interface INavigationModel
    {
        void Navigate(ViewType viewType);
    }
}
