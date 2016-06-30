using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Data.Models
{
    public class Settings
    {

        public string SettingKey { get; set; }

        public string Value { get; set; }

        public int ApplicationName { get; set; }

        public bool IsActive { get; set; }

        public bool IsValueEncrypted { get; set; }
    }
}
