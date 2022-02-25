using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Reserva
    {
        public int IdReserva { get; set; }
        public byte? IdSituacao { get; set; }
        public int? IdProduto { get; set; }
        public short? IdEmpresa { get; set; }
        public int? IdCliente { get; set; }
        public string Descricao { get; set; }
        public DateTime? DataSolicitacao { get; set; }

        public virtual Cliente IdClienteNavigation { get; set; }
        public virtual Empresa IdEmpresaNavigation { get; set; }
        public virtual Produto IdProdutoNavigation { get; set; }
        public virtual SituacaoReserva IdSituacaoNavigation { get; set; }
    }
}
