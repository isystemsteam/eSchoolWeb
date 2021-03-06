﻿using HSchool.Business.Repository;
using HSchool.Data.SqlRepository;
using Microsoft.Practices.Unity;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.CompositionRoot
{
    public class DependencyMapper : NinjectModule
    {
        public override void Load()
        {
            Bind<IUserRepository>().To<UserRepository>();
            Bind<IAdminRepository>().To<AdminRepository>();
            Bind<IStudentRepository>().To<StudentRepository>();
            Bind<IApplicationRepository>().To<ApplicationRepository>();
            Bind<IRolePrivilegeRepository>().To<RolePrivilegeRepository>();
            Bind<IClassRepository>().To<ClassRepository>();
            Bind<ISectionRepository>().To<SectionRepository>();
        }

        //public static IUnityContainer BuildUnityContainer()
        //{
        //    var container = new UnityContainer();
        //    container.RegisterType<IUserRepository, UserRepository>();
        //    container.RegisterType<IAdminRepository, AdminRepository>();
        //    return container;
        //}
    }
}
