﻿using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IClassRepository
    {
        int SaveClassSectionTeacher(ClassSectionTeacher csTeacher);
    }
}
