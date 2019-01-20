using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System.Collections.Generic;

namespace SportApi.Models {

    public class Player {
        [Key]
        public int id { get; set; }
        public string name { get; set; }
        [ForeignKey("team")]
        public int team_id { get; set; }

        public Team team { get; set; }

        public List<PlayerStat> playerStats { get; set; }
    }
}