using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

using System.Collections.Generic;

namespace SportApi.Models
{
    public class Team
    {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        public string full_name { get; set; }
        public string abbrev { get; set; }

        [IgnoreDataMember]
        public List<Player> players { get; set; }
    }
}