using System;

namespace Authentication
{
    internal class User
    {
        private string FirstName;
        private string LastName;
        private string UserName;
        private string Password;
        public User(string fname, string lname, string username, string password)
        {
            FirstName = fname;
            LastName = lname;
            UserName = username;
            Password = password;
        }
        public string GetFirstName()
        {
            return FirstName;
        }
        public string GetLastName()
        {
            return LastName;
        }
        public string GetUserName()
        {
            return UserName;
        }
        public string GetPassword()
        {
            return Password;
        }
        public void SetLastName(string lname)
        {
            LastName = lname;
        }
        public void SetUserName(string username)
        {
            UserName = username;
        }
        public void SetPassword(string password)
        {
            Password = password;
        }
    }
}
