using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;
using System;

namespace SportApi.Models {

    public class Game {

        [Key]
        public int id { get; set; }

        [ForeignKey("homeTeam")]
        public int home_team_id { get; set; }

        [ForeignKey("awayTeam")]
        public int away_team_id { get; set; }

        public DateTime date { get; set; }


        public Team awayTeam { get; set; }
        public Team homeTeam { get; set; }
    }
}