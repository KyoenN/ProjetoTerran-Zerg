using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Aeroporto
    {
        public Aeroporto()
        {
            VooIdAeroportoDestinoNavigations = new HashSet<Voo>();
            VooIdAeroportoOrigemNavigations = new HashSet<Voo>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }

        public virtual ICollection<Voo> VooIdAeroportoDestinoNavigations { get; set; }
        public virtual ICollection<Voo> VooIdAeroportoOrigemNavigations { get; set; }
    }
}
