using AutoMapper;
using Bootstrap.AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserInfo = HSchool.Business.Models.UserInfo;
using UserCredential = HSchool.Business.Models.UserCredential;
using UserGuardian = HSchool.Business.Models.UserGuardian;
using UserStatus = HSchool.Business.Models.UserStatus;
using UserSecurity = HSchool.Business.Models.UserSecurity;
using Settings = HSchool.Business.Models.Settings;
using Classes = HSchool.Business.Models.Classes;
using Section = HSchool.Business.Models.Section;
using ClassSection = HSchool.Business.Models.ClassSection;
using CommunityMaster = HSchool.Business.Models.CommunityMaster;
using PasswordQuestions = HSchool.Business.Models.PasswordQuestions;
using ApplicationRole = HSchool.Business.Models.ApplicationRole;

namespace HSchool.CompositionRoot
{
    public class MapCreator : IMapCreator
    {
        public void CreateMap(IProfileExpression mapper)
        {
            mapper.CreateMap<UserInfo, Data.Models.UserInfo>();
            mapper.CreateMap<Data.Models.UserInfo, UserInfo>();

            mapper.CreateMap<UserGuardian, Data.Models.UserGuardian>();
            mapper.CreateMap<Data.Models.UserGuardian, UserGuardian>();

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

        }
    }
}
