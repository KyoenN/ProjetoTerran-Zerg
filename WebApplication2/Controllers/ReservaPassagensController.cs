using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservaPassagensController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaPassagensController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservaPassagens
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaPassagem>>> GetReservaPassagems()
        {
            return await _context.ReservaPassagems.ToListAsync();
        }

        // GET: api/ReservaPassagens/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaPassagem>> GetReservaPassagem(int id)
        {
            var reservaPassagem = await _context.ReservaPassagems.FindAsync(id);

            if (reservaPassagem == null)
            {
                return NotFound();
            }

            return reservaPassagem;
        }

        // POST: api/ReservaPassagens
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaPassagem>> PostReservaPassagem(ReservaPassagem reservaPassagem)
        {
            _context.ReservaPassagems.Add(reservaPassagem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaPassagem", new { id = reservaPassagem.Id }, reservaPassagem);
        }

        private bool ReservaPassagemExists(int id)
        {
            return _context.ReservaPassagems.Any(e => e.Id == id);
        }
    }
}
