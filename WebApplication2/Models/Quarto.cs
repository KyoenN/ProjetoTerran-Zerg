using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Quarto
    {
        public Quarto()
        {
            ReservaHotels = new HashSet<ReservaHotel>();
        }

        public int Id { get; set; }
        public int IdHotel { get; set; }
        public int NumeroHospedes { get; set; }
        public int NumeroQuarto { get; set; }
        public string TipoQuarto { get; set; }
        public string Descrição { get; set; }
        public decimal ValorDiaria { get; set; }

        public virtual Hotel IdHotelNavigation { get; set; }
        public virtual ICollection<ReservaHotel> ReservaHotels { get; set; }
    }
}
