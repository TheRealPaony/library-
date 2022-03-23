using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet
{
    class User
    {
        private String login;
        public int id;
        private String password;
        private static int cmp = 0;

        public User() { }
        private User(String login , String password)
        {
            this.login = login;
            this.password = password;
            this.id = ++cmp;


        }

    }
}
