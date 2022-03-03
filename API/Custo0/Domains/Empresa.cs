using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Empresa
    {
        public Empresa()
        {
            Produtos = new HashSet<Produto>();
            Reservas = new HashSet<Reserva>();
        }

        public short IdEmpresa { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdEndereco { get; set; }
        public string NomeFantasia { get; set; }
        public string Cnpj { get; set; }
        public string ImagemEmpresa { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Produto> Produtos { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
