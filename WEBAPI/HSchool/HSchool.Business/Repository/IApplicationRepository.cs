﻿using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface IApplicationRepository
    {
        int? SaveApplication(ApplicationForm form);

        List<ApplicationForm> GetApplications(ApplicationFormSearch formSearch);

        ApplicationForm GetApplicationById(int id);
    }
}
