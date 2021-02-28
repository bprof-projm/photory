using System;

namespace PhotoryModels
{

    public enum UserAccess 
    {
        RegularUser,GroupAdmin,Admin
    }

    public class User
    {
        public string Email { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public DateTime BirthDate { get; set; }

        public string Password { get; set; }

        public UserAccess UserAccess { get; set; }


    }
}
