using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Taxopark
{
    class User
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public User(string login, string password)
        {
            Login = login;
            Password = password;
        }

    }
}
