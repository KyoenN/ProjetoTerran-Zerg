using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class ReservaHotel
    {
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int IdQuarto { get; set; }
        public DateTime DtCheckin { get; set; }
        public DateTime DtCheckout { get; set; }
        public decimal ValorTotal { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Quarto IdQuartoNavigation { get; set; }
    }
}
