using System;
namespace IvySchool.Domain.Models
{
    public class SignIn
    {
        public SignIn(int id,DateTime signInTime,string signinIp,int userId)
        {
            Id = id;
            SigninTime = signInTime;
            SigninIp = signinIp;
            UserId = userId;

            
        }
        public int Id { get; set; }
        public DateTime SigninTime { get; set; }
        public string SigninIp { get; set; }
        public int UserId { get; set; }
    }
}
