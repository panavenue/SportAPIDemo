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
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayers () {
            // var users = await _context.Users
            //     .Include(u => u.Posts)
            //     .ToArrayAsync();
 
            // var response = users.Select(u => new
            // {
            //     firstName = u.FirstName,
            //     lastName = u.LastName,
            //     posts = u.Posts.Select(p => p.Content)
            // });
 
            // return Ok(response);
            return await _context.Players.ToListAsync ();
        }

        // GET: api/players/{id}
        [HttpGet ("{id}")]
        public async Task<ActionResult<Player>> GetTeam (int id) {
            var player = await _context.Players.FindAsync (id);

            if (player == null) {
                return NotFound ();
            }

            return player;
        }

        [HttpGet ("{id}/stats")]
        public async Task<ActionResult<IEnumerable<Player>>> GetPlayerStat () {
            // var users = await _context.Users
            //     .Include(u => u.Posts)
            //     .ToArrayAsync();
 
            // var response = users.Select(u => new
            // {
            //     firstName = u.FirstName,
            //     lastName = u.LastName,
            //     posts = u.Posts.Select(p => p.Content)
            // });
 
            // return Ok(response);
            return await _context.Players.ToListAsync ();
        }
    }
}