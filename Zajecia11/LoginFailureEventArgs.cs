using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zajecia11
{
    public class LoginFailureEventArgs : EventArgs
    {
        public List<LoginError> Errors { get; set; }

        public class LoginError
        {
            public LoginFields Field { get; set; }
            public string ErrorMessage { get; set; }

            public enum LoginFields
            {
                Login,
                Password,
                All
            }
        }
    }
}
