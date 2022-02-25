using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Estado
    {
        public Estado()
        {
            Enderecos = new HashSet<Endereco>();
        }

        public byte IdEstado { get; set; }
        public string NomeEstado { get; set; }

        public virtual ICollection<Endereco> Enderecos { get; set; }
    }
}
