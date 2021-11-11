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
    public class VoosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public VoosController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/Voos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Voo>>> GetVoos()
        {
            return await _context.Voos.ToListAsync();
        }

        // GET: api/Voos/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Voo>> GetVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);

            if (voo == null)
            {
                return NotFound();
            }

            return voo;
        }

        [HttpGet("{cidadeOrigem/cidadeDestino/dataHoraPartida}")]
        public async Task<ActionResult<IList<Voo>>> GetVoo(string cidadeAeroportoOrigem, string cidadeAeroportoDestino, 
            DateTime dataHoraPartida)
        {
            List<Voo> voosDataHoraFiltrada = await _context.Voos.Where(v => v.DateTimePartida == dataHoraPartida).ToListAsync();
            List<Aeroporto> aeroportosOrigem = await _context.Aeroportos.Where(a => a.Cidade == cidadeAeroportoOrigem)
                .ToListAsync();
            List<Aeroporto> aeroportosDestino = await _context.Aeroportos.Where(a => a.Cidade == cidadeAeroportoDestino)
                .ToListAsync();
            List<Voo> voosFiltrado = new List<Voo>();
            foreach(var voo in voosDataHoraFiltrada)
            {
                foreach(var aeroOrigem in aeroportosOrigem)
                {
                    foreach(var aeroDestino in aeroportosDestino)
                    {
                        if ((voo.IdAeroportoOrigem == aeroOrigem.Id) && (voo.IdAeroportoDestino == aeroDestino.Id))
                        {
                            voosFiltrado.Add(voo);
                        }

                    }
                }
            }
            /*List<Voo> voosComOrigemCerta = voos.ForEach(v => v.IdAeroportoOrigem == aeroportosOrigem.ForEach(a => a.Id));
            voos.ForEach(voosComOrigemCerta.Add(Voo v => v.IdAeroportoOrigem == aeroportosOrigem.ForEach(a => a.Id)));
            List<Voo>sla = voos.ForEach(v => v.DateTimePartida == dataHoraPartida);
            //&& aeroportosOrigem.ForEach(a => a.Id == v.IdAeroportoOrigem));
         //==  &&
          //   v.IdAeroportoDestino == await _context.Aeroportos.Where(a => a.Cidade = cidadeAeroportoDestino);
             IList<Voo> voos2 = await _context.Voos.Where(async v => v.DateTimePartida == dataHoraPartida 
                 && v.IdAeroportoOrigem == await _context.Aeroportos.Where(predicate: a => a.Cidade == cidadeAeroportoDestino) &&
                 v.IdAeroportoDestino == await _context.Aeroportos.Where(a => a.Cidade = cidadeAeroportoDestino);
         //var modelo = await _context.Modelos.FirstOrDefaultAsync(m => m.id == estoque.Id_Modelo);

         //FirstOrDefaultAsync(m => m.id == estoque.Id_Modelo);*/

            if (voosFiltrado.First() == null)
            {
                return NotFound();
            }

            return voosFiltrado;
        }

        // PUT: api/Voos/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVoo(int id, Voo voo)
        {
            if (id != voo.Id)
            {
                return BadRequest();
            }

            _context.Entry(voo).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VooExists(id))
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

        // POST: api/Voos
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Voo>> PostVoo(Voo voo)
        {
            _context.Voos.Add(voo);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVoo", new { id = voo.Id }, voo);
        }

        // DELETE: api/Voos/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVoo(int id)
        {
            var voo = await _context.Voos.FindAsync(id);
            if (voo == null)
            {
                return NotFound();
            }

            _context.Voos.Remove(voo);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool VooExists(int id)
        {
            return _context.Voos.Any(e => e.Id == id);
        }
    }
}
