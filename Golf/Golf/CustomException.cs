using System;
using System.Runtime.Serialization;

namespace Golf
{
    [Serializable]
    internal class CustomException : Exception
    {
        public CustomException()
        {
        }

        public CustomException(string message) : base(message)
        {
        }
             
    }
}