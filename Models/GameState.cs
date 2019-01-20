using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.Serialization;

namespace SportApi.Models {

    public class GameState {
        [Key]
        public int id { get; set; }
        [ForeignKey("game")]
        public int game_id { get; set; }
        public int home_team_score { get; set; }
        public int away_team_score { get; set; }
        public string broadcast { get; set; }
        public int quarter { get; set; }
        public string time_left_in_quarter { get; set; }
        public string game_status { get; set; }

        [IgnoreDataMember]
        public Game game { get; set; }
    }
}