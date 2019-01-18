using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SportApi.Models;

namespace SportApi.Controllers {
    [Route ("api/[controller]")]
    [ApiController]
    public class TeamsController : ControllerBase {
        private readonly SportContext _context;

        public TeamsController (SportContext context) {
            _context = context;
        }

        // GET: api/Team
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams () {
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
            return await _context.Teams.ToListAsync ();
        }

        // GET: api/Team/{id}
        [HttpGet ("{id}")]
        public async Task<ActionResult<Team>> GetTeam (int id) {
            var team = await _context.Teams.FindAsync (id);

            if (team == null) {
                return NotFound ();
            }

            return team;
        }
    }
}