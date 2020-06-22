using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia11
{
    class User
    {

        public string Login { get; private set; }
        private string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }
        public bool CheckLogin(string login, SecureString password)
        {
            return (Login == login && password.ToString() == Password);
        }
    }
}

