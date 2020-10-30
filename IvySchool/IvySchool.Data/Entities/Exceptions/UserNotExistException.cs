using System;
using Microsoft.EntityFrameworkCore;

namespace IvySchool.Data.Entities.Exceptions
{
    public class UserNotExistException:Exception
    {
        public UserNotExistException(DbUpdateConcurrencyException updateConcurrencyException) : base("Vehicle not exist.", updateConcurrencyException)
        {
        }
    }
}
