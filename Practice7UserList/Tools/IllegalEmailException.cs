using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7UserList.Tools
{
    public class IllegalEmailException : Exception
    {

        public IllegalEmailException(string email)
            : base($"Your email {email} is not valid.")
        {
        }
    }
}
