using System;
using System.Runtime.Serialization;

namespace Assignment3
{
    public class NotValidNameException : Exception
    {
       
        public NotValidNameException() : base("Not a valid name, please try again!")
        {
            
        }

       
    }
}
