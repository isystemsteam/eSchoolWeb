using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class ClassSection
    {
        [JsonProperty("classSectionId")]
        public int ClassSectionId { get; set; }

        [JsonProperty("classId")]
        [DisplayName("Class")]
        public int ClassId { get; set; }

        [DisplayName("Section")]
        [JsonProperty("sectionId")]
        public int SectionId { get; set; }

        [DisplayName("Is Active")]
        [JsonProperty("isActive")]
        public bool IsActive { get; set; }

        [DisplayName("Is Deleted")]
        [JsonProperty("isDeleted")]
        public bool IsDeleted { get; set; }

        public string ClassName { get; set; }

        public string SectionName { get; set; }

        public int RowNumber { get; set; }

    }
}
