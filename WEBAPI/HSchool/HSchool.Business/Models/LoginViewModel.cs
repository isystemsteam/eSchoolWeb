﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class LoginViewModel : UserCredential
    {
        public string ReturnUrl { get; set; }
    }
}
