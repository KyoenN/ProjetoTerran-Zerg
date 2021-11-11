using System;
using System.Collections.Generic;

#nullable disable

namespace WebApplication2.Models
{
    public partial class Hotel
    {
        public Hotel()
        {
           // Quartos = new HashSet<Quarto>();
        }

        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public long Cnpj { get; set; }
        public int? Classificacao { get; set; }

        //public virtual ICollection<Quarto> Quartos { get; set; }
    }
}
