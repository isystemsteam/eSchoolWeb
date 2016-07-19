using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class UserRelationship
    {
        public int RelationshipId { get; set; }

        public string Name { get; set; }

        public bool IsActive { get; set; }
    }
}
