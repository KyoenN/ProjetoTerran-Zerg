using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class ReservaPassagem
    {
        public int Id { get; set; }
        public int IdVoo { get; set; }
        public int IdCliente { get; set; }
        public int NumeroAssento { get; set; }
        public int BagagemExtra { get; set; }

        //public virtual Cliente IdClienteNavigation { get; set; }
        //public virtual Voo IdVooNavigation { get; set; }
    }
}
