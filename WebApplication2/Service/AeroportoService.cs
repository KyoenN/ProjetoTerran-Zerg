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



    }
}