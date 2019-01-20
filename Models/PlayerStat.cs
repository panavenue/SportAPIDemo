using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportApi.Models {

    public class PlayerStat {
        [Key]
        public int id { get; set; }

        [ForeignKey("game")]
        public int game_id { get; set; }
        [ForeignKey("player")]
        public int player_id { get; set; }
        [ForeignKey("team")]
        public int team_id { get; set; }
        public int points { get; set; }
        public int assists { get; set; }
        public int rebounds { get; set; }
        public double nerd { get; set; }

        [IgnoreDataMember]
        public Game game { get; set; }
        [IgnoreDataMember]
        public Player player { get; set; }
        [IgnoreDataMember]
        public Team team { get; set; }
    }
}