﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class UserCredential
    {
        public string UserName { get; set; }

        public string Password { get; set; }

        public int UserRole { get; set; }
    }
}
