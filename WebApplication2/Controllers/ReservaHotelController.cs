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
    public class ReservaHotelController : ControllerBase
    {
        private readonly AppDbContext _context;

        public ReservaHotelController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/ReservaHotel
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ReservaHotel>>> GetReservaHotels()
        {
            return await _context.ReservaHotels.ToListAsync();
        }

        // GET: api/ReservaHotel/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ReservaHotel>> GetReservaHotel(int id)
        {
            var reservaHotel = await _context.ReservaHotels.FindAsync(id);

            if (reservaHotel == null)
            {
                return NotFound();
            }

            return reservaHotel;
        }

        // PUT: api/ReservaHotel/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutReservaHotel(int id, ReservaHotel reservaHotel)
        {
            if (id != reservaHotel.Id)
            {
                return BadRequest();
            }

            _context.Entry(reservaHotel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReservaHotelExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/ReservaHotel
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ReservaHotel>> PostReservaHotel(ReservaHotel reservaHotel)
        {
            _context.ReservaHotels.Add(reservaHotel);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetReservaHotel", new { id = reservaHotel.Id }, reservaHotel);
        }

        // DELETE: api/ReservaHotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservaHotel(int id)
        {
            var reservaHotel = await _context.ReservaHotels.FindAsync(id);
            if (reservaHotel == null)
            {
                return NotFound();
            }

            _context.ReservaHotels.Remove(reservaHotel);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ReservaHotelExists(int id)
        {
            return _context.ReservaHotels.Any(e => e.Id == id);
        }
    }
}
