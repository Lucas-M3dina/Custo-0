using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Usuario
    {
        public Usuario()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
        }

        public long IdUsuario { get; set; }
        public byte? IdTipoUsuario { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }

        public virtual TipoUsuario IdTipoUsuarioNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
