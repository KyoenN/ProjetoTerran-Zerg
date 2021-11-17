using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Voo
    {
        public Voo()
        {
            //ReservaPassagems = new HashSet<ReservaPassagem>();
        }

        public int Id { get; set; }
        public int NumeroVoo { get; set; }
        public int IdAeroportoOrigem { get; set; }
        public int IdAeroportoDestino { get; set; }
        public DateTime DateTimePartida { get; set; }
        public DateTime DateTimeChegada { get; set; }
        public decimal Valor { get; set; }

        //public virtual Aeroporto IdAeroportoDestinoNavigation { get; set; }
        //public virtual Aeroporto IdAeroportoOrigemNavigation { get; set; }
        //public virtual ICollection<ReservaPassagem> ReservaPassagems { get; set; }
    }
}
