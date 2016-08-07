using HSchool.Business.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Repository
{
    public interface ISectionRepository
    {
        int? SaveSections(Section section);

        List<Section> GetAllSections(bool isGetAll);

        Section GetSectionById(int sectionId);
    }
}
