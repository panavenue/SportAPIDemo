namespace SportApi.Models {

    public class PlayerStat {
        public int id { get; set; }
        public int game_id { get; set; }
        public int player_id { get; set; }
        public int team_id { get; set; }
        public int points { get; set; }
        public int assists { get; set; }
        public int rebounds { get; set; }
        public int nerd { get; set; }
    }
}