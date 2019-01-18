namespace SportApi.Models {

    public class Game {
        public int id { get; set; }
        public int home_team_id { get; set; }
        public Team away_team_id { get; set; }
        public string date { get; set; }
    }
}