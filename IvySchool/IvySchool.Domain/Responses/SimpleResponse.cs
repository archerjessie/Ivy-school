using System;
namespace IvySchool.Domain.Responses
{
    public class SimpleResponse
    {
        protected SimpleResponse(bool isSuccessful)
        {
            IsSuccessful = isSuccessful;
        }

        protected SimpleResponse(bool isSuccessful, string errorMessage) : this(isSuccessful)
        {
            ErrorMessage = errorMessage;
        }

        public bool IsSuccessful { get; }
        public string ErrorMessage { get; }

        public static SimpleResponse Success()
        {
            return new SimpleResponse(true);
        }

        public static SimpleResponse Error(string message)
        {
            return new SimpleResponse(false, message);
        }
    }
}
