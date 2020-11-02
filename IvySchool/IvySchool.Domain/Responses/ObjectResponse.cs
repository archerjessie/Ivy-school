using System;
namespace IvySchool.Domain.Responses
{
    public class ObjectResponse<T> : SimpleResponse
    {
        protected ObjectResponse(bool isSuccessful, string errorMessage, T responseObject)
            : base(isSuccessful, errorMessage)
        {
            ResponseObject = responseObject;
        }

        protected ObjectResponse(bool isSuccessful, string errorMessage) : base(isSuccessful, errorMessage)
        {
        }

        public T ResponseObject { get; private set; }

        public static new ObjectResponse<T> Error(string message)
        {
            return new ObjectResponse<T>(false, message);
        }

        public static ObjectResponse<T> Success(T responseObject)
        {
            return new ObjectResponse<T>(true, null, responseObject);
        }
    }
}
