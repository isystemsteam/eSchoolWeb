using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public enum Privilege
    {
        All = 1,
        Create = 2,
        Edit = 3,
        View = 4,
        Delete = 5
    }

    public enum UserStatusEnum
    {
        Registered=1,
        Active=2,
        InActive=3,
        InActiveByAdmin=4,
        InActiveByTeacher=5,
        InActiveByGovernment=6,
        Invited=7,
        Suspended=8,
        Deferred=9
    }

    public enum StudentStatus
    {

    }
}
