﻿using System;
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
    public class AeroportosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AeroportosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Aeroportos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Aeroporto>>> GetAeroportos()
        {
            return await _context.Aeroportos.ToListAsync();
        }

        // GET: api/Aeroportos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Aeroporto>> GetAeroporto(int id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);

            if (aeroporto == null)
            {
                return NotFound();
            }

            return aeroporto;
        }

        // PUT: api/Aeroportos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAeroporto(int id, Aeroporto aeroporto)
        {
            if (id != aeroporto.Id)
            {
                return BadRequest();
            }

            _context.Entry(aeroporto).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AeroportoExists(id))
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

        // POST: api/Aeroportos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Aeroporto>> PostAeroporto(Aeroporto aeroporto)
        {
            _context.Aeroportos.Add(aeroporto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAeroporto", new { id = aeroporto.Id }, aeroporto);
        }

        // DELETE: api/Aeroportos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAeroporto(int id)
        {
            var aeroporto = await _context.Aeroportos.FindAsync(id);
            if (aeroporto == null)
            {
                return NotFound();
            }

            _context.Aeroportos.Remove(aeroporto);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool AeroportoExists(int id)
        {
            return _context.Aeroportos.Any(e => e.Id == id);
        }
    }
}
