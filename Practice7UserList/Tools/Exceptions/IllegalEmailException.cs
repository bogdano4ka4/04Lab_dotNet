using System;

namespace Practice7UserList.Tools.Exceptions
{
    public class IllegalEmailException : Exception
    {

        public IllegalEmailException(string email)
            : base($"Your email {email} is not valid.")
        {
        }
    }
}
