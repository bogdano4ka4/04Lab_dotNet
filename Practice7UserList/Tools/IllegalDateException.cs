using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice7UserList.Tools
{
    public class IllegalDateException : Exception
    {

        public IllegalDateException(string birth) :
            base($"Your date {birth} is incorrect.")
        {
        }


    }
}
