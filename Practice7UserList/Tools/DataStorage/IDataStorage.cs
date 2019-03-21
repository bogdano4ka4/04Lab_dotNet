using System.Collections.Generic;
using Practice7UserList.Models;

namespace Practice7UserList.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddUser(Person user);
        void DeleteUser(Person user);
        List<Person> UsersList { get; }
    }
}
