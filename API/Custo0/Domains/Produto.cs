using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Produto
    {
        public Produto()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdProduto { get; set; }
        public byte? IdTipoProduto { get; set; }
        public short? IdEmpresa { get; set; }
        public double Preco { get; set; }
        public int Quantidade { get; set; }
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string ImagemProduto { get; set; }
        public DateTime? DataValidade { get; set; }

        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual TipoProduto IdTipoProdutoNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
