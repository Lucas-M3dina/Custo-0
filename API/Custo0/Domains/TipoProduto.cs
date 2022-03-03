using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class TipoProduto
    {
        public TipoProduto()
        {
            Produtos = new HashSet<Produto>();
        }

        public byte IdTipoProduto { get; set; }
        public string Titulo { get; set; }

        public virtual ICollection<Produto> Produtos { get; set; }
    }
}
