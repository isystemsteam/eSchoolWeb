﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Authentication.Models
{
    public class LoginException : Exception
    {
        public LoginException(string message)
            : base(message)
        {

        }
    }
}
