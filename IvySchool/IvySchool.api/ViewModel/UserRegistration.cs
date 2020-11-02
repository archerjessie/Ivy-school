namespace IvySchool.api.ViewModel
{
    public class UserRegistration
    {
        public UserRegistration(string name,
            string email,
            string password,
            int roleId)
        {
            Name = name;
            Email = email;
            Password = password;
            RoleId = roleId;

        }

        public string Name { get; private set; }
        public string Email { get; private set; }
        public string Password { get; private set; }
        public int RoleId { get; private set;}
    }
}
