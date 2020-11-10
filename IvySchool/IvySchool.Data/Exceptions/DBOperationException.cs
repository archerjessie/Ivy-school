using System;
namespace IvySchool.Data.Entities.Exceptions
{
    public class DBOperationException:Exception
    {
        public DBOperationException(Exception ex) : base($"db operation error: {ex.Message}", ex)
        {
        }
    }
}
