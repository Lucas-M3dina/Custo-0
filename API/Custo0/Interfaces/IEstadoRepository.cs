using Custo0.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Custo0.Interfaces
{
    interface IEstadoRepository
    {
        /// <summary>
        /// Lista todos os Estados
        /// </summary>
        /// <returns>Uma lista de Estados</returns>
        List<Estado> Listar();
    }
}
