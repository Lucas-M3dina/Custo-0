using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Cliente
    {
        public Cliente()
        {
            Reservas = new HashSet<Reserva>();
        }

        public int IdCliente { get; set; }
        public long? IdUsuario { get; set; }
        public long? IdEndereco { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }

        public virtual Endereco IdEnderecoNavigation { get; set; }
        public virtual Usuario IdUsuarioNavigation { get; set; }
        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
