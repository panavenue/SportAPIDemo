using System.Collections.Generic;

namespace SportApi.Models
{
    public class Team
    {
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string abbrev { get; set; }
    }
}