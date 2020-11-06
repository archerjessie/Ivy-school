using System;
namespace IvySchool.Data.Entities
{
    public class SigninHistoryDb
    {
        public int Id { get; set; }
        public DateTime SigninTime { get; set; }
        public string SigninIp { get; set; }
        public int userId { get; set; }
        public UserDb user { get; set; }

    }
}
