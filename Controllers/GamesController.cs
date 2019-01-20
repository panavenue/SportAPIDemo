using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApi.Models;

namespace SportApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class GamesController : ControllerBase {
        private readonly SportContext _context;

        public GamesController (SportContext context) {
            _context = context;
        }

        // GET: api/games
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Game>>> GetGames (string date) {
            if (string.IsNullOrEmpty(date)) {
                var games = await _context.GameStates
                    .Include(g => g.game)
                    .Select(g => new {
                        g.id,
                        g.game.home_team_id,
                        home_team_name = g.game.homeTeam.name,
                        g.game.away_team_id,
                        away_team_name = g.game.awayTeam.name,
                        g.home_team_score,
                        g.away_team_score,
                        g.game_status,
                        date = g.game.date.ToString("MM/dd/yyyy")
                    })
                    .ToListAsync ();

                return Ok(games);
            } else {
                var games = await _context.GameStates
                    .Include(g => g.game)
                    .Where(g => g.game.date.ToString("MMddyyyy") == date)
                    .Select(g => new {
                        g.id,
                        g.game.home_team_id,
                        home_team_name = g.game.homeTeam.name,
                        g.game.away_team_id,
                        away_team_name = g.game.awayTeam.name,
                        g.home_team_score,
                        g.away_team_score,
                        g.game_status,
                        date = g.game.date.ToString("MM/dd/yyyy")
                    })
                    .ToListAsync ();

                return Ok(games);
            }
        }

        // GET: api/games/{id}
        [HttpGet ("{id}")]
        public async Task<ActionResult<Game>> GetTeam (int id) {
            var game = await _context.Games.FindAsync (id);

            if (game == null) {
                return NotFound ();
            }

            return game;
        }
    }
}