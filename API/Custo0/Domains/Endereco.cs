using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class Endereco
    {
        public Endereco()
        {
            Clientes = new HashSet<Cliente>();
            Empresas = new HashSet<Empresa>();
        }

        public long IdEndereco { get; set; }
        public byte? IdEstado { get; set; }
        public string Cep { get; set; }
        public string Titulo { get; set; }

        public virtual Estado IdEstadoNavigation { get; set; }
        public virtual ICollection<Cliente> Clientes { get; set; }
        public virtual ICollection<Empresa> Empresas { get; set; }
    }
}
