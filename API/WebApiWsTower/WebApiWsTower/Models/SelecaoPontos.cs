using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiWsTower.Domains;

namespace WebApiWsTower.Models
{
    public class SelecaoPontos
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public byte[] Bandeira { get; set; }
        public byte[] Uniforme { get; set; }
        public string Escalacao { get; set; }
        public int TotalPontos { get; set; }

        public virtual ICollection<Jogador> Jogador { get; set; }
    }
}
