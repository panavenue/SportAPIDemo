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

        // GET: api/teams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Team>>> GetTeams () {
            return await _context.Teams.ToListAsync ();
        }

        // GET: api/teams/{id}
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