using Custo0.Contexts;
using Custo0.Domains;
using Custo0.Interfaces;
using Custo0.Utils;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Repositories
{
    public class EstadoRepository : IEstadoRepository
    {
        private readonly Cust0Context ctx = new();

        public List<Estado> Listar()
        {
            return ctx.Estados.ToList();

        }
    }
}
