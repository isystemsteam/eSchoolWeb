using HSchool.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business
{
    public class AuthenticationForm
    {
        public static bool ValidateUser()
        {
            LogHelper.Info(string.Format("AuthenticationForm.ValidateUser - Begin"));

            LogHelper.Info(string.Format("AuthenticationForm.ValidateUser - End"));
            return true;
        }
    }
}
