using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia11
{
    public class LoginEventArgs : EventArgs
    {
        public string Login { get; set; }
        public SecureString Password { get; set; }

        public LoginEventArgs(string login, SecureString password)
        {
            Login = login;
            Password = password;
        }
    }
}
