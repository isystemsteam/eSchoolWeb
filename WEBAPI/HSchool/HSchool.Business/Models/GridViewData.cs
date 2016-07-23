using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HSchool.Business.Models
{
    public class GridViewTable
    {
        [JsonProperty("Columns")]
        public List<string> Columns { get; set; }

        [JsonProperty("Rows")]
        public List<GridViewRow> Rows { get; set; }

        [JsonProperty("TotalRows")]
        public int TotalRows { get; set; }

        [JsonProperty("TotalPages")]
        public int TotalPages { get; set; }

        [JsonProperty("PageSize")]
        public int PageSize { get; set; }

        [JsonProperty("TotalRecords")]
        public int TotalRecords { get; set; }

        [JsonProperty("ViewResultMessage")]
        public string ViewResultMessage { get; set; }
    }

    public class GridViewRow
    {
        [JsonProperty("Cells")]
        public List<GridViewCell> Cells { get; set; }

    }

    public class GridViewCell
    {
        [JsonProperty("Value")]
        public string Value { get; set; }

    }
}
