using System;
namespace IvySchool.Domain.Responses
{
    public class SimpleResponseObject
    {
        private SimpleResponseObject(bool isSuccessful, string errorMessage)
        {
            IsSuccessful = isSuccessful;
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }
        public string ErrorMessage { get; }

        public static SimpleResponseObject Success()
        {
            return new SimpleResponseObject(true, null);
        }

        public static SimpleResponseObject Error(string message)
        {
            return new SimpleResponseObject(false, message);
        }
    }
}
