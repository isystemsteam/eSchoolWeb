using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IUserRepository
    {
        bool ValidateUser(UserCredential credential);

        UserInfo GetUserDetailsById(int userId);

        int InsertUpdateUser(UserInfo userInfo);
    }
}
