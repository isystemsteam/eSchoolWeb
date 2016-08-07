using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class UserCreateModel : UserAccount
    {
        public List<Address> Addresses { get; set; }
    }
}
