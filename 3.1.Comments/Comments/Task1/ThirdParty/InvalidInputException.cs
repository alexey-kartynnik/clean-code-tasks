using System;

namespace Comments.Task1.ThirdParty
{
    [Serializable]
    public class InvalidInputException : Exception
    {
        public InvalidInputException(string message) : base(message)
        {
        }
    }
}
