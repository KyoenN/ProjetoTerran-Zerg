using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Cliente
    {
        public Cliente()
        {
           //ReservaHotels = new HashSet<ReservaHotel>();
            //ReservaPassagems = new HashSet<ReservaPassagem>();
        }

        public int? Id { get; set; }
        public string Nome { get; set; }
        public long Cpf { get; set; }
        public DateTime DataNasc { get; set; }
        public string Sexo { get; set; }

        //public virtual ICollection<ReservaHotel> ReservaHotels { get; set; }
        //public virtual ICollection<ReservaPassagem> ReservaPassagems { get; set; }
    }
}
