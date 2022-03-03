using System;
using System.Collections.Generic;

#nullable disable

namespace Custo0.Domains
{
    public partial class SituacaoReserva
    {
        public SituacaoReserva()
        {
            Reservas = new HashSet<Reserva>();
        }

        public byte IdSituacaoReserva { get; set; }
        public string TituloReserva { get; set; }

        public virtual ICollection<Reserva> Reservas { get; set; }
    }
}
