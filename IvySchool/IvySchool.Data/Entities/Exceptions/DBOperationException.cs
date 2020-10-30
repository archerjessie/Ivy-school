using System;
namespace IvySchool.Data.Entities.Exceptions
{
    public class DBOperationException:Exception
    {
        public DBOperationException(Exception ex) : base("error occured when try to add vehicle to database.", ex)
        {
        }
    }
}
