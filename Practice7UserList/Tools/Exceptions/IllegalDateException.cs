using System;

namespace Practice7UserList.Tools.Exceptions
{
    public class IllegalDateException : Exception
    {

        public IllegalDateException(string birth) :
            base($"Your date {birth} is incorrect.")
        {
        }


    }
}
