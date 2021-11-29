using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebApplication2.Models;

namespace WebApplication2.Service
{
    public class AeroportoService
    {
        private readonly AppDbContext dbContext;
        public AeroportoService(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<IEnumerable<Aeroporto>> GetAeroportos()
        {
            return await dbContext.Aeroportos.ToListAsync();
        }
        public async Task<Aeroporto> GetAeroporto(int id)
        {
            var aeroporto = await dbContext.Aeroportos.FindAsync(id);
            return aeroporto;
        }

    }
}