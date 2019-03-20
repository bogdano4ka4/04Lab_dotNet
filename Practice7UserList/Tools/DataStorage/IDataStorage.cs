using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7UserList.Tools.DataStorage
{
    internal interface IDataStorage
    {
        void AddUser(Person user);
        void DeleteUser(Person user);
        List<Person> UsersList { get; }
    }
}
