using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApi.Models;

namespace SportApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase {
        private readonly SportContext _context;

        public PlayersController (SportContext context) {
            _context = context;
        }

        // GET: api/Players
        /**
         * return all players' info
         */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers (string date) {
            if (string.IsNullOrEmpty(date)) {
                var players = await _context.Players
                    .Include(u => u.team)
                    .ToArrayAsync();
    
                var response = players.Select(u => new
                {
                    id = u.id,
                    name = u.name,
                    team_name = u.team.name
                });
    
                return Ok(response);
            } else {
                var playerStats = await _context.PlayerStats
                    .Include(ps => ps.game)
                    .Include(ps => ps.player)
                    .Where(ps => ps.game.date.ToString("MMddyyyy") == date)
                    .Select(p => new {
                        id = p.player.id,
                        name = p.player.name,
                        team_name = p.team.name,
                        datetime = p.game.date,
                    })
                    .Distinct()
                    .ToArrayAsync();
    
                return Ok(playerStats);
            }
        }

        /**
        GET: api/players/{id}
        Get player info
         */
        [HttpGet ("{id}")]
        public async Task<ActionResult<Player>> GetTeam (int id) {
            var player = await _context.Players
                .FindAsync (id);

            if (player == null) {
                return NotFound ();
            }

            return Ok(player);
        }

        /**
        get a player's all game stats
         */
        [HttpGet ("{id}/stats")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerStat (int id) {
            var player = await _context.Players
                .Include(p => p.playerStats)
                .Select(p => new {
                    id = p.id,
                    name = p.name,
                    team = p.team.name,
                    player_stats = p.playerStats.Select(ps => new {
                        id = ps.id,
                        points = ps.points,
                        assists = ps.assists,
                        rebounds = ps.rebounds,
                        nerd = ps.nerd
                    })
                })
                .FirstOrDefaultAsync(i => i.id == id);

            if (player == null) {
                return NotFound ();
            }
 
            return Ok(player);
        }
    }


}