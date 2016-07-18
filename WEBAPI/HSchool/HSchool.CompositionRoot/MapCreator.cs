using AutoMapper;
using Bootstrap.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccount = HSchool.Business.Models.UserAccount;
using UserCredential = HSchool.Business.Models.UserCredential;
using StudentGuardian = HSchool.Business.Models.StudentGuardian;
using UserStatus = HSchool.Business.Models.UserStatusEnum;
using UserSecurity = HSchool.Business.Models.UserSecurity;
using Settings = HSchool.Business.Models.Settings;
using Classes = HSchool.Business.Models.Classes;
using Section = HSchool.Business.Models.Section;
using ClassSection = HSchool.Business.Models.ClassSection;
using CommunityMaster = HSchool.Business.Models.CommunityMaster;
using PasswordQuestions = HSchool.Business.Models.PasswordQuestions;
using ApplicationRole = HSchool.Business.Models.ApplicationRole;
using ApplicationModule = HSchool.Business.Models.ApplicationModule;
using RolePrivilege = HSchool.Business.Models.RolePrivilege;
using ApplicationPrivilege = HSchool.Business.Models.ApplicationPrivilege;
using StudentImage = HSchool.Business.Models.StudentImage;
using Student = HSchool.Business.Models.Student;
using ApplicationForm = HSchool.Business.Models.ApplicationForm;
using AcademicYear = HSchool.Business.Models.AcademicYear;

namespace HSchool.CompositionRoot
{
    public class MapCreator : IMapCreator
    {
        public void CreateMap(IProfileExpression mapper)
        {
            mapper.CreateMap<UserAccount, Data.Models.UserAccount>();
            mapper.CreateMap<Data.Models.UserAccount, UserAccount>();

            mapper.CreateMap<Student, Data.Models.Student>();
            mapper.CreateMap<Data.Models.Student, Student>();

            mapper.CreateMap<StudentGuardian, Data.Models.StudentGuardian>();
            mapper.CreateMap<Data.Models.StudentGuardian, StudentGuardian>();

            mapper.CreateMap<StudentImage, Data.Models.StudentImage>();
            mapper.CreateMap<Data.Models.StudentImage, StudentImage>();

            mapper.CreateMap<UserCredential, Data.Models.UserCredential>();
            mapper.CreateMap<Data.Models.UserCredential, UserCredential>();

            mapper.CreateMap<UserStatus, Data.Models.UserStatus>();
            mapper.CreateMap<Data.Models.UserStatus, UserStatus>();

            mapper.CreateMap<UserSecurity, Data.Models.UserSecurity>();
            mapper.CreateMap<Data.Models.UserSecurity, UserSecurity>();

            mapper.CreateMap<Settings, Data.Models.Settings>();
            mapper.CreateMap<Data.Models.Settings, Settings>();

            mapper.CreateMap<Classes, Data.Models.Classes>();
            mapper.CreateMap<Data.Models.Classes, Classes>();

            mapper.CreateMap<Section, Data.Models.Section>();
            mapper.CreateMap<Data.Models.Section, Section>();

            mapper.CreateMap<ClassSection, Data.Models.ClassSection>();
            mapper.CreateMap<Data.Models.ClassSection, ClassSection>();

            mapper.CreateMap<CommunityMaster, Data.Models.CommunityMaster>();
            mapper.CreateMap<Data.Models.CommunityMaster, CommunityMaster>();

            mapper.CreateMap<PasswordQuestions, Data.Models.PasswordQuestions>();
            mapper.CreateMap<Data.Models.PasswordQuestions, PasswordQuestions>();

            mapper.CreateMap<ApplicationRole, Data.Models.ApplicationRole>();
            mapper.CreateMap<Data.Models.ApplicationRole, ApplicationRole>();

            mapper.CreateMap<ApplicationModule, Data.Models.ApplicationModule>();
            mapper.CreateMap<Data.Models.ApplicationModule, ApplicationModule>();

            mapper.CreateMap<RolePrivilege, Data.Models.RolePrivilege>();
            mapper.CreateMap<Data.Models.RolePrivilege, RolePrivilege>();

            mapper.CreateMap<ApplicationPrivilege, Data.Models.ApplicationPrivilege>();
            mapper.CreateMap<Data.Models.ApplicationPrivilege, ApplicationPrivilege>();

            mapper.CreateMap<ApplicationForm, Data.Models.ApplicationForm>();
            mapper.CreateMap<Data.Models.ApplicationForm, ApplicationForm>();

            mapper.CreateMap<AcademicYear, Data.Models.AcademicYear>();
            mapper.CreateMap<Data.Models.AcademicYear, AcademicYear>();            
        }
    }
}
