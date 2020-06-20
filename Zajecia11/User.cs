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

        public string login { get; private set; }

        private string password { get; set; }

        public bool CheckLogin(string a, SecureString b)
        {
            string pwd = default(string);

            IntPtr pwdpointer = IntPtr.Zero;
            try
            {
                pwdpointer = Marshal.SecureStringToGlobalAllocUnicode(b);
                pwd = Marshal.PtrToStringUni(pwdpointer);
            }
            finally
            {

                Marshal.ZeroFreeGlobalAllocUnicode(pwdpointer);
            }
            return (login == a && password == pwd);
        }

        public User(string x, string y)
        {
            login = x;
            password = y;
        }
    }
}
