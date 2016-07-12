using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class UserSecurity
    {
        public int UserId { get; set; }

        public string SecurityKey { get; set; }

        public string Password { get; set; }        

        public string PasswordFormat { get; set; }

        public int PasswordQuestion { get; set; }

        public string PasswordAnswer { get; set; }        
    }
}
